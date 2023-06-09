﻿using Projekt.Crud_Services;
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
    /// Logika interakcji dla klasy Window_Products.xaml
    /// </summary>
    public partial class Window_Products : Window
    {
        private readonly ProductCrudServices productcrudservices;
        public Window_Products()
        {
            InitializeComponent();
            productcrudservices = new ProductCrudServices();
            RefBut.Click += ButtonRefresh;
            AddBut.Click += ButtonAdd;
            DelBut.Click += ButtonDelete;
            SerBut.Click += ButtonSearch;
            Updbut.Click += ButtonUpdate;
            ButShift.Click += Button_Shifts;
            ButSupplier.Click += Button_Suppliers;
            ButWorker.Click += Button_Workers;
            ButDepartament.Click += Button_Departaments;
            ButQuit.Click += Button_Quit;
        }
        private async Task ListBrands()
        {
            var brandList = await productcrudservices.ListBrands();
            DataGridBrand.ItemsSource = brandList.ToList().Select(p => new { Id = p.Id, Name = p.Name, Type = p.Type, Price = p.Price, Quantity = p.Quantity,  departament = String.Join(",", p.departments.Select(d => d.Type))});
        }
        private async void ButtonRefresh(object sender, RoutedEventArgs e)
        {
            ListBrands();
        }
        private async void ButtonAdd(object sender, RoutedEventArgs e)
        {
            try
            {
                await productcrudservices.AddBrand(Int32.Parse(txtProductID.Text), txtProductName.Text, txtProductType.Text, Double.Parse(txtProductQuantity.Text), Double.Parse(txtProductPrice.Text) );
                ButtonRefresh(sender, e);
                throw new Exception("Data Added");

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally
            {
                txtProductID.Clear();
                txtProductName.Clear();
                txtProductType.Clear();
                txtProductQuantity.Clear();
                txtProductPrice.Clear();
                txtProductID.Focus();
            }

        }
        private async void ButtonDelete(object sender, RoutedEventArgs e)
        {
            try
            {
                await productcrudservices.DeleteBrand(Int32.Parse(txtProductID.Text));
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
                await productcrudservices.UpdateBrand(Int32.Parse(txtProductID.Text), txtProductName.Text, txtProductType.Text, Double.Parse(txtProductQuantity.Text), Double.Parse(txtProductPrice.Text) );
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
            var search = await productcrudservices.SearchBrandByName(txtProductName.Text);
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
        private void Button_Workers(object sender, RoutedEventArgs e)
        {
            MainWindow worker = new MainWindow();
            worker.Show();
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

    

