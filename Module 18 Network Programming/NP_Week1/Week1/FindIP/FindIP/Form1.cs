using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace FindIP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            try
            {
                IPHostEntry url = Dns.GetHostByName(txtUrl.Text);
                IPHostEntry hostInfo = Dns.Resolve(txtUrl.Text);
                string result = "Canonical Name: " + hostInfo.HostName + "\r\n";
                result += "List of IPs associated with this host: \r\n";
                foreach (IPAddress ip in hostInfo.AddressList)
                {
                    result += ip.ToString() +"\r\n";
                }
                result += "List of Alias Names associated with this host: \n";
                foreach (String alias in hostInfo.Aliases)
                {
                    result += alias +"\r\n";
                }
                txtAddress.Text = result; 
               
            }
            catch(Exception ex){
                MessageBox.Show(ex.ToString());
            }

        }
    }
}
