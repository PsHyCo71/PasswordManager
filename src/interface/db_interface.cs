using System;
using Microsoft.Data.Sqlite;
namespace PasswordManager.Interface;
public class DbInterface
{
    public int Id { get; set;}
    public string? Username { get; set;}
    public string? Email { get; set;}
    public string URL { get; set;} = "";    //TODO: fix nullable error
    public string Password { get; set;} = "";   //TODO: fix nullable error
    public byte[] Salt { get; set; } = {};
    public byte[] Hash { get; set; } = {};

}