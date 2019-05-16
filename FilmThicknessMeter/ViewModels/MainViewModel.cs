using FilmThicknessMeter.Interfaces;
using FilmThicknessMeter.Model;
using FilmThicknessMeter.Utilites;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FilmThicknessMeter.ViewModels
{
    class MainViewModel : BindableBase
    { 
        private string _iPString;
        public string IPString
        {
            get => _iPString;
            set =>  _iPString = value;
        }

        public ConnectionClient ConnectionClient;
      //  public ConstantChangesChart ConstantChanges = new ConstantChangesChart();



        public DelegateCommand<object> ConnectionCommand { get; set; }


        public MainViewModel()
        {
            ConnectionClient = new ConnectionClient();


            ConnectionCommand = new DelegateCommand<object>(
                param =>
                {
                    Task.Run(() =>
                    {
                        ConnectionClient.SetSocket(55555, IPString);
                        ConnectionClient.Connect();
                    });
                },
                param =>
                {
                    return true;
                });
            
        }
    }
}
