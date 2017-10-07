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

        // головний цикл роботи читання коду клавіші та її опрацювання 
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
            Console.WriteLine("F6 - Ввід даних про компенсування реактивної потужності");
            Console.WriteLine("F9 - Розрахунок переліку та сумарного навантаження");
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
                case ConsoleKey.F5:
                    LoadItem load = InputRegularLoad();
                    gridData.loadItems.Add(load);
                    break;
                case ConsoleKey.F6:
                    LoadItem bank = InputCapacitorBank(); 
                    gridData.loadItems.Add(bank);
                    break;
                case ConsoleKey.F9:
                    Print();
                    break;
                case ConsoleKey.Escape:
                    res = true;
                    break;
                default:
                    break; 
            }
            return res;
        }
        // процедура введення даних про споживача
        public LoadItem InputRegularLoad()
        {
            // створення примірника
            RegularLoad load = new RegularLoad();
            // ввід даних
            Console.WriteLine("Код Спожтвача: ");
            load.name = Console.ReadLine();
            Console.WriteLine("P, кВт: ");
            load.power.P = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Q, кВАР: ");
            load.power.Q = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Назва споживача: ");
            load.customer = Console.ReadLine();
            return load;
        }
        // процедура введення даних про КБ
        public LoadItem InputCapacitorBank()
        {
            // створення примірника
            CapacitorBank bank = new CapacitorBank();
            // ввід даних
            Console.WriteLine("Код КБ: ");
            bank.name = Console.ReadLine();
            Console.WriteLine("Q, кВАР: ");
            bank.power.Q = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Тип КБ: ");
            bank.type = Console.ReadLine();
            return bank;
        }

        // роздруку списку
        public void Print()
        {
            Console.WriteLine("Підстанція");
            Console.WriteLine("---------------------------------------");
            foreach (LoadItem load in gridData.loadItems)
            {
                Console.WriteLine(load.DisplayName());
            }
            Console.WriteLine("---------------------------------------");
            Power powerSum = gridData.PowerSum;
            Console.WriteLine("Сумарне навантаження: P={0}, Q={1}", powerSum.P, powerSum.Q);
        }
    }
}
