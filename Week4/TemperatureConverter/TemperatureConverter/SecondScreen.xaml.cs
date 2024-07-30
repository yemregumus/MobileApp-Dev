using Xamarin.Forms;

namespace TemperatureConverter
{
    public partial class SecondScreen : ContentPage
    {
        public SecondScreen(double fahrenheit)
        {
            InitializeComponent();
            fahrenheitLabel.Text = $"{fahrenheit} °F";
        }
    }
}
