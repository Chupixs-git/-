using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class SMSNotification : Notification
    {
        public string PhoneNumber { get; set; }
        

        public SMSNotification(string message, string phoneNumber) : base(message)
        {
            PhoneNumber = phoneNumber;
        }

        public override string FormatMessage()
        {
            
            return $"SMS на {PhoneNumber}: {Message}";
        }

        public override void Send()
        {
            
            Console.WriteLine($"Время отправки{Timespan} на {PhoneNumber}: {FormatMessage()}");
        }
    }
}
