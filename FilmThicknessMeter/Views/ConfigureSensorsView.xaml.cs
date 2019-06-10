using FilmThicknessMeter.Interfaces;
using FilmThicknessMeter.ViewModels;
using System.Text.RegularExpressions;
using System.Windows;

namespace FilmThicknessMeter.Views
{
    /// <summary>
    /// Interaction logic for ConfigureSensorsView.xaml
    /// </summary>
    public partial class ConfigureSensorsView : Window, IClosable
    {
        public ConfigureSensorsView()
        {
            var viewModel = new ConfigureSensorsViewModel(this);

            DataContext = viewModel;
            InitializeComponent();
        }

        private void TextBox_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
