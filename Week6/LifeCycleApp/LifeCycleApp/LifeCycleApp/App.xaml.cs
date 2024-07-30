using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LifeCycleApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            Console.WriteLine("+++++ APP: Calling MainPage()");
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            Console.WriteLine("+++++ APP: Calling OnStart()");
        }

        protected override void OnSleep()
        {
            Console.WriteLine("+++++ APP: Calling OnSleep()");
        }

        protected override void OnResume()
        {
            Console.WriteLine("+++++ APP: Calling OnResume()");
        }
    }
}
