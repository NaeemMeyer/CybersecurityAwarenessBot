namespace ST10468609_Mogamat_Naeem_Meyer_PROG6221
{
    partial class ChatBotForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.ListBox lstChat;
        private System.Windows.Forms.TextBox txtUserInput;
        private System.Windows.Forms.Button btnSend;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblLogo = new System.Windows.Forms.Label();
            this.lstChat = new System.Windows.Forms.ListBox();
            this.txtUserInput = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblLogo
            // 
            this.lblLogo.AutoSize = true;
            this.lblLogo.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Bold);
            this.lblLogo.ForeColor = System.Drawing.Color.Green;
            this.lblLogo.Location = new System.Drawing.Point(12, 9);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Size = new System.Drawing.Size(0, 17);
            this.lblLogo.TabIndex = 0;
            // 
            // lstChat
            // 
            this.lstChat.BackColor = System.Drawing.Color.Black;
            this.lstChat.ForeColor = System.Drawing.Color.White;
            this.lstChat.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular);
            this.lstChat.FormattingEnabled = true;
            this.lstChat.HorizontalScrollbar = true;
            this.lstChat.ItemHeight = 17;
            this.lstChat.Location = new System.Drawing.Point(15, 120);
            this.lstChat.Name = "lstChat";
            this.lstChat.Size = new System.Drawing.Size(600, 274);
            this.lstChat.TabIndex = 1;
            // 
            // txtUserInput
            // 
            this.txtUserInput.Location = new System.Drawing.Point(15, 410);
            this.txtUserInput.Name = "txtUserInput";
            this.txtUserInput.Size = new System.Drawing.Size(500, 23);
            this.txtUserInput.TabIndex = 2;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(530, 410);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(85, 23);
            this.btnSend.TabIndex = 3;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // ChatBotForm
            // 
            this.AcceptButton = this.btnSend;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 450);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtUserInput);
            this.Controls.Add(this.lstChat);
            this.Controls.Add(this.lblLogo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ChatBotForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cybersecurity Awareness Bot";
            this.Load += new System.EventHandler(this.ChatBotForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
