using System;
using Microsoft.Data.Sqlite;
namespace PasswordManager.Db;

public class DbPasswords
{
    public static void InitializeTables()
    {
        InitializeTablePasswords();
        InitializeTableMasterKey();
    }
    
    public static void InitializeTablePasswords()
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

    public static void InitializeTableMasterKey()
    {
        using var connection = new SqliteConnection("Data Source=src/db/passwords.db");
        connection.Open();
        using var command = connection.CreateCommand();
        command.CommandText = "CREATE TABLE IF NOT EXISTS MasterKey (" +
                                    "Id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                                    "Salt BLOB NOT NULL, " +
                                    "Hash BLOB NOT NULL);";
        command.ExecuteNonQuery();
    }
}