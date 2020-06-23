using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityFrameworkDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ProductDal _productDal=new ProductDal(); //methodların dışında olduğu için "_" ile isimlendirdik.
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void LoadProducts()
        {
            dgwProducts.DataSource = _productDal.GetAll();
        }
        private void SearchProducts(string key)
        {
            
           // var result= _productDal.GetAll().Where(p=>p.Name.Contains(key)).ToList();//gelen keye göre verileri listeli şekilde getirdik ve "result" a atadık//listeye bakarak sorguladık.// Eğer bunu kullansaydık büyük küçük harf duyarlı olacaktık. //burası koleksiyona sorgu atıyor!!!
           var result = _productDal.GetByName(key);//ProductDal da bulunan GetByName ile veritabanı sorgusunu yolladık.
            dgwProducts.DataSource = result;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _productDal.Add(new Product
            {
                Name = tbxName.Text,
                UnitPrice = Convert.ToDecimal(tbxUnitPrice.Text),
                StockAmount = Convert.ToInt32(tbxStockAmount.Text)
            });
            MessageBox.Show("Added!");
            LoadProducts();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            _productDal.Update(new Product
            {
                Id = Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value),
                Name = tbxNameUpdate.Text.ToString(),
                UnitPrice = Convert.ToDecimal(tbxUnitPriceUpdate.Text),
                StockAmount = Convert.ToInt32(tbxStockAmountUpdate.Text)//seçilen verileri id'ye göre değiştiriyor.
            }); //öncelikle verinin gelmesi lazım CellClick event bunu sağlıyor.
            LoadProducts();
            MessageBox.Show("Updated!!!");
        }

        private void dgwProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbxNameUpdate.Text = dgwProducts.CurrentRow.Cells[1].Value.ToString();
            tbxUnitPriceUpdate.Text = dgwProducts.CurrentRow.Cells[2].Value.ToString();
            tbxStockAmountUpdate.Text = dgwProducts.CurrentRow.Cells[3].Value.ToString();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            _productDal.Delete(new Product
            {
                Id=Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value)//sadece Id vermemiz yeterli çünkü silinecek veriyi id den siliyor.
            });
            LoadProducts();
            MessageBox.Show("Deleted!");
        }

        private void tbxSearch_TextChanged(object sender, EventArgs e)//tbxSearch her tuş vuruşunda bu event çalışacak
        {
            SearchProducts(tbxSearch.Text);
        }

        private void btnGetById_Click(object sender, EventArgs e)
        {
            _productDal.GetById(1);
        }
    }
}
