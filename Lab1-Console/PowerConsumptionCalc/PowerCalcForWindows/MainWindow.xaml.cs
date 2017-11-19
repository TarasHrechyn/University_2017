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
using Microsoft.Win32;
using System.Data;
using GridClassLibrary;


namespace PowerCalcForWindows
{
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
            // очищеня списку
            busesListView.Items.Clear();
            // заповненя переліку шин
            foreach (Bus bus in data.model.Buses)
            {
                busesListView.Items.Add(bus.Name.Trim() + " - " + bus.Voltage);
            }

            // альтернативний вигляд переліку шин із використанянм DataGrid
            busesDataGrid.ItemsSource = data.model.Buses.Local.ToList();
           
        }

        private void menuExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void menuAbout_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Інформація про програму...\n"
                + "Це є демонстраційна програма", "Про...");
        }

                
        private void menuEditAddLoad_Click(object sender, RoutedEventArgs e)
        {
            // перевірка чи відзначено поточну шину
            if (busesDataGrid.SelectedItem is Bus)
            {
                // отримання посилання на поточну шину
                Bus selectedBus = (Bus)busesDataGrid.SelectedItem;
                // показ діалогу
                LoadInputDlg dlg = new LoadInputDlg();
                if (dlg.ShowDialog() == true)
                {
                    // створення нового приєднання засобами класу діалогового вікна
                    BusConnection connectedLoad = dlg.CreateNewLoad();
                    // присвоєння власника
                    connectedLoad.Bus = selectedBus;
                    // добавлення приєднання в список приєднань шини
                    data.model.BusConnections.Add(connectedLoad);
                    // запис змін в базу даних
                    data.model.SaveChanges();
                    // оневлення даних таблиць
                    UpdateView(false);                    
                }
            }
            else
            {
                MessageBox.Show("Виберіть шину для якої створити приєднання", "Cтворення приєднання...");
            }
        }

        private void menuEditDelete_Click(object sender, RoutedEventArgs e)
        {
            //int idx = listView.SelectedIndex;
            //if (idx != -1)
           // {
            //    data.model.BusConnections.Remove(data.model.items[idx]);
            //}            
            //UpdateView(false);
        }

        private void busesDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (busesDataGrid.SelectedItem is Bus)
            {
                Bus selectedBus = (Bus)busesDataGrid.SelectedItem;
                connectionsDataGrid.ItemsSource = selectedBus.BusConnections;
            } else
            {
                connectionsDataGrid.ItemsSource = data.model.BusConnections.Local.ToList();
            }
            connectionsDataGrid.Columns[0].Visibility = Visibility.Hidden;
            
          
        }

        private void connectionsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void connectionsDataGrid_AutoGeneratingColumn(object sender, 
            DataGridAutoGeneratingColumnEventArgs e)
        {
            string colName = e.Column.Header.ToString();
            if ((colName == "Bus") || (colName == "Id") || (colName == "BusId"))
            {
                e.Column.Visibility = Visibility.Hidden;
            } else
            if (colName == "Name")
            {
                e.Column.Header = "Назва";
            }
        }
    }
}
