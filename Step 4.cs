using System;
using System.Collections.Generic;
using System.IO;

// Logghiamo su DB 
// Logger diventa LoggerFile

namespace SolidButNotTooMuch_4
{
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

    public class Notification
    {
        public string EmailAddress { get; set; }
        public string MobilePhoneNumber { get; set; }

        public void Send()
        {
            if (!string.IsNullOrEmpty(EmailAddress))
                Console.WriteLine($"<simulazione>: Inviata email a {EmailAddress}");
            else if (!string.IsNullOrEmpty(MobilePhoneNumber))
                Console.WriteLine($"<simulazione>: SMS inviato a {MobilePhoneNumber}");
        }
    }

    public class User
    {
        private readonly ILogger _logger;

        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string MobilePhoneNumber { get; set; }

        public User(ILogger logger)
        {
            _logger = logger;
        }

        public void Add()
        {
            Console.WriteLine($"<simulazione>: Aggiunto utente {Name}");

            _logger.Log(Name);

            var notifier = new Notification();
            notifier.EmailAddress = EmailAddress;
            notifier.MobilePhoneNumber = MobilePhoneNumber;
            notifier.Send();
        }
    }

    class Program
    {
        static void Main_(string[] args)
        {
            var user = new User(new LoggerFile());
            user.Name = "Max";
            user.EmailAddress = "max@gmail.com";
            user.Add();

            Console.WriteLine();

            var user2 = new User(new LoggerDB());
            user2.Name = "Paolo";
            user2.MobilePhoneNumber = "3391234567";
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
