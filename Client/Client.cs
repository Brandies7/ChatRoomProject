using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Client
    {
        TcpClient clientSocket;
        NetworkStream stream;
        public Client(string IP, int port)
        {
            clientSocket = new TcpClient();
<<<<<<< HEAD
            clientSocket.Connect(IPAddress.Parse("192.168.0.152"), 9999);
=======
            clientSocket.Connect(IPAddress.Parse("127.0.0.1"), 9999);
>>>>>>> 48bf7fd4c29debebf06d93105ca11f3002bca22f
            stream = clientSocket.GetStream();
            
        }
        public void Send()
        {
            while(true)
            {
                string messageString = UI.GetInput();
                byte[] message = Encoding.ASCII.GetBytes(messageString);
                stream.Write(message, 0, message.Count());
            }

        }
        public void Recieve()
        {
            while (true)
            {
                byte[] recievedMessage = new byte[256];
                stream.Read(recievedMessage, 0, recievedMessage.Length);
                UI.DisplayMessage(Encoding.ASCII.GetString(recievedMessage));
            }
<<<<<<< HEAD
=======
            
            
>>>>>>> ca128099f06fdafb09e41891097494e5fc142f6d
        }
            
    }
}
