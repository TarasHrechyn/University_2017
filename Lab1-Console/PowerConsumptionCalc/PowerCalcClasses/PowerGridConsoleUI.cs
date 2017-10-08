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
        private PowerGridData gridData { get; set; }

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
            Console.Clear();
            Console.WriteLine("Розрахунок навантаження");
            Console.WriteLine("F2 - Запис на диск");
            Console.WriteLine("F5 - Ввід даних про нового споживача");
            Console.WriteLine("F6 - Ввід даних про компенсування РП");
            Console.WriteLine("F8 - Добавити компенсування РП");
            Console.WriteLine("F9 - Роздрук переліку та сумарного навантаження");
            Console.WriteLine("Esc - Завершення роботи програми");
            Console.WriteLine();
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
                case ConsoleKey.F8:
                    CalcCapacitorBanks();
                    break;
                case ConsoleKey.F9:
                    PrintCompleteList();
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
            // ввід даних у локальні змінні
            Console.Write("Код Споживача: ");
            string code = Console.ReadLine();
            Console.Write("Назва споживача: ");
            string customer = Console.ReadLine();
            Console.Write("P, кВт: ");
            double P = Convert.ToDouble(Console.ReadLine());
            Console.Write("Q, кВАр: ");
            double Q = Convert.ToDouble(Console.ReadLine());
            // створення примірника
            RegularLoad load = new RegularLoad(code, customer, P, Q);
            return load;
        }
        // процедура введення даних про наявну КБ
        public LoadItem InputCapacitorBank()
        {
            // ввід даних
            Console.Write("Код КБ: ");
            string code = Console.ReadLine();
            Console.Write("Тип КБ: ");
            string type = Console.ReadLine();
            Console.Write("Q, кВАр: ");
            double Q = Convert.ToDouble(Console.ReadLine());
            // створення примірника
            CapacitorBank bank = new CapacitorBank(code, type, Q);
            return bank;
        }

        // обчислення доцільності компенсування РП
        private void CalcCapacitorBanks()
        {
            Power powerSum = gridData.PowerSum;
            if (powerSum.Q > 0)
            {
                int index = gridData.loadItems.Count + 1;
                double bankQ = Math.Round(powerSum.Q / 100) * 100;

                CapacitorBank bank = new CapacitorBank("БК" + index.ToString(), "unknown type", bankQ);
                gridData.loadItems.Add(bank);
                PrintCompleteList();
            }
            else
            {
                Console.WriteLine("Немає потреби у компенсуванні РП");
            }
        }

        // роздруку списку
        public void PrintCompleteList()
        {
            Console.WriteLine("Підстанція");
            Console.WriteLine("---------------------------------------");
            foreach (LoadItem load in gridData.loadItems)
            {
                Console.WriteLine(load.ToString());
            }
            Console.WriteLine("---------------------------------------");
            Power powerSum = gridData.PowerSum;
            Console.WriteLine("Сумарне навантаження: P={0}, Q={1}", powerSum.P, powerSum.Q);
        }
    }
}
