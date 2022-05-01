using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Required Libraries
using System.Net;
using System.Net.Sockets;

namespace UDPServerSide
{
    class Program
    {
        static void Main(string[] args)
        {
            // strat the server by listenin to a specific port
            UdpClient listner = new UdpClient(5000);//listen port
            Console.WriteLine(">>UDP Server Started ...");
            // while server is open
            while (true)
            {
                // Read datagram packets send by any source
                IPEndPoint remote = new IPEndPoint(IPAddress.Any, 0);//accept any connection
                // receive the bytes in a byte array
                byte[] buffer = listner.Receive(ref remote);
                // convert the message to string
                string returnData = Encoding.ASCII.GetString(buffer);
                // write it on the server console
                Console.WriteLine(">>Recieved: "+returnData);
            }
            // close the server
            listner.Close();
        }
    }
}
