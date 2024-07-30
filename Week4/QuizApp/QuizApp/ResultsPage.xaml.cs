using System;
using Xamarin.Forms;

namespace QuizApp
{
    public partial class ResultsPage : ContentPage
    {
        public ResultsPage(QuizData quizData)
        {
            InitializeComponent();
            DisplayResults(quizData);
        }

        private void DisplayResults(QuizData quizData)
        {
            int score = 0;

            if (quizData.Answer1 == "Paris") score++;
            if (quizData.Answer2 == "4") score++;
            if (quizData.Answer3 == "Blue") score++;

            resultLabel.Text = $"Your Score: {score}/3\n\n" +
                $"Question 1: {quizData.Answer1} (Correct Answer: Paris)\n" +
                $"Question 2: {quizData.Answer2} (Correct Answer: 4)\n" +
                $"Question 3: {quizData.Answer3} (Correct Answer: Blue)";
        }

        private async void OnRestartQuizClicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }
    }
}
