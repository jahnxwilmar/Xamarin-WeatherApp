using System;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Newtonsoft.Json;
using WeatherApplication.Models;
using Xamarin.Forms;

namespace WeatherApplication.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private WeatherData data;

        public WeatherData Data
        {
            get => data;
            set
            {
                data = value;
                OnPropertyChanged();
            }
        }

        public ICommand SearchCommand { get; set; }

        public MainPageViewModel()
        {
            SearchCommand = new Command(async (searchTerm) =>
            {
                await GetData("https://api.openweathermap.org/data/2.5/weather?q=" + searchTerm + "&units=metric&APPID=30d4741c779ba94c470ca1f63045390a");
            });
        }

        public async Task GetData(string url)
        {
            try
            {
                var client = new HttpClient();
                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResult = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<WeatherData>(jsonResult);
                    Data = result;
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", $"Failed to fetch weather data. Status code: {response.StatusCode}", "OK");
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public double TemperatureInCelsius
        {
            get { return ConvertFahrenheitToCelsius(Data.main.temp); }
        }

        private double ConvertFahrenheitToCelsius(double fahrenheit)
        {
            return (fahrenheit - 32) * 5 / 9;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
