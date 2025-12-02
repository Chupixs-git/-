using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class EmailNotification : Notification
    {
        public string SenderAddress { get; set; }

        public EmailNotification(string message, string senderAddress) : base(message)
        {
            SenderAddress = senderAddress;
        }

        public override string FormatMessage()
        {
            
            return $"Email {SenderAddress}: {Message}";
        }

        public override void Send()
        {
            
            Console.WriteLine($"Отправлено на Email{Timespan} От {SenderAddress}: {FormatMessage()}");
        }

    }
}
