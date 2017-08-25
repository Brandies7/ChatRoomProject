using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Client client = new Client("127.0.0.1", 9999);

                // Creating a new thread start for sending messages
                ThreadStart sendThreadStart = new ThreadStart(client.Send);
                Thread sendThread = new Thread(sendThreadStart);

                // Creating a new thread start for receiving messages
                ThreadStart receiveThreadStart = new ThreadStart(client.Receive);
                Thread receiveThread = new Thread(receiveThreadStart);

                sendThread.Start();
                receiveThread.Start();

                while (true) ;
                //Console.ReadLine();
            }
        }
    }
}
