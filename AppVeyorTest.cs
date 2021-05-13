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
            var connection = new SqlConnection("Server=(local)\\SQL2019;Database=master;User ID=sa;Password=Password12!");
            //var connection = new SqlConnection("Server=(local);Database=master;Trusted_Connection=true;");

            Console.WriteLine($"The environment variable Sql_Connection is defined as: {Environment.GetEnvironmentVariable("Sql_Connection")}");

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