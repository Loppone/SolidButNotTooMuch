using System;
using System.Collections.Generic;
using System.IO;

// Notification

namespace SolidButNotTooMuch_5
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
        private readonly ILogger _logger;
        private readonly INotification _notification;

        public string Name { get; set; }

        // In questo contesto non mi servono più
        //public string EmailAddress { get; set; }
        //public string MobilePhoneNumber { get; set; }

        public User(ILogger logger, INotification notification)
        {
            _logger = logger;
            _notification = notification;
        }

        public void Add()
        {
            Console.WriteLine($"<simulazione>: Aggiunto utente {Name}");

            _logger.Log(Name);

            _notification.Send();
        }
    }

    class Program
    {
        static void Main_(string[] args)
        {
            var user = new User(new LoggerFile(), new EmailNotification() { EmailAddress= "max@gmail.com" });
            user.Name = "Max";
            user.Add();

            Console.WriteLine();

            var user2 = new User(new LoggerDB(), new SmsNotification() { MobilePhoneNumber = "3391234567" });
            user2.Name = "Paolo";
            user2.Add();

            //*************

            var users = new List<User>();
            users.Add(user);
            users.Add(user2);

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
