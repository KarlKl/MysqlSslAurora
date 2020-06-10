using System;
using MySql.Data.MySqlClient;

namespace MysqlSslAurora
{
    public static class Program
    {
        public static void Main()
        {
            var connectionString = "Server=xxx;Database=xxx;Uid=xxx;Password=xxx;SslMode=VerifyFull;SslCa=rds-combined-ca-bundle.pem";
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new MySqlCommand("SELECT field FROM table;", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                            Console.WriteLine(reader.GetString(0));
                    }
                }
            }
        }
    }
}
