﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Model;
using WeatherApp.Model2;

namespace WeatherApp.ViewModel.Helpers
{
    public class AccuWeatherHelper
    {
        public const string BASE_URL = "http://dataservice.accuweather.com/";
        public const string AUTOCOMPLETE_ENDPOINT = "locations/v1/cities/autocomplete?apikey={0}&q={1}";
        public const string CURRENT_CONDITIONS_ENDPOINT = "currentconditions/v1/{0}?apikey={1}";
        public const string FIVE_DAYS_FORECAST_ENDPOINT = "forecasts/v1/daily/5day/{0}?apikey={1}";
        //public const string API_KEY = "LcFJrVUpU3lVT8aA0IAGgXnMLFqK8DmW";
        //public const string API_KEY = "8STY2SK0tiXMl8X0URkZY6pRvqy6ybW9 ";
        public const string API_KEY = "HTW76OFqgI8mYAuPLyTF8TXEUlnwLQIG  ";

        public static async Task<List<City>> GetCities(string query)
        {
            List<City> cities = new List<City>();

            string url = BASE_URL + string.Format(AUTOCOMPLETE_ENDPOINT, API_KEY, query);

            using(HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                string json = await response.Content.ReadAsStringAsync();

                cities = JsonConvert.DeserializeObject<List<City>>(json);
            }

            return cities;
        }

        public static async Task<CurrrentConditions> GetCurrrentConditions(string cityKey)
        {
            CurrrentConditions currrentConditions = new CurrrentConditions();

            string url = BASE_URL + string.Format(CURRENT_CONDITIONS_ENDPOINT, cityKey, API_KEY);

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                string json = await response.Content.ReadAsStringAsync();

                currrentConditions = (JsonConvert.DeserializeObject<List<CurrrentConditions>>(json)).FirstOrDefault();
            }

            return currrentConditions;
        }

        public static async Task<FiveDayForecast> GetFiveDayForecast(string cityKey)
        {
            FiveDayForecast FiveDaysForecast = new FiveDayForecast();

            string url = BASE_URL + string.Format(FIVE_DAYS_FORECAST_ENDPOINT, cityKey, API_KEY);

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                string json = await response.Content.ReadAsStringAsync();

                FiveDaysForecast = (JsonConvert.DeserializeObject<FiveDayForecast>(json));

                int i = 1;

                return FiveDaysForecast;
            }
        }
    }
}
