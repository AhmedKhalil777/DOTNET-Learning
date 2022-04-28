namespace TCPClient
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
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtClientMsg = new System.Windows.Forms.TextBox();
            this.txtServerMsg = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSend = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(26, 289);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(177, 20);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "Messages From Server:";
            // 
            // txtClientMsg
            // 
            this.txtClientMsg.Location = new System.Drawing.Point(30, 72);
            this.txtClientMsg.Multiline = true;
            this.txtClientMsg.Name = "txtClientMsg";
            this.txtClientMsg.Size = new System.Drawing.Size(654, 152);
            this.txtClientMsg.TabIndex = 1;
            // 
            // txtServerMsg
            // 
            this.txtServerMsg.Location = new System.Drawing.Point(30, 335);
            this.txtServerMsg.Multiline = true;
            this.txtServerMsg.Name = "txtServerMsg";
            this.txtServerMsg.Size = new System.Drawing.Size(654, 152);
            this.txtServerMsg.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(265, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Type your message and click \"Send\"";
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(574, 243);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(103, 39);
            this.btnSend.TabIndex = 4;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 540);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtServerMsg);
            this.Controls.Add(this.txtClientMsg);
            this.Controls.Add(this.lblStatus);
            this.Name = "Form1";
            this.Text = "TCP Client";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Leave += new System.EventHandler(this.Form1_Leave);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TextBox txtClientMsg;
        private System.Windows.Forms.TextBox txtServerMsg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSend;
    }
}

