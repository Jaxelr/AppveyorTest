using System;
using System.Data.SqlClient;
using Xunit;

namespace sqlserver2019buildtest
{
    public class AppVeyorTest
    {
        [Fact]
        public void AppVeyorTest_Only()
        {
            string connectionString = Environment.GetEnvironmentVariable("Sql_Connection");

            Console.WriteLine($"The environment variable Sql_Connection is defined as: {connectionString}");

            var connection = new SqlConnection(connectionString);
            
            connection.Open();

            var command = connection.CreateCommand();

            command.CommandText = "SELECT 1";

            int result = 0;
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    result = reader.GetInt32(0);
                }
            }

            Assert.Equal(1, result);
        }
    }
}