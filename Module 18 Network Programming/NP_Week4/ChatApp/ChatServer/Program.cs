using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// import libraries
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Collections; // for the HashTable class

namespace ChatServer
{
    class Program
    {
        // Prepare a hash table instance to save clients' names along their sockets (name, socket)
        public static Hashtable clientList = new Hashtable();

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
            int counter = 0;
            TcpClient clientSocket;

            // Part 1: Joining Chat Room
            // Accept client request for joining
            // broadcast the "Join" message to all other chat clients
            while (true) // while the server is ON, accept client's connection for joining the chat room
            {
                // Increase the clients' counter and accept the connection for that client
                counter += 1;
                clientSocket = listener.AcceptTcpClient();
                
                // Step 3: Setup the Network Stream
                NetworkStream networkStream = clientSocket.GetStream();

                // Step 4: Send & Receive
                // prepare a byte array to receive the incoming data packets
                // set the array size to the size of the socket buffer size
                byte[] buffer = new byte[clientSocket.ReceiveBufferSize];
                // read the incoming message from the start "0" to the end of data packets "socket buffer size"
                int bytesRead = networkStream.Read(buffer, 0, clientSocket.ReceiveBufferSize);

                // convert receiving data from bytes to string
                string clientName = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                
                // Add that client to the clients's list in the Hash table
                clientList.Add(clientName, clientSocket);

                // Broadcast joining new client to the chat room
                broadcast(clientName + " Joined Chat Room", clientName, false);

                //print on the server console
                Console.WriteLine(clientName + " Joined the chat room");
                
                // Handle that client through threading
                handleClient client = new handleClient(clientSocket, clientName, clientList);

            }

            clientSocket.Close();
            listener.Stop();
            Console.ReadKey();
        }

        // "broadcast" method within the server
        public static void broadcast(string msg, string clientName, bool flag)
        {
            
            foreach (DictionaryEntry client in clientList)
            {
                TcpClient broadcastSocket = (TcpClient)client.Value; // value is the client sockets in the hash table
                NetworkStream broadcastStream = broadcastSocket.GetStream();
                byte[] broadcastBuffer = null;

                if (flag == true)
                {
                    // new chat room message
                    broadcastBuffer = Encoding.ASCII.GetBytes(clientName + " says: " + msg);
                }
                else
                {
                    // server's message
                    broadcastBuffer = Encoding.ASCII.GetBytes(msg); // server's message
                }
                broadcastStream.Write(broadcastBuffer, 0, broadcastBuffer.Length);
                broadcastStream.Flush();    
            }
        }
    }

    // Class to handle each client request seperately
    public class handleClient
    {
        TcpClient clientSocket;
        string clientName;
        Hashtable clientList;

        public handleClient(TcpClient socket, string cName, Hashtable cList)
        {
            clientSocket = socket;
            clientName = cName;
            clientList = cList;
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
                    Console.WriteLine(">>From client " + clientName + " :" + data);

                    // BroadCast
                    Program.broadcast(data, clientName, true);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

            }
        }
    }
}
