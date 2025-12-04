using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class Car2
    {
        private bool _is_running_engine = false;
        public bool IsRunningEngine
        {
            get
            {   if (_is_running_engine)
                {
                    Console.WriteLine("Двигатель Заведен");
                    
                }
                else
                {
                    Console.WriteLine("Двигатель Не Заведен");
                   
                }
                return _is_running_engine;
            }
            set
            {
                if(_is_running_engine && value) 
                {
                    Console.WriteLine("Двигатель уже Запушен");
                }
                else if(_is_running_engine && value)
                {
                    Console.WriteLine("Двигатель и так уже запущен");
                }
                _is_running_engine = value;
            } 
        }
        public double FuelLevel { get; private set; }

        public void MakeTrip(double km)
        {
            double neededFuel = km * 0.1;
            if(neededFuel < FuelLevel)
            {
                Console.WriteLine("Топлива не хватает");
                return;
            }
            FuelLevel -= neededFuel;
            Console.WriteLine("Поездка совершена");

        }
        public void ShowStatus()
        {
            string is_running;
            if(_is_running_engine)
            {
                is_running = "Запушен";
            }
            else
            {
                is_running = "Не запушен";
            }
            is_running = _is_running_engine ? "Запущен" : "Не запушен";
            Console.WriteLine($"Двигатель {is_running}. \n Топливо осталось {FuelLevel:f2}");

            
        }
    }
}
