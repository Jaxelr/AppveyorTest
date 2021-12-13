using Npgsql;
using System.Data.SqlClient;
using Xunit;

namespace AppveyorTests;

public class AppVeyorTest
{
    [Fact]
    public void AppVeyorTest_SqlServer()
    {
        var connection = new SqlConnection("Server=127.0.0.1,1434;Database=master;User Id=sa;Password=P@ssword123;");

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
        var connection = new MySql.Data.MySqlClient.MySqlConnection("Server=127.0.0.1;Port=3308;Database=test;User Id=root;");

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
    public void AppVeyorTest_Postgres()
    {
        var connection = new NpgsqlConnection("Host=localhost;Port=5432;database=postgres;User ID=postgres;Password=postgres");

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