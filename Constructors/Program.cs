﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
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
            Product product2 =new Product();
            Product product3 = new Product(2,"Laptop");


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
}