using System;
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
            if (!int.TryParse(mod, out Id_parsed) || Id_parsed < 1 || Id_parsed > 6)
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

    public static string GetQuery()
    {
        string query;
        string? query_nullable = Console.ReadLine();
        if (string.IsNullOrEmpty(query_nullable))
        {
            Console.WriteLine("Error: query cannot be empty.");
            return GetQuery();
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
            Console.Write("Insert the paassword Id: ");
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

        Console.Write("Insert a URL: ");
        string url = GetQuery();

        Console.Write("Insert a password: ");
        string pw = GetQuery();

        return new DbInterface
        {
            Username = username,
            Email = email,
            URL = url,
            Password = pw
        };
    }
}