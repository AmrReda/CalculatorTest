using System;
using System.Data.SqlClient;
using CalculatorTest.DataAccess.Models;

namespace CalculatorTest.DataAccess
{
    public class DbDiagnosticsNoEF : IDiagnostics
    {
        public void LogInformation(string message)
        {
            string sqlString = "INSERT INTO " +
                               "Logs " +
                               "(" +
                               "createdDate," +
                               "verbose," +
                               "message)" +
                               "VALUES " +
                               "(" +
                               "@l_createdDate," +
                               "@l_verbose," +
                               "@l_message)";
            string s = ConfigurationManager.ConnectionStrings["CalculatorContext2"].ConnectionString;
            SqlConnection con = new SqlConnection(s);
            SqlCommand cmd = new SqlCommand(sqlString, con);
            cmd.Parameters.AddWithValue("@l_createdDate", DateTime.UtcNow);
            cmd.Parameters.AddWithValue("@l_verbose", Verbose.Information.ToString());
            cmd.Parameters.AddWithValue("@l_message", message);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void LogError(string message)
        {
            throw new System.NotImplementedException();
        }
    }
}