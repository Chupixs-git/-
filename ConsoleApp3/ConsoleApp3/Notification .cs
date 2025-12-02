using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class Notification
    {
        public string Message { get; set; }

        
        public string Timespan { get; set; }

        
        public Notification(string message)
        {
            Message = message;
            Timespan = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
        public virtual string FormatMessage()
        {
            return Message;
        }

        public virtual void Send()
        {
            
            Console.WriteLine($"Sending notification at {Timespan}: {FormatMessage()}");
        }
    }
}

