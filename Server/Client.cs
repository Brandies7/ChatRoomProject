using System;
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
        public Queue<string> Queue;
        private Server server;

        public Client(NetworkStream Stream, TcpClient Client, Server server)
        {
            stream = Stream;
            client = Client;
            UserId = Guid.NewGuid().ToString();
            Queue = new Queue<string>();
            this.server = server;
        }

        public void Send(string Message)
        {
                // Convert message to binary (1s and 0s)
                byte[] message = Encoding.ASCII.GetBytes(Message);

                // Send the message to the client.
            try
            {
                stream.Write(message, 0, message.Count());
            }
            catch
            {
                Console.WriteLine("Send error");
            }
        }


        public Message Receive()
        {
                // Create a 256 byte array
                byte[] recievedMessage = new byte[256];
            try
            {
                stream.Read(recievedMessage, 0, recievedMessage.Length);
            }
            catch (Exception e)
            {
               Message message = new Message(this, "Has logged out");
                server.queue.Enqueue(message);
            }
                // Read up to 256 bytes from the input
               

                // Convert the input as a string
                string recievedMessageString = Encoding.ASCII.GetString(recievedMessage);



                // Write the input to the server log and then return.
                Console.WriteLine(recievedMessageString.Trim());


                Message myMessage = new Message(this, recievedMessageString);
                //Server.Response(myMessage);
                return myMessage;
             // Send(recievedMessageString);

        }


    }
}