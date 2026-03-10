using System;
using System;
using PasswordManager.Db;
using PasswordManager.Interface;
using PasswordManager.Services;
namespace PasswordManager.Services;

public class Cli
{
    public static void Startup()
    {
        Console.Write($"==== PASSWORD MANAGER ==== \n" +
                            "1. Add password \n" +
                            "2. Update password \n" +
                            "3. Delete password \n" +
                            "4. Search password \n" +
                            "5. Show all passwords \n" +
                            "6. Exit \n" +
                            "Select option: ");
        int mod = InputService.GetMode();
        ModeSelection(mod);
    }

    public static void ModeSelection(int mode)
    {
        switch (mode)
        {
            case 1:
                DbInterface passwordData = InputService.GetPassword();
                DbRepository.InsertPassword(passwordData.Username, passwordData.Email, passwordData.URL, passwordData.Password);
                Console.WriteLine("Password added succesfully.");
                break;
            case 2:
                DbInterface id = InputService.GetId();
                DbInterface newPasswordData = InputService.GetPassword();
                DbRepository.UpdatePassword(id.Id, newPasswordData.Username, newPasswordData.Email, newPasswordData.URL, newPasswordData.Password);
                Console.WriteLine("Password updated succesfully.");
                break;
            case 6:
                Environment.Exit(0);
                break;
                
        }
    }
}