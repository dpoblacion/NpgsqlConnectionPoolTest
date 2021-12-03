using System;
using Npgsql;
using Xunit;

namespace NpgsqlConnectionPoolTest
{
    public class UnitTest1
    {
        [Fact]
        public async void Test1()
        {
            var connString = "Server=localhost;Database=test;Username=test;Password=test;Maximum Pool Size=5";

            await using var conn = new NpgsqlConnection(connString);
            await conn.OpenAsync();

            Console.WriteLine(DateTime.Now);

            // Insert some data
            await using (var cmd = new NpgsqlCommand("select pg_sleep(15);", conn))
            {
                await cmd.ExecuteNonQueryAsync();
            }

            Console.WriteLine(DateTime.Now);
        }
    }
}
