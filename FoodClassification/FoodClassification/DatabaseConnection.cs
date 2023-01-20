using System;
using System.Data.SqlClient;

namespace FoodClassification
{
	public static class DatabaseConnection
    {
        public static SqlConnection Connection()
        {
            string connectionString = @"Data Source=" + "SERVER_NAME" + ";Initial Catalog=" + "FoodPlannerDb";
            //create instanace of database connection
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                return conn;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                return null;
            }
            finally
            {
                //conn.Close();
            }
        }
    }
}
