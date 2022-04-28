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
using System.Reflection;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace ReadOutlook
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        

        private void Form1_Load(object sender, EventArgs e)
        {
            ListViewItem listEmail;
            Outlook.Application app;
            Outlook.NameSpace mapi;
            Outlook.MAPIFolder inbox;
            Outlook.Items items;

            Outlook.MailItem msg;

            app = new Outlook.Application();
            mapi = app.GetNamespace("mapi");
            inbox = mapi.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderInbox);
            items = inbox.Items;

            for (int i = 1; i < 100 ; i++)
            {
                msg = (Outlook.MailItem)items[i];
                listEmail = listView1.Items.Add(msg.SenderName);
                listEmail.SubItems.Add(msg.Subject);
                listEmail.SubItems.Add(msg.Body);
            }

            
        }

        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
