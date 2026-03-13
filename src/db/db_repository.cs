using Microsoft.Data.Sqlite;
using PasswordManager.Core;
using PasswordManager.Interface;
namespace PasswordManager.Db;

public class DbRepository
{
    public static void InsertPassword(SqliteConnection conn, string? username, string? email, string url, string password)
    {
        using var command = new SqliteCommand("INSERT INTO Passwords (Username, Email, URL, Password) " +
                                                "VALUES (@username, @email, @url, @password)", conn);
        command.Parameters.AddWithValue("@username", username);
        command.Parameters.AddWithValue("@email", email);
        command.Parameters.AddWithValue("@url", url);
        command.Parameters.AddWithValue("@password", password);
        command.ExecuteNonQuery();
    }

    public static void UpdatePassword(SqliteConnection conn, long id, string? username, string? email, string url, string password)
    {
        using var command = new SqliteCommand("UPDATE Passwords " +
                                                "SET Username = @username, Email = @email, URL = @url, Password = @password " +
                                                "WHERE Id = @id", conn);
        command.Parameters.AddWithValue("@id", id);
        command.Parameters.AddWithValue("@username", username);
        command.Parameters.AddWithValue("@email", email);
        command.Parameters.AddWithValue("@url", url);
        command.Parameters.AddWithValue("@password", password);
        command.ExecuteNonQuery();
    }

    public static void DeletePassword(SqliteConnection conn, long id)
    {
        using var command = new SqliteCommand("DELETE FROM Passwords " +
                                                "WHERE Id = @id", conn);
        command.Parameters.AddWithValue("@id", id);
        command.ExecuteNonQuery();
    }

    public static void DeleteAllPassword(SqliteConnection conn)
    {
        using var command = new SqliteCommand("DELETE FROM Passwords ", conn);
        command.ExecuteNonQuery();
    }

    public static void SaveMasterKey(byte[] salt, byte[] hash)
    {
        using var command = new SqliteCommand("INSERT INTO MasterKey (Salt, Hash)" +
                                                "VALUES (@salt, @hash)", Program.connectionPw);
        command.Parameters.AddWithValue("@salt", salt);
        command.Parameters.AddWithValue("@hash", hash);
        command.ExecuteNonQuery();
    }

    public static void GetMasterKey(out byte[] salt, out byte[] hash)
    {
        using var command = new SqliteCommand("SELECT * FROM MasterKey", Program.connectionPw);
        using SqliteDataReader reader = command.ExecuteReader();

        if (reader.Read())
        {
            salt = (byte[])reader["Salt"];
            hash = (byte[])reader["Hash"];
        }
        else
        {
            throw new Exception("Master password hasn't been created.");
        }
    }

    public static void SelectPassword(SqliteConnection conn, string search, List<DbInterface> results)
    {
        using var command = new SqliteCommand("SELECT * FROM Passwords " +
                                                "WHERE URL LIKE @search " +
                                                "OR Username LIKE @search " +
                                                "OR Email LIKE @search", conn);

        command.Parameters.AddWithValue("@search", "%" + search + "%");

        using SqliteDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            DbInterface entry = new DbInterface();
            entry.Id = reader.GetInt32(reader.GetOrdinal("Id"));
            entry.Username = (string?)reader["Username"];
            entry.Email = (string?)reader["Email"];
            entry.URL = (string)reader["URL"];
            entry.Password = (string)reader["Password"];

            results.Add(entry);
        }
    }

    public static void SelectAllPassword(SqliteConnection conn, List<DbInterface> results)
    {
        using var command = new SqliteCommand("SELECT * FROM Passwords", conn);
        using SqliteDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            DbInterface entry = new DbInterface();
            entry.Id = reader.GetInt32(reader.GetOrdinal("Id"));
            entry.Username = (string?)reader["Username"];
            entry.Email = (string?)reader["Email"];
            entry.URL = (string)reader["URL"];
            entry.Password = (string)reader["Password"];

            results.Add(entry);
        }
    }
}