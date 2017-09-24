using System;

namespace PowerConsumptionCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            // організація циклу для читання та опрацювання натисненої клавіші
            bool programTerminated = false;
            while (!programTerminated)
            {
                Console.Clear();
                Console.WriteLine("Виберіть пункт меню: ");
                Console.WriteLine("F1 - Допомога");
                Console.WriteLine("F2 - Розрахунок довжини кола");
                Console.WriteLine("Esc - завершення роботи програми");
                ConsoleKeyInfo key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.F1:
                        // Todo - доповнити інструкцію
                        Console.WriteLine("\nТут буде детальніша інформація...\n");
                        break;
                    case ConsoleKey.F2:
                        Console.WriteLine("\nЗадайте радіус кола: ");
                        string radiusStr = Console.ReadLine();
                        double radius = Convert.ToDouble(radiusStr);
                        double constantaPi = 3.14;
                        double length = 2 * constantaPi * radius;
                        Console.WriteLine("Довжина кола: {0}\n", length);                        
                        break;
                    case ConsoleKey.Escape:
                        programTerminated = true;
                        break;
                    default:
                        Console.WriteLine("\nНевідома операція\n");
                        break;
                }
                // Затримка перед наступним сеансом роботи
                Console.WriteLine("Натисніть довільну клавішу");
                Console.ReadKey();
            }
        }
    }
}
