using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Model
{
    public class DailyForecast
    {
        public DateTime Date { get; set; }
        public Headline Headline { get; set; }
        public DailyTemperature DailyTemperature { get; set; }
        public string Link { get; set; }
        public string MobileLink { get; set; }

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
        
    }

    public class Night
    {
        public int Icon { get; set; }
        public bool HasPrecipitation { get; set; }
        public string PrecipitationType { get; set; }
    }


    public class DailyTemperature
    {
        public Units Minimum { get; set; }
        public Units Maximum { get; set; }
    }
}
