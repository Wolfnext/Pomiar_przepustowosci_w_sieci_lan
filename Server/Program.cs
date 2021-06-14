using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Server
{
    class Program
    {
        const string responseText = "server_v1.0";
        const int PORT_NO = 53405; // PORT SERVER
        private static int broadcastPort = 50050; // PORT BROADCAST
        const string SERVER_IP = "localhost";
        public static int HEADS_UP = 11;
        static void Main(string[] args)
        {
            Thread listenerThread = new Thread(BroadcastToClients); // broadcast response in other thread
            listenerThread.Start(); // start other thread
            tcpserver(); // start TCP server
        }

 static private void tcpserver()
        {
            TcpListener server = null;
            try
            {
            server = new TcpListener(IPAddress.Any, PORT_NO); // TCP server
            Console.WriteLine("Listening..."); 
            server.Start(); // start

                int uploadLength = 0;
                // Enter the listening loop.
                while (true)
                { 
                TcpClient client = server.AcceptTcpClient(); // accept all  TCP client
                Console.WriteLine("Connected!");   // write when client connected            
                NetworkStream stream = client.GetStream();
                    client.SendTimeout = 600000;                  
                 
                    int lengthPacket = 1024;
                    byte[] packet;
                   // byte[] bytes = new byte[HEADS_UP];
                    int receiveLength = 0;

                    byte[] buffer = new byte[client.ReceiveBufferSize];

                    //---read incoming stream---
                    int bytesRead = stream.Read(buffer, 0, client.ReceiveBufferSize);

                    //---convert the data received into a string---
                    string dataReceived = Encoding.ASCII.GetString(buffer, 0, bytesRead);

                    // -------------------------------------------------------------------------------------
                    // Download Mode
                    // -------------------------------------------------------------------------------------
                    if (dataReceived.Length > 6 && dataReceived.Substring(0, 6) == "length")
                    {
                        lengthPacket = int.Parse(dataReceived.Substring(7));
                        try
                        {
                            packet = new byte[lengthPacket];
                            stream.Write(packet, 0, packet.Length);
                        }
                        catch (Exception ex)
                        {
                        }
                    }

                    // -------------------------------------------------------------------------------------
                    // Upload Mode
                    // -------------------------------------------------------------------------------------
                    else if (dataReceived.Length > 6 && dataReceived.Substring(0, 6) == "upload")  
                    {
                        lengthPacket = int.Parse(dataReceived.Substring(7));
                        uploadLength = lengthPacket; // save length uploading packet
                    }

                    
                    int total_received = bytesRead;
                    if (uploadLength > 0)
                    {
                        Stopwatch stopwatch = new Stopwatch();
                        while (bytesRead != 0)
                        {
                            //  stopwatch.Reset();
                            stopwatch = Stopwatch.StartNew();
                            
                            buffer = new byte[client.ReceiveBufferSize];                     
                            bytesRead = stream.Read(buffer, 0, client.ReceiveBufferSize);  
                            total_received += bytesRead;                         
                            stopwatch.Stop();
                            var speed = 0;
                            Console.WriteLine(stopwatch.ElapsedMilliseconds);
                            if (stopwatch.ElapsedMilliseconds > 0) speed = (bytesRead * 8) / (int)stopwatch.ElapsedMilliseconds;

                            byte[] uplACK = System.Text.Encoding.UTF8.GetBytes("ACK=" + bytesRead+","+speed);
                            stream.Write(uplACK, 0, uplACK.Length); // send ACK with actual read bytes and calculate speed
                            if (total_received >= lengthPacket) break;
                        }
                        byte[] endACK = System.Text.Encoding.UTF8.GetBytes("ACK=END"); // send ACK=END when end reading Data
                        stream.Write(endACK, 0, endACK.Length);

                        uploadLength = 0;
                    }
                }
                // ------------------------------------------------------------------------------------- //
            }
            catch (SocketException e)
    {
      Console.WriteLine("SocketException: {0}", e);
    }
    finally
    {

    }
                        
        }

        // -------------------------------------------------------------------------------------
        // Listining Broadcast and response to client 
        // -------------------------------------------------------------------------------------
        static private void BroadcastToClients()
        {
            var Server = new UdpClient(broadcastPort);
            var ResponseData = Encoding.ASCII.GetBytes(responseText);

            while (true)
            {
                var ClientEp = new IPEndPoint(IPAddress.Any, 0);
                var ClientRequestData = Server.Receive(ref ClientEp);
                var ClientRequest = Encoding.ASCII.GetString(ClientRequestData);
                if(ClientRequest == "searchServer__v1.0") {
                    Console.WriteLine("Recived {0} from {1}, sending response", ClientRequest, ClientEp.Address.ToString());
                    Server.Send(ResponseData, ResponseData.Length, ClientEp);
                }
             
            }
        }
    }
}
