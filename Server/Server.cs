using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    class Server
    {
        public static Client client;
        TcpListener server;
        private List<ThreadStart> clientThreadStarts = new List<ThreadStart>();
        private List<Thread> clientThreads = new List<Thread>();

        public Server()
        {
<<<<<<< HEAD
<<<<<<< HEAD
            server = new TcpListener(IPAddress.Parse("192.168.0.152"),9999);
=======
            server = new TcpListener(IPAddress.Parse("127.0.0.1"),9999);
>>>>>>> 48bf7fd4c29debebf06d93105ca11f3002bca22f
=======
            // We want to listten on an address and a port.(We are listening for anything to be sent to us).
            server = new TcpListener(IPAddress.Parse("127.0.0.1"), 9999);

            // Let's start listening
>>>>>>> 1201f550720d858c94fcba09049db11bf6bb44ca
            server.Start();
        }
        public void Run()
        {
            AcceptClient();
            // Continuously accept clients.
            ThreadStart acceptClientStart = new ThreadStart(AcceptClient);
            Thread acceptClientThread = new Thread(AcceptClient);
            acceptClientThread.Start();

            // Continuously look for messages to receive.
            ThreadStart receiveMessageStart = new ThreadStart(client.Receive);
            Thread receiveMessageThread = new Thread(receiveMessageStart);
            receiveMessageThread.Start();




            //            if (message.Length > 0)
            //                Respond(message);



        }
        private void AcceptClient()
        {
<<<<<<< HEAD
            TcpClient clientSocket = default(TcpClient);
            clientSocket = server.AcceptTcpClient();
            Console.WriteLine("Connected");
            NetworkStream stream = clientSocket.GetStream();
            client = new Client(stream, clientSocket);
            
=======
            while (true)
            {
                // Create a client that is requesting to connect (Client called GetStream());
                TcpClient clientSocket = server.AcceptTcpClient();
                Console.WriteLine("Connected a new client");

                // Determine what stream the client is using
                NetworkStream stream = clientSocket.GetStream();

                // Create a client object.
                client = new Client(stream, clientSocket);

                ThreadStart receiveMessageStart = new ThreadStart(client.Receive); // Create a thread starter that uses the client.receive function
                Thread receiveMessageThread = new Thread(receiveMessageStart); // Create a thread that calls client.receive()
                receiveMessageThread.Start(); // Start that thread. (We need resource locking?)
            }
>>>>>>> 1201f550720d858c94fcba09049db11bf6bb44ca
        }

        // This is probably going to be what we use to broadcast messages. 
        private void Respond(string body)
        {
           
        }
    }
}
