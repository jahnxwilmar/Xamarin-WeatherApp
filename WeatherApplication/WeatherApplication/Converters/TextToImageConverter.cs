using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.NetworkInformation;
using System.Text;
using Xamarin.Forms;

namespace WeatherApplication.Converters
{
    public class TextToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string weather = value as string;
            string path = string.Empty;
            switch (weather)
            {
                case "Thunderstorm":
                    path = "thunderstorm.png"; 
                    break;
                case "Drizzle":
                    path = "drizzle.png"; 
                    break;
                case "Rain":
                    path = "rain.png"; 
                    break;
                case "Snow":
                    path = "snow.png"; 
                    break;
                case "Atmosphere":
                    path = "atmosphere.png";
                    break;
                case "Clear":
                    path = "clear.png";
                    break;
                case "Clouds":
                    path = "cloud.png";
                    break;
                case "Mist":
                    path = "mist.png";
                    break;
                case "Smoke":
                    path = "mist.png";
                    break;
                case "Haze":
                    path = "mist.png";
                    break;
                case "Dust":
                    path = "dust.png";
                    break;
                case "Fog":
                    path = "fog.png";
                    break;
                case "Sand":
                    path = "dust.png";
                    break;
                case "Ash":
                    path = "dust.png";
                    break;
                case "Squall":
                    path = "squall.png";
                    break;
                case "Tornado":
                    path = "tornado.png";
                    break;
                default:
                    path = "atmosphere.png";
                    break;
            }
            return path;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
