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
        }
    }
    //isimlendirme 'I' ile başlatılır
    //Soyut nesneler IPerson
    interface IPerson
    {
        int Id { get; set; }
        int FirstName { get; set; }
        int LastName { get; set; }
    }

    //somut nesneler Customer Student
    class Customer : IPerson
    {
        public int Id { get; set; }
        public int FirstName { get; set; }
        public int LastName { get; set; }
        public string Address { get; set; }
    }
    class Student : IPerson
    {
        public int Id { get; set; }
        public int FirstName { get; set; }
        public int LastName { get; set; }
        public string Departmant { get; set; }
    }

}
