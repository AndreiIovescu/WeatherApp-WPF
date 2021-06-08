using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Model2
{
    public class FiveDayForecast
    {
        public Headline Headline { get; set; }

        public List<DailyForecast> DailyForecasts;

    }

    public class DailyForecast
    {
        public DateTime Date { get; set; }
        public Temperature Temperature { get; set; }
        public string Link { get; set; }
        public string MobileLink { get; set; }
        public Day Day { get; set; }
        public Night Night { get; set; }

    }

    public class Headline
    {
        public DateTime EffectiveDate { get; set; }
        public string Text { get; set; }
    }

    public class Day
    {
        public int Icon { get; set; }
        public bool HasPrecipitation { get; set; }
        public string PrecipitationType { get; set; }
        public int PrecipitationProbability { get; set; }
        
    }

    public class Night
    {
        public int Icon { get; set; }
        public bool HasPrecipitation { get; set; }
        public string PrecipitationType { get; set; }
        public int PrecipitationProbability { get; set; }
    }

    public class Temperature 
    {
        public Units Minimum { get; set; }
        public Units Maximum { get; set; }
    }

    public class Units
    {
        public string Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
    }

}
