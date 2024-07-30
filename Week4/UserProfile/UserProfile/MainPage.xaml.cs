using System;
using Xamarin.Forms;

namespace UserProfile
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async void OnSubmitButtonClicked(object sender, EventArgs e)
        {
            string name = nameEntry.Text;
            string email = emailEntry.Text;
            string profilePictureUrl = profilePictureEntry.Text;

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(profilePictureUrl))
            {
                await DisplayAlert("Invalid Input", "Please enter all details.", "OK");
            }
            else
            {
                await Navigation.PushAsync(new ProfilePage(name, email, profilePictureUrl));
            }
        }
    }
}
