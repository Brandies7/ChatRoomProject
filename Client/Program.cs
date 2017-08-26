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
            Client client = new Client("127.0.0.1", 9999);

            ThreadStart sendThreadStart = new ThreadStart(client.Send);
            Thread sendThread = new Thread(sendThreadStart);
            sendThread.Start();

            ThreadStart receiveThreadStart = new ThreadStart(client.Receive);
            Thread receiveThread = new Thread(receiveThreadStart);
            receiveThread.Start();
            Console.ReadLine();
        }
    }
}
