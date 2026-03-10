using System;
using Microsoft.Data.Sqlite;
using PasswordManager.Db;
using PasswordManager.Services;
namespace PasswordManager.Core;
public class Program
{
    public static SqliteConnection? connection;
    public static void Main()
    {
        connection = new SqliteConnection("Data Source=src/db/passwords.db");
        connection.Open();
        MasterPassword.CheckFirstBoot();
        Cli.Startup();
    }
}