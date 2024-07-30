using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LifeCycleApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            Console.WriteLine("+++++ MainPage.xaml: Calling the MainPage constructor()");
            InitializeComponent();
            Console.WriteLine("+++++ MainPage.xaml: Done with MainPage constructor()");
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Console.WriteLine("+++++ MainPage.xaml: OnAppearing() function called");
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            Console.WriteLine("+++++ MainPage.xaml: OnDisappearing() function called");
        }

        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new SecondScreen());
        }
    }
}
