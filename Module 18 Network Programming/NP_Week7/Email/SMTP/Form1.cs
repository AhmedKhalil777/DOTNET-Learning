using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//
using System.Net.Mail;


namespace SMTP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                SmtpClient client = new SmtpClient();
                client.Port = 587;
                client.Host = "smtp.gmail.com";
                client.EnableSsl = true;
                // DefaultCredentials represents the system credentials for the current security context in which the application is running. 
                client.UseDefaultCredentials = false;
                // SMTP Authentication: You must provide a real email address and te real password assciated with it
                client.Credentials = new System.Net.NetworkCredential("mj77777theking@gmail.com", "Maninthemirror123");

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(txtFrom.Text);
                mail.To.Add(txtTo.Text);
                mail.Subject = txtSubject.Text;
                mail.Body = txtBody.Text;

                mail.BodyEncoding = UTF8Encoding.UTF8;
                mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

                Attachment file = new Attachment(lblAttach.Text);
                mail.Attachments.Add(file);

                client.Send(mail);
                MessageBox.Show("Message Send!");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAttach_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            lblAttach.Text = openFileDialog1.FileName;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
