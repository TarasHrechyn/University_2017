using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerConsumptionCalc
{
    class OperatorsDemo
    {
        // Опис перелічуваного типу
        enum MeasureUnits { Deg, Rad, Custom};
        
        // Використання перелічуваного типу
        const MeasureUnits defaultMeasureUnits = MeasureUnits.Deg;
       
        // Опис константи символьного типу
        const char degChar = '°';
        
        static string VarsAndConstsDemo(int sectorAngleDeg)
        {
            // sectorAngle - змінна передана як параметр виклику функції

            // Опис константної величини
            const double Pi = 3.14;

            // змінна результату, тип якої визначено на підставі початкового присваєння
            var res  = 0.0;

            // змінна, прочитана з консолі 
            string radiusStr = Console.ReadLine();
            
            // змінна що буде використовуватись надалі повинна бути перетворена до дійсного типу
            double radius = Convert.ToDouble(radiusStr);

            // перевірка правильності змінної
            bool radiusValid = radius > 0.0;

            // обчислення результату. Константи 2 та 360 використана у виразі безпосередньо
            res = radiusValid ? (2 * Pi * radius * sectorAngleDeg / 360) : (0.0);

            // повернення результату з автоматичним перетворенням дійсного числа у стрічку
            return res.ToString();
        }

        static void ConsoleDemoReadWrite()
        {
            // відображення статичного тексту
            Console.WriteLine("Розрахунок властивостей кола:");

            // змінна прочитана з консолі повертається у стрічковому виді
            string radiusStr = Console.ReadLine();

            // перетворення стрічки до дійсної величини
            double radius = Convert.ToDouble(radiusStr);

            // проведення розрахуноку та занесення результату у тимчасову змінну
            double length = 2 * 3.14 * radius;

            // відображення статичного тексту, змінної та результату виразу
            Console.WriteLine("Для кола радіусом {0}, його довжина становитеме {1} та площа {2}", 
                radius, length, radius * radius * 3.14);
        }

        static void ConsoleDemoReadKey()
        {
            // відображення статичного тексту
            Console.WriteLine("Натисніть клавішу F1");

            // читання коду натисненої клавіші
            ConsoleKeyInfo key = Console.ReadKey();

            // опрацювання коду натисненої клавіші
            if (key.Key == ConsoleKey.F1)
            {
                Console.WriteLine("тут буде опрацювання клавіші F1");
            } else
            {
                Console.WriteLine("натиснено іншу клавішу");
            }

            // очікування поки користувач ознайомиться з результатом
            Console.ReadKey();
        }

        // знаходимо значення факторіал якого більший 100
        static int LoopDemoWhile()
        {
            int n = 1;
            int factorial = 1;
            while (factorial <= 100)
            {
                factorial *= n;
                n++;
            }
            return n;
        }

        static int LoopDemoDo()
        {
            int n = 1;
            int factorial = 1;
            do
            {
                factorial *= n;
                n++;
            } while (factorial <= 100);
            return n;
        }

        static int LoopDemoFor()
        {
            int factorial = 1;
            int res = 0;
            for (int i = 1; factorial <= 100; i++)
            {
                factorial *= i;
                res = i;
            }
            return res;
        }

        static int LoopDemoForEach()
        {
            int res = 1;
            int[] numbers = new int[] { 1, 2, 6, 24, 120, 720 };
            foreach (int element in numbers)
            {
                res++;
                if (element > 100)
                {
                    break;
                }
            }
            return res;
        }

        static int SelectinDemoIfElse(int number)
        {
            int res;
            if (number == 1)
            {
                res = 1000;
            }
            else
            {
                if (number == 0)
                {
                    res = 800;
                }
                else
                {
                    res = 5;
                }
            }
            return res;
        }

        static int SelectinDemoSwitch(int number)
        {
            int res;
            switch (number)
            {
                case 1:
                    res = 1000;
                    break;
                case 0:
                    res = 800;
                    break;
                default:
                    res = 5;
                    break;
            }
            return res;
        }

        // оголошення константи
        const int constDemo = 9;

        void ProcB()
        {
            // оголошення змінної всередині методу
            int simpleVar = 5 + constDemo;
            // оголошення змінної та створення масиву
            int[] intArray = new int[] {1, 4, -29, simpleVar, 0xFF };
            // оголошення стрічкової змінної
            string testStr = "string demo";
        }

        void ProcA()
        {
            int a1 = 0;
            ProcB();
            int A2 = 0;
        }

        int Main()
        {
            int m = 0;
            ProcA();
            return m + 1;
        }

        void PowerDemo()
        {
            // опис змінної потужності p1
            Power p1 = new Power(900, 500);
            // опис змінної потужності p2
            Power p2 = new Power(100, 200);
            // опис змінної та розрахунок суми потужностей
            Power pSum = p1 + p2;
        }
    }

    

}
