using System;
using Microsoft.Data.Sqlite;
namespace PasswordManager.Db;

public class DbInitializer
{
    public static void InitializeDatabase()
    {
        using var connection = new SqliteConnection("Data Source=src/db/passwords.db");
        connection.Open();
        using var command = connection.CreateCommand();
        command.CommandText = "CREATE TABLE IF NOT EXISTS Passwords (" +
                                    "Id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                                    "Username TEXT, " +
                                    "Email TEXT, " +
                                    "URL TEXT NOT NULL, " +
                                    "Password TEXT NOT NULL);";
        command.ExecuteNonQuery();
    }
}