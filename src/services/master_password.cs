using System;
using System.Security;

public class MasterPassword
{
    public static string CheckFirstBoot()
    {
        if (File.Exists("src/db/passwords.db"))
        {
            // return GetMasterPassword();
        }
        else
        {
            Console.WriteLine("Welcome to Password Manager! Please set a master password to secure your data.");
            return SetMasterPassword();
        }
    }

    public static string SetMasterPassword()
    {
        Console.Write("Create a master password to access the database: ");

        string password = "";

        while (true)
        {
            var key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.Enter)
                break;

            password += key.KeyChar;
            Console.Write("*");
        }

        Console.WriteLine();
        return password;
    }
}