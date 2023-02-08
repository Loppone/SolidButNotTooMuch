using System;
using System.Collections.Generic;
using System.IO;

// Nuovo Design con interfacce

namespace SolidButNotTooMuch_8B
{
    #region Logger
    public interface ILogger
    {
        void Log(string message);
    }

    public class LoggerFile : ILogger
    {
        public string Path { get; set; } = @"C:\Temp\logFile.txt";

        public void Log(string message)
        {
            File.AppendAllText(Path, message + "\r\n");
            Console.WriteLine($"File log: {message}");
        }
    }

    public class LoggerDB : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine($"Record db log: {message}");
        }
    }

    #endregion

    #region Notification
    public interface INotification
    {
        void Send();
    }

    public class EmailNotification : INotification
    {
        public string EmailAddress { get; set; }

        public void Send()
        {
            if (!string.IsNullOrEmpty(EmailAddress))
                Console.WriteLine($"<simulazione>: Inviata email a {EmailAddress}");
        }
    }

    public class SmsNotification : INotification
    {
        public string MobilePhoneNumber { get; set; }

        public void Send()
        {
            if (!string.IsNullOrEmpty(MobilePhoneNumber))
                Console.WriteLine($"<simulazione>: SMS inviato a {MobilePhoneNumber}");
        }
    }

    #endregion

    #region Util

    public static class Util
    {
        public static string NewPhoneNumber()
        {
            return "339" + GetDigits();
        }

        private static string GetDigits()
        {
            var digits = "";
            for (int i = 0; i < 8; i++)
            {
                digits += new Random().Next(0, 9);
            }

            return digits;
        }
    }

    #endregion

    public class AccountModel
    {
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string MobilePhoneNumber { get; set; }
    }

    public interface IAccount
    {
        AccountModel Add(IUser user);
    }

    public class StandardAccount : IAccount
    {
        public AccountModel Add(IUser user)
        {
            var account = new AccountModel();

            account.Name = user.Name;
            account.EmailAddress = $"{user.Name}@ff3d.com";
            account.MobilePhoneNumber = "";

            return account;
        }
    }

    public class SuperAccount : IAccount
    {
        public ILogger Logger { get; set; }

        public AccountModel Add(IUser user)
        {
            var account = new AccountModel();

            account.Name = user.Name;
            account.EmailAddress = $"{user.Name}@ff3d.com";
            account.MobilePhoneNumber = Util.NewPhoneNumber();

            if (Logger != null)
                Logger.Log($"Configurato utente GOLD: {user.Name}");

            return account;
        }
    }

    public class BabyAccount : IAccount
    {
        public AccountModel Add(IUser user)
        {
            var account = new AccountModel();

            account.Name = user.Name;
            account.EmailAddress = $"guest.{user.Name}@guest-ff3d.com";
            account.MobilePhoneNumber = "";

            return account;
        }
    }

    public interface IUser
    {
        string Name { get; set; }
        public IAccount AccountManager { get; set; }
    }

    public class User : IUser
    {
        public string Name { get; set; }
        public IAccount AccountManager { get; set; } = new StandardAccount();
    }

    public class SuperUser : IUser
    {
        public string Name { get; set; }
        public IAccount AccountManager { get; set; }

        public SuperUser(ILogger logger)
        {
            // Inizializzo il super account
            var super = new SuperAccount();
            super.Logger = logger;
            AccountManager = super;
        }
    }

    public class BabyUser : IUser
    {
        public string Name { get; set; }
        public IAccount AccountManager { get; set; } = new BabyAccount();
    }

    class Program
    {
        static void Main_(string[] args)
        {
            var users = new List<IUser>()
            {
                new User() { Name = "Max" },
                new SuperUser(new LoggerDB()) { Name = "Paolo" },
                new BabyUser() { Name = "Domenico" }
            };

            List<AccountModel> accounts = new List<AccountModel>();

            foreach (var user in users)
            {
                accounts.Add(user.AccountManager.Add(user));
            }

            foreach (var account in accounts)
            {
                Console.WriteLine($"Creato account a {account.Name}. Email: {account.EmailAddress}, Cellulare aziendale: {account.MobilePhoneNumber}");
            }

            Console.ReadKey();
        }
    }
}
