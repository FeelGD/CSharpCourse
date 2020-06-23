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
        //ilk ürünlerin listelenmesi
        //kurumsal bir mimari yaparken normalde interface kullanmamız gerekiyor fakat adonet amaçlı olduğu için normal yapacağız
        public DataTable GetAll()
        {
            //ürünleri listeyeceğiz
            SqlConnection connection=new SqlConnection(@"server=(localdb)\MSSQLLocalDB;initial catalog=ETrade;integrated security=true");//bağlantı nesnesi oluşturuldu
            if (connection.State==ConnectionState.Closed)//eğer connection state kapalı ise bağlantıyı aç
            {
                connection.Open();//bağlantıyı açtık
            }
            SqlCommand command  =new SqlCommand("Select * from Products",connection);//komut oluşturuldu

            //executeReader select yaptığımız için tablo sonucu için sadece
            SqlDataReader reader = command.ExecuteReader(); //okuma komutu

            DataTable dataTable=new DataTable();
            dataTable.Load(reader); //DataTable oluşturduk ve reader ile doldurduk
            reader.Close();
            connection.Close();
            return dataTable;

        }
    }
}
