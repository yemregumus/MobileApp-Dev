using System;
using Xamarin.Forms;

namespace QuizApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnStartQuizClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new QuestionPage1());
        }
    }
}
