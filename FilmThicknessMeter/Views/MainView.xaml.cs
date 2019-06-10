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
    }
}
