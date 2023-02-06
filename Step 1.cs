using System;
using System.Collections.Generic;
using System.IO;

namespace SolidButNotTooMuch_1
{
    public class User
    {
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string MobilePhoneNumber { get; set; }

        public void Add()
        {
            Console.WriteLine($"<simulazione>: Aggiunto utente {Name}");

            File.AppendAllText(@"C:\Temp\logFile.txt", Name + "\r\n");

            if (!string.IsNullOrEmpty(EmailAddress))
                Console.WriteLine($"<simulazione>: Inviata email a {EmailAddress}");
            else if (!string.IsNullOrEmpty(MobilePhoneNumber))
                Console.WriteLine($"<simulazione>: SMS inviato a {MobilePhoneNumber}");
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
