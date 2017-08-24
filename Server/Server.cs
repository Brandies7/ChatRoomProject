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
        public static List<Client> clients;
        TcpListener server;
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
            AcceptClient();

            // Continuously look for messages to receive.
            foreach (Client client in clients)
            {
                string message = client.Receive();
                if(message.Length > 0)
                    Respond(message);
            }

            
        }
        private void AcceptClient()
        {
            // Create a client that is requesting to connect (Client called GetStream());
            TcpClient clientSocket = server.AcceptTcpClient();
            Console.WriteLine("Connected a new client");

            // Determine what stream the client is using
            NetworkStream stream = clientSocket.GetStream();

            // Create a client object.
            clients.Add(new Client(stream, clientSocket));
        }

        // This is probably going to be what we use to broadcast messages. 
        private void Respond(string body)
        {
           
        }
    }
}
