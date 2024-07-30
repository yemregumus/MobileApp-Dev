using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LifeCycleApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SecondScreen : ContentPage
    {
        public SecondScreen()
        {
            Console.WriteLine("+++++ SecondScreen.xaml: Calling the MainPage constructor()");
            InitializeComponent();
            Console.WriteLine("+++++ SecondScreen.xaml: Done with MainPage constructor()");
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Console.WriteLine("+++++ SecondScreen.xaml: OnAppearing() function called");
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            Console.WriteLine("+++++ SecondScreen.xaml: OnDisappearing() function called");
        }
    }
}