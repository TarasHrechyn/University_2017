using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridClassLibrary
{
    public class PowerGridData
    {
        public PowerGridDBEntities model = new PowerGridDBEntities(); 
    }
    
    // Оголошення логічного доповнення класу
    public partial class BusConnection
    {
        // значення номінального струму
        public double In { get
            {
                // розрахунок потужності
                double S = Math.Sqrt(P.Value * P.Value + Q.Value * Q.Value);
                // розрахунок струму
                return S / Bus.Voltage;
            }
        }
    }
}
