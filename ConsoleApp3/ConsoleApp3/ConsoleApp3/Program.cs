using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConsoleApp3.Casino;

namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //var stats = new Casino();
            //int startBalance = 10000000;
            //var game = new CasinoGame(startBalance, stats);
            //game.Run();

            //Character character = new Character("Персонаж", 80);
            //Warrior warrior = new Warrior("Андрей", 100, 30);
            //Warrior warrior2 = new Warrior("Андрей", 100, 30);

            //Mage mage = new Mage("geter", 80, 3200);
            //Mage mage1 = new Mage("geter2", 80, 3200);

            //character.Attack();
            //character.DisplayInfo();

            //warrior.Attack();
            //warrior.DisplayInfo();

            //Console.WriteLine();

            //mage.Attack();
            //mage.DisplayInfo();

            //PhysicalProduct physicalProduct = new PhysicalProduct(1, "Книга", 15.99m, 0.5);
            //DigitalProduct digitalProduct = new DigitalProduct(2, "E-Book", 9.99m, 2.5);




            //Console.WriteLine("Физический товар:");
            //physicalProduct.DisplayProductInfo();

            //Console.WriteLine("\nЦифровой товар:");
            //digitalProduct.DisplayProductInfo();


            //EmailNotification email = new EmailNotification("Hello, world!", "sender@example.com");
            //email.Send();


            //SMSNotification sms = new SMSNotification("Твой код 1234", "+1234567890");
            //sms.Send();


            //Console.WriteLine(email.FormatMessage());
            //Console.WriteLine(sms.FormatMessage());

            //ElectricCar teslaModelS = new ElectricCar("Tesla Model S", 250, 4, 100);
            //  Console.WriteLine($"Модель: {teslaModelS.Model}");
            //  Console.WriteLine($"Максимальная скорость: {teslaModelS.MaxSpeed} км/ч");
            //  Console.WriteLine($"Количество дверей: {teslaModelS.NumberOfDoors}");
            //  Console.WriteLine($"Емкость батареи: {teslaModelS.BatteryCapacity} кВт·ч");
            //  teslaModelS.Charge();

            //BankAccount account = new BankAccount((decimal)137.73d);


            //Console.WriteLine(account.Number);
            //Console.WriteLine(account.Balance);

            //Console.WriteLine(account.TopUp(500m));
            //Console.WriteLine(account.Balance);
            //Console.WriteLine(account.TopDown(500m));
            //Console.WriteLine(account.Balance);

            //Rectangle rect1 = new Rectangle(10, 20);
            //Rectangle rect2 = new Rectangle(10, 20);
            //Rectangle rect3 = new Rectangle(10, 20);

            //Triangle triang1 = new Triangle(a: 2, h: 5);
            //Triangle triang2 = new Triangle(a: 5, h : 1);
            //Triangle triang3 = new Triangle(a: 6, h: 2);

            //List<Shape> shapes = new List<Shape>() {rect1,rect2,rect3,triang1,triang2,triang3 };

            //foreach (var item in shapes)
            //{


            //}

            //Document document1 = new PDFDocument();
            //Document document2 = new ExcelDocument();
            //Document document3 = new WordDocument();

            //document1.Print();
            //document2.Print();
            //document3.Print();
            //Go runner1 = new Go("Алина", 17);
            //Go runner2 = new Go("Игорь", 15);
            //runner1.Register(); 
            //runner2.Register(); 


            //GoWater swimmer1 = new GoWater("Катя", 20, true);
            //GoWater swimmer2 = new GoWater("Михаил", 19, false);
            //swimmer1.Register(); 
            //swimmer2.Register(); 


            //VoleyBoll team = new VoleyBoll(true);
            //team.AddMember(new Sport("Паша", 25));
            //team.AddMember(new Sport("Оля", 24));
            //team.Register(); 


            //VoleyBoll incompleteTeam = new VoleyBoll(false);
            //incompleteTeam.AddMember(new Sport("Коля", 22));
            //incompleteTeam.Register(); 

            //Abstract[] shapes = new Abstract[5] {
            //    new Treygol(12,8,2),
            //    new Rectengel(12, 8),
            //    new Treygol(12,8,2),
            //    new Circle(12),
            //    new Treygol(12,2,9)


            //};
            //foreach (var item in shapes)
            //{
            //    item.PrintInfo();
            //}

            HomeDelivery delivery1 = new HomeDelivery(1000, 3, "New Yourk ,Volkin Strit", "Serpan",
            new DateTime(1999,12,10));
            delivery1.ShowInfo();
            ExpressDelivery delivery2 = new ExpressDelivery(1000, 3, "New Yourk ,Volkin Strit", "Serpan",
            new DateTime(1999,12,10));
            delivery2.ShowInfo();
            PickPointDelivery delivery3 = new PickPointDelivery(1000, "New Yourk ,Volkin Strit", "Serpan",
            new DateTime(1999, 12, 10));
            delivery3.ShowInfo();





        }

    }
}
