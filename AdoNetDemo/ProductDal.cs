using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNetDemo
{
    //veritabanı operasyonları
    public class ProductDal
    {
        SqlConnection _connection = new SqlConnection(@"server=(localdb)\MSSQLLocalDB;initial catalog=ETrade;integrated security=true");//bağlantı nesnesi oluşturuldu
        //"_" kullanmamızın nedeni methodların dışında kullandık



        //ilk ürünlerin listelenmesi
        //kurumsal bir mimari yaparken normalde interface kullanmamız gerekiyor fakat adonet amaçlı olduğu için normal yapacağız
        public List<Product> GetAll()
        {
            //ürünleri listeyeceğiz


            ConnectionControl();
            SqlCommand command = new SqlCommand("Select * from Products", _connection);//komut oluşturuldu

            //executeReader select yaptığımız için tablo sonucu için sadece
            SqlDataReader reader = command.ExecuteReader(); //okuma komutu

            List<Product>products=new List<Product>();//ürünleri listeleyelim

            while (reader.Read())//kayıtları okuyabildiğin sürece döngüyü çalıştır
            {
                Product product = new Product
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Name = reader["Name"].ToString(),
                    StockAmount = Convert.ToInt32(reader["StockAmount"]),
                    UnitPrice = Convert.ToDecimal(reader["UnitPrice"])
                };
                products.Add(product);//her okuduğun elemanı producta aktarıp listeye ekliyoruz.

            }



            reader.Close();
            _connection.Close();
            return products;


        }

        private void ConnectionControl()
        {
            if (_connection.State == ConnectionState.Closed) //eğer connection state kapalı ise bağlantıyı aç
            {
                _connection.Open(); //bağlantıyı açtık
            }
        }

        public DataTable GetAll2()
        {
            ConnectionControl();

            SqlCommand command = new SqlCommand("Select * from Products", _connection);//komut oluşturuldu

            //executeReader select yaptığımız için tablo sonucu için sadece
            SqlDataReader reader = command.ExecuteReader(); //okuma komutu

            DataTable dataTable = new DataTable();
            dataTable.Load(reader); //DataTable oluşturduk ve reader ile doldurduk
            reader.Close();
            _connection.Close();
            return dataTable;

            //DataTable artık kullanılmıyor ki kullanılmamalı. Memory açısından pahalıdır. 

        }

        public void Add(Product product)
        {
            ConnectionControl();
            SqlCommand command=new SqlCommand("Insert into Products values(@name,@UnitPrice,@StockAmount)",_connection);
            command.Parameters.AddWithValue("@Name", product.Name);
            command.Parameters.AddWithValue("@UnitPrice", product.UnitPrice);
            command.Parameters.AddWithValue("@StockAmount", product.StockAmount);
            command.ExecuteNonQuery();

            _connection.Close();


        }
    }
}
