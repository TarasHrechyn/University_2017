using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerCalcClasses
{
    class PowerGridData
    {
        public string Name = "Підстанція";
        // перелік навантаження
        public List<LoadItem> loadItems = new List<LoadItem>();
        // обчислювана властивість
        public Power PowerSum
        {  
            // метод який реалізує повернення результату властивості
            get
            {
                Power res = new Power();
                foreach (LoadItem load in loadItems)
                {
                    res = res + load.power;
                }
                return res;
            }
        }

        // реалізац
        public void Save()
        {
        }

        // 
        public void Load()
        {
        }
    }
}
