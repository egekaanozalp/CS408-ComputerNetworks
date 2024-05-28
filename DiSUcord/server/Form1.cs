using Microsoft.VisualBasic.Logging;
using System.Net;
using System.Net.Sockets;
using System.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace server
{
    public partial class Form1 : Form
    {
        // Created a serverSocket for TCP connection.
        Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        // Created the below lists to keep track of users that are connected to the system
        // and subscribed to any of the channel.
        List<Socket> clientSockets = new List<Socket>();
        List<Socket> sps101Sockets = new List<Socket>();
        List<Socket> if100Sockets = new List<Socket>();
        List<string> SPS101Users = new List<string>();
        List<string> IF100Users = new List<string>();
        List<string> AllUsers = new List<string>();

        // Used the below Boolean values to keep track of the status of the system.
        bool terminating = false;
        bool listening = false;

        public Form1()
        {
            // Initializes the form application once it is called.
            Control.CheckForIllegalCrossThreadCalls = false;
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
            InitializeComponent();
            // Since initially a user is not connected to the system, inform the user.
            ServerLog.AppendText("The server has not initialized. Please select a port. \n");

            AllUsersLog.Enabled = false;
            IFUsersLog.Enabled = false;
            SPSUsersLog.Enabled = false;
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            if (Int32.TryParse(PortTextbox.Text, out int serverPort))
            {
                // Create the IP end point and bind it to the server socket:
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, serverPort);
                serverSocket.Bind(endPoint);

                // Update the UI:
                AllUsersLog.Enabled = true;
                IFUsersLog.Enabled = true;
                SPSUsersLog.Enabled = true;

                // Once binded, specify the maximum number of pending connections in the queue as 3
                // which is totally arbitrary. You can change the number given as parameter.
                serverSocket.Listen(3);

                // Update the below Boolean values since we started the server.
                listening = true;
                StartButton.Enabled = false;

                // Start the accept thread to accept clients to the server.
                Thread acceptThread = new Thread(Accept);
                acceptThread.Start();

                // Inform the admin that the server is started listening on the specified port.
                ServerLog.AppendText("Started listening on port: " + serverPort + "\n");

            }
            else
            {
                // If there is a problem, most probably the user specified the port number falsely.
                ServerLog.AppendText("Please check port number \n");
            }
        }
        private void Accept()
        {
            while (listening)
            {
                try
                {
                    // Create a socket object that points to the accepted client socket.
                    Socket newClient = serverSocket.Accept();
                    // Start receiving thread to receive data from the client.
                    Thread receiveThread = new Thread(() => Receive(newClient));
                    receiveThread.Start();
                    // Inform the admin that a client is trying to connect to the server.
                    // We have not fully accepted the client to the server yet since the server
                    // has not checked the uniquness of the username yet.
                    ServerLog.AppendText("A client is trying to connect to the server. \n");
                }
                catch
                {
                    // If there happens any problem, we are handling the issue with the below cases.
                    if (terminating)
                    {
                        listening = false;
                    }
                    else
                    {
                        ServerLog.AppendText("The socket stopped working.\n");
                    }

                }
            }
        }
        private void Receive(Socket thisClient)
        {
            bool connected = true;

            while (connected && !terminating)
            {
                try
                {
                    // Create a buffer object to receive buffer data from the user.
                    Byte[] buffer = new Byte[128];
                    thisClient.Receive(buffer);
                    // Turn the byte buffer into string.
                    string incomingMessage = Encoding.Default.GetString(buffer);
                    // Delete the null character from the end of the string.
                    incomingMessage = incomingMessage.Substring(0, incomingMessage.IndexOf('\0'));
                    // Split the message using the specified string delimiter of the system.
                    string[] inputs = incomingMessage.Split(new string[] { "<<" }, StringSplitOptions.None);
                    // The first splitted string is always the command type:
                    string commandType = inputs[0];


                    // The below if-else code blocks are there to handle 4 types of commands specified by me:
                    // These 4 commands are namely: unique, subscribe, unsubscribe, send, disconnect.
                    // In each of the if-else block, corresponding UI actions are handled. In addition to that,
                    // the corresponding messages are sent back to the client socket based on the action:
                    if (commandType == "unique")
                    {
                        // Check whether the username is unique or not and send the corresponding 0 or 1 value to the client.
                        // Also try to close the connection with the user if the value is 0 (meaning that it is not unique).
                        string username = inputs[1];
                        if (AllUsers.Contains(username))
                        {
                            ServerLog.AppendText(username + " is already taken. Ending connection with the client. \n");
                            Byte[] uniqueBuffer = Encoding.Default.GetBytes("unique<<0");
                            thisClient.Send(uniqueBuffer);
                            connected = false;
                            try { thisClient.Close(); } catch { Console.WriteLine("This client socket is already closed."); }
                        }
                        else
                        {
                            clientSockets.Add(thisClient);
                            AllUsers.Add(username);
                            connected = true;
                            Byte[] uniqueBuffer = Encoding.Default.GetBytes("unique<<1");
                            thisClient.Send(uniqueBuffer);
                            ServerLog.AppendText(username + " is successfully connected to the server. \n");
                            AllUsersLog.AppendText(username + " \n");
                        }
                    }
                    else if (commandType == "subscribe")
                    {
                        // Subscribe the user to the corresponding channel. Update the UI, update the user list of the
                        // corresponding channel and inform the user.
                        string channel = inputs[1];
                        string username = inputs[2];
                        if (channel == "sps101")
                        {
                            SPS101Users.Add(username);
                            sps101Sockets.Add(thisClient);
                            SPSUsersLog.AppendText(username + " \n");
                            Byte[] subscribeBuffer = Encoding.Default.GetBytes("subscribe<<sps101");
                            thisClient.Send(subscribeBuffer);
                            ServerLog.AppendText(username + " is successfully subscribed to SPS 101 channel. \n");
                        }
                        else if (channel == "if100")
                        {
                            IF100Users.Add(username);
                            if100Sockets.Add(thisClient);
                            IFUsersLog.AppendText(username + " \n");
                            Byte[] subscribeBuffer = Encoding.Default.GetBytes("subscribe<<if100");
                            thisClient.Send(subscribeBuffer);
                            ServerLog.AppendText(username + " is successfully subscribed to IF100 channel. \n");

                        }
                    }
                    else if(commandType == "unsubscribe")
                    {
                        // Unsubscribe the user from the corresponding channel. Update the UI and the user list of the
                        // corresponding channel.

                        string channel = inputs[1];
                        string username = inputs[2];

                        if(channel == "sps101")
                        {
                            SPS101Users.Remove(username);
                            sps101Sockets.Remove(thisClient);
                            SPSUsersLog.Text = SPSUsersLog.Text.Replace(username + " \n", "");
                            ServerLog.AppendText(username + " is successfully unsubscribed from SPS101 channel. \n");
                        }
                        else if(channel == "if100")
                        {
                            IF100Users.Remove(username);
                            if100Sockets.Remove(thisClient);
                            IFUsersLog.Text = IFUsersLog.Text.Replace(username + " \n", "");
                            ServerLog.AppendText(username + " is successfully unsubscribed from IF100 channel. \n");
                        }
                    }
                    else if(commandType == "send")
                    {
                        // Send the message which is aimed to sent to a channel to only the users who are subscribed
                        // to the corresponding channel. 
                        string channel = inputs[1];
                        string username = inputs[2];
                        string message = inputs[3];

                        message = username + ": " + message;

                        if(channel == "sps101")
                        {
                            ServerLog.AppendText(" (sps101) " + message + " \n");
                            foreach(Socket socket in sps101Sockets)
                            {
                                Byte[] sendBuffer = Encoding.Default.GetBytes("send<<" + username + "<<" + message + "<<sps101");
                                socket.Send(sendBuffer);
                            }
                        }
                        else if(channel == "if100")
                        {
                            ServerLog.AppendText(" (if100) " + message + " \n");
                            foreach (Socket socket in if100Sockets)
                            {
                                Byte[] sendBuffer = Encoding.Default.GetBytes("send<<" + username + "<<" + message + "<<if100");
                                socket.Send(sendBuffer);
                            }
                        }
                    }
                    else if(commandType == "disconnect")
                    {
                        // Disconnect the user. Remove the username from all channels. Remove the socket from all channels.
                        // Try to close the socket to finish the connection.
                        string username = inputs[1];
                        ServerLog.AppendText(username + " has disconnected. \n");
                        AllUsersLog.Text = AllUsersLog.Text.Replace(username + " \n", "");
                        IFUsersLog.Text = IFUsersLog.Text.Replace(username + " \n", "");
                        SPSUsersLog.Text = SPSUsersLog.Text.Replace(username + " \n", "");

                        AllUsers.Remove(username);
                        IF100Users.Remove(username);
                        SPS101Users.Remove(username);
                        clientSockets.Remove(thisClient);
                        sps101Sockets.Remove(thisClient);
                        if100Sockets.Remove(thisClient);
                        try { thisClient.Close(); } catch { Console.WriteLine("This client socket is already closed."); }
                    }
                }
                catch
                {
                    // Handle the error cases:
                    if (!terminating)
                    {
                        ServerLog.AppendText("A client has disconnected\n");
                    }
                    clientSockets.Remove(thisClient);
                    connected = false;

                }
            }
        }
        private void Form1_FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Close the form application.
            listening = false;
            terminating = true;
            Environment.Exit(0);
        }
    }
}