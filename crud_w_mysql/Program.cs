using System;
using System.Collections.Generic;
using DbConnection;

namespace ConsoleApplication
{
    public class Program
    {
        // Build a Read function that displays all current users information when the app start and after every insert
        public static void Read()
        {
            List<Dictionary<string, object>> Users = DbConnector.Query("SELECT first_name, last_name, favoriteNum from Users");
            foreach (Dictionary<string, object> user_item in Users)
            {
                System.Console.WriteLine("First Name: " + user_item["first_name"]);
                System.Console.WriteLine("Last Name: " + user_item["last_name"]);
                System.Console.WriteLine("Favorite Number: " + user_item["favoriteNum"]);
                System.Console.WriteLine();
            }
        }
        // Build a "create" function that accepts input and create a new User row
        public static void Create()
        {
            
            System.Console.WriteLine("Creating new user...");
            System.Console.WriteLine("What's the user's first name?");
            string first_name = Console.ReadLine();
            System.Console.WriteLine("What's the user's last name?");
            string last_name = Console.ReadLine();
            System.Console.WriteLine("What's the user's favorite number?");
            string fav_num = Console.ReadLine();
            DbConnector.Execute($"INSERT INTO Users (first_name, last_name, favoriteNum) VALUES ('{first_name}', '{last_name}', {fav_num})");
            Read();
        }
        // Build an Update function that when you specify a User Id will allow you to update all prompted rows
        public static void Update(int id)
        {
            System.Console.WriteLine("Updating user with id = " + id + "...");
            System.Console.WriteLine("What's the updated favorite number?");
            string fav_num = Console.ReadLine();
            DbConnector.Execute($"UPDATE Users SET favoriteNum={fav_num} WHERE id={id}");
            Read();
        }
        // Build a Delete function that will remove a user with the ID specified
        public static void Delete(int id)
        {
            System.Console.WriteLine("Deleting user with id=" + id);
            System.Console.WriteLine("Are you sure you want to delete? [y/n]");
            string input = Console.ReadLine();
            if (input == "y")
            {
                DbConnector.Execute($"DELETE from Users WHERE id={id}");
                Read();
            }
            else
            {
                return;
            }
        }
        public static void Main(string[] args)
        {
            Read();
            Delete(3);
        }
    }
}
