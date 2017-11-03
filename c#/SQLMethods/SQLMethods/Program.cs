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
        String connectionString;
        DataSet dataset;
        static void Main(string[] args)
        {
        }

        private void NonQuery(String sqlNonQuery)
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
                }
            }
            catch(SqlException e)
            {
                Console.WriteLine("SQL EXCEPTION: "+ e);
            }
        }

        private DataSet Query(String sqlQuery)
        {
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
