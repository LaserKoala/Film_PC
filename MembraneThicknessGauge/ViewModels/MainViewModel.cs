using MembraneThicknessGauge.Model;
using MembraneThicknessGauge.Utilites;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MembraneThicknessGauge.ViewModels
{
    class MainViewModel : INotifyPropertyChanged
    {
        private ConnectionClient connectionClient { get; set; }

        private string _iPString = null;
        public string IPString
        {
            get => _iPString;
            set => SetProperty(ref _iPString,value);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private readonly DelegateCommand _connectCommand;
        public ICommand ConnectCommand => _connectCommand;

        public MainViewModel()
        {
            _connectCommand = new DelegateCommand(OnConnect);
        }

        protected bool SetProperty<T>(ref T field, T newValue, [CallerMemberName]string propertyName = null)
        {
            if(!EqualityComparer<T>.Default.Equals(field,newValue))
            {
                field = newValue;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                return true;
            }
            return false;
        }

        private void OnConnect(object commandParameter)
        {
            if (connectionClient==null)
            {
                connectionClient = new ConnectionClient();
            }
            connectionClient.Connect(55555,_iPString);
        }
    }
}
