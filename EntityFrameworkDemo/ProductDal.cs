using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkDemo
{
    public class ProductDal
    {
        //App.Config içerisine sql bağlantımızı aldık.
        public List<Product> GetAll()
        {
            using (ETradeContext context = new ETradeContext()
            ) //ETradeContext pahalı bir nesne bu bağlamda method bittiği zaman bellekten atar GarbageCollector Dispose yapar direk!!!
            {
                return context.Products.ToList(); //veritabanındaki tabloya erişip listeledik.


            }
        }
        public List<Product> GetByName(string key)
        {
            using (ETradeContext context = new ETradeContext()
            )
            {
                //çok veri olduğu zaman performans kazancı 
                return context.Products.Where(p => p.Name.Contains(key)).ToList();//veritabanından sorgu yapıyor 

            }
        }
        public List<Product> GetByUnitPrice(decimal price)
        {
            using (ETradeContext context = new ETradeContext()
            )
            {
                //çok veri olduğu zaman performans kazancı 
                return context.Products.Where(p => p.UnitPrice>=price).ToList();//veritabanından sorgu yapıyor //adonetteki aynı sorguyu yapar

            }
        }
        public List<Product> GetByUnitPrice(decimal min,decimal max)
        {
            using (ETradeContext context = new ETradeContext()
            )
            {
                //çok veri olduğu zaman performans kazancı 
                return context.Products.Where(p => p.UnitPrice >= min&&p.UnitPrice<=max).ToList();//veritabanından sorgu yapıyor //adonetteki aynı sorguyu yapar

            }
        }

        public Product GetById(int id)
        {
            using (ETradeContext context = new ETradeContext()
            ) //ETradeContext pahalı bir nesne bu bağlamda method bittiği zaman bellekten atar GarbageCollector Dispose yapar direk!!!
            {
                //var result = context.Products.SingleOrDefault(p => p.Id == id); //1 den fazla gelirse ilk geleni verir
                var result= context.Products.SingleOrDefault(p => p.Id == id);//1 den fazla kayıt gelirse hata fırlatır.
               return result;

            }
        }







        public void Add(Product product)
        {
            using (ETradeContext context = new ETradeContext()
            ) //ETradeContext pahalı bir nesne bu bağlamda method bittiği zaman bellekten atar GarbageCollector Dispose yapar direk!!!
            {
                //context.Products.Add(product); //Ekleme yapmak için Add çağırdık ve değişenleri kaydet dedik.
                var entity = context.Entry(product);//contexte abone ol product için gönderdiğimiz productu veritabanındaki product ile eşitliyor
                entity.State = EntityState.Added;//id üzerinden eşitler primary key olduğu için
                context.SaveChanges();
                context.SaveChanges();


            }
        }

        public void Update(Product product)
        {
            using (ETradeContext context = new ETradeContext())
            {
                var entity = context.Entry(product);//contexte abone ol product için gönderdiğimiz productu veritabanındaki product ile eşitliyor
                entity.State = EntityState.Modified;//id üzerinden eşitler primary key olduğu için
                context.SaveChanges();


            }
        }
        public void Delete(Product product)
        {
            using (ETradeContext context = new ETradeContext())
            {
                var entity = context.Entry(product);//contexte abone ol product için gönderdiğimiz productu veritabanındaki product ile eşitliyor
                entity.State = EntityState.Deleted;//id üzerinden eşitler primary key olduğu için
                context.SaveChanges();


            }
        }
    }
}