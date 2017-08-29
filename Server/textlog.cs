using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Server
{
    class Consolelog : ILog

{
    public string message;


    public void RecieveMessage(string message)
    {
        this.message = message;
    }

    public void SaveMessage()
    {
        Console.WriteLine(message);
    }
}
}
