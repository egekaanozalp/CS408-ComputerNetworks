namespace client
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            IPLabel = new Label();
            PortLabel = new Label();
            IPTextbox = new TextBox();
            PortTextbox = new TextBox();
            UsernameTextbox = new TextBox();
            UsernameLabel = new Label();
            ConnectButton = new Button();
            DisconnectButton = new Button();
            ChannelsLabel = new Label();
            SPSLabel = new Label();
            SPSSubscribeButton = new Button();
            SPSUnsubscribeButton = new Button();
            IFLabel = new Label();
            IFSubscribeButton = new Button();
            IFUnsubscribeButton = new Button();
            SPSMessageScreen = new RichTextBox();
            IFMessageScreen = new RichTextBox();
            SPSMessageScreenLabel = new Label();
            IFMessageScreenLabel = new Label();
            SystemStatusLabel = new Label();
            SystemStatusScreen = new RichTextBox();
            SPSSendButton = new Button();
            SPSSendTextbox = new TextBox();
            IFSendButton = new Button();
            IFSendTextbox = new TextBox();
            DisucordLabel = new Label();
            DisucordMotto = new Label();
            SuspendLayout();
            // 
            // IPLabel
            // 
            IPLabel.AutoSize = true;
            IPLabel.Location = new Point(67, 45);
            IPLabel.Name = "IPLabel";
            IPLabel.Size = new Size(24, 20);
            IPLabel.TabIndex = 0;
            IPLabel.Text = "IP:";
            // 
            // PortLabel
            // 
            PortLabel.AutoSize = true;
            PortLabel.Location = new Point(53, 81);
            PortLabel.Name = "PortLabel";
            PortLabel.Size = new Size(38, 20);
            PortLabel.TabIndex = 1;
            PortLabel.Text = "Port:";
            // 
            // IPTextbox
            // 
            IPTextbox.Location = new Point(97, 45);
            IPTextbox.Name = "IPTextbox";
            IPTextbox.Size = new Size(125, 27);
            IPTextbox.TabIndex = 2;
            // 
            // PortTextbox
            // 
            PortTextbox.Location = new Point(97, 78);
            PortTextbox.Name = "PortTextbox";
            PortTextbox.Size = new Size(125, 27);
            PortTextbox.TabIndex = 3;
            // 
            // UsernameTextbox
            // 
            UsernameTextbox.Location = new Point(97, 111);
            UsernameTextbox.Name = "UsernameTextbox";
            UsernameTextbox.Size = new Size(125, 27);
            UsernameTextbox.TabIndex = 4;
            // 
            // UsernameLabel
            // 
            UsernameLabel.AutoSize = true;
            UsernameLabel.Location = new Point(13, 114);
            UsernameLabel.Name = "UsernameLabel";
            UsernameLabel.Size = new Size(78, 20);
            UsernameLabel.TabIndex = 5;
            UsernameLabel.Text = "Username:";
            // 
            // ConnectButton
            // 
            ConnectButton.Location = new Point(50, 144);
            ConnectButton.Name = "ConnectButton";
            ConnectButton.Size = new Size(94, 29);
            ConnectButton.TabIndex = 6;
            ConnectButton.Text = "Connect";
            ConnectButton.UseVisualStyleBackColor = true;
            ConnectButton.Click += ConnectButton_Click;
            // 
            // DisconnectButton
            // 
            DisconnectButton.Location = new Point(175, 144);
            DisconnectButton.Name = "DisconnectButton";
            DisconnectButton.Size = new Size(94, 29);
            DisconnectButton.TabIndex = 7;
            DisconnectButton.Text = "Disconnect";
            DisconnectButton.UseVisualStyleBackColor = true;
            DisconnectButton.Click += DisconnectButton_Click;
            // 
            // ChannelsLabel
            // 
            ChannelsLabel.AutoSize = true;
            ChannelsLabel.Location = new Point(20, 207);
            ChannelsLabel.Name = "ChannelsLabel";
            ChannelsLabel.Size = new Size(71, 20);
            ChannelsLabel.TabIndex = 8;
            ChannelsLabel.Text = "Channels:";
            // 
            // SPSLabel
            // 
            SPSLabel.AutoSize = true;
            SPSLabel.Location = new Point(20, 237);
            SPSLabel.Name = "SPSLabel";
            SPSLabel.Size = new Size(74, 20);
            SPSLabel.TabIndex = 9;
            SPSLabel.Text = "• SPS 101:";
            // 
            // SPSSubscribeButton
            // 
            SPSSubscribeButton.Location = new Point(20, 260);
            SPSSubscribeButton.Name = "SPSSubscribeButton";
            SPSSubscribeButton.Size = new Size(94, 29);
            SPSSubscribeButton.TabIndex = 10;
            SPSSubscribeButton.Text = "Subscribe";
            SPSSubscribeButton.UseVisualStyleBackColor = true;
            SPSSubscribeButton.Click += SPSSubscribeButton_Click;
            // 
            // SPSUnsubscribeButton
            // 
            SPSUnsubscribeButton.Location = new Point(120, 260);
            SPSUnsubscribeButton.Name = "SPSUnsubscribeButton";
            SPSUnsubscribeButton.Size = new Size(102, 29);
            SPSUnsubscribeButton.TabIndex = 11;
            SPSUnsubscribeButton.Text = "Unsubscribe";
            SPSUnsubscribeButton.UseVisualStyleBackColor = true;
            SPSUnsubscribeButton.Click += SPSUnsubscribeButton_Click;
            // 
            // IFLabel
            // 
            IFLabel.AutoSize = true;
            IFLabel.Location = new Point(20, 309);
            IFLabel.Name = "IFLabel";
            IFLabel.Size = new Size(61, 20);
            IFLabel.TabIndex = 12;
            IFLabel.Text = "• IF 100:";
            // 
            // IFSubscribeButton
            // 
            IFSubscribeButton.Location = new Point(20, 332);
            IFSubscribeButton.Name = "IFSubscribeButton";
            IFSubscribeButton.Size = new Size(94, 29);
            IFSubscribeButton.TabIndex = 13;
            IFSubscribeButton.Text = "Subscribe";
            IFSubscribeButton.UseVisualStyleBackColor = true;
            IFSubscribeButton.Click += IFSubscribeButton_Click;
            // 
            // IFUnsubscribeButton
            // 
            IFUnsubscribeButton.Location = new Point(120, 332);
            IFUnsubscribeButton.Name = "IFUnsubscribeButton";
            IFUnsubscribeButton.Size = new Size(102, 29);
            IFUnsubscribeButton.TabIndex = 14;
            IFUnsubscribeButton.Text = "Unsubscribe";
            IFUnsubscribeButton.UseVisualStyleBackColor = true;
            IFUnsubscribeButton.Click += IFUnsubscribeButton_Click;
            // 
            // SPSMessageScreen
            // 
            SPSMessageScreen.Location = new Point(330, 105);
            SPSMessageScreen.Name = "SPSMessageScreen";
            SPSMessageScreen.Size = new Size(299, 315);
            SPSMessageScreen.TabIndex = 16;
            SPSMessageScreen.Text = "";
            // 
            // IFMessageScreen
            // 
            IFMessageScreen.Location = new Point(635, 105);
            IFMessageScreen.Name = "IFMessageScreen";
            IFMessageScreen.Size = new Size(299, 315);
            IFMessageScreen.TabIndex = 17;
            IFMessageScreen.Text = "";
            // 
            // SPSMessageScreenLabel
            // 
            SPSMessageScreenLabel.AutoSize = true;
            SPSMessageScreenLabel.Location = new Point(330, 82);
            SPSMessageScreenLabel.Name = "SPSMessageScreenLabel";
            SPSMessageScreenLabel.Size = new Size(118, 20);
            SPSMessageScreenLabel.TabIndex = 18;
            SPSMessageScreenLabel.Text = "SPS 101 Channel";
            // 
            // IFMessageScreenLabel
            // 
            IFMessageScreenLabel.AutoSize = true;
            IFMessageScreenLabel.Location = new Point(635, 82);
            IFMessageScreenLabel.Name = "IFMessageScreenLabel";
            IFMessageScreenLabel.Size = new Size(101, 20);
            IFMessageScreenLabel.TabIndex = 19;
            IFMessageScreenLabel.Text = "IF100 Channel";
            // 
            // SystemStatusLabel
            // 
            SystemStatusLabel.AutoSize = true;
            SystemStatusLabel.Location = new Point(330, 45);
            SystemStatusLabel.Name = "SystemStatusLabel";
            SystemStatusLabel.Size = new Size(103, 20);
            SystemStatusLabel.TabIndex = 20;
            SystemStatusLabel.Text = "System Status:";
            // 
            // SystemStatusScreen
            // 
            SystemStatusScreen.Location = new Point(439, 45);
            SystemStatusScreen.Name = "SystemStatusScreen";
            SystemStatusScreen.Size = new Size(495, 24);
            SystemStatusScreen.TabIndex = 21;
            SystemStatusScreen.Text = "";
            // 
            // SPSSendButton
            // 
            SPSSendButton.Location = new Point(330, 426);
            SPSSendButton.Name = "SPSSendButton";
            SPSSendButton.Size = new Size(53, 29);
            SPSSendButton.TabIndex = 22;
            SPSSendButton.Text = "Send";
            SPSSendButton.UseVisualStyleBackColor = true;
            SPSSendButton.Click += SPSSendButton_Click;
            // 
            // SPSSendTextbox
            // 
            SPSSendTextbox.Location = new Point(389, 427);
            SPSSendTextbox.Name = "SPSSendTextbox";
            SPSSendTextbox.Size = new Size(240, 27);
            SPSSendTextbox.TabIndex = 23;
            // 
            // IFSendButton
            // 
            IFSendButton.Location = new Point(635, 425);
            IFSendButton.Name = "IFSendButton";
            IFSendButton.Size = new Size(53, 29);
            IFSendButton.TabIndex = 24;
            IFSendButton.Text = "Send";
            IFSendButton.UseVisualStyleBackColor = true;
            IFSendButton.Click += IFSendButton_Click;
            // 
            // IFSendTextbox
            // 
            IFSendTextbox.Location = new Point(694, 426);
            IFSendTextbox.Name = "IFSendTextbox";
            IFSendTextbox.Size = new Size(240, 27);
            IFSendTextbox.TabIndex = 25;
            // 
            // DisucordLabel
            // 
            DisucordLabel.AutoSize = true;
            DisucordLabel.Font = new Font("Stencil", 15F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            DisucordLabel.Location = new Point(49, 387);
            DisucordLabel.Name = "DisucordLabel";
            DisucordLabel.Size = new Size(142, 30);
            DisucordLabel.TabIndex = 26;
            DisucordLabel.Text = "DiSUcord";
            // 
            // DisucordMotto
            // 
            DisucordMotto.AutoSize = true;
            DisucordMotto.Font = new Font("Segoe UI", 7.20000029F, FontStyle.Regular, GraphicsUnit.Point);
            DisucordMotto.Location = new Point(63, 417);
            DisucordMotto.Name = "DisucordMotto";
            DisucordMotto.Size = new Size(114, 17);
            DisucordMotto.TabIndex = 27;
            DisucordMotto.Text = "\"A CS 408 Project\"";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(966, 480);
            Controls.Add(DisucordMotto);
            Controls.Add(DisucordLabel);
            Controls.Add(IFSendTextbox);
            Controls.Add(IFSendButton);
            Controls.Add(SPSSendTextbox);
            Controls.Add(SPSSendButton);
            Controls.Add(SystemStatusScreen);
            Controls.Add(SystemStatusLabel);
            Controls.Add(IFMessageScreenLabel);
            Controls.Add(SPSMessageScreenLabel);
            Controls.Add(IFMessageScreen);
            Controls.Add(SPSMessageScreen);
            Controls.Add(IFUnsubscribeButton);
            Controls.Add(IFSubscribeButton);
            Controls.Add(IFLabel);
            Controls.Add(SPSUnsubscribeButton);
            Controls.Add(SPSSubscribeButton);
            Controls.Add(SPSLabel);
            Controls.Add(ChannelsLabel);
            Controls.Add(DisconnectButton);
            Controls.Add(ConnectButton);
            Controls.Add(UsernameLabel);
            Controls.Add(UsernameTextbox);
            Controls.Add(PortTextbox);
            Controls.Add(IPTextbox);
            Controls.Add(PortLabel);
            Controls.Add(IPLabel);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label IPLabel;
        private Label PortLabel;
        private TextBox IPTextbox;
        private TextBox PortTextbox;
        private TextBox UsernameTextbox;
        private Label UsernameLabel;
        private Button ConnectButton;
        private Button DisconnectButton;
        private Label ChannelsLabel;
        private Label SPSLabel;
        private Button SPSSubscribeButton;
        private Button SPSUnsubscribeButton;
        private Label IFLabel;
        private Button IFSubscribeButton;
        private Button IFUnsubscribeButton;
        private RichTextBox SPSMessageScreen;
        private RichTextBox IFMessageScreen;
        private Label SPSMessageScreenLabel;
        private Label IFMessageScreenLabel;
        private Label SystemStatusLabel;
        private RichTextBox SystemStatusScreen;
        private Button SPSSendButton;
        private TextBox SPSSendTextbox;
        private Button IFSendButton;
        private TextBox IFSendTextbox;
        private Label DisucordLabel;
        private Label DisucordMotto;
    }
}