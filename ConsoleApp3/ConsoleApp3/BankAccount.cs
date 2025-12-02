using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class BankAccount
    {
        private static int num;
        public string Number { get; private set;}
        public decimal Balance { get; private set;}
        public BankAccount(decimal balance)
        {
            num++;
            Number = num.ToString();

            Balance = balance;
        }

        public string TopUp(decimal money)
        {
           Balance =+ money;
            return "Деньги внесены";
        }

        public string TopDown(decimal money) 
        {
            if (Balance - money < 0)
            {
                return "Не достаточно Средств";
            }
            Balance -= money;
            return "Деньги Сняты со Счета";
        }

    }
}
