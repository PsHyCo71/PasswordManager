using Microsoft.Data.Sqlite;
using PasswordManager.Services;
namespace PasswordManager.Core;
public class Program
{
    public static SqliteConnection? connectionPw;
    public static void Main()
    {
        SQLitePCL.Batteries_V2.Init();

        connectionPw = new SqliteConnection("Data Source=src/db/MasterKey.db");
        connectionPw.Open();
        MasterPassword.CheckFirstBoot();
        while (true)
        {
            Cli.Startup();
        }
    }
}