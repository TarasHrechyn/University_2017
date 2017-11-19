using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using GridClassLibrary;

namespace PowerCalcForWindows
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class LoadInputDlg : Window
    {
        public LoadInputDlg()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            /// ToDo - Добавити перевірку правильності значень
            this.DialogResult = true;
        }

        public BusConnection CreateNewLoad()
        {
            // перетворення значень текстових полів до дійсних величин
            double localP = Convert.ToDouble(textP.Text);
            double localQ = Convert.ToDouble(textQ.Text);
            // створення шинного приєднання та присвоєння початкових данів з діалогу
            return new BusConnection()
                {
                    Code = textCode.Text,
                    Name = textName.Text,
                    P = localP,
                    Q = localQ
                };
        }
    }
}
