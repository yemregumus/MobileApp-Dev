using System.Collections.Generic;
using Xamarin.Forms;

namespace ShoppingList
{
    public partial class SummaryPage : ContentPage
    {
        public SummaryPage(List<string> items)
        {
            InitializeComponent();
            itemsListView.ItemsSource = items;
        }
    }
}
