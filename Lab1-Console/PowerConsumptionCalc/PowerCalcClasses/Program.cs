using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerCalcClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            // створення примірника моделі даних системи
            PowerGridData gridData = new PowerGridData();

            // створення примірника візуального інтерфкйсу
            PowerGridConsoleUI gridUI = new PowerGridConsoleUI(gridData);

            // старт візуального інтерфейсу користувача
            gridUI.ExecuteMainLoop();
        }
    }
}

