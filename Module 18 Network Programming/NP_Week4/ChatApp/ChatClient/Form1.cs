using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//libraries
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ChatClient
{
    public partial class Form1 : Form
    {
        TcpClient clientSocket = new TcpClient();
        NetworkStream serverStream = default(NetworkStream);
        string chatMessage = null;

        public Form1()
        {
            InitializeComponent();
           
        }

        
        // Connect to the chat server and start reading thread
        private void btnConnect_Click(object sender, EventArgs e)
        {
            chatMessage = "Connected to Server ...";
            showinChatRoom();

            // connect
            clientSocket.Connect("127.0.0.1", 5000);
            serverStream = clientSocket.GetStream();

            //send user's nickname
            byte[] outStream = Encoding.ASCII.GetBytes(txtNickName.Text);
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();

            // start the chat thread which implements the "getMessage()" method to read broadcast messages from the server
            Thread chatThread = new Thread(getMessage);
            chatThread.Start();
        }

        // send user's messages to the chat server
        // just "send" no "receive", as receiving will be done using the "getMessage()" method
        private void btnSend_Click(object sender, EventArgs e)
        {
            serverStream = clientSocket.GetStream();

            byte[] outStream = Encoding.ASCII.GetBytes(txtMsg.Text);
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();

            txtMsg.Text = "";
            txtMsg.Focus();
            
        }

        // Reading server's as well as other clients messages
        private void getMessage()
        {
            // It is important to read the stream in an infinite loop 
            // as we don't know number of chat messages and when it will come
            while (true) 
            {
                // read incoming data stream
                byte[] inStream = new byte[clientSocket.ReceiveBufferSize];
                serverStream.Read(inStream, 0, inStream.Length);
                string newMessage = Encoding.ASCII.GetString(inStream);

                // show message in client's chat window
                chatMessage = "" + newMessage;
                showinChatRoom();
            }
        }


        // simple method that write the new message in the ChatRoom textbox then writes a newline break
        private void showinChatRoom()
        {
            if (this.InvokeRequired)// see the explanation below
                this.Invoke(new MethodInvoker(showinChatRoom)); 
            else

                txtChatRoom.Text += Environment.NewLine + " >> " + chatMessage; 
            /*
             * Multithreading can expose your code to very serious and complex bugs.
             * Two or more threads manipulating a control can force the control into an inconsistent state 
             * and lead to race conditions, deadlocks, and freezes or hangs. 
             * If you implement multithreading in your app, be sure to call cross-thread controls in a thread-safe way. 
             */
        }
    }
}
