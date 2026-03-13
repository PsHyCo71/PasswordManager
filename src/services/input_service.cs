using System.Text;
using PasswordManager.Db;
using PasswordManager.Interface;
namespace PasswordManager.Services;

public class InputService
{
    public static int GetMode()
    {
        int Id_parsed = 0;
        while (true)
        {
            string? mod = Console.ReadLine();
            if (!int.TryParse(mod, out Id_parsed) || Id_parsed < 1 || Id_parsed > 7)
            {
                Console.WriteLine($"Error: please enter a valid number between 1 and 6.");
                continue;
            }
            else
            {
                break;
            }
        }
        return Id_parsed;
    }

    public static string GetQuery(string text)
    {
        string query;
        Console.Write($"{text}");
        string? query_nullable = Console.ReadLine();
        if (string.IsNullOrEmpty(query_nullable))
        {
            Console.WriteLine("Error: query cannot be empty.");
            return GetQuery(text);
        }
        else
        {
            query = query_nullable;
        }
        return query;
    }

    public static DbInterface GetId()
    {
        int Id_parsed = 0;
        while (true)
        {
            Console.Write("Insert the password Id: ");
            string? Id = Console.ReadLine();
            if (!int.TryParse(Id, out Id_parsed) || Id_parsed < 1)
            {
                Console.WriteLine($"Error: please enter a valid number.");
                continue;
            }
            else
            {
                break;
            }
        }
        return new DbInterface
        {
            Id = Id_parsed
        };
    }

    public static DbInterface GetPassword()
    {
        string? username = null;
        string? email = null;

        while (true)
        {
            Console.Write("Insert a username: ");
            username = Console.ReadLine();

            Console.Write("Insert an email: ");
            email = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(username) && string.IsNullOrWhiteSpace(email))
            {
                Console.WriteLine("Error: please enter at least a username or an email");
                continue;
            }

            break;
        }

        string URL_string = "Insert a URL: ";
        string url = GetQuery(URL_string);

        string pw_string = "Insert a password: ";
        string pw = GetQuery(pw_string);

        return new DbInterface
        {
            Username = username,
            Email = email,
            URL = url,
            Password = pw
        };
    }

    public static string AskMasterPassword()
    {
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

            if (char.IsControl(key.KeyChar))
            {
                continue;
            }

            password.Append(key.KeyChar);
            Console.Write("*");
        }

        Console.WriteLine();
        return password.ToString();
    }
}