using Microsoft.Data.SqlClient;

namespace recognitionProj
{
    public class DatabaseHandler
    {
        // Private field to store the connection string
        private string _connectionString;

        // Constructor to initialize connection string
        public DatabaseHandler(string connectionString)
        {
            _connectionString = connectionString;
        }

    
        

        // You can add more methods to interact with the database (insert, update, etc.)
        public void Query(string query)//manual query
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
                catch (SqlException ex)
                {
                    // Handle exceptions
                    throw new Exception("Database query failed", ex);
                }
            }
        }


        // Method to close the connection (you can call this in your app)
        public void CloseConnection() {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Close();
                    // Handle any required operations when connection is closed
                }
                catch (SqlException ex)
                {
                    // Handle exceptions
                    throw new Exception("Database connection closing failed", ex);
                }
            }
        }
    }
}
