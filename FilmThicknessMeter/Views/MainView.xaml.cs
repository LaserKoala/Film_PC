using FilmThicknessMeter.Model;
using FilmThicknessMeter.ViewModels;
using FilmThicknessMeter.Views;
using System;
using System.Text.RegularExpressions;
using System.Windows;

namespace FilmThicknessMeter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            var viewModel = new MainViewModel();
            viewModel.IPString = "172.22.11.2";

            DataContext = viewModel;
            InitializeComponent();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var configureSensorsView = new ConfigureSensorsView();
            configureSensorsView.Owner = this;
            configureSensorsView.Show();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "Document"; // Default file name
            dlg.DefaultExt = ".csv"; // Default file extension
            dlg.Filter = "Данные датчиков|*.csv|Данные датчиков|*.xlsx|Данные датчиков|*.json";
            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                string filename = dlg.FileName;
                if (Regex.IsMatch(filename, ".csv$"))
                {
                    Console.WriteLine("csv");
                }
                else if (Regex.IsMatch(filename, ".json$"))
                {
                    Console.WriteLine("json");
                }
            }
        }
    }
}
