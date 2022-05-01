using System.Net.Sockets;

try
{
    StartListener(5000).Wait();
    return 0;
}
catch (Exception ex)
{
    Console.Error.WriteLine(ex);
    return -1;
}

static async Task StartListener(int port)
{

    var tcpListener = TcpListener.Create(port);
    tcpListener.Start();
    var baseClientNum = 0;
    for (; ; )
    {
        Console.WriteLine("[Server] waiting for clients...");
        using (var tcpClient = await tcpListener.AcceptTcpClientAsync())
        {
           
            try
            {
                var clientNum = baseClientNum++;
                Console.WriteLine("[Server] Client has connected");
                using (var networkStream = tcpClient.GetStream())
                using (var reader = new StreamReader(networkStream))
                using (var writer = new StreamWriter(networkStream) { AutoFlush = true })
                {

                    // Step 5: Send & Receive
                    // prepare a byte array to receive the incoming data packets
                    // set the array size to the size of the socket buffer size
                    byte[] buffer = new byte[tcpClient.ReceiveBufferSize];
                    // read the incoming message from the start "0" to the end of data packets "socket buffer size"
                    int bytesRead = networkStream.Read(buffer, 0, tcpClient.ReceiveBufferSize);

                    // convert receiving data from bytes to string and print it in the server console
                    string data = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                    Console.WriteLine(">>From client " + clientNum + " Data recieved:" + data);

                    // Return the data back to the client by writing received data on the network stream
                    string serverResponse = ">>Server to client " + clientNum + ": " + data;
                    byte[] responseBuffer = Encoding.ASCII.GetBytes(serverResponse);
                    networkStream.Write(responseBuffer, 0, responseBuffer.Length);
                    Console.WriteLine(">>" + serverResponse);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("[Server] client connection lost");
            }
        }
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
        Thread clientThread = new Thread(ExchangeData);
        clientThread.Start();
    }

    private void ExchangeData()
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
                Console.WriteLine(">>From client " + clientNo + " Data recieved:" + data);

                // Return the data back to the client by writing received data on the network stream
                string serverResponse = ">>Server to client " + clientNo + ": " + data;
                byte[] responseBuffer = Encoding.ASCII.GetBytes(serverResponse);
                networkStream.Write(responseBuffer, 0, responseBuffer.Length);
                Console.WriteLine(">>" + serverResponse);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }
    }
}
