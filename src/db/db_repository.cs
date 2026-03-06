using System.Dynamic;
using Microsoft.Data.Sqlite;
using PasswordManager.Models;
namespace PasswordManager.Db;

public class DbRepository
{   
    public static void InsertPassword(string? username, string? email, string url, string password)
    {
        using var connection = new SqliteConnection("Data Source=src/db/passwords.db");
        connection.Open();
        using var command = new SqliteCommand("INSERT INTO Passwords (Username, Email, URL, Password) " +
                                                "VALUES (@username, @email, @url, @password)", connection);
        command.Parameters.AddWithValue("@username", username);
        command.Parameters.AddWithValue("@email", email);
        command.Parameters.AddWithValue("@url", url);
        command.Parameters.AddWithValue("@password", password);
        command.ExecuteNonQuery();
    }

    public static void UpdatePassword(int id, string? username, string? email, string url, string password)
    {
        using var connection = new SqliteConnection("Data Source=src/db/passwords.db");
        connection.Open();
        using var command = new SqliteCommand("UPDATE Passwords " +
                                                "SET Username = @username, Email = @email, URL = @url, Password = @password " +
                                                "WHERE Id = @id", connection);
        command.Parameters.AddWithValue("@id", id);
        command.Parameters.AddWithValue("@username", username);
        command.Parameters.AddWithValue("@email", email);
        command.Parameters.AddWithValue("@url", url);
        command.Parameters.AddWithValue("@password", password);         
        command.ExecuteNonQuery();
    }

    public static void DeletePassword(int id)
    {
        using var connection = new SqliteConnection("Data Source=src/db/passwords.db");
        connection.Open();
        using var command = new SqliteCommand("DELETE FROM Passwords " +
                                                "WHERE Id = @id", connection);
        command.Parameters.AddWithValue("@id", id);
        command.ExecuteNonQuery();
    }

    public static List<DbInterface> SelectPassword(string search)
    {
        using var connection = new SqliteConnection("Data Source=src/db/passwords.db");
        connection.Open();
        using var command = new SqliteCommand("SELECT * FROM Passwords " +
                                                "WHERE URL LIKE @search " +
                                                "OR Username LIKE @search " +
                                                "OR Email LIKE @search", connection);
        command.Parameters.AddWithValue("@search", "%"+search+"%");
        using SqliteDataReader reader = command.ExecuteReader();

        List<DbInterface> results = new List<DbInterface>();

        while (reader.Read())
        {
            DbInterface entry = new DbInterface();
            entry.Id = (int)reader["Id"];
            entry.Username = (string?)reader["Username"];
            entry.Email = (string?)reader["Email"];
            entry.URL = (string)reader["URL"];
            entry.Password = (string)reader["Password"];

            results.Add(entry);
        }
        return results;
    }

    public static List<DbInterface> SelectAllPassword()
    {
        using var connection = new SqliteConnection("Data Source=src/db/passwords.db");
        connection.Open();
        using var command = new SqliteCommand("SELECT * FROM Passwords ", connection);
        using SqliteDataReader reader = command.ExecuteReader();

        List<DbInterface> results = new List<DbInterface>();

        while (reader.Read())
        {
            DbInterface entry = new DbInterface();
            entry.Id = (int)reader["Id"];
            entry.Username = (string?)reader["Username"];
            entry.Email = (string?)reader["Email"];
            entry.URL = (string)reader["URL"];
            entry.Password = (string)reader["Password"];

            results.Add(entry);
        }
        return results;
    }
}