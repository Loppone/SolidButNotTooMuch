using System;
using System.Collections.Generic;
using System.IO;

namespace SolidButNotTooMuch_3
{
    public class Logger
    {
        public string Path { get; set; } = @"C:\Temp\logFile.txt";

        public void Log(string message)
        {
            File.AppendAllText(Path, message + "\r\n");
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
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string MobilePhoneNumber { get; set; }

        public void Add()
        {
            Console.WriteLine($"<simulazione>: Aggiunto utente {Name}");

            var log = new Logger();
            log.Log(Name);

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
            var users = new List<User>();

            var user = new User();
            user.Name = "Max";
            user.EmailAddress = "Max@gmail.com";
            //user.MobilePhoneNumber = "3391234567";

            user.Add();

            users.Add(user);

            Console.WriteLine("---Lista utenti---");
            foreach (var userList in users)
            {
                Console.WriteLine($"{userList.Name}\r\n");
            }

            Console.ReadKey();
        }
    }
}
