using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Required  Libraries
using System.Net.Sockets;
using System.Net;

namespace UDPClientSide
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            // Create a udp socket
            UdpClient client = new UdpClient();
            // connect to the server with the port number
            client.Connect("localhost", 5000);
            // convert message to a byte array to be transfered
            byte[] buffer = Encoding.ASCII.GetBytes(txtMsg.Text);
            // send 
            client.Send(buffer, buffer.Length);
            // close the socket
            client.Close();
        }
    }
}
