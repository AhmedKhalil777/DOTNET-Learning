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
using System.Net.Sockets;
using System.Net;

namespace TCPClient
{
    public partial class Form1 : Form
    {
        // Step1: Creat a TCP client socket and bind it to the server IP and the service Port No.
        TcpClient clientSocket = new TcpClient("127.0.0.1",5000);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            // Step 2: Setup the Network Stream
            NetworkStream ntStream = clientSocket.GetStream();

            // Step 3: Send & Receive
            // prepare a byte array that contains data to be send
            // convert the string message to bytes using "GetBytes" method
            byte[] outStream = Encoding.ASCII.GetBytes(txtClientMsg.Text);

            // write the byte[] on the network stream so that it can be delivered to the server
            // parameter "0" means start of the message, and "outstream.Length" is the end of it
            ntStream.Write(outStream, 0, outStream.Length);

            // prepare another byte array to receive the incoming data packets
            // set the array size to the size of the socket buffer size
            byte[] inStream = new byte[clientSocket.ReceiveBufferSize];

            // read the incoming message from the start "0" to the end of data packets "socket buffer size"
            int bytesRead = ntStream.Read(inStream, 0, clientSocket.ReceiveBufferSize);

            // convert receiving data from bytes to string
            string returnData = Encoding.ASCII.GetString(inStream,0,bytesRead);

            // print the received message in the text box
            txtServerMsg.Text += Environment.NewLine + ">> " + returnData;
            txtClientMsg.Text = " ";

            // place the cursor back in client text box
            txtClientMsg.Focus();
            
        }

        private void Form1_Leave(object sender, EventArgs e)
        {

            // Step 4: Close the socket
            clientSocket.Close();
        }
    }
}
