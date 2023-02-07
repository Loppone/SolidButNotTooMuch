﻿using System;
using System.Collections.Generic;
using System.IO;

// ISP: Interfacce separate R/W
//      Il design è sbagliato

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

    public interface IRepositoryReader
    {
        string GetUser(string name);
    }

    public interface IRepositoryWriter
    {
        void Add(User user);
    }

    public interface IRepository : IRepositoryReader, IRepositoryWriter
    {
        void Update(User user);
        User Delete(string name);
    }

    public class Repository : IRepository
    {
        private readonly IRepositoryReader _repoReader;
        private readonly IRepositoryWriter _repoWriter;

        public Repository(IRepositoryReader repoReader, IRepositoryWriter repoWriter)
        {
            _repoReader = repoReader;
            _repoWriter = repoWriter;
        }

        public void Add(User user)
        {
            _repoWriter.Add(user);    
        }

        public User Delete(string name)
        {
            // TO-DO
            return new User();
        }

        public string GetUser(string name)
        {
            return _repoReader.GetUser(name);
        }

        public void Update(User user)
        {
            // TO-DO
        }
    }

    public class RepositoryReader : IRepositoryReader
    {
        public RepositoryReader()
        {
        }

        public string GetUser(string name)
        {
            Console.WriteLine($"Utente {name} letto da DB");
            return name;
        }
    }

    public class RepositoryWriter : IRepositoryWriter
    {
        public RepositoryWriter()
        {

        }

        public void Add(User user)
        {
            Console.WriteLine($"Utente {user.Name} salvato su DB");
        }
    }

    public class User
    {
        protected ILogger _logger;
        protected IRepository _repository;

        public INotification Notification { get; set; }
        public string Name { get; set; }

        public User(ILogger logger, IRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public User()
        {
        }

        public virtual void Add()
        {
            Console.WriteLine($"<simulazione>: Aggiunto utente {Name}");
            _repository.Add(this);

            _logger.Log(Name);

            if (Notification != null)
                Notification.Send();
        }

        public virtual string Get()
        {
            return _repository.GetUser(Name);
        }
    }

    public class SuperUser : User
    {
        public bool IsGold { get; set; }

        public SuperUser(ILogger logger, IRepository repository) : base(logger, repository)
        {
        }


        public override void Add()
        {
            Console.WriteLine($"<simulazione>: Aggiunto un super utente utente {Name}");
            _repository.Add(this);

            _logger.Log(Name);

            if (Notification == null)
                throw new Exception("E' obbligatorio inviare una notifica ai super utenti");
        }

        public override string Get()
        {
            return base.Get();
        }
    }

    public class BabyUser : User
    {
        public BabyUser(ILogger logger, IRepository repository) : base(logger, repository)
        {
        }

        public override void Add()
        {
            Console.WriteLine($"<simulazione>: Aggiunto un baby utente {Name}");
            _repository.Add(this);

            _logger.Log(Name);

            if (Notification != null)
                Notification.Send();
        }

        public override string Get()
        {
            // Astrazione 
            throw new NotImplementedException("I BabyUser possono solo essere memorizzati a sistema");
        }
    }

    class Program
    {
        static void Main_(string[] args)
        {
            var users = new List<User>();

            var user = new User(new LoggerFile(), new Repository(new RepositoryReader(),new RepositoryWriter()));
            user.Notification = new EmailNotification() { EmailAddress = "max@gmail.com" };
            user.Name = "Max";
            user.Add();
            users.Add(user);

            Console.WriteLine();

            var user2 = new User(new LoggerDB(), new Repository(new RepositoryReader(), new RepositoryWriter()));
            user2.Notification = new SmsNotification() { MobilePhoneNumber = "3391234567" };
            user2.Name = "Paolo";
            user2.Add();
            users.Add(user2);

            Console.WriteLine();

            User user3 = new SuperUser(new LoggerDB(), new Repository(new RepositoryReader(), new RepositoryWriter()));
            user3.Name = "Domenico";
            try
            {
                user3.Add();
                users.Add(user3);
            }
            catch (Exception)
            {
                Console.WriteLine("ROLLBACK: violato il principio LSP");
            }

            //*************


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
