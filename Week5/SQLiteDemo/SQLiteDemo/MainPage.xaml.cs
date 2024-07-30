using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SQLiteDemo
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            Console.WriteLine("+++++++ MainPage Constructor called");
        }

        async void AddItem_Clicked(System.Object sender, System.EventArgs e)
        {

            // 1. get item information from UI
            string title = txtItemName.Text;
            bool isHighPriority = swPriority.IsToggled;

            // 2. Build the todo list item
            ToDoItem itemToAdd = new ToDoItem(title, isHighPriority);

            // 3. Add it to the database
            int results = await App.MyDb.AddItem(itemToAdd);
            if (results == 0)
            {
                Console.WriteLine("++++ ERROR: Item could not be created");
            }
            else
            {
                Console.WriteLine("++++ Item added!");
            }

            // 4. Clear form fields and prepare for new input
            txtItemName.Text = "";
            swPriority.IsToggled = false;

        }

        async void Update_Clicked(System.Object sender, System.EventArgs e)
        {
            // 1. get item information from UI
            string idFromUI = txtItemId.Text;

            // attempt to convert to a number
            int id = -1;
            try
            {
                id = Int32.Parse(idFromUI);

            }
            catch(Exception)
            {
                lblResults.Text = "ERROR: You must enter a number for ID";
                return;
            }

            // 2. if we get to this point, then the user must have entered a numeric id

            // - find the item
            ToDoItem itemFromDb = null;
            try
            {
                itemFromDb = await App.MyDb.GetItemById(id);
            }  catch(Exception)
            {
                lblResults.Text = $"ERROR: Cannot find item with id: {id}";
                return;
            }



            // 3. if we get to this point, then we must have the object that should be updated

            // - get the updated values from the UI
            string updatedTitleFromUI = txtItemName.Text;
            bool updatedPriorityFromUI = swPriority.IsToggled;


            // 4. set the item's new values

            itemFromDb.Title = updatedTitleFromUI;
            itemFromDb.IsHighPriority = updatedPriorityFromUI;



            // 5. save the changes
            int rowsUpdated = await App.MyDb.UpdateItem(itemFromDb);
            if(rowsUpdated == 0)
            {
                lblResults.Text = $"ERROR: Update for the for {id} failed";
            }
            else
            {
                lblResults.Text = $"SUCCESS:Item {id} updated successfully!";
            }

            // 6. Clear form fields and prepare for new input
            txtItemName.Text = "";
            swPriority.IsToggled = false;
        }

        async void Delete_Clicked(System.Object sender, System.EventArgs e)
        {
            // 1. get item information from UI
            string idFromUI = txtItemId.Text;

            // attempt to convert to a number
            int id = -1;
            try
            {
                id = Int32.Parse(idFromUI);

            }
            catch (Exception)
            {
                lblResults.Text = "ERROR: You must enter a number for ID";
                return;
            }


            // if you reach this point, then you have a numeric id number

            // 2. delete from database
            int rowsDeleted = await App.MyDb.DeleteItemById(id);
            if (rowsDeleted == 0)
            {
                lblResults.Text = $"ERROR: Delete for the for {id} failed";
            }
            else
            {
                lblResults.Text = $"SUCCESS:Item {id} deleted successfully!";
            }


            // 3. Clear form fields and prepare for new input
            txtItemId.Text = "";

        }

        async void GetItemById_Clicked(System.Object sender, System.EventArgs e)
        {
            // 1. get item information from UI
            string idFromUI = txtItemId.Text;

            // attempt to convert to a number
            int id = -1;
            try
            {
                id = Int32.Parse(idFromUI);

            }
            catch (Exception)
            {
                lblResults.Text = "ERROR: You must enter a number for ID";
                return;
            }
            // if you reach this point, then you have a numeric id number

            // 3. Retrieve the data from the database
            try
            {
                ToDoItem item = await App.MyDb.GetItemById(id);
                lblResults.Text = item.ToString();
            }
            catch(Exception)
            {
                lblResults.Text = $"ERROR: Could not find an item with the specified ID {id}";
                return;
            }

            // 4. Clear all text fields and prepare for new input
            txtItemId.Text = "";
        }

        async void GetAll_Clicked(System.Object sender, System.EventArgs e)
        {
            // get items from database
            List<ToDoItem> results = await App.MyDb.GetAllItems();

            lvItems.ItemsSource = null;
            lvItems.ItemsSource = results;

        }

        async void GetItemsByPriority_Clicked(System.Object sender, System.EventArgs e)
        {
            // get toggle
            bool isHighPriority = swPriority.IsToggled;

            // get items from database
            List<ToDoItem> results = await App.MyDb.GetItemsByPriority(isHighPriority);

            lvItems.ItemsSource = null;
            lvItems.ItemsSource = results;

            // reset form fields
            swPriority.IsToggled = false;
        }
    }
}