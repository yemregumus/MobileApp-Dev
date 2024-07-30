using System;
using Xamarin.Forms;

namespace TemperatureConverter
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async void OnConvertButtonClicked(object sender, EventArgs e)
        {
            if (double.TryParse(celsiusEntry.Text, out double celsius))
            {
                double fahrenheit = (celsius * 9 / 5) + 32;
                await Navigation.PushAsync(new SecondScreen(fahrenheit));
            }
            else
            {
                await DisplayAlert("Invalid Input", "Please enter a valid number.", "OK");
            }
        }
    }
}
