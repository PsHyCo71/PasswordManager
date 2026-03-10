using System;
using Microsoft.Data.Sqlite;
using PasswordManager.Core;
namespace PasswordManager.Db;

public class DbTables
{
    public static void InitializeTables()
    {
        InitializeTablePasswords();
        InitializeTableMasterKey();
    }

    public static void InitializeTablePasswords()
    {
        using var command = new SqliteCommand("CREATE TABLE IF NOT EXISTS Passwords (" +
                                                "Id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                                                "Username TEXT, " +
                                                "Email TEXT, " +
                                                "URL TEXT NOT NULL, " +
                                                "Password TEXT NOT NULL);", Program.connection);
        command.ExecuteNonQuery();
    }

    public static void InitializeTableMasterKey()
    {
        using var command = new SqliteCommand("CREATE TABLE IF NOT EXISTS MasterKey (" +
                                                "Id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                                                "Salt BLOB NOT NULL, " +
                                                "Hash BLOB NOT NULL);", Program.connection);
        command.ExecuteNonQuery();
    }
}