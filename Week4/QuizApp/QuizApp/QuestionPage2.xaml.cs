using System;
using Xamarin.Forms;

namespace QuizApp
{
    public partial class QuestionPage2 : ContentPage
    {
        private QuizData quizData;

        public QuestionPage2(QuizData data)
        {
            InitializeComponent();
            quizData = data;
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

            quizData.Answer2 = selectedAnswer;
            await Navigation.PushAsync(new QuestionPage3(quizData));
        }
    }
}
