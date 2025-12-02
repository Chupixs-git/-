using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    abstract class Deliver
    {

        public string Address { get; }
        public string Recipient { get; }
        public abstract int BaseCost { get;}

        public Deliver(string address,string recipient) 
        {
            Address = address;
            Recipient = recipient;
        }

        public abstract float CalculateCost();
        public abstract float GetDeliveryTime();

        public void ShowInfo()
        {
            Console.WriteLine($"Получатель : {Recipient} ");
            Console.WriteLine($"Адрес : {Address} ");
            Console.WriteLine($"Тип Доставки : {GetType().Name} ");
            Console.WriteLine($"Стоимость : {CalculateCost()} ");
            Console.WriteLine($"Время : {GetDeliveryTime()} ");

        }
    }
    class HomeDelivery : Deliver
    {
        private float Distance;
        private float Weight;
        private int basecost = 400;

        public override int BaseCost
        {
            get { return basecost; }
        }
        public HomeDelivery(float distance, float weight,string address,string recipient) : base(address, recipient) 
        {
            Distance = distance;
            Weight = weight;
        }
        public override float CalculateCost()
        {
            return Distance * Weight * BaseCost;
        }
        public override float GetDeliveryTime() 
        {
            if(Distance < 100)
            {
                return 1;
            }
            else
            {
               return Convert.ToSingle(Math.Floor(Distance / 100));
            }
        }
    }
    class   PickPointDelivery : Deliver
    {
        
        private float Weight;
        private int basecost = 400;

        public override int BaseCost
        {
            get { return basecost; }
        }
        public PickPointDelivery(float weight, string address, string recipient) : base(address, recipient)
        {
            Weight = weight;
        }
        public override float CalculateCost()
        {
            return 1000 + Weight * BaseCost;
        }
        public override float GetDeliveryTime()
        {
                return 7;
        }
    }
    class ExpressDelivery : Deliver
    {
        private float Distance;
        private float Weight;
        private int basecost = 400;

        public override int BaseCost
        {
            get { return basecost; }
        }
        public ExpressDelivery(float distance, float weight, string address, string recipient) : base(address, recipient)
        {
            Distance = distance;
            Weight = weight;
        }
        public override float CalculateCost()
        {
            return Distance * Weight * BaseCost;
        }
        public override float GetDeliveryTime()
        {
            if (Distance < 300)
            {
                return 1;
            }
            else
            {
                return Convert.ToSingle(Math.Floor(Distance / 300));
            }
        }
    }



}
