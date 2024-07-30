using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Week2XamarinApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            myImage.Source = ImageSource.FromResource("Week2XamarinApp.images.robot.jpg");

        }

        void Button_Clicked(object sender, EventArgs e)
        {
            Console.WriteLine("Button Clicked!");

            string name = txtName.Text;
            string age = txtAge.Text;

            if(Int32.TryParse(age, out int tempAge))
            {
                int updtAge = tempAge + 5;
                lblResult.Text = $"Hi {name}, you are {age} years old and you will be {updtAge} in 5 years.";
            }
            else { lblResult.Text = "Could not convert from string to int: age"; }

            
        }
    }

}
