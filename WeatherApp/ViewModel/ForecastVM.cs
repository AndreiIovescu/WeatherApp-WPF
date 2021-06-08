using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Model;
using WeatherApp.ViewModel.Helpers;

namespace WeatherApp.ViewModel
{
    public class ForecastVM : INotifyPropertyChanged
    {
        public string _City { get; set; }

        private AccuWeather5DayModel dailyForecast;

        public AccuWeather5DayModel DailyForecast
        {
            get { return dailyForecast; }
            set
            {
                dailyForecast = value;
                OnPropertyChanged("DailyForecast");
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
           DailyForecast = await AccuWeatherHelper.GetFiveDayForecast(_City);
           int i = 0;
        }

        public ForecastVM()
        {
            _City = WeatherVM.CityForDetails;
            GetFiveDayForecast();
        }

    }
}
