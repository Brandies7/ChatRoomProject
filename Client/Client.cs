using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Client:IObservable
    {
        TcpClient clientSocket;
        NetworkStream stream;

        public Client(string IP, int port)
        {
            // Instantiating a TcpClient
            clientSocket = new TcpClient();

            clientSocket.Connect(IPAddress.Parse("127.0.0.1"), 9999);


            // We are connecting it to a server with IP = IP and port = port
            clientSocket.Connect(IPAddress.Parse(IP), port);

            // Open a stream connection between client and server.

            stream = clientSocket.GetStream();
        }

        public void Send()
        {
            while (true)
            {
                // Get a message.
                string messageString = UI.GetInput();

                // Convert the message to bytes (1s and 0s).
                byte[] message = Encoding.ASCII.GetBytes(messageString);

                // Send the message over the network stream
                stream.Write(message, 0, message.Count());
            }

        }

        public void Receive()
        {
            while (true)
            {
                // Creating a byte array with length 256.
                byte[] recievedMessage = new byte[256];

                // Reads 256 bytes of any message being received.
                stream.Read(recievedMessage, 0, recievedMessage.Length);

                // Displays the message received into the console.
                UI.DisplayMessage(Encoding.ASCII.GetString(recievedMessage));
            }
        }
    }
}
