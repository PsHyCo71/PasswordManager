using System;
using System.Data;
using System.Runtime.InteropServices;
using Microsoft.Data.Sqlite;
using Microsoft.VisualBasic;
namespace PasswordManager.data;

public class DatabaseService
{
    public static void InizializeDatabase()
    {
        using var connection = new SqliteConnection("Data Source=Data/passwords.db");
        connection.Open();
        SqliteCommand command = new SqliteCommand();
        command.CommandText = "CREATE TABLE IF NOT EXITS passwords = (" +
                                        "Id INTEGER PRIMARY KEY AUTOINCREMENT," +
                                        "Auth TEXT NOT NULL," +
                                        "Site TEXT NOT NULL," +
                                        "EncryptedPassword, );";
        command.ExecuteNonQuery();
    }
}