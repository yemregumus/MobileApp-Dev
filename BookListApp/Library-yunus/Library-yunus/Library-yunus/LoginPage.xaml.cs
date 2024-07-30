using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Library_yunus
{
    // Partial class for LoginPage, inheriting from ContentPage
    public partial class LoginPage : ContentPage
    {
        // Constructor initializes the component
        public LoginPage()
        {
            InitializeComponent();
        }

        // Event handler for the login button click event
        async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            // Retrieve the entered username and password
            string username = usernameEntry.Text;
            string password = passwordEntry.Text;

            // Check if the username or password fields are empty
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                errorLabel.Text = "ERROR: Username or password fields cannot be empty.";
                errorLabel.IsVisible = true;
                return;
            }
            // Check for hardcoded valid credentials
            else if ((username == "peter" && password == "1234") ||
                    (username == "mary" && password == "0000"))
            {
                // Navigate to Books List page if credentials are valid
                await Navigation.PushAsync(new BooksListPage(username));
            }
            else
            {
                // Display an error message if the credentials are invalid
                errorLabel.Text = "Invalid username or password.";
                errorLabel.IsVisible = true;
            }
        }

        // Override the OnAppearing method to reset the fields when the page appears
        protected override void OnAppearing()
        {
            base.OnAppearing();
            // Clear the username and password fields
            usernameEntry.Text = string.Empty;
            passwordEntry.Text = string.Empty;
            // Clear the error label
            errorLabel.Text = string.Empty;
            errorLabel.IsVisible = false;
        }
    }
}
