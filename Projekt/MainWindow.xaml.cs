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
        }
        private async Task ListBrands()
        {
            var brandList = await workercrudservice.ListBrands();
            DataGridBrand.ItemsSource = brandList.ToList();
        }
        private async void ButtonRefresh(object sender, RoutedEventArgs e)
        {
            var list = (await workercrudservice.ListBrands()).ToList();
            DataGridBrand.ItemsSource = list;
        }
        private async void ButtonAdd(object sender, RoutedEventArgs e)
        {
            try
            {
               await workercrudservice.AddBrand(Int32.Parse(txtWorkerID.Text), txtWorker.Text, txtLastname.Text, Int32.Parse(txtAge.Text), txtAddress.Text, txtPostalCode.Text);
                ButtonRefresh(sender, e);
                throw new Exception("Data Added");

            }
            catch (Exception ex) {MessageBox.Show(ex.Message); }
            finally {
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
            try {
                await workercrudservice.DeleteBrand(Int32.Parse(txtWorkerID.Text));
                throw new Exception("Data Removed");
            }
            catch(Exception ex)
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
            catch(Exception ex)
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
    }
}
