namespace Socket
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LstClients = new System.Windows.Forms.ListBox();
            this.BtnStartServer = new System.Windows.Forms.Button();
            this.BtnStopServer = new System.Windows.Forms.Button();
            this.BtnSendMessage = new System.Windows.Forms.Button();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // LstClients
            // 
            this.LstClients.FormattingEnabled = true;
            this.LstClients.Location = new System.Drawing.Point(494, 12);
            this.LstClients.Name = "LstClients";
            this.LstClients.Size = new System.Drawing.Size(292, 420);
            this.LstClients.TabIndex = 0;
            // 
            // BtnStartServer
            // 
            this.BtnStartServer.Location = new System.Drawing.Point(69, 47);
            this.BtnStartServer.Name = "BtnStartServer";
            this.BtnStartServer.Size = new System.Drawing.Size(116, 23);
            this.BtnStartServer.TabIndex = 1;
            this.BtnStartServer.Text = "Start Server";
            this.BtnStartServer.UseVisualStyleBackColor = true;
            this.BtnStartServer.Click += new System.EventHandler(this.BtnStartServer_Click);
            // 
            // BtnStopServer
            // 
            this.BtnStopServer.Location = new System.Drawing.Point(69, 94);
            this.BtnStopServer.Name = "BtnStopServer";
            this.BtnStopServer.Size = new System.Drawing.Size(116, 23);
            this.BtnStopServer.TabIndex = 2;
            this.BtnStopServer.Text = "Stop Server";
            this.BtnStopServer.UseVisualStyleBackColor = true;
            this.BtnStopServer.Click += new System.EventHandler(this.BtnStopServer_Click);
            // 
            // BtnSendMessage
            // 
            this.BtnSendMessage.Location = new System.Drawing.Point(69, 140);
            this.BtnSendMessage.Name = "BtnSendMessage";
            this.BtnSendMessage.Size = new System.Drawing.Size(116, 23);
            this.BtnSendMessage.TabIndex = 3;
            this.BtnSendMessage.Text = "Send Message";
            this.BtnSendMessage.UseVisualStyleBackColor = true;
            this.BtnSendMessage.Click += new System.EventHandler(this.BtnSendMessage_Click);
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(208, 142);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(100, 20);
            this.txtMessage.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 453);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.BtnSendMessage);
            this.Controls.Add(this.BtnStopServer);
            this.Controls.Add(this.BtnStartServer);
            this.Controls.Add(this.LstClients);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox LstClients;
        private System.Windows.Forms.Button BtnStartServer;
        private System.Windows.Forms.Button BtnStopServer;
        private System.Windows.Forms.Button BtnSendMessage;
        private System.Windows.Forms.TextBox txtMessage;
    }
}

