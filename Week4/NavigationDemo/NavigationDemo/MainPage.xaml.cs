using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NavigationDemo
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {

            string nameFromUI = name.Text;
            int ageFromUI = int.Parse(age.Text);
            bool canVoteFromUI = canVote.IsToggled;

            Person p = new Person(nameFromUI, ageFromUI, canVoteFromUI);

            await Navigation.PushAsync(new SecondPage(p));
        }
    }
}