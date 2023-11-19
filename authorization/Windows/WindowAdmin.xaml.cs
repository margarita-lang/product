using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace authorization.Windows
{
    /// <summary>
    /// Логика взаимодействия для WindowAdmin.xaml
    /// </summary>
    public partial class WindowAdmin : System.Windows.Window
    {
        public WindowAdmin()
        {
            InitializeComponent();
            dgProduct.ItemsSource = App.DB.Product.ToList();            
        }        
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void btnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            WindowAddEditProduct addProduct= new WindowAddEditProduct(new Product());
            addProduct.Width = 400;
            addProduct.ShowDialog();            
            dgProduct.ItemsSource = null;
            dgProduct.ItemsSource = App.DB.Product.ToList();
        }
        private void btnEditProduct_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Product product=dgProduct.SelectedItem as Product;
                WindowAddEditProduct editProduct = new WindowAddEditProduct(product);
                editProduct.lbl1.Content = "Редактирование товара";
                editProduct.Width = 410;
                editProduct.ShowDialog();
                dgProduct.ItemsSource = null;
                dgProduct.ItemsSource = App.DB.Product.ToList();
            }
            catch { }           
        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Product product = dgProduct.SelectedItem as Product;
                App.DB.Product.Remove(product);
                App.DB.SaveChanges();
                dgProduct.ItemsSource = null;
                dgProduct.ItemsSource = App.DB.Product.ToList();
            }
            catch { System.Windows.MessageBox.Show("Выберите запись для удаления"); }
        }
        private void btnIncreasing_Click(object sender, RoutedEventArgs e)
        {

        }
        private void btnDecreasing_Click(object sender, RoutedEventArgs e)
        {

        }
        private void tbFind_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }
        private void cmbManufacturer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedValue = cmbManufacturer.SelectedItem.ToString();            
            ICollectionView view = CollectionViewSource.GetDefaultView(dgProduct.ItemsSource);
            view.Filter = item =>
            {
                return ((Product)item).Manufacturer == selectedValue;
            };
        }
    }
}