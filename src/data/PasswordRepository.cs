using System;
using Microsoft.Data.Sqlite;
using PasswordManager.Models;
namespace PasswordManager.Data;

public class PasswordRepository
{   
    public static void AddPassword(string? username, string? email, string url, string encryptedPassword)
    {
        using var connection = new SqliteConnection("Data Source=src/data/passwords.db");
        connection.Open();
        using var command = new SqliteCommand("INSERT INTO Passwords (Username, Email, URL, EncryptedPassword)" +
                                                "VALUES (@username, @email, @url, @encryptedPassword)", connection);
        command.Parameters.AddWithValue("@username", username);
        command.Parameters.AddWithValue("@email", email);
        command.Parameters.AddWithValue("@url", url);
        command.Parameters.AddWithValue("@encryptedPassword", encryptedPassword);
        command.ExecuteNonQuery();
    }
}