﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Client
    {
        NetworkStream stream;
        TcpClient client;
        public string UserId;

        public Client(NetworkStream Stream, TcpClient Client)
        {
            stream = Stream;
            client = Client;
            UserId = "495933b6-1762-47a1-b655-483510072e73";
        }

        public void Send(string Message)
        {
<<<<<<< HEAD
            while (true)
            {
                byte[] message = Encoding.ASCII.GetBytes(Message);
                stream.Write(message, 0, message.Count());
            }
            
=======
            // Convert message to binary (1s and 0s)
            byte[] message = Encoding.ASCII.GetBytes(Message);

            // Send the message to the client.
            stream.Write(message, 0, message.Count());
            stream.Close();
>>>>>>> 1201f550720d858c94fcba09049db11bf6bb44ca
        }

        public void Receive()
        {
            while (true)
            {
<<<<<<< HEAD
                byte[] recievedMessage = new byte[256];
                stream.Read(recievedMessage, 0, recievedMessage.Length);
                string recievedMessageString = Encoding.ASCII.GetString(recievedMessage);
                Console.WriteLine(recievedMessageString);
                return recievedMessageString;
            }
        }
=======
                // Create a 256 byte array
                byte[] recievedMessage = new byte[256];

                // Read up to 256 bytes from the input
                stream.Read(recievedMessage, 0, recievedMessage.Length);
>>>>>>> 1201f550720d858c94fcba09049db11bf6bb44ca

                // Convert the input as a string
                string recievedMessageString = Encoding.ASCII.GetString(recievedMessage);

                // Write the input to the server log and then return.
                Console.WriteLine(recievedMessageString);
            }
        }
    }
}