using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CountingApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        void BtnCountUp_Clicked(System.Object sender, System.EventArgs e)
        {
            Console.WriteLine("Count up clicked");

            setCountLabel("add");
        }

        void BtnCountDown_Clicked(System.Object sender, System.EventArgs e)
        {
            Console.WriteLine("Count down clicked");

            setCountLabel("sub");
        }

        void BtnInitialVal_Clicked(System.Object sender, System.EventArgs e)
        {
            Console.WriteLine("Initial value clicked");

            if (Int32.TryParse(count.Text, out int tempVal))
            {
                setCountLabel("init");
            }
            else
            {
                lblErr.Text = "Please enter a number";
            }
        }

        void setCountLabel(string op)
        {
            lblErr.Text = "";
            if (Int32.TryParse(lblCount.Text, out int val))
            {
                if (op == "add")
                {
                    lblCount.Text = $"{val + 1}";
                }
                else if (op == "sub")
                {
                    lblCount.Text = $"{val - 1}";
                }
                else if (op == "init")
                {
                    lblCount.Text = count.Text;
                    count.Text = "";
                }
            }
            else
            {
                lblErr.Text = "Could not convert string to int";
            }
        }
    }
}