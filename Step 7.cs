using System;
using System.Collections.Generic;
using System.IO;

// LSP: User vs SuperUser

namespace SolidButNotTooMuch_7
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

    public class User
    {
        protected ILogger _logger;
        public INotification Notification { get; set; }
        public string Name { get; set; }

        public User(ILogger logger)
        {
            _logger = logger;
        }

        public virtual void Add()
        {
            Console.WriteLine($"<simulazione>: Aggiunto utente {Name}");

            _logger.Log(Name);

            if (Notification != null)
                Notification.Send();
        }
    }

    public class SuperUser : User
    {
        public bool IsGold { get; set; }

        public SuperUser(ILogger logger) : base(logger)
        {
            _logger = logger;
        }


        public override void Add()
        {
            Console.WriteLine($"<simulazione>: Aggiunto un super utente utente {Name}");

            _logger.Log(Name);

            if (Notification == null)
                throw new Exception("E' obbligatorio inviare una notifica ai super utenti");
        }
    }

    class Program
    {
        static void Main_(string[] args)
        {
            var user = new User(new LoggerFile());
            user.Notification = new EmailNotification() { EmailAddress = "max@gmail.com" };
            user.Name = "Max";
            user.Add();

            Console.WriteLine();

            var user2 = new User(new LoggerDB());
            user2.Notification = new SmsNotification() { MobilePhoneNumber = "3391234567" };
            user2.Name = "Paolo";
            user2.Add();

            User user3 = new SuperUser(new LoggerDB());
            user3.Name = "Domenico";
            user3.Add();

            //*************

            var users = new List<User>();
            users.Add(user);
            users.Add(user2);
            users.Add(user3);

            Console.WriteLine();
            Console.WriteLine("---Lista utenti---");
            foreach (var userList in users)
            {
                Console.WriteLine($"{userList.Name}");
            }

            Console.ReadKey();
        }
    }
}
