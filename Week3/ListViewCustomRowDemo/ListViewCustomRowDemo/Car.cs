using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;

namespace ListViewCustomRowDemo
{
    public class Car
    {
        public string Model { get; set; }
        public int Year { get; set; }
        public Car(string model, int year)
        {
            this.Model = model;
            this.Year = year;
        }

        public override string ToString()
        {
            return $"{this.Year} {this.Model}";
        }
    }
}
