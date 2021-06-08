using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Model2;
using WeatherApp.ViewModel.Helpers;

namespace WeatherApp.ViewModel
{
    public class ForecastVM : INotifyPropertyChanged
    {
        public string _City { get; set; }

        private FiveDayForecast forecast;

        public FiveDayForecast Forecast
        {
            get { return forecast; }
            set
            {
                forecast = value;
                foreach (DailyForecast dailyForecast in forecast.DailyForecasts)
                {
                    dailyForecast.Temperature.Maximum.Value = Convert.ToString(Math.Round((Convert.ToDouble(dailyForecast.Temperature.Maximum.Value) -32.0 ) / 1.8));
                    dailyForecast.Temperature.Minimum.Value = Convert.ToString(Math.Round((Convert.ToDouble(dailyForecast.Temperature.Maximum.Value) -32.0 ) / 1.8));
                }
                OnPropertyChanged("Forecast");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string City
        {
            get => _City;
            set
            {
                _City = value;
                OnPropertyChanged("City");
            }
        }

        private async void GetFiveDayForecast()
        {
           Forecast = await AccuWeatherHelper.GetFiveDayForecast(_City);
        }

        public ForecastVM()
        {
            _City = WeatherVM.CityForDetails;
            GetFiveDayForecast();
        }

    }
}
