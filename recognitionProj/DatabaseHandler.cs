using Microsoft.Data.SqlClient;
using System.Data;

namespace recognitionProj;

public class DatabaseHandler//this class is to create the connection to the database
{
    // Private field to store the connection string
    private readonly string _connectionString;

    // Constructor to initialize connection string
    public DatabaseHandler(string connectionString)
    {
        _connectionString = connectionString;
    }


    

    // You can add more methods to interact with the database (insert, update, etc.)
    public void Query(string query)//manual query
    {
        using (SqlConnection connection = new(_connectionString))
        {
            try
            {
                connection.Open();
                using (SqlCommand command = new(query, connection))
                {
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
            catch (SqlException ex)
            {
                // Handle exceptions
                throw new Exception("Database query failed", ex);
            }
        }
    }

    public void InsertRecord(string tableName, string columns, string values)
    {
        string query = $"INSERT INTO {tableName} ({columns}) VALUES ({values})";

        using (SqlConnection connection = new(_connectionString))
        {
            try
            {
                connection.Open();
                using (SqlCommand command = new(query, connection))
                {
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
            catch (SqlException ex)
            {
                // Handle exceptions
                throw new Exception("Database insert operation failed", ex);
            }
        }
    }

    public void UpdateRecord(string tableName, string setValues, string condition)
    {
        string query = $"UPDATE {tableName} SET {setValues} WHERE {condition}";

        using (SqlConnection connection = new(_connectionString))
        {
            try
            {
                connection.Open();
                using (SqlCommand command = new(query, connection))
                {
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
            catch (SqlException ex)
            {
                // Handle exceptions
                throw new Exception("Database update operation failed", ex);
            }
        }
    }

    public void DeleteRecord(string tableName, string condition)
    {
        string query = $"DELETE FROM {tableName} WHERE {condition}";

        using (SqlConnection connection = new(_connectionString))
        {
            try
            {
                connection.Open();
                using (SqlCommand command = new(query, connection))
                {
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
            catch (SqlException ex)
            {
                // Handle exceptions
                throw new Exception("Database delete operation failed", ex);
            }
        }
    }

    public DataTable SelectRecords(string query)
    {
        DataTable dataTable = new();

        using (SqlConnection connection = new(_connectionString))
        {
            try
            {
                connection.Open();
                using (SqlCommand command = new(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        dataTable.Load(reader);
                    }

                }
                connection.Close();
            }
            catch (SqlException ex)
            {
                // Handle exceptions
                throw new Exception("Database select operation failed", ex);
            }
        }

        return dataTable;
    }





    //we can customize and make our own methods to interact with the database laters

}
