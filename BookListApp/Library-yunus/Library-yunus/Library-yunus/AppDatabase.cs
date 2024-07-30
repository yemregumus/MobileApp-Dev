using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Threading.Tasks;

namespace Library_yunus
{
    public class AppDatabase
    {
        // Async connection to the SQLite database
        readonly SQLiteAsyncConnection database;

        // Constructor initializes the SQLite connection and creates the Book table if it doesn't exist
        public AppDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Book>().Wait(); // Waits synchronously to ensure the table is created
        }

        // Retrieves all books from the database as a list
        public Task<List<Book>> GetBooksAsync()
        {
            return database.Table<Book>().ToListAsync();
        }

        // Saves a book to the database
        // If the book has an Id (i.e., it's already in the database), it updates the record
        // Otherwise, it inserts a new record
        public Task<int> SaveBookAsync(Book book)
        {
            if (book.Id != 0)
                return database.UpdateAsync(book);
            else
                return database.InsertAsync(book);
        }

        // Deletes a book from the database
        public Task<int> DeleteBookAsync(Book book)
        {
            return database.DeleteAsync(book);
        }
    }
}
