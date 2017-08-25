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
        public Server()
        {
<<<<<<< HEAD
            server = new TcpListener(IPAddress.Parse("192.168.0.152"),9999);
=======
            server = new TcpListener(IPAddress.Parse("127.0.0.1"),9999);
>>>>>>> 48bf7fd4c29debebf06d93105ca11f3002bca22f
            server.Start();
        }
        public void Run()
        {
            while (true)
            {
                AcceptClient();
                string message = client.Recieve();
                Respond(message);
            }
        }
        private void AcceptClient()
        {
            TcpClient clientSocket = default(TcpClient);
            clientSocket = server.AcceptTcpClient();
            Console.WriteLine("Connected");
            NetworkStream stream = clientSocket.GetStream();
            client = new Client(stream, clientSocket);
            
        }
        private void Respond(string body)
        {
           
        }
    }
}
