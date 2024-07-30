using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using System.Linq;
using System.IO;
using System.Threading.Tasks;

namespace Library_yunus
{
    // Main Application class for the Library_yunus app
    public partial class App : Application
    {
        // Static variable to hold the database path
        public static string DatabasePath;

        // Constructor initializes the component and sets the main page to the LoginPage wrapped in a NavigationPage
        public App()
        {
            InitializeComponent();

            // Set the main page of the application to the LoginPage wrapped in a NavigationPage
            // The NavigationPage provides a navigation stack, allowing for navigation between pages
            MainPage = new NavigationPage(new LoginPage());
        }

        protected async override void OnStart()
        {
            // Set the database path to a file in the local application data folder
            DatabasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Library_yunus.db3");
            var db = new AppDatabase(DatabasePath);

            // Clear the database by deleting all existing books
            var existingBooks = await db.GetBooksAsync();
            if (existingBooks.Any())
            {
                foreach (var book in existingBooks)
                {
                    await db.DeleteBookAsync(book);
                }
            }

            // Prepopulate the database with books
            await db.SaveBookAsync(new Book { ISBN = "1234567890", Title = "Verity", Author = "Colleen Hoover" });
            await db.SaveBookAsync(new Book { ISBN = "0987654321", Title = "Dreamland", Author = "Nicholas Sparks" });
            await db.SaveBookAsync(new Book { ISBN = "9876543210", Title = "The Golden Enclaves", Author = "Naomi Novik" });
            await db.SaveBookAsync(new Book { ISBN = "0123456789", Title = "Lucy By The Sea", Author = "Elizabeth Strout" });
            await db.SaveBookAsync(new Book { ISBN = "0123456987", Title = "How to Stop Worrying and Start Living", Author = "Dale Carnegie" });
        }
        protected override void OnSleep()
        {
        
        }   
        protected override void OnResume()
        {
           
        }
    }
}
