using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.Models
{
    public class DBContext : DbContext
    {
        public DbSet<Worker> workers { get ; set; }
        public DbSet<Suppliers> suppliers { get; set; }
        public DbSet<Shifts> shifts { get; set; }
        public DbSet<Products> products { get; set; }
        public DbSet<Departments> departments { get; set; }
        private string DbPath;
        public DBContext() {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "Supermarket.db");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={DbPath}");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Worker>().HasData(
                new Worker() { Id = 1, Name = "Jan", Lastname = "Nowak", Address = "ul.Krakowska", Age = 30, Postalcode = "31-004 Kraków"},
                new Worker() { Id = 2, Name = "Kuba", Lastname = "Krzyszczak", Address = "ul.Parkowa", Age = 25, Postalcode = "31-004 Kraków" },
                new Worker() { Id = 3, Name = "Janina", Lastname = "Chrostowa", Address = "ul.Bocheńska", Age = 50, Postalcode = "32-000 Niepołomice" },
                new Worker() { Id = 4, Name = "Krystyna", Lastname = "Kowalska", Address = "ul.Kazimierza Wielkiego", Age = 42, Postalcode = "32-700 Bochnia" }

                );
        }
    }   
}
