using System;
using Microsoft.Data.Sqlite;
namespace PasswordManager.Data;

public class DatabaseInitializer
{
    public static void InitializeDatabase()
    {
        using var connection = new SqliteConnection("Data Source=src/data/passwords.db");
        connection.Open();
        using var command = connection.CreateCommand();
        command.CommandText = "CREATE TABLE IF NOT EXISTS Passwords (" +
                                    "Id INTEGER PRIMARY KEY AUTOINCREMENT," +
                                    "Username TEXT," +
                                    "Email TEXT," +
                                    "URL TEXT NOT NULL," +
                                    "EncryptedPassword TEXT NOT NULL);";
        command.ExecuteNonQuery();
    }
}