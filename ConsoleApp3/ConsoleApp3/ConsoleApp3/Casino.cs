using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static ConsoleApp3.Casino;

namespace ConsoleApp3
{
    internal class Casino
    {
        

        public int TotalSpin { get; private set; }
        public int WinSpins { get; private set; }
        public int LoseSpins { get; private set; }
        public decimal TotalMoneyWin { get; private set; }
        public decimal TotalMoneyLose { get; private set; }
        public decimal MaxWin { get; private set; }

        public void RecordSpin() => TotalSpin++;
        public void RecordWinSpins(decimal amount)
        {
            WinSpins++;
            TotalMoneyWin += amount;
            if (MaxWin < amount) MaxWin = amount;
        }
        public void RecordLoseSpins(decimal amount)
        {
            LoseSpins++;
            TotalMoneyLose += amount;
        }

        public void Print()
        {
            Console.WriteLine("Общая статистика за сессию: \n");
            Console.WriteLine($"Всего раундов сыграно: {TotalSpin}");
            Console.WriteLine($"Побед: {WinSpins}");
            Console.WriteLine($"Поражений: {LoseSpins}");
            Console.WriteLine($"Всего выиграно: {TotalMoneyWin} руб");
            Console.WriteLine($"Всего проиграно: {TotalMoneyLose} руб");
            Console.WriteLine($"Максимальный выигрыш за один раунд: {MaxWin} руб");
        }

        public class SlotSymbol
        {
            public string Icon { get; }
            public int PayoutMultiplier { get; }
            public int Weight { get; }

            public SlotSymbol(string icon, int p_mult, int weight)
            {
                Icon = icon;
                PayoutMultiplier = p_mult;
                Weight = weight;
            }
        }

        public class SlotReel
        {
            private readonly List<SlotSymbol> _symbols;
            private readonly Random _random;

            public SlotReel(List<SlotSymbol> symbols, Random random)
            {
                _symbols = symbols;
                _random = random;
            }
            public SlotSymbol Spin()
            {
                int totalWeight = _symbols.Sum(s => s.Weight);
                int weight = _random.Next(0, totalWeight);
                int sum = 0;
                foreach (SlotSymbol s in _symbols)
                {
                    sum += s.Weight;
                    if (sum > weight) return s;
                }
                return _symbols.Last();
            }
        }

        public class SlotMachine
        {
            private readonly List<SlotReel> _reels;
            private readonly Random _random;
            public SlotMachine(Random random)
            {
                _random = random;
                var symbols = new List<SlotSymbol>()
                {
                    new SlotSymbol("1", 1, 40),
                    new SlotSymbol("2", 2, 35),
                    new SlotSymbol("3", 3, 25),
                    new SlotSymbol("4", 4, 15),
                    new SlotSymbol("5", 5, 8),
                    new SlotSymbol("6", 7, 4),
                    new SlotSymbol("7", 9, 2)
                };

                _reels = new List<SlotReel>()
                {
                    new SlotReel(symbols, _random),
                    new SlotReel(symbols, _random),
                    new SlotReel(symbols, _random),
                };
            }

            public List<SlotSymbol> SpinReel()
            {
                return _reels.Select(r => r.Spin()).ToList();
            }

            public int CalculatePayout(List<SlotSymbol> result, int bet)
            {
                
                if (result.Select(s => s.Icon).Distinct().Count() == 1)
                {
                    return bet * result[0].PayoutMultiplier * 5;
                }
               
                var pairs = result.GroupBy(s => s.Icon).Where(g => g.Count() == 2).ToList();
                if (pairs.Count > 0)
                {
                    
                    var symbol = pairs[0].Key;
                    var symbolData = result.First(s => s.Icon == symbol);
                    return bet * symbolData.PayoutMultiplier * 2;
                }
                
                return 0;
            }
        }

        public class CasinoGame
        {
            private int _balance;
            private SlotMachine _machine ;
            private Casino _stats;
            private Random _random;

            public CasinoGame(int balance, Casino stats)
            {
                _balance = balance;
                _stats = stats;
                _random = new Random();
                _machine = new SlotMachine(_random);
            }

            public void Run()
            {
                Console.Clear();
                Console.WriteLine("Игра началась");
                while (_balance > 0)
                {
                    Console.WriteLine($"Баланс: {_balance}");
                    Console.Write("Введите ставку (0 - выйти, -1 - статистика): ");
                    if (!int.TryParse(Console.ReadLine(), out int bet))
                    {
                        Console.WriteLine("Некорректный ввод, попробуйте еще раз");
                        continue;
                    }

                    if (bet == 0)
                    {
                        Console.WriteLine("Выход из игры...");
                        break;
                    }

                    if (bet == -1)
                    {
                        _stats.Print();
                        continue;
                    }

                    if (bet < 0 || bet > _balance)
                    {
                        Console.WriteLine("Некорректная ставка");
                        continue;
                    }

                    _balance -= bet;
                    _stats.RecordSpin();

                    Console.WriteLine("Вращайте барабан...");
                    Thread.Sleep(800);

                    var result = _machine.SpinReel();
                    Console.WriteLine($"Результат вращения: {result[0].Icon} | {result[1].Icon} | {result[2].Icon}");

                    int payout = _machine.CalculatePayout(result, bet);
                    if (payout > 0)
                    {
                        Console.WriteLine($"Вы выиграли {payout} руб");
                        _balance += payout;
                       
                        _stats.RecordWinSpins(payout);
                    }
                    else
                    {
                        Console.WriteLine($"Вы проиграли {bet} руб");
                        _stats.RecordLoseSpins(bet);
                    }

                    Console.WriteLine();
                }

                Console.WriteLine("Игра завершена!");
                _stats.Print();
            }
        }

        
        
    }
    //internal class Casino
    //{
    //    private Casino _stats;
    //    public int TotalSpin { get; private set; }
    //    public int WinSpins { get; private set; }
    //    public int LoseSpins { get; private set; }
    //    public decimal TotalMoneyWin { get; private set; }
    //    public decimal TotalMoneyLose { get; private set; }
    //    public decimal MaxWin { get; private set; }

    //    public void RecordSpin() => TotalSpin++;
    //    public void RecordWinSpins(int amount)
    //    {
    //        WinSpins++;
    //        TotalMoneyWin += amount;
    //        if (MaxWin < amount) MaxWin = amount;
    //    }
    //    public void RecordLoseSpins(int amount)
    //    {
    //        LoseSpins++;
    //        TotalMoneyLose += amount;

    //    }




    //    public void Print()
    //    {
    //        Console.WriteLine("Общая статистика за сессию: \n");
    //        Console.WriteLine($"Всего раундов Сыграно: {TotalSpin}");
    //        Console.WriteLine($"Побед: {WinSpins}");
    //        Console.WriteLine($"Поражений: {LoseSpins}");
    //        Console.WriteLine($"Всего Выйграно: {TotalMoneyWin}");
    //        Console.WriteLine($"Всего проиграно: {TotalMoneyLose}");
    //        Console.WriteLine($"МАX Выйгрыш: {MaxWin}");

    //    }
    //    public class SlotSymbol
    //    {
    //        public string Icon { get; }
    //        public int PayoutMultiplier { get; }
    //        public int Weight { get; }

    //        public SlotSymbol(string icon, int p_mult, int weight)
    //        {
    //            Icon = icon;
    //            PayoutMultiplier = p_mult;
    //            Weight = weight;
    //        }
    //    }
    //    public class SlotReel
    //    {
    //        private readonly List<SlotSymbol> _symbols;
    //        private readonly Random _random;

    //        public SlotReel(List<SlotSymbol> symbols, Random random)
    //        {
    //            _symbols = symbols;
    //            _random = random;
    //        }
    //        public SlotSymbol Spin()
    //        {
    //            int totalWeigt = _symbols.Sum(s => s.Weight);
    //            int weight = _random.Next(0, totalWeigt);
    //            int sum = 0;
    //            foreach (SlotSymbol s in _symbols)
    //            {
    //                sum += s.Weight;
    //                if (sum > weight) return s;
    //            }
    //            return _symbols.Last();
    //        }
    //    }
    //    public class SlotMachine
    //    {
    //        private readonly List<SlotReel> _reels;
    //        private readonly Random _random;

    //        public SlotMachine()
    //        {
    //            var _symbol = new List<SlotSymbol>()
    //            {
    //                    new SlotSymbol("1", 1, 40),
    //                    new SlotSymbol("2", 2, 35),
    //                    new SlotSymbol("3", 33, 25),
    //                    new SlotSymbol("4", 44, 15),
    //                    new SlotSymbol("5", 55, 8),
    //                    new SlotSymbol("6", 777, 4),
    //                    new SlotSymbol("7", 999, 2),

    //            };
    //            _reels = new List<SlotReel>()
    //            {
    //                new SlotReel(_symbol, _random),
    //                new SlotReel(_symbol, _random),
    //                new SlotReel(_symbol, _random),


    //            };

    //        }

    //        public List<SlotSymbol> SpinReel()
    //        {
    //            return _reels.Select(r => r.Spin()).ToList();

    //        }
    //        public int CalculatePayout(List<SlotSymbol> result, int bet)
    //        {
    //            if (result.Select(s => s.Icon).Distinct().Count() == 1)
    //            {
    //                return bet * result[0].PayoutMultiplier * 5;

    //            }
    //            var pair = result.GroupBy(s => s.Icon).FirstOrDefault(g => g.Count() == 2);
    //            if (pair != null)
    //            {
    //                return bet * result[0].PayoutMultiplier * 2;
    //            }
    //            return 0;
    //        }
    //    }
    //    public class CasinoGame
    //    {
    //        private int _balance;
    //        private SlotMachine _machine;
    //        private Casino _stats;

    //        public CasinoGame(int balance)
    //        {
    //            _balance = balance;

    //        }
    //        public void Run()
    //        {
    //            Console.Clear();
    //            Console.WriteLine("Игра началась");

    //            while (_balance > 0)
    //            {
    //                Console.WriteLine($"Баланс: {_balance}");
    //                Console.Write("Введите ставку (0 - выход, -1 - статистика): ");
    //                if (!int.TryParse(Console.ReadLine(), out int bet))
    //                {
    //                    Console.WriteLine();
    //                    continue;

    //                }
    //                if (bet == 0) break;
    //                if (bet == 1)
    //                {
    //                    _stats.Print();
    //                    continue;
    //                }
    //                if (bet < 0 || bet > _balance)
    //                {
    //                    Console.WriteLine("Некорректная ставка");
    //                    continue;
    //                }

    //                _balance -= bet;
    //                _stats.RecordSpin();
    //                _stats.RecordLoseSpins(bet);

    //                Console.WriteLine("Вращайте барабан цифра : ");
    //                Thread.Sleep(800);

    //                var result = _machine.SpinReel();
    //                Console.WriteLine("Результат вращения :");
    //                Console.WriteLine($"{result[0].Icon} | {result[1].Icon} | {result[2].Icon}");

    //                int payout = _machine.CalculatePayout(result, bet);
    //                if (payout > 0)
    //                {
    //                    Console.WriteLine($"Вы выйграли {payout} руб");
    //                    _balance += payout;

    //                    _stats.RecordWinSpins(payout);
    //                }
    //                else
    //                {
    //                    Console.WriteLine($"Вы Проиграли {payout} руб");
    //                    _balance -= payout;
    //                    _stats.RecordLoseSpins(payout);
    //                }

    //            }
    //        }
    //    }
    //}
}
