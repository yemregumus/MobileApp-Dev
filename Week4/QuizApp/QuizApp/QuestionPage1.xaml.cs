using System;
using Xamarin.Forms;

namespace QuizApp
{
    public partial class QuestionPage1 : ContentPage
    {
        public QuestionPage1()
        {
            InitializeComponent();
        }

        private async void OnNextClicked(object sender, EventArgs e)
        {
            string selectedAnswer = null;
            foreach (var child in Answers.Children)
            {
                if (child is RadioButton radioButton && radioButton.IsChecked)
                {
                    selectedAnswer = radioButton.Content.ToString();
                    break;
                }
            }

            if (string.IsNullOrEmpty(selectedAnswer))
            {
                await DisplayAlert("Error", "Please select an answer", "OK");
                return;
            }

            var quizData = new QuizData { Answer1 = selectedAnswer };
            await Navigation.PushAsync(new QuestionPage2(quizData));
        }
    }
}
