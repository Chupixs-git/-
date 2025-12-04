using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static ConsoleApp3.Casino;

namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("КАЛЬКУЛЯТОР");
            Console.WriteLine("Программа корректно обрабатывает ошибки ввода и вычислений\n");

            bool continueCalculation = true;

            while (continueCalculation)
            {
                try
                {
                    PerformCalculation();
                }
                catch (Exception ex)
                {
                   
                    Console.WriteLine($"\nПроизошла непредвиденная ошибка: {ex.Message}");
                    Console.WriteLine("Программа продолжает работу\n");
                }

                continueCalculation = AskToContinue();
            }

            Console.WriteLine("\nКонец калькулятора!");
        }

        static void PerformCalculation()
        {
            double num1 = GetNumberFromUser("Введите первое число: ");
            char operation = GetOperationFromUser();
            double num2 = GetNumberFromUser("Введите второе число: ");

            double result = Calculate(num1, num2, operation);

            if (!double.IsNaN(result))
            {
                Console.WriteLine($"\nОтвет: {num1} {operation} {num2} = {result}");
            }
        }

        static double GetNumberFromUser(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Ошибка: Ввод не может быть пустым. Пожалуйста, введите число.");
                    continue;
                }

                
                if (double.TryParse(input.Replace('.', ','), out double number))
                {
                    return number;
                }
                else
                {
                    Console.WriteLine(" Ошибка: Введено недопустимое число. Пожалуйста, попробуйте снова.");
                }
            }
        }

        static char GetOperationFromUser()
        {
            string[] validOperations = { "+", "-", "*", "/", "%", "^" };

            while (true)
            {
                Console.Write("Введите операцию (+, -, *, /, %, ^): ");
                string input = Console.ReadLine();

                
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Ошибка: Операция не может быть пустой.");
                    continue;
                }

                char operation = input[0];

               
                foreach (string validOp in validOperations)
                {
                    if (validOp[0] == operation)
                    {
                        return operation;
                    }
                }

                Console.WriteLine($"Ошибка: Операция '{operation}' не доступна. Допустимые операции: +, -, *, /, %, ^");
            }
        }

        static double Calculate(double num1, double num2, char operation)
        {
            try
            {
                switch (operation)
                {
                    case '+':
                        return num1 + num2;

                    case '-':
                        return num1 - num2;
                        

                    case '*':
                        return num1 * num2;

                    case '/':
                        
                        if (Math.Abs(num2) < double.Epsilon)
                        {
                            Console.WriteLine("Ошибка: Деление на ноль невозможно!");
                            return double.NaN;
                        }
                        return num1 / num2;

                    case '%':
                        
                        if (Math.Abs(num2) < double.Epsilon)
                        {
                            Console.WriteLine("Ошибка: Операция остатка от деления на ноль невозможна!");
                            return double.NaN;
                        }
                        return num1 % num2;

                    case '^':
                        
                        try
                        {
                            return Math.Pow(num1, num2);
                        }
                        catch (ArithmeticException)
                        {
                            Console.WriteLine("Ошибка: Невозможно вычислить степень с такими аргументами!");
                            return double.NaN;
                        }

                    default:
                        
                        Console.WriteLine($"Ошибка: Неподдерживаемая операция '{operation}'");
                        return double.NaN;
                }
            }
            catch (OverflowException)
            {
                Console.WriteLine("Ошибка: Результат вычисления слишком велик или слишком мал!");
                return double.NaN;
            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"Ошибка при вычислении: {ex.Message}");
                return double.NaN;
            }
        }

        static bool AskToContinue()
        {
            while (true)
            {
                Console.Write("\nХотите выполнить еще одно вычисление? (да/нет): ");
                string input = Console.ReadLine()?.ToLower();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine(" Пожалуйста, введите 'да' или 'нет'");
                    continue;
                }

                if (input == "да" || input == "д" || input == "yes" || input == "y")
                {
                    Console.WriteLine("\n" + new string('-', 40) + "\n");
                    return true;
                }
                else if (input == "нет" || input == "н" || input == "no" || input == "n")
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("Неизвестный ответ. Пожалуйста, введите 'да' или 'нет'");
                }
            }
        }

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

        //try
        //{
        //    Console.WriteLine("-------Калькулятор-------");
        //    Console.WriteLine("Введите что хотите сделать :");
        //    Console.WriteLine("1.+,2.-,3.*,4./");

        //    int answer = char.Parse(Console.ReadLine());
        //    if(answer > 8)
        //    {
        //        Console.WriteLine("Неправеный выбор");
        //        return;
        //    }
        //    else
        //    {
        //        int number3;

        //        Console.WriteLine("Введите чисто :");
        //        int number = int.Parse(Console.ReadLine());
        //        Console.WriteLine("Введите чисто :");
        //        int number2 = int.Parse(Console.ReadLine());



        //        switch (answer)
        //        {
        //            case 1:

        //                number3 = number + number2;
        //                Console.WriteLine($"{number} + {number2} = {number3}");
        //                break;
        //            case 2:
        //                number3 = number - number2;
        //                Console.WriteLine($"{number} - {number2} = {number3}");
        //                break;
        //            case 3:
        //                number3 = number * number2;
        //                Console.WriteLine($"{number} * {number2} = {number3}");
        //                break;
        //            case 4:
        //                number3 = number / number2;
        //                Console.WriteLine($"{number} / {number2} = {number3}");
        //                break;


        //            default:
        //                Console.WriteLine("Неверный выбор");
        //                break;

        //        }
        //    }



        //}
        //catch(DivideByZeroException)
        //{   


        //}
        //catch(Exception ex) 
        //{
        //    Console.WriteLine("Возникла ошибка");
        //    Console.WriteLine(ex.Message);
        //    Console.WriteLine(ex.InnerException);
        //    Console.WriteLine(ex.StackTrace);
        //    Console.WriteLine(ex.TargetSite);
        //}
        //finally// блок выпоняется не зависимо от ошибок
        //{

        //}
        //HomeDelivery delivery1 = new HomeDelivery(1000, 3, "New Yourk ,Volkin Strit", "Serpan",
        //new DateTime(1999,12,10));
        //delivery1.ShowInfo();
        //ExpressDelivery delivery2 = new ExpressDelivery(1000, 3, "New Yourk ,Volkin Strit", "Serpan",
        //new DateTime(1999,12,10));
        //delivery2.ShowInfo();
        //PickPointDelivery delivery3 = new PickPointDelivery(1000, "New Yourk ,Volkin Strit", "Serpan",
        //new DateTime(1999, 12, 10));
        //delivery3.ShowInfo();





    }

    }

