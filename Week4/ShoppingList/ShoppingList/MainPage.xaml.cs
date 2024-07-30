using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ShoppingList
{
    public partial class MainPage : ContentPage
    {
        List<string> items = new List<string>();

        public MainPage()
        {
            InitializeComponent();
        }

        void OnAddItemButtonClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(itemEntry.Text))
            {
                items.Add(itemEntry.Text);
                itemEntry.Text = string.Empty;
            }
            else
            {
                DisplayAlert("Invalid Input", "Please enter a valid item.", "OK");
            }
        }

        async void OnViewSummaryButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SummaryPage(items));
        }
    }
}
