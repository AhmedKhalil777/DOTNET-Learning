using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//import libraries
using System.Net;
using System.IO;

namespace ClientBrowser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            string url = txtURL.Text;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            // Defined Properties for the Web Request 
            request.Method = "GET";
            request.MediaType = "HTTP / 1.1";
            request.ContentType = "text / html";

            // send web request and receive a web response
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            // Convert data from the Web Response to a string
            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
            string responseString = reader.ReadToEnd();

            //print on form text box and navigate the browser to the url
            txtSource.Text = responseString;
            webBrowser1.Navigate(url);
            reader.Close();
        }
    }
}
