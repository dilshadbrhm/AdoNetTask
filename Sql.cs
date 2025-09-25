using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNetTask
{
    internal class Sql
    {
        private readonly string _connection = "Server=.;Database=Students;Trusted_Connection=True;";

        public int ExecuteCommand(string query)
        {
            int result = 0;
            SqlConnection conn = new SqlConnection(_connection);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine($"SQL error: {e.Message}");
            }
            finally
            {
                conn.Close();
            }
            return result;
        }
    }
}

