using System;
using SQLite;
using System.IO;

using System.Threading.Tasks;
using System.Collections.Generic;

namespace SQLiteDemo
{
    public class MyDatabase
    {

        // 1. Define a property that represents the connection to the database
        // - C# property modifier
        // - only the constructor can modify the value of this property
        // (no other methods in the class can modify it)
        readonly SQLiteAsyncConnection dbConnection;

        public MyDatabase()
        {
            // Configure the connection

            // - specifying the name of the database file
            string databasePath = Path.Combine(Xamarin.Essentials.FileSystem.AppDataDirectory, "TodoDatabase.db");
            Console.WriteLine($"++++++ Database path: {databasePath}");

            // - specify "where" on the device the file will be saved
            dbConnection = new SQLiteAsyncConnection(databasePath);

            // Create the table (based on the TodoItem)
            dbConnection.CreateTableAsync<ToDoItem>().Wait();

            // Done!
            Console.WriteLine($"++++++ Database table created!");
        }

        // CRUD operations
        public async Task<int> AddItem(ToDoItem itemToAdd)
        {
            // INSERT INTO TodoItems (...,...,..,)
            int numRowsAdded = await dbConnection.InsertAsync(itemToAdd);
            return numRowsAdded;
        }

        //get everything from the table
        public async Task<List<ToDoItem>> GetAllItems()
        {
            List<ToDoItem> resultsList = await dbConnection.Table<ToDoItem>().ToListAsync(); //similar to select * from 
            return resultsList;
        }

        //get an item from the table by its primary key
        public async Task<ToDoItem> GetItemById(int id)
        {
            ToDoItem result= await dbConnection.GetAsync<ToDoItem>(id); //similar to select id from items where itemId=id
            return result;
        }

        //get items based on a manual sql query
        public async Task<List<ToDoItem>> GetItemsByPriority(bool priority)
        {
            List<ToDoItem> results = await dbConnection.QueryAsync<ToDoItem>("SELECT * FROM ToDoItem WHERE IsHighPriority = ?", priority);  
            return results;
        }

        //update an existing item
        public async Task<int> UpdateItem(ToDoItem item)
        {
            return await dbConnection.UpdateAsync(item);
            
        }

        //delete an existing item
        public async Task<int> DeleteItemById(int id)
        {
            return await dbConnection.DeleteAsync<ToDoItem>(id);

        }
    }
}