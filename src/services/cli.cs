using PasswordManager.Core;
using PasswordManager.Db;
using PasswordManager.Interface;
namespace PasswordManager.Services;

public class Cli
{
    public static void Startup()
    {
        Console.WriteLine();
        Console.Write($"==== PASSWORD MANAGER ==== \n" +
                            "1. Add password \n" +
                            "2. Update password \n" +
                            "3. Delete password \n" +
                            "4. Delete all passwords \n" +
                            "5. Search password \n" +
                            "6. Show all passwords \n" +
                            "7. Exit \n" +
                            "Select option: ");
        ModeSelection();
    }

    // public static void ModeSelection(int mode)
    // {
    //     while (true)
    //     {
    //         switch (mode)
    //         {
    //             case 1:
    //                 DbInterface passwordData = InputService.GetPassword();
    //                 DbCrypto.CryptoService(conn =>
    //                 {
    //                     DbRepository.InsertPassword(conn, passwordData.Username, passwordData.Email, passwordData.URL, passwordData.Password);
    //                 });
    //                 Console.WriteLine("Password added succesfully.");
    //                 break;
    //             case 2:
    //                 DbInterface id = InputService.GetId();
    //                 DbInterface newPasswordData = InputService.GetPassword();
    //                 DbCrypto.CryptoService(conn =>
    //                 {
    //                     DbRepository.UpdatePassword(conn, id.Id, newPasswordData.Username, newPasswordData.Email, newPasswordData.URL, newPasswordData.Password);
    //                 });
    //                 Console.WriteLine("Password updated succesfully.");
    //                 break;
    //             case 3:
    //                 DbInterface id_2 = InputService.GetId();
    //                 DbCrypto.CryptoService(conn =>
    //                 {
    //                     DbRepository.DeletePassword(conn, id_2.Id);
    //                 });
    //                 Console.WriteLine($"Password deleted succesfully.");
    //                 break;
    //             case 4:
    //                 DbCrypto.CryptoService(conn =>
    //                 {
    //                     DbRepository.DeleteAllPassword(conn);
    //                 });
    //                 Console.WriteLine($"All passwords deleted succesfully.");
    //                 break;
    //             case 5:
    //                 List<DbInterface> results_1 = new List<DbInterface>();
    //                 string query_string = "Enter a word to search the password: ";
    //                 string search = InputService.GetQuery(query_string);
    //                 DbCrypto.CryptoService(conn =>
    //                 {
    //                     DbRepository.SelectPassword(conn, search, results_1);
    //                 });
    //                 foreach (var entry in results_1)
    //                 {
    //                     Console.WriteLine($"Id: {entry.Id}");
    //                     Console.WriteLine($"Username: {entry.Username}");
    //                     Console.WriteLine($"Email: {entry.Email}");
    //                     Console.WriteLine($"URL: {entry.URL}");
    //                     Console.WriteLine($"Password: {entry.Password}");
    //                     Console.WriteLine("----------------------");
    //                 }
    //                 break;
    //             case 6:
    //                 List<DbInterface> results_2 = new List<DbInterface>();
    //                 DbCrypto.CryptoService(conn =>
    //                 {
    //                     DbRepository.SelectAllPassword(conn, results_2);
    //                 });
    //                 foreach (var entry in results_2)
    //                 {
    //                     Console.WriteLine($"Id: {entry.Id}");
    //                     Console.WriteLine($"Username: {entry.Username}");
    //                     Console.WriteLine($"Email: {entry.Email}");
    //                     Console.WriteLine($"URL: {entry.URL}");
    //                     Console.WriteLine($"Password: {entry.Password}");
    //                     Console.WriteLine("----------------------");
    //                 }
    //                 break;
    //             case 7:
    //                 Program.connectionPw!.Close();
    //                 Console.WriteLine($"Exiting program...");
    //                 Environment.Exit(0);
    //                 break;
    //             default:
    //                 Console.WriteLine($"Error: enter a valid number between 1 and 7.");

    //                 break;
    //         }
    //     }
    // }

    public static void ModeAction(Mode mod)
    {
        Action action = mod switch
        {
            Mode.NewPassword => () =>
            {
                var data = InputService.GetPassword();
                DbCrypto.CryptoService(conn =>
                    DbRepository.InsertPassword(conn, data.Username, data.Email, data.URL, data.Password)
                );
                Console.WriteLine("Password added successfully.");
            }
            ,

            Mode.UpdatePassword => () =>
            {
                var id = InputService.GetId();
                var data = InputService.GetPassword();
                DbCrypto.CryptoService(conn =>
                    DbRepository.UpdatePassword(conn, id.Id, data.Username, data.Email, data.URL, data.Password)
                );
                Console.WriteLine("Password updated successfully.");
            }
            ,

            Mode.DeletePassword => () =>
            {
                var id = InputService.GetId();
                DbCrypto.CryptoService(conn =>
                    DbRepository.DeletePassword(conn, id.Id)
                );
                Console.WriteLine("Password deleted successfully.");
            }
            ,

            Mode.DeleteAllPassword => () =>
            {
                DbCrypto.CryptoService(conn =>
                    DbRepository.DeleteAllPassword(conn)
                );
                Console.WriteLine("All passwords deleted successfully.");
            }
            ,

            Mode.SearchPassword => () =>
            {
                var results = new List<DbInterface>();
                string search = InputService.GetQuery("Enter a word to search the password: ");

                DbCrypto.CryptoService(conn =>
                    DbRepository.SelectPassword(conn, search, results)
                );

                PrintResults(results);
            }
            ,

            Mode.ShowAllPasswords => () =>
            {
                var results = new List<DbInterface>();

                DbCrypto.CryptoService(conn =>
                    DbRepository.SelectAllPassword(conn, results)
                );

                PrintResults(results);
            }
            ,

            Mode.Exit => () =>
            {
                Program.connectionPw!.Close();
                Console.WriteLine("Exiting program...");
                Environment.Exit(0);
            }
            ,

            _ => () =>
            {
                Console.WriteLine("Error: enter a valid number between 1 and 7.");
            }
        };

        action();

    }
    
    public static void ModeSelection()
    {
        int mod = InputService.GetMode();
        Mode selectedMode = mod switch
        {
            1 => Mode.NewPassword,
            2 => Mode.UpdatePassword,
            3 => Mode.DeleteAllPassword,
            4 => Mode.DeleteAllPassword,
            5 => Mode.SearchPassword,
            6 => Mode.ShowAllPasswords,
            7 => Mode.Exit,
            _ => throw new Exception("Error: invalid input.") 

        };
        Console.WriteLine();
        ModeAction(selectedMode);
    } 
    
    public static void PrintResults(List<DbInterface> results)
    {
        foreach (var entry in results)
        {
            Console.WriteLine($"Id: {entry.Id}");
            Console.WriteLine($"Username: {entry.Username}");
            Console.WriteLine($"Email: {entry.Email}");
            Console.WriteLine($"URL: {entry.URL}");
            Console.WriteLine($"Password: {entry.Password}");
            Console.WriteLine("----------------------");
        }
    }
}