/*
 Student name                               : Yunus Emre Gumus
 Student number                             : 150331197
 Course                                     : MAP526
 Section                                    : NZA
 Assignment name                            : Assignment 1
 Due date                                   : Friday, May 31st – 11:59pm
 Date handed                                : Friday, May 31st
 Preferred mobile platform to run the app   : Pixel 2 Pie 9.0 - API 28
 
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace UtilityBillCalculator
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            // Event handler for when the province picker selection changes
            provincePicker.SelectedIndexChanged += ProvincePicker_SelectedIndexChanged;
        }

        // Event handler for province picker selection changes
        private void ProvincePicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            // If British Columbia is selected, enable and lock the renewable switch
            if (provincePicker.SelectedItem != null && provincePicker.SelectedItem.ToString() == "British Columbia (BC)")
            {
                renewableSwitch.IsToggled = true;
                renewableSwitch.IsEnabled = false;
            }
            else
            {
                renewableSwitch.IsToggled = false;
                renewableSwitch.IsEnabled = true;
            }
        }

        // Event handler for Calculate button click
        private void OnCalculateClicked(object sender, EventArgs e)
        {
         
            errorLabel.IsVisible = false; // Hide the error label initially

            // Validate input fields
            if (string.IsNullOrWhiteSpace(txtDayUse.Text) ||
                string.IsNullOrWhiteSpace(txtEveningUse.Text) ||
                provincePicker.SelectedItem == null)
            {
                errorLabel.Text = "You must enter valid usage values.";
                errorLabel.IsVisible = true;
                return;
            }

            // Validate numeric input
            if (!double.TryParse(txtDayUse.Text, out double dayUsage) ||
                !double.TryParse(txtEveningUse.Text, out double eveningUsage))
            {
                errorLabel.Text = "Please enter valid numeric values for usage.";
                errorLabel.IsVisible = true;
                return;
            }

            // Define usage rates
            double daytimeRate = 0.314;
            double eveningRate = 0.186;

            // Calculate charges
            double daytimeCharge = CalculateCharge(dayUsage, daytimeRate);
            double eveningCharge = CalculateCharge(eveningUsage, eveningRate);
            double totalUsageCharge = CalculateTotalUsageCharge(daytimeCharge, eveningCharge);

            // Get province and calculate taxes and rebates
            string province = provincePicker.SelectedItem.ToString();
            double salesTax = CalculateSalesTax(totalUsageCharge, province);
            double environmentalRebate = CalculateEnvironmentalRebate(totalUsageCharge, renewableSwitch.IsToggled);

            // Calculate total bill
            double totalBill = CalculateTotalBill(totalUsageCharge, salesTax, environmentalRebate);

            // Update labels with calculation results
            UpdateResultLabels(daytimeCharge, eveningCharge, totalUsageCharge, salesTax, environmentalRebate, totalBill);

            // Show the results
            resultsStack.IsVisible = true;
        }

        // Event handler for Reset button click
        private void OnResetClicked(object sender, EventArgs e)
        {
            // Reset input fields and switch
            provincePicker.SelectedItem = null;
            txtDayUse.Text = string.Empty;
            txtEveningUse.Text = string.Empty;
            renewableSwitch.IsToggled = false;
            renewableSwitch.IsEnabled = true;

            // Hide results and error message
            resultsStack.IsVisible = false;
            errorLabel.IsVisible = false;
        }

        // Method to get the sales tax rate based on the province
        private double GetSalesTaxRate(string province)
        {
            switch (province)
            {
                case "Alberta (AB)":
                    return 0.0;
                case "British Columbia (BC)":
                    return 0.12;
                case "Ontario (ON)":
                    return 0.13;
                case "Newfoundland & Labrador (NL)":
                    return 0.15;
                default:
                    return 0.0;
            }
        }

        // Method to calculate charge based on usage and rate
        private double CalculateCharge(double usage, double rate)
        {
            return usage * rate;
        }

        // Method to calculate the total usage charge
        private double CalculateTotalUsageCharge(double daytimeCharge, double eveningCharge)
        {
            return daytimeCharge + eveningCharge;
        }

        // Method to calculate the sales tax based on total usage charge and province
        private double CalculateSalesTax(double totalUsageCharge, string province)
        {
            double salesTaxRate = GetSalesTaxRate(province);
            return totalUsageCharge * salesTaxRate;
        }

        // Method to calculate the environmental rebate
        private double CalculateEnvironmentalRebate(double totalUsageCharge, bool isUsingRenewable)
        {
            return isUsingRenewable ? totalUsageCharge * 0.095 : 0;
        }

        // Method to calculate the total bill amount
        private double CalculateTotalBill(double totalUsageCharge, double salesTax, double environmentalRebate)
        {
            return totalUsageCharge + salesTax - environmentalRebate;
        }

        // Method to update the result labels with calculation results
        private void UpdateResultLabels(double daytimeCharge, double eveningCharge, double totalUsageCharge, double salesTax, double environmentalRebate, double totalBill)
        {
            daytimeChargeLabel.Text = $"Daytime Usage Charges: {daytimeCharge:C}";
            eveningChargeLabel.Text = $"Evening Usage Charges: {eveningCharge:C}";
            totalUsageChargeLabel.Text = $"Total Usage Charge: {totalUsageCharge:C}";
            salesTaxLabel.Text = $"Sales Tax (%{100 * GetSalesTaxRate(provincePicker.SelectedItem.ToString())}): {salesTax:C}";
            environmentalRebateLabel.Text = $"Environmental Rebate: -{environmentalRebate:C}";
            totalBillLabel.Text = $"You must pay: {totalBill:C}";
        }
    }
}
