namespace FindIP
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
            this.lblurl = new System.Windows.Forms.Label();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.btnCheck = new System.Windows.Forms.Button();
            this.lblAdd = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblurl
            // 
            this.lblurl.AutoSize = true;
            this.lblurl.Location = new System.Drawing.Point(49, 49);
            this.lblurl.Name = "lblurl";
            this.lblurl.Size = new System.Drawing.Size(89, 20);
            this.lblurl.TabIndex = 0;
            this.lblurl.Text = "Enter URL:";
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(170, 49);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(238, 26);
            this.txtUrl.TabIndex = 1;
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(427, 45);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(92, 34);
            this.btnCheck.TabIndex = 3;
            this.btnCheck.Text = "Show Info";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // lblAdd
            // 
            this.lblAdd.AutoSize = true;
            this.lblAdd.Location = new System.Drawing.Point(49, 115);
            this.lblAdd.Name = "lblAdd";
            this.lblAdd.Size = new System.Drawing.Size(91, 20);
            this.lblAdd.TabIndex = 4;
            this.lblAdd.Text = "IP Address:";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(170, 109);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(349, 137);
            this.txtAddress.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 270);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.lblAdd);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.txtUrl);
            this.Controls.Add(this.lblurl);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblurl;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Label lblAdd;
        private System.Windows.Forms.TextBox txtAddress;
    }
}

