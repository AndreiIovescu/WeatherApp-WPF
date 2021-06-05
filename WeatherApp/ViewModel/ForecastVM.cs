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

        private List<DailyForecast> dailyForecast;

        public List<DailyForecast> DailyForecast
        {
            get { return dailyForecast; }
            set
            {
                dailyForecast = value;
                OnPropertyChanged("_City");
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
            //DailyForecast = await AccuWeatherHelper.GetFiveDayForecast(_City);
        }

        public ForecastVM()
        {
            _City = WeatherVM.CityForDetails;
            GetFiveDayForecast();
        }

    }
}
