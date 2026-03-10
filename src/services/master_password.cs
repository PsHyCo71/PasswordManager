using System;
using System.ComponentModel;
using System.Data.Common;
using System.Security;
using System.Text;
using PasswordManager.Db;
using PasswordManager.Services;

public class MasterPassword
{
    public static string CheckFirstBoot()
    {
        if (File.Exists("src/db/passwords.db"))
        {
            return GetMasterPassword();
        }
        else
        {
            DbTables.InitializeTables();
            Console.WriteLine("Welcome to Password Manager! Please set a master password to secure your data.");
            InputService.SetMasterKey();
            return "Master password created successfully.";
        }
    }

    public static string SetMasterPassword()
    {
        Console.Write("Enter master password: ");

        StringBuilder password = new StringBuilder();

        while (true)
        {
            var key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.Enter)
            {
                break;
            }

            if (key.Key == ConsoleKey.Backspace)
            {
                if (password.Length > 0)
                {
                    password.Remove(password.Length - 1, 1);
                    Console.Write("\b \b");
                }
                continue;
            }

            password.Append(key.KeyChar);
            Console.Write("*");
        }

        Console.WriteLine();
        return password.ToString();
    }

    public static string GetMasterPassword()
    {
        string password = InputService.AskMasterPassword();

        var (salt, savedHash) = DbRepository.GetMasterKey();

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
}