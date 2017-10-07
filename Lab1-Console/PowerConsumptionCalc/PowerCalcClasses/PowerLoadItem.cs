using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerCalcClasses
{
    // перелічуваний тип - перелік стандартних номінальних напруг
    public enum Voltage : int { v220 = 220, v380 = 380 };

    // структура опису потужності
    public struct Power
    {
        // фізичні поля для зберігання даних
        public double P;
        public double Q;
        // опис конструктора ініціалізації
        public Power(double p, double q)
        {
            P = p;
            Q = q;
        }
        // опис обчислювальної властивості повної потужності
        public double S
        {
            get { return Math.Sqrt(P * P + Q * Q); }
        }

        // опис опаретора додавання потужностей
        public static Power operator +(Power p1, Power p2)
        {
            return new Power(p1.P + p2.P, p1.Q + p2.Q);
        }
    }

    // опис узагальненого навантаження
    public class LoadItem
    {
        // поля для зберігання даних
        public string name;
        public Voltage voltage;
        public Power power;
        // очищення значення потужності
        public void Clear()
        {
            power = new Power(0.0, 0.0);
        }
        // перевірка чи потужність є нульовою
        public bool IsEmpty()
        {
            return (power.S == 0.0);
        }
        // перевірка чи потужність є вказана 
        public bool IsDefined()
        {
            return (power.S > 0.0);
        }
        // конструктор за замовчуванням
        public LoadItem()
        {
            power = new Power(0, 0);
            voltage = Voltage.v220;
        }
        // конструктор з параметрами
        public LoadItem(Power initialPower, Voltage initialVoltage = Voltage.v220)
        {
            power = initialPower;
            voltage = initialVoltage;
        }
        // обчислювальна властивість струму
        public double Current
        {
            get
            {
                return power.S / (int)voltage;
            }
            set
            {
                double newS = value * (int)voltage;
                double prevS = power.S;
                power = new Power(power.P * newS / prevS, power.Q * newS / prevS); 
            }
        }

        public virtual string DisplayName() 
        {
            return name + ", V=" + voltage.ToString();
        }
    }
    
    // опис типу звичайного навантаження
    public class RegularLoad: LoadItem
    {
        public string customer;        
        public override string DisplayName()
        {
            return base.DisplayName() + ", P=" + power.P.ToString("0.0") + ", Q=" + power.Q.ToString("0.0") + ", споживач: " + customer;
        }
    }

    // опис конденсаторної батареї
    public class CapacitorBank : LoadItem
    {
        public string type;
        public CapacitorBank()
        {
            power = new Power(0, 1000);
        }
        public override string DisplayName()
        {
            return base.DisplayName() + ", Q=" + power.Q.ToString("0.0") + ", тип КБ:" + type;
        }
    }
}
