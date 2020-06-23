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