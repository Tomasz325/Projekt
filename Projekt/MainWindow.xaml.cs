using Microsoft.EntityFrameworkCore;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Projekt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly WorkerCrudServices workercrudservice;

        public MainWindow()
        {
            InitializeComponent();
            workercrudservice = new WorkerCrudServices();
            RefBut.Click += ButtonRefresh;
            AddBut.Click += ButtonAdd;
            DelBut.Click += ButtonDelete;
            SerBut.Click += ButtonSearch;
            Updbut.Click += ButtonUpdate;
            ButShift.Click += Button_Shifts;
            ButSupplier.Click += Button_Suppliers; 
            ButProduct.Click += Button_Products;
            ButDepartament.Click += Button_Departaments;
            ButQuit.Click += Button_Quit;
        }
        private async Task ListBrands()
        {
            var brandList = await workercrudservice.ListBrands();
            DataGridBrand.ItemsSource = brandList.ToList().Select(w => new { Id = w.Id, Name = w.Name, Lastname = w.Lastname, shifts = String.Join(",", w.shifts.Select(s => $"{s.Type} : {s.Shours} - {s.Fhours}")), department = String.Join(",", w.departments.Select(d => d.Type) ) });
        }
        private async void ButtonRefresh(object sender, RoutedEventArgs e)
        {
            ListBrands();
        }
        private async void ButtonAdd(object sender, RoutedEventArgs e)
        {
            try
            {
                await workercrudservice.AddBrand(Int32.Parse(txtWorkerID.Text), txtWorker.Text, txtLastname.Text, Int32.Parse(txtAge.Text), txtAddress.Text, txtPostalCode.Text);
                ButtonRefresh(sender, e);
                throw new Exception("Data Added");

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally
            {
                txtWorkerID.Clear();
                txtWorker.Clear();
                txtLastname.Clear();
                txtAge.Clear();
                txtAddress.Clear();
                txtPostalCode.Clear();
                txtWorkerID.Focus();
            }

        }
        private async void ButtonDelete(object sender, RoutedEventArgs e)
        {
            try
            {
                await workercrudservice.DeleteBrand(Int32.Parse(txtWorkerID.Text));
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
                await workercrudservice.UpdateBrand(Int32.Parse(txtWorkerID.Text), txtWorker.Text, txtLastname.Text, Int32.Parse(txtAge.Text), txtAddress.Text, txtPostalCode.Text);
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
            var search = await workercrudservice.SearchBrandByName(txtWorker.Text);
            DataGridBrand.ItemsSource = search.ToList();
        }
        private void Button_Shifts(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            Window_Shifts shifts = new Window_Shifts();
            shifts.Show();
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
