using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace SQLiteDemo
{
    // this also acts as the definition of the Todo table in the database
    public class ToDoItem
    {

        // define a primary key
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        // properties
        public string Title { get; set; }
        public bool IsHighPriority { get; set; }

        // mandatory: When working with SQLite, you must
        // provide an empty, no-argument constructor
        public ToDoItem()
        {
        }

        // this is the constructor that will be used to
        // create new items
        public ToDoItem(string title, bool isHighPriority)
        {
            this.Title = title;
            this.IsHighPriority = isHighPriority;
        }

        public override string ToString()
        {
            return $"Id: {this.Id}, Title: {this.Title}, High Priority: {this.IsHighPriority}";
        }
    }
}
