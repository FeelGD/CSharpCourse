using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkDemo
{
    //isimlendirme Database isminin sonuna "Context" eklenir.
    class ETradeContext:DbContext
    {
        public DbSet<Product> Products { get; set; }//benim bir productum var onu entitysetim var yani tablo gibi kullanacağım


    }
}
