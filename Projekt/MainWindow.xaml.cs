using Microsoft.EntityFrameworkCore;
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
        DBContext context = new DBContext();
        public async Task<ICollection<Worker>> ListBrands()
        {
            try
            {
                return (ICollection<Worker>)await context.Workers.ToListAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
       
        private async Task Refresh()
        {
            var list = await context.Workers.ToListAsync();
            DataGridBrand.ItemsSource = list;
        }
        private async void Reverse(object sender, RoutedEventArgs e)
            {
            await Refresh();
            }
        public MainWindow()
        {
            InitializeComponent();
            RefBut.Click += Reverse;

        }
    }
}
