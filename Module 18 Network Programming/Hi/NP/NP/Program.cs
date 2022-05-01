using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace NP
{
    class Program
    {
        const int port = 5000;
        const string ip = "127.0.0.1";
        static void Main(string[] args)
        {
            IPAddress iP = IPAddress.Parse(ip);

            TcpListener server = new TcpListener(iP, port);
            server.Start();
            Console.WriteLine(">> srever started >>");
            TcpClient tcpClient = server.AcceptTcpClient();

            while (true)
            {
                try
                {
                    NetworkStream ntstream = tcpClient.GetStream();
                    byte[] buffer = new byte[tcpClient.ReceiveBufferSize];
                    int numbyte = ntstream.Read(buffer, 0, tcpClient.ReceiveBufferSize);
                    string mess = Encoding.ASCII.GetString(buffer, 0, numbyte);
                    Console.WriteLine(">> Data Recieved >>" +mess);
                    ntstream.Write(buffer, 0, numbyte);
                    Console.WriteLine("Data Echoed");

                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message); 
                }
            }
        }
    }
}
