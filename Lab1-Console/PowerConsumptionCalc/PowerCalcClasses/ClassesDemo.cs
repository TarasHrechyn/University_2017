using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerCalcClasses
{
    class ClassesDemo
    {

        void PowerDemo()
        {
            // опис змінної потужності p1
            Power p1 = new Power(900, 500);
            // опис змінної потужності p2
            Power p2 = new Power(100, 200);
            // опис змінної та розрахунок суми потужностей
            Power pSum = p1 + p2;
        }

        void LoadClassDemo()
        {
            // опис змінної та створення примірника навантаження
            LoadItem loadInfo1 = new LoadItem();
            // опис змінної та ініціалізація структури потужності
            Power powerInfo = new Power(5000.0, 1000.0);
            // копіювання структури
            loadInfo1.power = powerInfo;
            // копіювання вказівника
            LoadItem loadInfo2 = loadInfo1;
            // після втрати останнього посиланя примірник loadInfo1 буде звільнено з пам'яті
        }

        void LoadClassMethodsDemo()
        {
            LoadItem loadInfo = new LoadItem();

            // дані не вказані
            if (loadInfo.IsEmpty())
            {
                // внести дані потужності
            }

            // очистити дані потужності якщо вони вказані
            if (loadInfo.IsDefined())
            {
                loadInfo.Clear();
            }


            // опис змінної та ініціалізація структури потужності
            Power powerInfo = new Power(5000.0, 1000.0);
            // копіювання структури
            loadInfo1.power = powerInfo;
            // копіювання вказівника
            LoadItem loadInfo2 = loadInfo1;
            // після втрати останнього посиланя примірник loadInfo1 буде звільнено з пам'яті
        }
    }
}
