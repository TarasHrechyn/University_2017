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
        public Power PowerSum
        {
            get {
                Power res = new Power();
                foreach (LoadItem load in loadItems)
                {
                    res = res + load.power;
                }
                return res;
            }
        }

        //
        public void Save()
        {

        }
        // 
        public void Load()
        {
        }
    }
}
