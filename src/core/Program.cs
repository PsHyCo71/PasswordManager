using System;
using Microsoft.Data.Sqlite;
using PasswordManager.Db;
namespace PasswordManager.Core;
public class Program
{
    public static void Main()
    {
        DbInitializer.InitializeDatabase();
    }
}