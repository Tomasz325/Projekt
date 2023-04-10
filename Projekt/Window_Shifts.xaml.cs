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
    /// Logika interakcji dla klasy Window_Shifts.xaml
    /// </summary>
    public partial class Window_Shifts : Window
    {
        private readonly ShiftCrudServices shiftcrudservice;
        public Window_Shifts()
        {
            InitializeComponent();
            shiftcrudservice = new ShiftCrudServices();
            RefBut.Click += ButtonRefresh;
            AddBut.Click += ButtonAdd;
            DelBut.Click += ButtonDelete;
            SerBut.Click += ButtonSearch;
            Updbut.Click += ButtonUpdate;
            ButWork.Click += Button_Workers;
            ButSupplier.Click += Button_Suppliers;
            ButProduct.Click += Button_Products;
            ButDepartament.Click += Button_Departaments;
            ButQuit.Click += Button_Quit;
        }
        private async Task ListBrands()
        {
            var brandList = await shiftcrudservice.ListBrands();
            DataGridBrand.ItemsSource = brandList.ToList();
        }
        private async void ButtonRefresh(object sender, RoutedEventArgs e)
        {
            var list = (await shiftcrudservice.ListBrands()).ToList();
            DataGridBrand.ItemsSource = list;
        }
        private async void ButtonAdd(object sender, RoutedEventArgs e)
        {
            try
            {
                await shiftcrudservice.AddBrand(Int32.Parse(txtShiftID.Text), txtShiftType.Text, txtSHours.Text, txtFHours.Text);
                ButtonRefresh(sender, e);
                throw new Exception("Data Added");

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally
            {
                txtShiftID.Clear();
                txtShiftType.Clear();
                txtSHours.Clear();
                txtFHours.Clear();
                txtShiftID.Focus();
            }

        }
        private async void ButtonDelete(object sender, RoutedEventArgs e)
        {
            try
            {
                await shiftcrudservice.DeleteBrand(Int32.Parse(txtShiftID.Text));
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
                await shiftcrudservice.UpdateBrand(Int32.Parse(txtShiftID.Text), txtShiftType.Text, txtSHours.Text, txtFHours.Text);
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
            var search = await shiftcrudservice.SearchBrandByName(txtShiftType.Text);
            DataGridBrand.ItemsSource = search.ToList();
        }
        private void Button_Workers(object sender, RoutedEventArgs e)
        {
            Window_Shifts shifts = new Window_Shifts();
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
    

