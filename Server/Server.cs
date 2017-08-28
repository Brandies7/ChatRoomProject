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
        private static Dictionary<string, Client> users = new Dictionary<string, Client>();
        private static Dictionary<string, Thread> receiveThread = new Dictionary<string, Thread>();


        public Server()
        {
            // We want to listten on an address and a port.(We are listening for anything to be sent to us).
            server = new TcpListener(IPAddress.Parse("127.0.0.1"), 9999);

            // Let's start listening
            server.Start();
        }

        public void Run()
        {
            // Continuously accept clients.
            ThreadStart acceptClientStart = new ThreadStart(AcceptClient);
            Thread acceptClientThread = new Thread(AcceptClient);
            acceptClientThread.Start();

            while (true);
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
            }
        }

        private void AddUserToDictionary(Client newClient)
        {
            // Add user to dictionary of clients
            users.Add(newClient.UserId, newClient);

            // Create a thread for that new user
            receiveThread.Add(newClient.UserId, new Thread(new ThreadStart(users[newClient.UserId].Receive)));

            // Start that new users thread
            receiveThread[newClient.UserId].Start();
        }

        // This is probably going to be what we use to broadcast messages. 
        public static  void Response(Message message)
        {
            // Send the message to all users who aren't the sender
            // "If I send the message hey, I don't want it to send it back to me"
            foreach (KeyValuePair<string, Client> item in users)
            {
                if (item.Key == message.UserId) continue;
                item.Value.Send(message.Body);
            }
        }
    }
}