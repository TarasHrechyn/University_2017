using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace PowerCalcClasses
{

    [Serializable]
    public class PowerGridDataModel
    {
        public PowerGridDataModel()
        {
            name = "Підстанція";
            //            LoadItems =;
        }

        [XmlAttributeAttribute]
        public string name { get; set; }

        // перелік навантаження
        // cеріалізація списку
        [XmlArray]
        public List<LoadItem> items = new List<LoadItem>();
    }

    public class PowerGridData
    {
        // назва файлу фіксована
        static string defFileExt = ".pwr";
        static string defFileName = "New" + defFileExt;

        public string FileName { get; set; }

        public PowerGridData()
        {
            NewModel();
        }       

        public void NewModel()
        {
            model = new PowerGridDataModel();
            FileName = defFileName;
        }

        public PowerGridDataModel model { get; private set; }
        // обчислювана властивість
        public Power PowerSum
        {  
            // метод який реалізує повернення результату властивості
            get
            {
                Power res = new Power();
                foreach (LoadItem load in model.items)
                {
                    res = res + load.power;
                }
                return res;
            }
        }
        
        // реалізація запису моделі даних у файловий потік
        public void Save(string saveAsFileName = "")
        {
            if (saveAsFileName != "")
              FileName = saveAsFileName;
            // створення серіалізатора
            XmlSerializer serializer = new XmlSerializer(typeof(PowerGridDataModel));
            // відкривання файлового потоку для серіалізації
            // секція using закриває файл (запис на диск)
            using (Stream stream = new FileStream(FileName, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                // запис у потік
                serializer.Serialize(stream, model);
            }
        }

        // реалізація відновлення моделі даних з файлового потоку
        public void Load(string loadFromFileName = "")
        {
            if (loadFromFileName != "")
                FileName = loadFromFileName;

            // створення серіалізатора
            XmlSerializer serializer = new XmlSerializer(typeof(PowerGridDataModel));
            // відкривання файлового потоку для серіалізації
            // секція using закриває файл (запис на диск)
            using (Stream stream = new FileStream(FileName, FileMode.Open, FileAccess.Read, FileShare.None))
            {
                // створення та читання моделі даних
                model = (PowerGridDataModel)serializer.Deserialize(stream);                
            }
        }
    }
}
