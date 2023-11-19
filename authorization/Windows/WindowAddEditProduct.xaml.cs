using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace authorization.Windows
{
    /// <summary>
    /// Логика взаимодействия для WindowAddEditProduct.xaml
    /// </summary>
    public partial class WindowAddEditProduct : Window
    {
        public WindowAddEditProduct(Product product)
        {
            InitializeComponent();
            try
            {
                this.currentProduct= product;
                tbArticle.Text = product.Article;
                cmbCategory.SelectedValue = product.Category;
                tbCurrentDiscount.Text = product.CurrentDiscount.ToString();
                tbDescription.Text = product.Description;
                tbImage.Text = product.Image;
                tbManufacturer.Text = product.Manufacturer;
                tbMaximumDiscount.Text = product.MaximumPossibleDiscount.ToString();
                tbName.Text = product.Name;
                tbPrice.Text = product.Price.ToString();
                tbQuantity.Text = product.QuantityInStock.ToString();
                tbSupplier.Text = product.Supplier.ToString();  
                tbUnit.Text = product.UnitOfMeasurement.ToString();
            }catch{ } 
        }
        Product currentProduct;
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            currentProduct.Article= tbArticle.Text;
            currentProduct.Name= tbName.Text;
            currentProduct.UnitOfMeasurement= tbUnit.Text;
            currentProduct.Price = int.Parse(tbPrice.Text);
            currentProduct.MaximumPossibleDiscount = int.Parse(tbMaximumDiscount.Text);
            currentProduct.Manufacturer = tbManufacturer.Text;
            currentProduct.Supplier = tbSupplier.Text;
            currentProduct.Category= cmbCategory.SelectedValue.ToString();
            currentProduct.CurrentDiscount= int.Parse(tbCurrentDiscount.Text);
            currentProduct.QuantityInStock= int.Parse(tbQuantity.Text); 
            currentProduct.Description = tbDescription.Text;
            currentProduct.Image = tbImage.Text;
            if (currentProduct.id == 0)
                App.DB.Product.Add(currentProduct);
            App.DB.SaveChanges();
            Close();
        }

        private void btnCansel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
