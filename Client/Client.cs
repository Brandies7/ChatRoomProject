using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Client
    {
        TcpClient clientSocket;
        NetworkStream stream;
        public String name;

        public Client(string IP, int port)
        {
            
            // Instantiating a TcpClient
            clientSocket = new TcpClient();

            // We are connecting it to a server with IP = IP and port = port
            clientSocket.Connect(IPAddress.Parse(IP), port);

            // Open a stream connection between client and server.
            stream = clientSocket.GetStream();

            Console.WriteLine("What's your name?");
            name = Console.ReadLine();
            

        }

        public void Send()
        {
            
            while (true)
            {
                
                // Get a message.
                string messageString = name + ": " + UI.GetInput();

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
                byte[] receivedMessage = new byte[256];

                // Reads 256 bytes of any message being received.
                stream.Read(receivedMessage, 0, receivedMessage.Length);

                string receivedMessageString = Encoding.ASCII.GetString(receivedMessage);

                // Displays the message received into the console.
                UI.DisplayMessage(receivedMessageString.Trim());
            }
        }
    }
}
