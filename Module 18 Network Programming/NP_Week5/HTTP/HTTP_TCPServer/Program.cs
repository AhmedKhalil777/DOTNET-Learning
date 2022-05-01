using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//libraries
using System.Net.Sockets;
using System.Net;
using System.IO;

namespace HTTP_TCPServer
{
    class Program
    {
        const int PORT_NO = 5000;
        const string SERVER_IP = "127.0.0.1";

        static void Main(string[] args)
        {
            IPAddress localAdd = IPAddress.Parse(SERVER_IP);
            TcpListener listener = new TcpListener(localAdd, PORT_NO);
            listener.Start();
            Console.WriteLine(">> Server Started ....");
            TcpClient clientSocket = listener.AcceptTcpClient();
            Console.WriteLine(">> Accept connection from a client");
            while ((true)) // while the server is ON
            {
                try
                {
                    NetworkStream networkStream = clientSocket.GetStream();

                    /***************Rrepare the HTTP Response *********************************/

                    // HTTP String Format, here we wrap "Hello World" text
                    //with the http response package
                    string httpResponse = "HTTP/1.1 200 OK\n"+
                                        " Content-Type: text/plain\n"+
                                        "Content-Length: 12\n"+
                                        "\nHello world!";
                    // wrap the response in a byte array
                    byte[] buffer = Encoding.ASCII.GetBytes(httpResponse);
                    // send the byte array via the network stream
                    networkStream.Write(buffer, 0, buffer.Length);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
   
            }
        }
    }
}
