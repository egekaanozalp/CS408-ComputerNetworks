using Microsoft.VisualBasic.Logging;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Channels;

namespace client
{
    public partial class Form1 : Form
    {
        // Used the below Boolean variables to check the status of the system.
        bool terminating = false;
        bool connected = false;
        Socket clientSocket;

        public Form1()
        {
            // Initialize the form object and update the UI.
            Control.CheckForIllegalCrossThreadCalls = false;
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
            InitializeComponent();

            ConnectButton.Enabled = true;
            DisconnectButton.Enabled = false;

            IFSubscribeButton.Enabled = false;
            IFUnsubscribeButton.Enabled = false;

            SPSSubscribeButton.Enabled = false;
            SPSUnsubscribeButton.Enabled = false;

            SPSMessageScreen.Enabled = false;
            SPSSendButton.Enabled = false;
            SPSSendTextbox.Enabled = false;

            IFMessageScreen.Enabled = false;
            IFSendButton.Enabled = false;
            IFSendTextbox.Enabled = false;

            // Inform the user that they are currently disconnected.
            SystemStatusScreen.Clear(); SystemStatusScreen.AppendText("You are currently disconnected.");
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            // Create a new socket object to create connection with the server.
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            string IP = IPTextbox.Text;
            string username = UsernameTextbox.Text;
            // Check whether the username includes Turkish character or not.
            if (isAcceptableName(username))
            {
                if (Int32.TryParse(PortTextbox.Text, out int portNum))
                {
                    try
                    {
                        // Connect to the server and update the UI.
                        clientSocket.Connect(IP, portNum);
                        connected = true;
                        ConnectButton.Enabled = false;
                        IPTextbox.Enabled = false;
                        PortTextbox.Enabled = false;
                        UsernameTextbox.Enabled = false;

                        // Once connected, send the uniqueness test to the server.
                        string command = "unique<<" + username;

                        // Turn the string command into bytes to send it to the server.
                        byte[] commandBytes = Encoding.ASCII.GetBytes(command);
                        int len = commandBytes.Length;

                        if (command.Length <= 128)
                        {
                            // Send the command.
                            Byte[] buffer = Encoding.Default.GetBytes(command);
                            clientSocket.Send(buffer);

                            // Start receiving messages from the server.
                            Thread receiveThread = new Thread(Receive);
                            receiveThread.Start();
                        }
                        // If the first message is longer than 128 bytes, probably the username is too long.
                        else
                        {
                            SystemStatusScreen.Clear(); SystemStatusScreen.AppendText("Username is too long.");
                        }
                    }
                    catch
                    {
                        SystemStatusScreen.Clear(); SystemStatusScreen.AppendText("Could not connect to the server. Check the IP address or make sure server is initialized.");
                    }
                }
                else
                {
                    SystemStatusScreen.Clear(); SystemStatusScreen.AppendText("Check out the port number once again.");
                }
            }
            else
            {
                SystemStatusScreen.Clear(); SystemStatusScreen.AppendText("There should be no Turkish character in the username and it should not be empty.");
            }
        }
        private void Receive()
        {
            while (connected)
            {
                try
                {
                    // Start receiving 128 bytes of information.
                    Byte[] buffer = new Byte[128];
                    clientSocket.Receive(buffer);

                    string serverResponse = Encoding.Default.GetString(buffer);
                    serverResponse = serverResponse.Substring(0, serverResponse.IndexOf('\0'));
                    string[] values = serverResponse.Split(new string[] { "<<" }, StringSplitOptions.None);

                    if (values.Length == 2)
                    {
                        string responseType = values[0];

                        if (responseType == "unique")
                        {
                            string responseMessage = values[1];

                            // Response format for unique command: unique<<0 or unique<<1.
                            // Handle the uniqueness success case:
                            if (responseMessage == "1")
                            {
                                ConnectButton.Enabled = false;
                                IPTextbox.Enabled = false;
                                PortTextbox.Enabled = false;
                                UsernameTextbox.Enabled = false;

                                DisconnectButton.Enabled = true;
                                SPSSubscribeButton.Enabled = true;
                                IFSubscribeButton.Enabled = true;
                                SystemStatusScreen.Clear(); SystemStatusScreen.AppendText("Connected to the server.");
                            }
                            else
                            {
                                // Handle the uniqueness failure case:
                                SystemStatusScreen.Clear(); SystemStatusScreen.AppendText("Username is already in use.");
                                try { clientSocket.Close(); } catch { Console.WriteLine("This client socket is already closed."); }
                                connected = false;
                                IPTextbox.Enabled = true;
                                PortTextbox.Enabled = true;
                                UsernameTextbox.Enabled = true;
                                ConnectButton.Enabled = true;
                            }
                        }
                        else if (responseType == "subscribe")
                        {
                            // Response format for subscription: subscribe<<sps101 or subscribe<<if100.
                            // Handle the corresponding subscription and update the UI based on the channel info.
                            string channel = values[1];

                            if (channel == "sps101")
                            {
                                SPSSubscribeButton.Enabled = false;
                                SPSUnsubscribeButton.Enabled = true;

                                SPSMessageScreen.Enabled = true;
                                SPSSendButton.Enabled = true;
                                SPSSendTextbox.Enabled = true;
                            }
                            else if (channel == "if100")
                            {
                                IFSubscribeButton.Enabled = false;
                                IFUnsubscribeButton.Enabled = true;

                                IFMessageScreen.Enabled = true;
                                IFSendButton.Enabled = true;
                                IFSendTextbox.Enabled = true;
                            }
                        }
                    }
                    else if (values.Length == 4)
                    {
                        // Response type: send<<username<<user_message<<channel.
                        // Adds the messages that are sent to the corresponding channel
                        // to the UI. If the user is receiving such response, it means that
                        // the user is subscribed to the channel. If the user is not subscribed,
                        // server does not send such response to the user.
                        string responseType = values[0];
                        string username = values[1];
                        string responseMessage = values[2];
                        string channel = values[3];

                        if (responseType == "send")
                        {
                            if (channel == "sps101")
                            {
                                SPSMessageScreen.AppendText(responseMessage + " \n");
                            }
                            else if (channel == "if100")
                            {
                                IFMessageScreen.AppendText(responseMessage + " \n");
                            }
                        }
                    }

                }
                catch
                {
                    if (!terminating)
                    {
                        SystemStatusScreen.Clear(); SystemStatusScreen.AppendText("Server has disconnected.");

                        IPTextbox.Enabled = true;
                        PortTextbox.Enabled = true;

                        UsernameTextbox.Enabled = true;
                        ConnectButton.Enabled = true;
                        DisconnectButton.Enabled = false;

                        IFSubscribeButton.Enabled = false;
                        IFUnsubscribeButton.Enabled = false;

                        SPSSubscribeButton.Enabled = false;
                        SPSUnsubscribeButton.Enabled = false;

                        SPSMessageScreen.Enabled = false;
                        SPSSendButton.Enabled = false;
                        SPSSendTextbox.Enabled = false;

                        IFMessageScreen.Enabled = false;
                        IFSendButton.Enabled = false;
                        IFSendTextbox.Enabled = false;
                    }
                    try { clientSocket.Close(); } catch { Console.WriteLine("This client socket is already closed."); }
                    connected = false;
                }

            }
        }
        private bool isAcceptableName(string username)
        {
            // Check whether the username contains Turkish character or not.
            if (username == "")
            {
                return false;
            }
            var TurkishChars = new List<char>() { 'ç', 'ð', 'ý', 'ö', 'þ', 'ü' };
            foreach (char c in username)
            {
                if (TurkishChars.Contains(c))
                {
                    return false;
                }
            }
            return true;
        }

        private void DisconnectButton_Click(object sender, EventArgs e)
        {
            // Disconnect from the server.
            connected = false;

            IPTextbox.Enabled = true;
            PortTextbox.Enabled = true;
            UsernameTextbox.Enabled = true;

            ConnectButton.Enabled = true;
            DisconnectButton.Enabled = false;

            IFSubscribeButton.Enabled = false;
            IFUnsubscribeButton.Enabled = false;

            SPSSubscribeButton.Enabled = false;
            SPSUnsubscribeButton.Enabled = false;

            SPSMessageScreen.Enabled = false;
            SPSSendButton.Enabled = false;
            SPSSendTextbox.Enabled = false;

            IFMessageScreen.Enabled = false;
            IFSendButton.Enabled = false;
            IFSendTextbox.Enabled = false;

            Byte[] buffer = Encoding.Default.GetBytes("disconnect<<" + UsernameTextbox.Text);
            clientSocket.Send(buffer);
            
            try
            { clientSocket.Close(); } catch { Console.WriteLine("This client socket is already closed."); } 
        }

        private void SPSSubscribeButton_Click(object sender, EventArgs e)
        {
            // Send subscription command:
            string command = "subscribe<<sps101<<" + UsernameTextbox.Text;
            Byte[] buffer = Encoding.Default.GetBytes(command);
            clientSocket.Send(buffer);
        }

        private void SPSUnsubscribeButton_Click(object sender, EventArgs e)
        {
            // Send unsubscription command:
            string command = "unsubscribe<<sps101<<" + UsernameTextbox.Text;
            Byte[] buffer = Encoding.Default.GetBytes(command);
            clientSocket.Send(buffer);

            SPSUnsubscribeButton.Enabled = false;

            SPSSendButton.Enabled = false;
            SPSMessageScreen.Enabled = false;
            SPSSubscribeButton.Enabled = true;
        }

        private void IFSubscribeButton_Click(object sender, EventArgs e)
        {
            // Send subscription command:
            string command = "subscribe<<if100<<" + UsernameTextbox.Text;
            Byte[] buffer = Encoding.Default.GetBytes(command);
            clientSocket.Send(buffer);
        }

        private void IFUnsubscribeButton_Click(object sender, EventArgs e)
        {
            // Send unsubscription command:
            string command = "unsubscribe<<if100<<" + UsernameTextbox.Text;
            Byte[] buffer = Encoding.Default.GetBytes(command);
            clientSocket.Send(buffer);

            IFUnsubscribeButton.Enabled = false;

            IFSendButton.Enabled = false;
            IFMessageScreen.Enabled = false;
            IFSubscribeButton.Enabled = true;
        }

        private void SPSSendButton_Click(object sender, EventArgs e)
        {
            // Inform the server that you want to send a message to the SPS101 channel.
            string command = "send<<sps101<<" + UsernameTextbox.Text + "<<" + SPSSendTextbox.Text;
            Byte[] buffer = Encoding.Default.GetBytes(command);
            clientSocket.Send(buffer);
            SPSSendTextbox.Clear();
        }

        private void IFSendButton_Click(object sender, EventArgs e)
        {
            // Inform the server that you want to send a message to the IF100 channel.
            string command = "send<<if100<<" + UsernameTextbox.Text + "<<" + IFSendTextbox.Text;
            Byte[] buffer = Encoding.Default.GetBytes(command);
            clientSocket.Send(buffer);
            IFSendTextbox.Clear();
        }
        private void Form1_FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Close the form application.
            Byte[] buffer = Encoding.Default.GetBytes("disconnect<<" + UsernameTextbox.Text);
            try { clientSocket.Send(buffer); } catch { Console.WriteLine("Client is already disconnected so no need."); }

            connected = false;
            terminating = true;

            try { clientSocket.Close(); } catch { Console.WriteLine("This client socket is already closed."); }

            Environment.Exit(0);
        }
    }
}