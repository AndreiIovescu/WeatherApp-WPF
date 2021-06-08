using System;
using System.Globalization;
using System.Windows.Data;

namespace WeatherApp.ViewModel.ValueConverters
{
    public class HasPrecipitationConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isPrecipitation = (bool)value;

            if (isPrecipitation)
                return "Possibility of precipitations";

            return "No precipitations expected";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string isPrecipitation = (string)value;
            if (isPrecipitation != null)
            {
                if (isPrecipitation == "Precipitations right now")
                    return true;
            }
            return false;
        }
    }
}
