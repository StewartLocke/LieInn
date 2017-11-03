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
        static void Main(string[] args)
        {
        }

        private void NonQuery(String sqlCommandText)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.CommandText = sqlCommandText;
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
    }
}
