using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// import libraries
using System.Net; //It allows classes to communicate with other applications by using the Hypertext Transfer Protocol (HTTP), Transmission Control Protocol (TCP), User Datagram Protocol (UDP), and Socket Internet protocols.
using System.Net.Sockets;
using System.Threading;

namespace MultiTCPServer
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

            // Step 2: For each incoming connection, create a single TCP socket
            TcpClient clientSocket;

            int counter = 0; // clients' counter

            while (true) // while the server is ON
            {
                counter += 1;
                // Accept connection
                clientSocket = listener.AcceptTcpClient();
                Console.WriteLine(">> " + "Client No:" + counter + " started!");

                // Step 3: Pass each client to a separate thread
                handleClient newClient = new handleClient(clientSocket, counter);
                
            }
            // Return Back
            // Step 6: Close Sockets
            clientSocket.Close();
            listener.Stop();
            Console.WriteLine(">> exit...");
            Console.ReadKey();

        }
    }

    // Threading Class which will handle (exchange data with) each client request seperately
    public class handleClient
    {
        TcpClient clientSocket;
        int clientNo;

        public handleClient(TcpClient socket, int clientNumber)
        {
            clientSocket = socket;
            clientNo = clientNumber;
            // create a thread instance to start the sending and receiving process with that client
            Thread clientThread = new Thread(exchangeData);
            clientThread.Start();
        }

        private void exchangeData()
        {
            while ((true)) // while there is a connection between this client and the server
            {
                try
                {
                    // Step 4: Setup the Network Stream
                    NetworkStream networkStream = clientSocket.GetStream();

                    // Step 5: Send & Receive
                    // prepare a byte array to receive the incoming data packets
                    // set the array size to the size of the socket buffer size
                    byte[] buffer = new byte[clientSocket.ReceiveBufferSize];
                    // read the incoming message from the start "0" to the end of data packets "socket buffer size"
                    int bytesRead = networkStream.Read(buffer, 0, clientSocket.ReceiveBufferSize);

                    // convert receiving data from bytes to string and print it in the server console
                    string data = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                    Console.WriteLine(">>From client "+ clientNo +" Data recieved:" + data);

                    // Return the data back to the client by writing received data on the network stream
                    string serverResponse = ">>Server to client " + clientNo + ": " + data;
                    byte[] responseBuffer = Encoding.ASCII.GetBytes(serverResponse);
                    networkStream.Write(responseBuffer, 0, responseBuffer.Length);
                    Console.WriteLine(">>"+serverResponse);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

            }
        }
    }
}
