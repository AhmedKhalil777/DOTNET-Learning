using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// libraries
using System.Net;
using System.IO;

namespace HTTPServer
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define an HTTP listener: its job is to listen and serve incoming web requests
            HttpListener server = new HttpListener();

            // Add uri prefixes for that server
            // A prefix consists of: schema(http or https)://address:port/
            // 
            server.Prefixes.Add("http://127.0.0.1:5000/");
            server.Prefixes.Add("http://localhost:5000/");

            // start the server
            server.Start();
            Console.WriteLine(">> Server Started... Waiting for web requests");

            while (true) // while server is ON
            {
                // Get HTTP context channel to give access to the request and response objects
                HttpListenerContext context = server.GetContext();
                // prepare an http response object by using the predefined response in the "context" class
                HttpListenerResponse response = context.Response;

                // get the page path from the server
                // Here, the page path is the project directory + requested page name (e.g. index.html)
                string page = Directory.GetCurrentDirectory() + context.Request.Url.LocalPath;

                try
                {
                    // Define a text reader that can read the web page as a series of characters
                    TextReader reader = new StreamReader(page);
                    string reply = reader.ReadToEnd();

                    // Send the reply as byte array via the reponse stream
                    byte[] buffer = Encoding.ASCII.GetBytes(reply);
                    Stream st = response.OutputStream;
                    st.Write(buffer, 0, buffer.Length);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                // close the stream
                context.Response.Close();
            }
        }
    }
}
