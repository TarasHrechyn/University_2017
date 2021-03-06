﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace PowerCalcClasses
{

    // перелічуваний тип - перелік стандартних номінальних напруг
    [Serializable]
    public enum Voltage : int { v220 = 220, v380 = 380 };

    // структура опису потужності
    [Serializable]
    public struct Power
    {
        // фізичні поля для зберігання даних
        [XmlAttribute]
        public double P;
        [XmlAttribute]
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
    
    [XmlInclude(typeof(LoadItem))]
    [XmlInclude(typeof(RegularLoad))]
    [XmlInclude(typeof(CapacitorBank))]

    // опис узагальненого навантаження
    [Serializable]
    public class LoadItem
    {
        // конструктор за замовчуванням (без параметрів)
        public LoadItem()
        {
            power = new Power(0, 0);
            voltage = Voltage.v220;
        }

        // віртуальна функція - початковий опис
        protected virtual string GetPropsDisplayName()
        {
            return "V=" + voltage.ToString();
        }
        // переозначена стандартна функція
        public override string ToString()
        {
            return code + ": " + GetPropsDisplayName();
        }

        // прості властивості для зберігання даних
        [XmlAttribute]
        public string code;// { get; set; }

        // серіалізація атрибута
        [XmlAttribute]
        public Voltage voltage;

        // серіалізація структури як елемента
        public Power power;

        // обчислювальна властивість струму. Не серіалізується
        [XmlIgnore]
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
        // конструктор з параметрами який перевикористовується лише в успадкованих класах
        protected LoadItem(string code, Power initialPower, Voltage ratedVoltage = Voltage.v220)
        {
            // назви поля та параметру співпадає. 
            this.code = code;
            // назви різняться тому this не є обовязковим
            power = initialPower;
            voltage = ratedVoltage;
        }

    }

    // опис классу звичайного навантаження, успадкований від узагальненого елементу навантаження
    [Serializable]
    public class RegularLoad: LoadItem
    {
        // додаткове поле
        [XmlAttribute]
        public string customer;
        // переозначення конструктора за умовчанням
        public RegularLoad(): base()
        {
        }
        // переозначення конструктора та виклик конструктора з базового класу
        public RegularLoad(string code, string customer, double P, double Q, Voltage ratedVoltage = Voltage.v220) :
            base(code, new Power(P, Q), ratedVoltage)
        {
            this.customer = customer;
        }

        // віртуальна функція - переозначена
        protected override string GetPropsDisplayName()
        {
            return base.GetPropsDisplayName() + ", P=" + power.P.ToString("0.0") + ", Q=" + power.Q.ToString("0.0") 
                + ", споживач: " + customer;
        }
    }

    // опис классу конденсаторної батареї
    [Serializable]
    public class CapacitorBank : LoadItem
    {
        [XmlAttribute]
        public string type;
        // переозначення конструктора за умовчанням
        public CapacitorBank(): base()
        {
        }

        // переозначення конструктора 
        public CapacitorBank(string code, string type, double Q, Voltage ratedVoltage = Voltage.v220) : 
            base(code, new Power(0, -Math.Abs(Q)), ratedVoltage)
        {
            this.type = type;            
        }
        protected override string GetPropsDisplayName()
        {
            return base.GetPropsDisplayName() + ", Q=" + (power.Q * -1).ToString("0.0") + ", тип КБ:" + type;
        }
    }
}
