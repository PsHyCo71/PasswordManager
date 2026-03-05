using System;
using Microsoft.Data.Sqlite;
using PasswordManager.Data;
namespace PasswordManager.Core;
public class Program
{
    public static void Main()
    {
        DatabaseInitializer.InitializeDatabase();
    }
}