using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Mini_Task_Manager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer dispatcherTimer;

        public MainWindow()
        {
            InitializeComponent();
            ListOfTasks.ItemsSource = Process.GetProcesses();
            dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 5);
            dispatcherTimer.Start();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            ListOfTasks.ItemsSource = Process.GetProcesses();
        }


        private void ListOfTasks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListOfTasks.SelectedItem is null) return;
                var tmp = (Process)ListOfTasks.SelectedItem;
                listOfThreads.ItemsSource = tmp.Threads;
            try
            {
                listOfModules.ItemsSource = tmp.Modules;
            }
            catch (Exception)
            {

            }
               

        }
    }
}
