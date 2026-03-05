using System;
using Microsoft.Data.Sqlite;
namespace PasswordManager.Models;
public class PasswordEntry
{
    public PasswordEntry(string URL, string EncryptedPassword)
    {
        this.URL = URL;
        this.EncryptedPassword = EncryptedPassword;
    }

    public int Id { get; set;}
    public string? Username { get; set;}
    public string? Email { get; set;}
    public string URL { get; set;}
    public string EncryptedPassword { get; set;}
}