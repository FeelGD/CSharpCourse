using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Constructors
{
    //bir sınıf newlendiğinde çalışacak kod dilimidir.
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.List();


            Product product = new Product { Id = 1, Name = "Laptop" };
            Product product2 = new Product();
            Product product3 = new Product(2, "Laptop");


            EmployeeManager employeeManager = new EmployeeManager(new DatabaseLogger());
            employeeManager.Add();
            EmployeeManager employeeManager2 = new EmployeeManager(new FileLogger());
            employeeManager2.Add();


            PersonManager personManager = new PersonManager("Product");
            personManager.Add();


            Teacher.Number = 10;


            Utilities.Validate();


            Manager.DoSmt();
            Manager manager = new Manager();
            manager.DoSmt2();






            Console.ReadLine();
        }
    }



    class CustomerManager
    {
        //sınıfın ihtiyaç duyduğu parametreler değişkenlik gösteriyorsa.
        //private bir field "_" ile başlatılır.
        private int _count = 15;

        public CustomerManager(int count)
        {
            _count = count;
        }

        public CustomerManager()
        {

        }
        //constructors overloading 




        public void List()
        {
            Console.WriteLine("Listed {0} items", _count);
        }

        public void Add()
        {
            Console.WriteLine("Added {0} items", _count);

        }


    }

    class Product
    {
        public Product()
        {

        }

        private int _id;
        private string _name;
        public Product(int id, string name)
        {
            _id = id;
            _name = name;
        }
        public int Id { get; set; }
        public string Name { get; set; }
    }

    interface ILogger
    {
        void Log();
    }

    class DatabaseLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged to database!");
        }
    }
    class FileLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged to file!");
        }
    }

    class EmployeeManager
    {
        private ILogger _logger;
        public EmployeeManager(ILogger logger)
        {
            _logger = logger;
        }
        public void Add()
        {
            _logger.Log();
            Console.WriteLine("Added!");
        }
    }

    class BaseClass
    {
        private string _entity;

        public BaseClass(string entity)
        {
            _entity = entity;
        }
        public void Message()
        {
            Console.WriteLine("{0} message", _entity);
        }
    }

    class PersonManager : BaseClass
    {
        public PersonManager(string entity) : base(entity)
        {
        }

        public void Add()
        {
            Console.WriteLine("Added!");
            Message();
        }
    }

    //statik nesnelerde hiçbir şekilde instance oluşamaz.
    //statik nesneler ortak nesnelerdir genellikle uzak durmaya çalışırız.
    static class Teacher
    {
        public static int Number { get; set; }
    }

    static class Utilities
    {
        static Utilities()
        {

        }
        public static void Validate()
        {
            Console.WriteLine("Validation is done");
        }
    }

    class Manager
    {
        public static void DoSmt()
        {
            Console.WriteLine("Done");
        }

        public void DoSmt2()
        {
            Console.WriteLine("Done2");
        }
    }


}
