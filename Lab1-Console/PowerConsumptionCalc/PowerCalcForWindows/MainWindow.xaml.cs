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
using System.Windows.Navigation;
using System.Windows.Shapes;
using PowerCalcClasses;
using Microsoft.Win32;

namespace PowerCalcForWindows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public PowerGridData data = new PowerGridData();

        public MainWindow()
        {
            InitializeComponent();
            UpdateView(true);
        }

        void UpdateView(bool updateTitle)
        {
            // оновлення списку
            listView.Items.Clear();
            foreach (PowerCalcClasses.LoadItem loadItem in data.model.items)
            {
                listView.Items.Add(loadItem.ToString());
            }
            // відображення підсумкової інформації
            Power sSum = data.PowerSum;
            labelTotal.Content =
                "P: " + sSum.P.ToString() + "\n" +
                "Q: " + sSum.Q.ToString();

            if (updateTitle)
            {
                // Оновлення заголовку головного вікна
                Title = "Навантаження - " + data.FileName;
            }
        }

        private void menuExit_Click(object sender, RoutedEventArgs e)
        {
            string message = "Файл містить зміни. Чи бажаєте Ви їх зберегти?";
            string caption = "Вихід з програми";
            MessageBoxButton button = MessageBoxButton.YesNoCancel;
            MessageBoxImage icon = MessageBoxImage.Question;
            // виклик діалогу
            MessageBoxResult result = MessageBox.Show(message, caption, button, icon);
            switch (result)
            {
                case MessageBoxResult.Cancel:
                    // Відміна виходу і повернення з процедури
                    return;
                case MessageBoxResult.Yes:
                    // Запис моделі
                    data.Save();
                    break;
                case MessageBoxResult.No:
                    // вихід без запису
                    break;
            }    
            this.Close();
        }

        private void menuAbout_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Інформація про програму...\n"
                + "Це є демонстраційна програма", "Про...");
        }

        private void menuFileOpen_Click(object sender, RoutedEventArgs e)
        {
            // Створюємо та конфігуруємо діалог
            OpenFileDialog dlg = new OpenFileDialog();

            // назву Файла беремо з обєкта даних
            dlg.FileName = data.FileName;                
            dlg.DefaultExt = ".pwr";                     
            dlg.Filter =  "Дані Мережі (.pwr)|*.pwr"; 

            // Показ на екрані та отримання даних
            Nullable<bool> result = dlg.ShowDialog();

            // Process open file dialog box results
            if (result == true)
            {
                // Відкриваємо документ
                string fileName = dlg.FileName;
                data.Load(fileName);
                UpdateView(true);
            }
        }

        private void menuFileSave_Click(object sender, RoutedEventArgs e)
        {
            data.Save();
        }

        private void menuFileNew_Click(object sender, RoutedEventArgs e)
        {
            data.NewModel();
            UpdateView(true);
        }

        private void menuEditAddLoad_Click(object sender, RoutedEventArgs e)
        {
            PowerCalcClasses.RegularLoad load = new PowerCalcClasses.RegularLoad("Н1", "Споживач", 1, 0.3);
            data.model.items.Add(load);
            UpdateView(false);
        }
        
        private void menuEditAddKB_Click(object sender, RoutedEventArgs e)
        {
            PowerCalcClasses.CapacitorBank bank = new PowerCalcClasses.CapacitorBank("В1", "Батарея", 1);
            data.model.items.Add(bank);
            UpdateView(false);
        }
    }
}
