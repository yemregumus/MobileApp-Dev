using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Net.Http;
using Newtonsoft.Json;


namespace DigimonApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            // Right before the screen is displayed to the user:
            // - Get the data from the API
            HttpClient client = new HttpClient();
            string resultFromAPI = await client.GetStringAsync("https://digimon-api.vercel.app/api/digimon");

            // - Convert it to a list of digimon objects
            Console.WriteLine(resultFromAPI);
            // - Show that list of digimon objects in the listview
            // - Convert it to a list of digimon objects
            List<Digimon> digimonList = JsonConvert.DeserializeObject<List<Digimon>>(resultFromAPI);
            Console.WriteLine($"Number of digimon found: {digimonList.Count}");

            // - Show that list of digimon objects in the listview
            lvDigimon.ItemsSource = digimonList;
        }

    }
}
