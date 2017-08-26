using System;
using System.Collections;
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
        Dictionary<string, Client> users = new Dictionary<string, Client>();

        public Server()
        {
            // We want to listten on an address and a port.(We are listening for anything to be sent to us).
            server = new TcpListener(IPAddress.Parse("127.0.0.1"), 9999);

            // Let's start listening
            server.Start();
        }

        public void Run()
        {
            while (true)
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
        }

        public void AcceptClient()
        {
            while (true)
            {
                // Create a client that is requesting to connect (Client called GetStream());
                TcpClient clientSocket = server.AcceptTcpClient();
                Console.WriteLine("Connected a new client");
                // dictionary.Add(UserID, clientSocket);

                // Determine what stream the client is using
                NetworkStream stream = clientSocket.GetStream();

                // Create a client object.
                client = new Client(stream, clientSocket);

                AddUserToDictionary(client);

                // Create a thread starter that uses the client.receive function
                ThreadStart receiveMessageStart = new ThreadStart(client.Receive);

                // Create a thread that calls client.receive()
                Thread receiveMessageThread = new Thread(receiveMessageStart);

                // Start that thread. (We need resource locking?)
                receiveMessageThread.Start(); 
            }
        }

        private void AddUserToDictionary(Client c)
        {
            users.Add(c.UserId, c);

            throw new NotImplementedException();
        }

        // This is probably going to be what we use to broadcast messages. 
        public void Response(string body)
        {
//            foreach (DictionaryEntry item in dictionary)
//            {
//            }
        }
    }
}