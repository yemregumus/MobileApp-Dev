using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace NavigationDemo
{
    public partial class SecondPage : ContentPage
    {
        public SecondPage(Person p)
        {
            InitializeComponent();

            lblName.Text = $"Hello {p.Name}! You are {p.Age} years old and your voting status is: {p.CanVote}";
        }
    }
}