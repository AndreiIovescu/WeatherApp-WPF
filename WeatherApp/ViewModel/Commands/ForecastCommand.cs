using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WeatherApp.View;

namespace WeatherApp.ViewModel.Commands
{
    public class ForecastCommand : ICommand
    {
        public WeatherVM VM { get; set; }

        event EventHandler ICommand.CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        bool ICommand.CanExecute(object parameter)
        {
            return true;
        }

        public ForecastCommand(WeatherVM vm)
        {
            VM = vm;
        }

        void ICommand.Execute(object parameter)
        {
            VM.SeeForecast();
        }
    }
}
