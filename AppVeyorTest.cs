using System;
using System.Data.SqlClient;
using Xunit;

namespace sqlserver2019buildtest
{
    public class AppVeyorTest
    {
        [Fact]
        public void AppVeyorTest_SqlServer()
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

        [Fact]
        public void AppVeyorTest_MySql()
        {
            string connectionString = Environment.GetEnvironmentVariable("MySql_Connection");

            Console.WriteLine($"The environment variable MySql_Connection is defined as: {connectionString}");

            //var connection = new MySql.Data.MySqlClient.MySqlConnection(connectionString);
            var connection = new MySql.Data.MySqlClient.MySqlConnection("Server=127.0.0.1;Port=3306;Database=test;User Id=root;Password=Password12!");

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