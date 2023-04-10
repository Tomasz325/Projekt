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
        }
        private async Task ListBrands()
        {
            var brandList = await departamenttcrudservice.ListBrands();
            DataGridBrand.ItemsSource = brandList.ToList();
        }
        private async void ButtonRefresh(object sender, RoutedEventArgs e)
        {
            var list = (await departamenttcrudservice.ListBrands()).ToList();
            DataGridBrand.ItemsSource = list;
        }
        private async void ButtonAdd(object sender, RoutedEventArgs e)
        {
            try
            {
                await departamenttcrudservice.AddBrand(Int32.Parse(txtDepartamentID.Text), txtDepartamentType.Text, txtLiability.Text);
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
                await departamenttcrudservice.UpdateBrand(Int32.Parse(txtDepartamentID.Text), txtDepartamentType.Text, txtLiability.Text);
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
        private void Button_Workers(object sender, RoutedEventArgs e)
        {
            Window_Departaments department = new Window_Departaments();
            MainWindow workers = new MainWindow();
            workers.Show();
            this.Close();

        }
        private void Button_Suppliers(object sender, RoutedEventArgs e)
        {
            Window_Suppliers suppliers = new Window_Suppliers();
            suppliers.Show();
            this.Close();
        }
        private void Button_Products(object sender, RoutedEventArgs e)
        {
            Window_Products product = new Window_Products();
            product.Show();
            this.Close();
        }
        private void Button_Shifts(object sender, RoutedEventArgs e)
        {
            Window_Shifts shift  = new Window_Shifts();
            shift.Show();
            this.Close();
        }
        private void Button_Quit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

    }
}
    

