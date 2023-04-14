using Projekt.Crud_Services;
using Projekt.Models;
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
    /// Logika interakcji dla klasy Window_Departaments.xaml
    /// </summary>
    public partial class Window_Departaments : Window
    {
        private readonly DepartamentCrudServices departamenttcrudservice;
        public Window_Departaments()
        {
            InitializeComponent();
            departamenttcrudservice = new DepartamentCrudServices();
            RefBut.Click += ButtonRefresh;
            AddBut.Click += ButtonAdd;
            DelBut.Click += ButtonDelete;
            SerBut.Click += ButtonSearch;
            Updbut.Click += ButtonUpdate;
            ButWork.Click += Button_Workers;
            ButSupplier.Click += Button_Suppliers;
            ButProduct.Click += Button_Products;
            ButShift.Click += Button_Shifts;
            ButQuit.Click += Button_Quit;
            ProBut.Click += AddProduct;
            RemPro.Click += DeleteProduct;
        }
        
        private async Task ListBrands()
        {
            var brandList = await departamenttcrudservice.ListBrands();
            DataGridBrand.ItemsSource = brandList.ToList().Select(d => new { Id = d.Id, Type = d.Type, products = String.Join(", ", d.products.Select( p => p.Name)), Workers = String.Join(",",d.Workers.Select(w => $"{w.Name}  {w.Lastname}")) });
            
        }
        /// <summary>
        /// Funkcja odświeżająca dane w DataGrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void ButtonRefresh(object sender, RoutedEventArgs e)
        {
            await ListBrands();
        }
        
        private async void ButtonAdd(object sender, RoutedEventArgs e)
        {
            try
            {
                await departamenttcrudservice.AddBrand(Int32.Parse(txtDepartamentID.Text), txtDepartamentType.Text, Int32.Parse(txtLiability.Text ));
                ButtonRefresh(sender, e);
                throw new Exception("Data Added");

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally
            {
                txtDepartamentID.Clear();
                txtDepartamentType.Clear();
                txtLiability.Clear();
                txtDepartamentID.Focus();
            }

        }
        
        private async void AddProduct(object sender, RoutedEventArgs e)
        {
            try
            {
                await departamenttcrudservice.AddProduct(Int32.Parse(txtDepartamentID.Text), Int32.Parse(txtProductID.Text));
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally
            {
                ListBrands();
            }
        }
        
        private async void DeleteProduct(object sender, RoutedEventArgs e)
        {
            try
            {
                await departamenttcrudservice.DeleteProduct(Int32.Parse(txtDepartamentID.Text), Int32.Parse(txtProductID.Text));
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }
            finally
            {
                ListBrands();
            }
        
            
        }
        
        private async void ButtonDelete(object sender, RoutedEventArgs e)
        {
            try
            {
                await departamenttcrudservice.DeleteBrand(Int32.Parse(txtDepartamentID.Text));
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
                await departamenttcrudservice.UpdateBrand(Int32.Parse(txtDepartamentID.Text), txtDepartamentType.Text, Int32.Parse(txtLiability.Text));
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
            var search = await departamenttcrudservice.SearchBrandByName(txtDepartamentType.Text);
            DataGridBrand.ItemsSource = search.ToList();
        }
        /// <summary>
        /// Przycisk służący do przejścia do nowego okna z tabelą Worker
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Workers(object sender, RoutedEventArgs e)
        {
            Window_Departaments department = new Window_Departaments();
            MainWindow workers = new MainWindow();
            workers.Show();
            this.Close();

        }
        /// <summary>
        /// Przycisk służący do przejścia do nowego okna z tabelą Suppliers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Suppliers(object sender, RoutedEventArgs e)
        {
            Window_Suppliers suppliers = new Window_Suppliers();
            suppliers.Show();
            this.Close();
        }
        /// <summary>
        /// Przycisk służący do przejścia do nowego okna z tabelą Products
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Products(object sender, RoutedEventArgs e)
        {
            Window_Products product = new Window_Products();
            product.Show();
            this.Close();
        }
        /// <summary>
        /// Przycisk służący do przejścia do nowego okna z tabelą Shifts
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Shifts(object sender, RoutedEventArgs e)
        {
            Window_Shifts shift  = new Window_Shifts();
            shift.Show();
            this.Close();
        }
        /// <summary>
        /// Przycisk służący do zamknięcia aplikacji
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Quit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

    }
}
    

