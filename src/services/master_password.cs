using System.Security.Cryptography.X509Certificates;
using PasswordManager.Core;
using PasswordManager.Db;
using PasswordManager.Services;

public class MasterPassword
{
    public static string CheckFirstBoot()
    {
        if (!File.Exists("src/db/passwords.db"))
        {
            DbTables.InitializeTableMasterKey();
            Console.WriteLine("Welcome to Password Manager! Please set a master password to secure your data.");
            SetMasterKey();
            Console.WriteLine($"Master password created succesfully!");
            DbTables.InitializeTablePasswords();
            return GetMasterPassword();
        }
        else
        {
            return GetMasterPassword();
        }
    }

    public static string SetMasterPassword()
    {
        Console.Write("Create a master password: ");

        string password = InputService.AskMasterPassword();
        return password;
    }

    public static string GetMasterPassword()
    {
        Console.Write($"Enter master password: ");
        
        string password = InputService.AskMasterPassword();

        byte[] salt;
        byte[] savedHash;
        DbRepository.GetMasterKey(out salt, out savedHash);

        byte[] hash = MasterPasswordEncryption.DeriveKey(password, salt);


        if (!hash.SequenceEqual(savedHash))
        {
            Console.WriteLine($"Wrong password!");
            return GetMasterPassword();
        }
        else
        {
            return "Password is correct connecting to database...";
        }
    }

    public static void SetMasterKey()
    {
        string password = SetMasterPassword();
        byte[] salt = MasterPasswordEncryption.GenerateSalt();
        byte[] hash = MasterPasswordEncryption.DeriveKey(password, salt);
        DbRepository.SaveMasterKey(salt, hash);
    }
}