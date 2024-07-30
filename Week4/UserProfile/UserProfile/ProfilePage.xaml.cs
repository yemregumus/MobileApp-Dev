using System;
using Xamarin.Forms;

namespace UserProfile
{
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage(string name, string email, string profilePictureUrl)
        {
            InitializeComponent();
            nameLabel.Text = name;
            emailLabel.Text = email;
            profileImage.Source = new UriImageSource
            {
                Uri = new Uri(profilePictureUrl),
                CachingEnabled = false
            };
        }
    }
}
