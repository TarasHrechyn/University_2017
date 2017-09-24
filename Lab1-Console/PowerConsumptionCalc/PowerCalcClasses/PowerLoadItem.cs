using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerCalcClasses
{
    enum Voltage : int { v220 = 220, v380 = 380 };

    public struct Power
    {
        public double P, Q;
        public Power(double p, double q)
        {
            P = p;
            Q = q;
        }
    }

    class LoadItem
    {
        public Voltage voltage;
        public Power load;
    }
}
