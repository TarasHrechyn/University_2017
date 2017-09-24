using System;

namespace PowerConsumptionCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            // організація циклу для читання та опрацювання коду натисненої клавіші
            Console.Title = "Console Demo App";
            bool programTerminated = false;
            while (!programTerminated)
            {
                Console.Clear();
                Console.WriteLine("Виберiть пункт меню: ");
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
                        Console.Write("\nЗадайте радiус кола: ");
                        string radiusStr = Console.ReadLine();
                        double radius = Convert.ToDouble(radiusStr);
                        double constantaPi = 3.14;
                        double length = 2 * constantaPi * radius;
                        Console.WriteLine("\nДовжина кола: {0}\n", length);                        
                        break;
                    case ConsoleKey.Escape:
                        programTerminated = true;                        
                        continue;
                    default:
                        Console.WriteLine("\nНевідома операція\n");
                        break;
                }
                // Затримка перед наступним сеансом роботи
                Console.WriteLine("Натиснiть довiльну клавiшу");
                Console.ReadKey();
            }
        }
    }
}
