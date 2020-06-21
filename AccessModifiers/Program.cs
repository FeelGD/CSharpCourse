using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessModifiers
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }


    class Customer
    {
        //private değişken tanımlandığı blok içerisinde geçerlidir.
        private int id;
        //protected class seviyesinde kullanılır.  !!!tanımladığın şey inherit edildiği sınıflarda kullanılabilir.
        protected int Id;
        public void Save() { }
        public void Delete() { }
    }
    class Student : Customer
    {
        public void Save()
        {
            Id = 1;// Customer'den çağırıldı
        }
    }

    //default olarak class'ın aldığı internaldir!!
    //internal class bağlı bulunduğu proje içerisinde referans ihtiyacı olmadan kullanabiliriz.
    internal class Job
    {
        public String Name { get; set; }
    }
}
