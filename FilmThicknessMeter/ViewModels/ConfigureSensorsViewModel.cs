using FilmThicknessMeter.Interfaces;
using GalaSoft.MvvmLight.Command;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FilmThicknessMeter.ViewModels
{
    public class ConfigureSensorsViewModel : BindableBase
    {
       // public DelegateCommand<object> SaveConfigurationCommand { get; set; }

        public RelayCommand<IClosable> SaveConfigurationCommand { get; private set; }

        public ulong _pwmValue;
        public ulong PWMValue
        {
            get
            {
                return _pwmValue;
            }
            set
            {
                _pwmValue = value;
                OnPropertyChanged(new PropertyChangedEventArgs("PWMValue"));
            }
        }

        public string _errorMessage;
        public string ErrorMessage
        {
            get
            {
                return _errorMessage;
            }
            set
            {
                _errorMessage = value;
                OnPropertyChanged(new PropertyChangedEventArgs("ErrorMessage"));
            }

        }

        private double _firstSensor;
        public double FirstSensor
        {
            get
            {
                return _firstSensor;
            }
            set
            {
                if ((value >= 0) && (value <= 1))
                {
                    _firstSensor = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("FirstSensor"));
                }
            }
        }

        private double _secondSensor;
        public double SecondSensor
        {
            get
            {
                return _secondSensor;
            }
            set
            {
                if ((value >= 0) && (value <= 1))
                {
                    _secondSensor = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("SecondSensor"));
                }
            }
        }

        private double _thirdSensor;
        public double ThirdSensor
        {
            get
            {
                return _thirdSensor;
            }
            set
            {
                if ((value >= 0) && (value <= 1))
                {
                    _thirdSensor = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("ThirdSensor"));
                }
            }
        }

        private double _fourthSensor;
        public double FourthSensor
        {
            get
            {
                return _fourthSensor;
            }
            set
            {
                if ((value >= 0) && (value <= 1))
                {
                    _fourthSensor = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("FourthSensor"));
                }
            }
        }



        public ConfigureSensorsViewModel(Window view)
        {
            this.SaveConfigurationCommand = new RelayCommand<IClosable>(this.SaveConfiguration);
            FirstSensor = 0;
            SecondSensor = 0;
            ThirdSensor = 0;
            FourthSensor = 0;
            PWMValue = 0;
            ErrorMessage = null;
        }

        private void SaveConfiguration(IClosable window)
        {
            if (PWMValue != 0)
            {
                window.Close();
            }
            else
            {
                ErrorMessage = "Введите ШИМ";
            }
        }
    }
}
