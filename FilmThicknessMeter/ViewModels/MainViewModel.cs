using FilmThicknessMeter.Enum;
using FilmThicknessMeter.Model;
using FilmThicknessMeter.Utilites;
using FilmThicknessMeter.Views;
using LiveCharts;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace FilmThicknessMeter.ViewModels
{
    public class MainViewModel : BindableBase
    { 
        public string IPString { get; set; }

        public ConnectionClient ConnectionClient { get; set; }
        public SensorsDataClient SensorsDataClient { get; set; }


        public DelegateCommand<object> ConnectionCommand { get; set; }
        public DelegateCommand<object> MeasurementCommand { get; set; }
        public DelegateCommand<object> ExportCommand { get; set; }
        public DelegateCommand<object> ConfigureCommand { get; set; }


        private string _connectionStatusText;
        public string ConnectionStatusText
        {
            get
            {
                return _connectionStatusText;
            }
            set
            {
                _connectionStatusText = value;
                OnPropertyChanged(new PropertyChangedEventArgs("ConnectionStatusText"));
            }
        }

        private string _connectionStatusColour;
        public string ConnectionStatusColour
        {
            get
            {
                return _connectionStatusColour;
            }
            set
            {
                _connectionStatusColour = value;
                OnPropertyChanged(new PropertyChangedEventArgs("ConnectionStatusColour"));
            }
        }


        private string _measurementTime;
        public string MeasurementTime
        {
            get
            {
                return _measurementTime;
            }
            set
            {
                _measurementTime = value;
                OnPropertyChanged(new PropertyChangedEventArgs("MeasurementTime"));
            }
        }


        private bool _exportButtonIsEnable;
        public bool ExportButtonIsEnable
        {
            get
            {
                return _exportButtonIsEnable;
            }
            set
            {
                _exportButtonIsEnable = value;
                OnPropertyChanged(new PropertyChangedEventArgs("ExportButtonIsEnable"));
            }
        }


        private bool _connectionButtonIsEnable;
        public bool ConnectionButtonIsEnable
        {
            get
            {
                return _connectionButtonIsEnable;
            }
            set
            {
                _connectionButtonIsEnable = value;
                OnPropertyChanged(new PropertyChangedEventArgs("ConnectionButtonIsEnable"));
            }
        }

        private string _connectionButtonText;
        public string ConnectionButtonText
        {
            get
            {
                return _connectionButtonText;
            }

            set
            {
                _connectionButtonText = value;
                OnPropertyChanged(new PropertyChangedEventArgs("ConnectionButtonText"));
            }
        }


        private bool _measurementButtonIsEnable;
        public bool MeasurementButtonIsEnable
        {
            get
            {
                return _measurementButtonIsEnable;
            }
            set
            {
                _measurementButtonIsEnable = value;
                OnPropertyChanged(new PropertyChangedEventArgs("MeasurementButtonIsEnable"));
            }
        }

        private bool _configureButtonIsEnable;
        public bool ConfigureButtonIsEnable
        {
            get
            {
                return _configureButtonIsEnable;
            }
            set
            {
                _configureButtonIsEnable = value;
                OnPropertyChanged(new PropertyChangedEventArgs("ConfigureButtonIsEnable"));
            }
        }
        public ConnectionStatus ConnectionStatus { get; set; }
        private bool IsConnectingBusy { get; set; }


        public ChartValues<SensorData> FirstSensor => SensorsDataClient.FirstSensor;
        public ChartValues<SensorData> SecondSensor => SensorsDataClient.SecondSensor;
        public ChartValues<SensorData> ThirdSensor => SensorsDataClient.ThirdSensor;
        public ChartValues<SensorData> FourthSensor => SensorsDataClient.FourthSensor;

        public MainViewModel()
        {
            ConnectionClient = new ConnectionClient();
            SensorsDataClient = new SensorsDataClient();


            ExportButtonIsEnable = false;
            SetConnectingStatus(ConnectionStatus.Disconnected);

            ConnectionCommand = new DelegateCommand<object>(
                param =>
                {
                    Task.Run(() =>
                    {
                        if ((ConnectionStatus == ConnectionStatus.Disconnected) || (ConnectionStatus == ConnectionStatus.Error))
                        {
                            try
                            {
                                SetConnectingStatus(ConnectionStatus.Connecting);

                                ConnectionClient.SetSocket(55555, IPString);
                                ConnectionClient.Connect();

                                SetConnectingStatus(ConnectionStatus.Connected);
                            }
                            catch (Exception)
                            {
                                SetConnectingStatus(ConnectionStatus.Error);
                            }
                        }
                        else
                        {
                            try
                            {
                                SetConnectingStatus(ConnectionStatus.Disconecting);

                                ConnectionClient.Disconnect();

                                SetConnectingStatus(ConnectionStatus.Disconnected);
                            }
                            catch (Exception)
                            {
                                SetConnectingStatus(ConnectionStatus.Error);
                            }

                        }
                        
                    });
                },
                param =>
                {
                    return !IsConnectingBusy;
                });


            MeasurementCommand = new DelegateCommand<object>(
                param =>
                {
                    Task.Run(() =>
                    {
                        try
                        {
                            StartMeasurementState();

                            SensorsDataClient.Clear();
                            var packet = new Packet(0, MeasurementTime);
                            ConnectionClient.Send(packet.ToBytes());
                            ConnectionClient.WaitForData(this);

                            EndMeasurementState();
                        }
                        catch (Exception)
                        {
                            SetConnectingStatus(ConnectionStatus.Disconnected);
                        }

                    });
                });

            ExportCommand = new DelegateCommand<object>(
                param =>
                {
                    Task.Run(() =>
                    {
                        Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
                        dlg.FileName = "SensorsData"; 
                        dlg.DefaultExt = ".csv"; 
                        dlg.Filter = "Данные датчиков|*.csv|Данные датчиков|*.xlsx|Данные датчиков|*.json";
                        Nullable<bool> result = dlg.ShowDialog();

                        if (result == true)
                        {
                            var container = new List<SensorData>();
                            foreach (var data in FirstSensor)
                            {
                                container.Add(new SensorData(data.Time, 0, data.Value));
                            }
                            foreach (var data in SecondSensor)
                            {
                                container.Add(new SensorData(data.Time, 1, data.Value));
                            }
                            foreach (var data in ThirdSensor)
                            {
                                container.Add(new SensorData(data.Time, 2, data.Value));
                            }
                            foreach (var data in FourthSensor)
                            {
                                container.Add(new SensorData(data.Time, 3, data.Value));
                            }

                            string filename = dlg.FileName;
                            if (Regex.IsMatch(filename, ".csv$"))
                            {
                                ExportTool.SaveCSV(Path.GetFullPath(filename), container);
                            }
                            else if (Regex.IsMatch(filename, ".json$"))
                            {
                                ExportTool.SaveJSON(Path.GetFullPath(filename), container);
                            }
                            else if (Regex.IsMatch(filename, ".xlsx$"))
                            {
                                ExportTool.SaveXLSX(Path.GetFullPath(filename), container);
                            }
                        }

                    });

                });

            ConfigureCommand = new DelegateCommand<object>(
                param =>
                {
                    Task.Run(() =>
                    {
                        Thread newWindowThread = new Thread(new ThreadStart(() =>
                        {
                            var configureSensorsView = new ConfigureSensorsView();
                            configureSensorsView.Show();
                            Dispatcher.Run();
                        }));
                        newWindowThread.SetApartmentState(ApartmentState.STA);
                        newWindowThread.IsBackground = true;
                        newWindowThread.Start();
                    });
                });
 
        }

        private void SetConnectingStatus(ConnectionStatus status)
        {
            switch(status)
            {
                case ConnectionStatus.Disconnected :
                    {
                        DisconnectedState();
                    }
                    break;

                case ConnectionStatus.Connecting :
                    {
                        ConnectingState();
                    }
                    break;

                case ConnectionStatus.Connected :
                    {
                        ConnectedState();
                    }
                    break;

                case ConnectionStatus.Disconecting:
                    {
                        DisconnectingState();
                    }
                    break;

                case ConnectionStatus.Error :
                    {
                        ErrorState();
                    }
                    break;     
            }
        }

        private void StartMeasurementState()
        {
            ConnectionButtonIsEnable = false;
            MeasurementButtonIsEnable = false;
            ConfigureButtonIsEnable = false;
        }

        private void EndMeasurementState()
        {
            ConnectionButtonIsEnable = true;
            MeasurementButtonIsEnable = true;
            ConfigureButtonIsEnable = true;
            ExportButtonIsEnable = true;
        }

        private void DisconnectedState()
        {
            ConnectionStatus = ConnectionStatus.Disconnected;
            IsConnectingBusy = false;
            ConnectionStatusText = "НЕ ПОДКЛЮЧЕНО";
            ConnectionStatusColour = "DarkRed";
            ConnectionButtonText = "Подключить";
            ConnectionButtonIsEnable = true;
            MeasurementButtonIsEnable = false;
            ConfigureButtonIsEnable = false;
        }

        private void ConnectingState()
        {
            ConnectionStatus = ConnectionStatus.Connecting;
            IsConnectingBusy = true;
            ConnectionStatusText = "ПОДКЛЮЧЕНИЕ";
            ConnectionStatusColour = "DarkGray";
            ConnectionButtonIsEnable = false;
        }

        private void ConnectedState()
        {
            ConnectionStatus = ConnectionStatus.Connected;
            IsConnectingBusy = false;
            ConnectionStatusText = "ПОДКЛЮЧЕНО";
            ConnectionStatusColour = "DarkGreen";
            ConnectionButtonText = "Отключить";
            ConnectionButtonIsEnable = true;
            MeasurementButtonIsEnable = true;
            ConfigureButtonIsEnable = true;
        }

        private void DisconnectingState()
        {
            ConnectionStatus = ConnectionStatus.Disconecting;
            IsConnectingBusy = true;
            ConnectionStatusText = "ОТКЛЮЧЕНИЕ";
            ConnectionStatusColour = "DarkGray";
            ConnectionButtonText = "Отключить";
            ConnectionButtonIsEnable = false;
            MeasurementButtonIsEnable = false;
        }

        private void ErrorState()
        {
            ConnectionStatus = ConnectionStatus.Error;
            IsConnectingBusy = false;
            ConnectionStatusText = "ОШИБКА ПОДКЛЮЧЕНИЯ";
            ConnectionStatusColour = "DarkRed";
            ConnectionButtonText = "Подключить";
            ConnectionButtonIsEnable = true;
            MeasurementButtonIsEnable = false;
            ConfigureButtonIsEnable = false;
        }

    }
}
