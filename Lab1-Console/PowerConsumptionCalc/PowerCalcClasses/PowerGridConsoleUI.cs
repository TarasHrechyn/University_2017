using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerCalcClasses
{
    class PowerGridConsoleUI
    {
        // посилання на редаговану модель
        private PowerGridData gridData;

        // конструктор для створення примірника візуального інтерфейсу
        public PowerGridConsoleUI(PowerGridData refGridData)
        {
            gridData = refGridData;
        }

        // головний цикл роботи читання клавіш та їх опрацювання 
        public void ExecuteMainLoop()
        {
            bool done;
            do
            {
                // роздрук підказки меню
                PrintHelp();
                // читання коду натисненої клавіші
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                // виклик обробника коду команди
                done = HandleKey(keyInfo.Key);
                if (!done)
                {
                    Console.ReadKey();
                }
            } while (!done);
        }

        // вивід на ектан тексту підказки головного меню
        private void PrintHelp()
        {
            Console.WriteLine("Розрахунок навантаження");
            Console.WriteLine("F2 - Запис на диск");
            Console.WriteLine("F5 - Ввід даних про нового споживача");
            Console.WriteLine("F6 - Ввід даних про компенсування");
            Console.WriteLine("F9 - Розрахунок сумарного навантаження");
            Console.WriteLine("Esc - Завершення роботи програми");
        }

        // функція опрацювання команд. повертає True у випадку натиснення клавіші Esc
        private bool HandleKey(ConsoleKey key)
        {
            bool res = false;
            switch (key)
            {
                case ConsoleKey.F2:
                    gridData.Save();
                    break;
                case ConsoleKey.Escape:
                    res = true;
                    break;
                default:
                    break; 
            }
            return res;
        }
    }
}
