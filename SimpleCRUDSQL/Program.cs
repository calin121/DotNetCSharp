using System;
using System.Collections.Generic;

namespace DbConnection
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            // Input for the Query
            // Query to get data from DB
            // Placed inside the code block where you want to query the database
            
            // // -- Delete and Query
            // string tableName = "users";
            // string columnId = "Id";
            // string idToDelete = "5";
            
            // string deleteAndQuery = $"DELETE FROM {tableName} WHERE {columnId} = {idToDelete}; SELECT * FROM {tableName};";
            
            // // List<Dictionary<string, object>> result = DbConnector.Query(deleteAndQuery);
            // foreach (Dictionary<string, object> item in DbConnector.Query(deleteAndQuery))
            // {
            //     System.Console.WriteLine(item["Id"]+" - "+item["LastName"] +", "+item["FirstName"]+" - who's favorite number is "+item["FavoriteNumber"]);
            // }

            // // -- Queries --
            // string tableName = "users";
            // string query = $"SELECT * FROM {tableName};";
            // foreach (Dictionary<string, object> item in DbConnector.Query(query))
            // {
            //     System.Console.WriteLine(item["Id"]+" - "+item["LastName"] +", "+item["FirstName"]+" - who's favorite number is "+item["FavoriteNumber"]);
            // }

            // -- Update Query --
            string tableName = "users";
            string column1 = "FirstName";
            string column2 = "LastName";
            string column3 = "FavoriteNumber";
            string column4 = "";
            string column5 = "";
            
            string value1 = "Marti";
            string value2 = "Lewis";
            string value3 = "55";
            string value4 = "";
            string value5 = "";

            string columnId = "Id";
            string idToUpdate = "6";
            

            string updateAndQuery = $"UPDATE {tableName} SET {column1} = '{value1}', {column2} = '{value2}', {column3} = '{value3}' WHERE {columnId} = '{idToUpdate}'; SELECT * FROM {tableName};";

            // System.Console.WriteLine(updateAndQuery);
            
            foreach (Dictionary<string, object> item in DbConnector.Query(updateAndQuery))
            {
                System.Console.WriteLine(item["Id"]+" - "+item["LastName"] +", "+item["FirstName"]+" - who's favorite number is "+item["FavoriteNumber"]);
            }

            // //or send a query with no return
            // // DbConnector.Execute("Some query with no expected return");

            // // string InputLine = Console.ReadLine();

            // string tableName = "users";
            // string fname = "Martin";
            // string lname = "Crystal";
            // int favnum = 2;
            // string dumb1 = "more others";
            // string dumb2 = "things";
            // string dumb3 = "more stuff and things";

            // string insertQuery = $"INSERT INTO users (FirstName, LastName, FavoriteNumber, Dummy1, Dummy2, Dummy3) VALUES ('{fname}', '{lname}', '{favnum}', '{dumb1}', '{dumb2}', '{dumb3}'); SELECT * FROM {tableName};";
            
            //  foreach (var item in DbConnector.Query(insertQuery))
            // {
            //     System.Console.WriteLine(item["Id"]+" - "+item["LastName"] +", "+item["FirstName"]+" - who's favorite number is "+item["FavoriteNumber"]);
            // }

            // // System.Console.WriteLine(insertQuery);

            // DbConnector.Execute(insertQuery);

        }
    }
}
