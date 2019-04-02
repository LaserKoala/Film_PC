using MembraneThicknessGauge.Code;
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
            InitializeComponent();
        }

        private void SettingComponents()
        {
            var IPTextBox = (TextBox)this.FindName("IPTextBox");
            IPTextBox.Text = MySettings.Default.DefaultIP;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var IPTextBox = (TextBox)this.FindName("IPTextBox");
            MySettings.Default.DefaultIP = IPTextBox.Text;
            MySettings.Default.Save();
            connectionClient.Connect(IPTextBox.Text);
            
            
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            connectionClient.Close();
        }
    }
}
