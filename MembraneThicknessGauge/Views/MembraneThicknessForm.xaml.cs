using MembraneThicknessGauge.Model;
using MembraneThicknessGauge.ViewModels;
using System;
using System.Windows;

namespace MembraneThicknessGauge
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ConnectionClient connectionClient = new ConnectionClient();

        public MainWindow()
        {
            var viewModel = new MainViewModel();
            viewModel.IPString = "numb";

            DataContext = viewModel;
            InitializeComponent();

            viewModel.IPString = "172.22.11.2";
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            
        }

        
    }
}
