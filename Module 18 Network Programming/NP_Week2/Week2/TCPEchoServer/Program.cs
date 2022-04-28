using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// import the Socket namespace
using System.Net.Sockets;
using System.Net;

namespace TCPServer
{
    class Program
    {
        // Assign the values of IP and Port numbers 
        const int PORT_NO = 5000;
        const string SERVER_IP = "127.0.0.1";

        static void Main(string[] args)
        {
            
            // Convert IP string to a form that can be identified by the Network Protocol
            IPAddress localAdd = IPAddress.Parse(SERVER_IP);

            // Step 1: Create a TCP Listener Socket, its job is to listen for incoming requests on the predefined IP and Port numbers
            TcpListener listener = new TcpListener(localAdd, PORT_NO);

            // Start the server. Set the server to working mode. The server now is basically waits for any incoming connections
            listener.Start();
            Console.WriteLine(">> Server Started ....");

            // Step 2: For each incoming connection, create a single TCP socket and accept the connection
            // its job is to deal and communicate with that client
            TcpClient clientSocket = listener.AcceptTcpClient();
            Console.WriteLine(">> Accept connection from a client");
            
            while ((true)) // while the server is ON
            {
                try
                {
                    // Step 3: Setup the Network Stream
                    NetworkStream networkStream = clientSocket.GetStream();

                    // Step 4: Send & Receive
                    // prepare a byte array to receive the incoming data packets
                    // set the array size to the size of the socket buffer size
                    byte[] buffer = new byte[clientSocket.ReceiveBufferSize];
                    // read the incoming message from the start "0" to the end of data packets "socket buffer size"
                    int bytesRead = networkStream.Read(buffer, 0, clientSocket.ReceiveBufferSize);

                    // convert receiving data from bytes to string and print it in the server console
                    string data = Encoding.ASCII.GetString(buffer,0,bytesRead);
                    Console.WriteLine(">> Data recieved:"+data);

                    // Return the data back to the client by writing received data on the network stream
                    Console.WriteLine(">> Sending back: "+ data);
                    networkStream.Write(buffer,0,bytesRead);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                
            }
            // Step 5: Close Sockets
            clientSocket.Close();   // client socket close, connection with that  client ends.
            listener.Stop();        // server listener stops, server is down

            Console.WriteLine(">> Server stops.");
            Console.ReadLine();
        }
    }
}
