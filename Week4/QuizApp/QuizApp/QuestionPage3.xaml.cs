using System;
using Xamarin.Forms;

namespace QuizApp
{
    public partial class QuestionPage3 : ContentPage
    {
        private QuizData quizData;

        public QuestionPage3(QuizData data)
        {
            InitializeComponent();
            quizData = data;
        }

        private async void OnFinishClicked(object sender, EventArgs e)
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

            quizData.Answer3 = selectedAnswer;
            await Navigation.PushAsync(new ResultsPage(quizData));
        }
    }
}
