using System.Runtime.InteropServices;
using Microsoft.Data.Sqlite;
using Microsoft.VisualBasic;
using PasswordManager.Db;
namespace PasswordManager.Core;

public class DbCrypto
{
    public static void CryptoService(Action<SqliteConnection> action)
    {
        byte[] key;
        DbRepository.GetMasterKey(out _, out key); 
        using var decrypt = new SqliteConnection($"Data Source=src/db/Passwords.db;Password={key}");
        decrypt.Open();

        action(decrypt);
    }
}