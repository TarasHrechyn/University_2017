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
using PowerCalcClasses;

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

        public LoadItem CreateNewLoad()
        {
            double P = Convert.ToDouble(textP.Text);
            double Q = Convert.ToDouble(textQ.Text);
            return new RegularLoad(textCode.Text, textName.Text, P, Q);
        }

    }
}
