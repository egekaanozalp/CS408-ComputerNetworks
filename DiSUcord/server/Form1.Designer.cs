namespace server
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
            PortLabel = new Label();
            PortTextbox = new TextBox();
            StartButton = new Button();
            AllUsersLabel = new Label();
            AllUsersLog = new RichTextBox();
            SPSUsersLabel = new Label();
            SPSUsersLog = new RichTextBox();
            IFUsersLog = new RichTextBox();
            IFUsersLabel = new Label();
            ServerLog = new RichTextBox();
            ServerLogLabel = new Label();
            DisucordLabel = new Label();
            DisucordMotto = new Label();
            SuspendLayout();
            // 
            // PortLabel
            // 
            PortLabel.AutoSize = true;
            PortLabel.Location = new Point(42, 35);
            PortLabel.Name = "PortLabel";
            PortLabel.Size = new Size(38, 20);
            PortLabel.TabIndex = 0;
            PortLabel.Text = "Port:";
            // 
            // PortTextbox
            // 
            PortTextbox.Location = new Point(86, 32);
            PortTextbox.Name = "PortTextbox";
            PortTextbox.Size = new Size(125, 27);
            PortTextbox.TabIndex = 1;
            // 
            // StartButton
            // 
            StartButton.Location = new Point(217, 31);
            StartButton.Name = "StartButton";
            StartButton.Size = new Size(56, 29);
            StartButton.TabIndex = 2;
            StartButton.Text = "Start";
            StartButton.UseVisualStyleBackColor = true;
            StartButton.Click += StartButton_Click;
            // 
            // AllUsersLabel
            // 
            AllUsersLabel.AutoSize = true;
            AllUsersLabel.Location = new Point(53, 88);
            AllUsersLabel.Name = "AllUsersLabel";
            AllUsersLabel.Size = new Size(69, 20);
            AllUsersLabel.TabIndex = 3;
            AllUsersLabel.Text = "All Users:";
            // 
            // AllUsersLog
            // 
            AllUsersLog.Location = new Point(42, 111);
            AllUsersLog.Name = "AllUsersLog";
            AllUsersLog.Size = new Size(91, 256);
            AllUsersLog.TabIndex = 4;
            AllUsersLog.Text = "";
            // 
            // SPSUsersLabel
            // 
            SPSUsersLabel.AutoSize = true;
            SPSUsersLabel.Location = new Point(149, 88);
            SPSUsersLabel.Name = "SPSUsersLabel";
            SPSUsersLabel.Size = new Size(103, 20);
            SPSUsersLabel.TabIndex = 5;
            SPSUsersLabel.Text = "SPS 101 Users:";
            // 
            // SPSUsersLog
            // 
            SPSUsersLog.Location = new Point(155, 111);
            SPSUsersLog.Name = "SPSUsersLog";
            SPSUsersLog.Size = new Size(91, 256);
            SPSUsersLog.TabIndex = 6;
            SPSUsersLog.Text = "";
            // 
            // IFUsersLog
            // 
            IFUsersLog.Location = new Point(267, 111);
            IFUsersLog.Name = "IFUsersLog";
            IFUsersLog.Size = new Size(91, 256);
            IFUsersLog.TabIndex = 7;
            IFUsersLog.Text = "";
            // 
            // IFUsersLabel
            // 
            IFUsersLabel.AutoSize = true;
            IFUsersLabel.Location = new Point(268, 88);
            IFUsersLabel.Name = "IFUsersLabel";
            IFUsersLabel.Size = new Size(90, 20);
            IFUsersLabel.TabIndex = 8;
            IFUsersLabel.Text = "IF 100 Users:";
            // 
            // ServerLog
            // 
            ServerLog.Location = new Point(437, 58);
            ServerLog.Name = "ServerLog";
            ServerLog.Size = new Size(500, 395);
            ServerLog.TabIndex = 9;
            ServerLog.Text = "";
            // 
            // ServerLogLabel
            // 
            ServerLogLabel.AutoSize = true;
            ServerLogLabel.Location = new Point(437, 35);
            ServerLogLabel.Name = "ServerLogLabel";
            ServerLogLabel.Size = new Size(82, 20);
            ServerLogLabel.TabIndex = 10;
            ServerLogLabel.Text = "Server Log:";
            // 
            // DisucordLabel
            // 
            DisucordLabel.AutoSize = true;
            DisucordLabel.Font = new Font("Stencil", 15F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            DisucordLabel.Location = new Point(131, 400);
            DisucordLabel.Name = "DisucordLabel";
            DisucordLabel.Size = new Size(142, 30);
            DisucordLabel.TabIndex = 11;
            DisucordLabel.Text = "DiSUcord";
            // 
            // DisucordMotto
            // 
            DisucordMotto.AutoSize = true;
            DisucordMotto.Font = new Font("Segoe UI", 7.20000029F, FontStyle.Regular, GraphicsUnit.Point);
            DisucordMotto.Location = new Point(144, 429);
            DisucordMotto.Name = "DisucordMotto";
            DisucordMotto.Size = new Size(114, 17);
            DisucordMotto.TabIndex = 12;
            DisucordMotto.Text = "\"A CS 408 Project\"";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(990, 482);
            Controls.Add(DisucordMotto);
            Controls.Add(DisucordLabel);
            Controls.Add(ServerLogLabel);
            Controls.Add(ServerLog);
            Controls.Add(IFUsersLabel);
            Controls.Add(IFUsersLog);
            Controls.Add(SPSUsersLog);
            Controls.Add(SPSUsersLabel);
            Controls.Add(AllUsersLog);
            Controls.Add(AllUsersLabel);
            Controls.Add(StartButton);
            Controls.Add(PortTextbox);
            Controls.Add(PortLabel);
            Name = "Form1";
            Text = "DiSUcord Admin";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label PortLabel;
        private TextBox PortTextbox;
        private Button StartButton;
        private Label AllUsersLabel;
        private RichTextBox AllUsersLog;
        private Label SPSUsersLabel;
        private RichTextBox SPSUsersLog;
        private RichTextBox IFUsersLog;
        private Label IFUsersLabel;
        private RichTextBox ServerLog;
        private Label ServerLogLabel;
        private Label DisucordLabel;
        private Label DisucordMotto;
    }
}