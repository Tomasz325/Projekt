using Projekt.Crud_Services;
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

namespace Projekt
{
    /// <summary>
    /// Logika interakcji dla klasy Window_Suppliers.xaml
    /// </summary>
    public partial class Window_Suppliers : Window
    {
        private readonly SupplierCrudServices suppliercrudservices;
        public Window_Suppliers()
        {
            InitializeComponent();
            suppliercrudservices = new SupplierCrudServices();
            RefBut.Click += ButtonRefresh;
            AddBut.Click += ButtonAdd;
            DelBut.Click += ButtonDelete;
            SerBut.Click += ButtonSearch;
            Updbut.Click += ButtonUpdate;
            ButWork.Click += Button_Workers;
            ButShift.Click += Button_Shifts;
            ButProduct.Click += Button_Products;
            ButDepartament.Click += Button_Departaments;
            ButQuit.Click += Button_Quit;
        }
        private async Task ListBrands()
        {
            var brandList = await suppliercrudservices.ListBrands();
            DataGridBrand.ItemsSource = brandList.ToList();
        }
        private async void ButtonRefresh(object sender, RoutedEventArgs e)
        {
            var list = (await suppliercrudservices.ListBrands()).ToList();
            DataGridBrand.ItemsSource = list;
        }
        private async void ButtonAdd(object sender, RoutedEventArgs e)
        {
            try
            {
                await suppliercrudservices.AddBrand(Int32.Parse(txtSupplierID.Text), txtSupplierName.Text, txtSType.Text, txtSCarsize.Text);
                ButtonRefresh(sender, e);
                throw new Exception("Data Added");

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally
            {
                txtSupplierID.Clear();
                txtSupplierName.Clear();
                txtSType.Clear();
                txtSCarsize.Clear();
                txtSupplierID.Focus();
            }

        }
        private async void ButtonDelete(object sender, RoutedEventArgs e)
        {
            try
            {
                await suppliercrudservices.DeleteBrand(Int32.Parse(txtSupplierID.Text));
                throw new Exception("Data Removed");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                await ListBrands();
            }

        }
        private async void ButtonUpdate(object sender, RoutedEventArgs e)
        {
            try
            {
                await suppliercrudservices.UpdateBrand(Int32.Parse(txtSupplierID.Text), txtSupplierName.Text, txtSType.Text, txtSCarsize.Text);
                throw new Exception("Data Updated");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { await ListBrands(); }
        }
        private async void ButtonSearch(object sender, RoutedEventArgs e)
        {
            var search = await suppliercrudservices.SearchBrandByName(txtSupplierName.Text);
            DataGridBrand.ItemsSource = search.ToList();
        }
        private void Button_Workers(object sender, RoutedEventArgs e)
        {
            Window_Suppliers suppliers = new Window_Suppliers();
            MainWindow workers = new MainWindow();
            workers.Show();
            this.Close();

        }
        private void Button_Shifts(object sender, RoutedEventArgs e)
        {
            Window_Shifts shifts = new Window_Shifts();
            shifts.Show();
            this.Close();
        }
        private void Button_Products(object sender, RoutedEventArgs e)
        {
            Window_Products product = new Window_Products();
            product.Show();
            this.Close();
        }
        private void Button_Departaments(object sender, RoutedEventArgs e)
        {
            Window_Departaments departament = new Window_Departaments();
            departament.Show();
            this.Close();
        }
        private void Button_Quit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

    }
}
    

