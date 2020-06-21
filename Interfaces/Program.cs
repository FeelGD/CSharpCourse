using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            //InterfacesIntro();

            /*IPerson person=new Customer();
            interface hiçbir zaman new'lenemez
            */
            /*interfaceleri genellikle katmanlar arası geçişlerde kullanıyoruz amacımız
             Bağımlılıkları en aza indirgemek.*/
            CustomerManager customerManager=new CustomerManager();
            customerManager.Add(new SqlServerCustomerDal());
            customerManager.Add(new OracleCustomerDal());


            Console.ReadLine();
        }

        private static void InterfacesIntro()
        {
            PersonManager manager = new PersonManager();
            Customer customer = new Customer
            {
                Id = 1,
                FirstName = "AliC",
                LastName = "Yıldız",
                Address = "Ankara"
            };

            Student student = new Student
            {
                Id = 1,
                FirstName = "AliS",
                LastName = "Yıldız",
                Departmant = "Computer Science"
            };
            Worker worker = new Worker
            {
                Id = 1,
                FirstName = "AliW",
                LastName = "Yıldız",
                Departmant = "Computer Science"
            };


            manager.Add(student);
            manager.Add(customer);
            manager.Add(worker);
        }
    }
    //isimlendirme 'I' ile başlatılır
    //Soyut nesneler IPerson
    interface IPerson
    {
        int Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
    }

    //somut nesneler Customer Student
    class Customer : IPerson
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Address { get; set; }
    }
    class Student : IPerson
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Departmant { get; set; }

    }
    class Worker : IPerson
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Departmant { get; set; }

    }
    //manager genellikle iş katmanı sınıfları için kullanılır.
    class PersonManager
    {
        public void Add(IPerson person)
        {
            Console.WriteLine(person.FirstName);
        }
    }


} 
