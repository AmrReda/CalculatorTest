using System;
using System.Data.SqlClient;
using CalculatorTest.DataAccess.Models;
using Microsoft.Extensions.Options;

namespace CalculatorTest.DataAccess
{
    public class DbDiagnosticsNoEF : IDiagnostics
    {
        private readonly CalcualtorDatabaseConfig _configOptions;

        public DbDiagnosticsNoEF(IOptions<CalcualtorDatabaseConfig> configOptions)
        {
            _configOptions = configOptions.Value;
        }


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
            string connectionString = _configOptions.ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);
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