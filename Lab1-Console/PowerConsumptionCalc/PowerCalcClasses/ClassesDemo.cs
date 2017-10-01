using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerCalcClasses
{
    class ClassesDemo
    {
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

    }
}
