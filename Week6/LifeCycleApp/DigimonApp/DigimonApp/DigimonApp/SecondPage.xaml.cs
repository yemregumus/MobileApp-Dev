using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net.Http;
using Newtonsoft.Json;

namespace DigimonApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SecondPage : ContentPage
    {
        public SecondPage()
        {
            InitializeComponent();
        }

        async void Button_Clicked(System.Object sender, System.EventArgs e) {

            string keyword = txtSearch.Text;
            Console.WriteLine($"Search button pressed:{keyword}");

            string API_URL = $"https://www.themealdb.com/api/json/v1/1/search.php?s={keyword}";
            Console.WriteLine($"API_URL is: {API_URL}");

            HttpClient client = new HttpClient();
            string resultFromAPI = await client.GetStringAsync(API_URL);

            MealsDbResponse response = JsonConvert.DeserializeObject<MealsDbResponse>(resultFromAPI);

            List<Recipe> recipeList = response.RecipeList;
            Console.WriteLine($"Number of recipes is: {recipeList.Count}");

            lvlRecipes.ItemsSource = recipeList;
        }

    }
}