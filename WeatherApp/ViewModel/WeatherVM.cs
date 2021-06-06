using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Model;
using WeatherApp.View;
using WeatherApp.ViewModel.Commands;
using WeatherApp.ViewModel.Helpers;

namespace WeatherApp.ViewModel
{
    public class WeatherVM : INotifyPropertyChanged
    {
        public static string CityForDetails = "NONE";

        private string query;

        public string Query
        {
            get { return query; }
            set
            {
                query = value;
                OnPropertyChanged("Query");
            }
        }

        public ObservableCollection<City> Cities { get; set; }

        private CurrrentConditions currrentConditions;

        public CurrrentConditions CurrrentConditions
        {
            get { return currrentConditions; }
            set
            {
                currrentConditions = value;
                OnPropertyChanged("CurrrentConditions");
            }
        }

        private City selectedCity;

        public City SelectedCity
        {
            get { return selectedCity; }
            set
            {
                selectedCity = value;
                if (selectedCity != null)
                {
                    CityForDetails = selectedCity.Key;

                    OnPropertyChanged("SelectedCity");
                    GetCurrentConditions();
                }
            }
        }

        public SearchCommand SearchCommand { get; set; }
        public ForecastCommand ForecastCommand { get; set; }

        public WeatherVM()
        {
            if (DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject()))
            {
                SelectedCity = new City
                {
                    LocalizedName = "New York"
                };
                CurrrentConditions = new CurrrentConditions
                {
                    WeatherText = "Partly cloudy",
                    HasPrecipitation = true,
                    Temperature = new Temperature
                    {
                        Metric = new Units
                        {
                            Value = "21"
                        }
                    }
                };
            }

            SearchCommand = new SearchCommand(this);
            ForecastCommand = new ForecastCommand(this);
            Cities = new ObservableCollection<City>();
        }

        private async void GetCurrentConditions()
        {
            Query = string.Empty;
            CurrrentConditions = await AccuWeatherHelper.GetCurrrentConditions(SelectedCity.Key);
            Cities.Clear();
        }

        public async void MakeQuery()
        {
            var cities = await AccuWeatherHelper.GetCities(Query);

            Cities.Clear();
            foreach (var city in cities)
            {
                Cities.Add(city);
            }
        }

        public void WriteToFile()
        {
            File.WriteAllText("Weather.json",JsonConvert.SerializeObject(currrentConditions));
        }


        public void SeeForecast()
        {

            ForecastWindow forecastWindow = new ForecastWindow();
            //forecastWindow.DataContext = this;
            forecastWindow.Show();
            WriteToFile();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
