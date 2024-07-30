using System;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Timers;

namespace Library_yunus
{
    public partial class BooksListPage : ContentPage
    {
        private ObservableCollection<Book> books; // Collection of books to display in the ListView
        private string currentUsername; // Username of the current user
        private Book selectedBook; // The currently selected book

        // Constructor for the BooksListPage, initializes components and sets the welcome label text
        public BooksListPage(string username)
        {
            InitializeComponent();
            currentUsername = username;
            welcomeLabel.Text = $"Welcome, {currentUsername}!";
        }

        // Called when the page is appearing, loads the books from the database
        protected override void OnAppearing()
        {
            base.OnAppearing();
            LoadBooks();
        }

        // Asynchronously loads the books from the database and sets the ItemsSource of the ListView
        async void LoadBooks()
        {
            var db = new AppDatabase(App.DatabasePath);
            var loadedBooks = await db.GetBooksAsync();
            books = new ObservableCollection<Book>(loadedBooks);
            booksListView.ItemsSource = books;
        }

        // Event handler for when a book is selected in the ListView
        void OnBookSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            selectedBook = e.SelectedItem as Book;
            UpdateWarningLabel();
        }

        // Event handler for when a book is tapped in the ListView
        void OnBookTapped(object sender, ItemTappedEventArgs e)
        {
            selectedBook = e.Item as Book;
            UpdateWarningLabel();

            // Deselect item
            ((ListView)sender).SelectedItem = null;
        }

        // Updates the warning label based on the selected book's availability and borrower
        void UpdateWarningLabel()
        {
            if (selectedBook != null)
            {
                if (!selectedBook.IsCheckedOut)
                {
                    warningLabel.Text = $"{selectedBook.Title} is available.";
                }
                else if (selectedBook.Borrower == currentUsername)
                {
                    warningLabel.Text = "You have this book checked out!";
                }
                else
                {
                    warningLabel.Text = $"Sorry, {selectedBook.Title} is already checked out by {selectedBook.Borrower}.";
                }
            }
            else
            {
                warningLabel.Text = string.Empty;
            }
        }

        // Event handler for the checkout button click event in the context menu
        async void OnCheckoutClicked(object sender, EventArgs e)
        {
            if (selectedBook == null)
                return;

            if (selectedBook.IsCheckedOut)
            {
                await DisplayAlert("Error", $"{selectedBook.Title} cannot be checked out as it is checked out by {selectedBook.Borrower}.", "OK");
            }
            else
            {
                selectedBook.IsCheckedOut = true;
                selectedBook.Borrower = currentUsername;
                var db = new AppDatabase(App.DatabasePath);
                await db.SaveBookAsync(selectedBook);
                await DisplayAlert("Success", "Success! Done!", "OK");
                LoadBooks();
            }
        }

        // Event handler for the return button click event in the context menu
        async void OnReturnClicked(object sender, EventArgs e)
        {
            if (selectedBook == null)
                return;

            if (!selectedBook.IsCheckedOut)
            {
                await DisplayAlert("Error", $"{selectedBook.Title} cannot be returned.", "OK");
            }
            else if (selectedBook.Borrower != currentUsername)
            {
                await DisplayAlert("Error", $"{selectedBook.Title} cannot be returned as it is checked out by {selectedBook.Borrower}.", "OK");
            }
            else
            {
                selectedBook.IsCheckedOut = false;
                selectedBook.Borrower = string.Empty;
                var db = new AppDatabase(App.DatabasePath);
                await db.SaveBookAsync(selectedBook);
                await DisplayAlert("Success", "You have successfully returned the book.", "OK");
                LoadBooks();
            }
        }

        // Event handler for the back button click event, navigates back to the previous page
        async void OnBackButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }

}
