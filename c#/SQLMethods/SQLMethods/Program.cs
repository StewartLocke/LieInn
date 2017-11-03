using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLMethods
{
    class Program
    {
        static String connectionString= @"Data Source=JOHN\SQLEXPRESS;Initial Catalog = HotelDB; Integrated Security = True";
        
        static void Main(string[] args)
        {
            //NonQuery("SELECT * FROM Bookings");
            DataSet ds =
            Query("SELECT * FROM Bookings");
        }

        private static  void NonQuery(String sqlNonQuery)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.CommandText = sqlNonQuery;
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.Text;

                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                    Console.WriteLine("Details Updated");
                }
            }
            catch(SqlException e)
            {
                Console.WriteLine("SQL EXCEPTION: "+ e);
            }
        }

        private static DataSet Query(String sqlQuery)
        {
            DataSet dataset = new DataSet();
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    if(sqlConnection.State == ConnectionState.Closed)
                    {
                        sqlConnection.Open();
                    }
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.CommandText = sqlQuery;
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.Text;
                    SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                    adapter.Fill(dataset);
                    Console.WriteLine("Test");
                    return dataset;
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine("SQL EXCEPTION: " + e);
                return dataset;
            }
        }
    }
}
