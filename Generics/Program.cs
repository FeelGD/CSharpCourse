using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    class Program
    {
        static void Main(string[] args)
        {
            Utilities utilities = new Utilities();
            List<string> result = utilities.BuildList<string>("Ankara", "İzmir", "Adana");
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            List<Customer> result2 = utilities.BuildList<Customer>(new Customer());

            foreach (var item in result2)
            {
                Console.WriteLine(item);


            }
            Console.ReadLine();

        }

        class Utilities
        {
            public List<T> BuildList<T>(params T[] items)
            {
                return new List<T>(items);
            }
        }

        class Product
        {

        }
        interface IProductDal : IRepository<Product>
        {

        }

        class Customer
        {
            public string FirstName { get; set; }
        }
        interface ICustomerDal : IRepository<Customer>
        {
            void Custom();

        }
        //sıklıkla yaptığımız operasyonları nesne tarzında değiştirebiliriz.
        interface IRepository<T>//T=type
        {
            List<T> GetAll();
            T Get(int id);
            void Add(T entity);
            void Delete(T entity);
            void Update(T entity);
        }

        class ProductDal : IProductDal
        {
            public List<Product> GetAll()
            {
                throw new NotImplementedException();
            }

            public Product Get(int id)
            {
                throw new NotImplementedException();
            }

            public void Add(Product entity)
            {
                throw new NotImplementedException();
            }

            public void Delete(Product entity)
            {
                throw new NotImplementedException();
            }

            public void Update(Product entity)
            {
                throw new NotImplementedException();
            }
        }

        class CustomerDal : ICustomerDal
        {
            public List<Customer> GetAll()
            {
                throw new NotImplementedException();
            }

            public Customer Get(int id)
            {
                throw new NotImplementedException();
            }

            public void Add(Customer entity)
            {
                throw new NotImplementedException();
            }

            public void Delete(Customer entity)
            {
                throw new NotImplementedException();
            }

            public void Update(Customer entity)
            {
                throw new NotImplementedException();
            }

            public void Custom()
            {
                throw new NotImplementedException();
            }
        }


    }
 