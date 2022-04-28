using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//import libraries
using System.Net;
using System.IO;

namespace ClientPost
{
    class Program
    {
        static void Main(string[] args)
        {
         
            // Create a Web Request to URL 
            // WebRequest is the standard class to access data from the Internet
            // Cast it to a particular protocol such as HTTP or FTP
            // Here, we cast it to the HTTPWebRequest
            string url = "http://localhost:5000/main.html";
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(url);

            // Define required headers for the Web Request 
            request.Method = "GET";
            request.MediaType = "HTTP / 1.1";
            request.ContentType = "text / html";
            request.Accept = "*/*";

            // send web request and receive a web response
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            // Convert data from the Web Response to a string
            // Data here is expected to be the requested web page's source code
            // Get the response stream
            // read it through a stream reader
            // ReadToEnd() as a string and print
            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
            string responseString = reader.ReadToEnd();
            Console.WriteLine(responseString);

            // close the stream reader
            reader.Close();

            Console.ReadKey();
        }
    }
}
