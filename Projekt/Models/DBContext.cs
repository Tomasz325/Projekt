﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.Models
{
    public class DBContext : DbContext
    {
        public DbSet<Worker> Workers { get ; set; }
        public DbSet<Suppliers> Suppliers { get; set; }
        public DbSet<Shifts> Shifts { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Departments> Departments { get; set; }
        private string DbPath;
        public DBContext(DbContextOptions options): base (options) {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Worker>().HasData(
                new Worker() { Id = 1, Name = "Jan", Lastname = "Nowak", Address = "ul.Krakowska", Age = 30, Postalcode = "31-004 Kraków"},
                new Worker() { Id = 2, Name = "Kuba", Lastname = "Krzyszczak", Address = "ul.Parkowa", Age = 25, Postalcode = "31-004 Kraków" },
                new Worker() { Id = 3, Name = "Janina", Lastname = "Chrostowa", Address = "ul.Bocheńska", Age = 50, Postalcode = "32-000 Niepołomice" },
                new Worker() { Id = 4, Name = "Krystyna", Lastname = "Kowalska", Address = "ul.Kazimierza Wielkiego", Age = 42, Postalcode = "32-700 Bochnia" }

                );
            modelBuilder.Entity<Suppliers>().HasData(
                new Suppliers() { Id = 1, Name = "Sokołów", Type = "Dostawcze", Carsize = "Duże" },
                new Suppliers() { Id = 2, Name = "Mlekovita", Type = "Dostawcze", Carsize = "Średnie" },
                new Suppliers() { Id = 3, Name = "Sadowcy", Type = "Osobowe", Carsize = "Małe" },
                new Suppliers() { Id = 4, Name = "Eurocash", Type = "Tir", Carsize = "Duże" }
                );
            modelBuilder.Entity<Shifts>().HasData(
               new Shifts() { Id = 1, Type = "Dzienna", Shours = "6:00", Fhours = "14:00" },
               new Shifts() { Id = 2, Type = "Nocna", Shours = "14:00", Fhours = "22:00" }
               );
            modelBuilder.Entity<Products>().HasData(
                new Products() { Id = 1, Type = "Napój gazowany", Name = "Pepsi 2L", Quantity = 12, Price = 6.50 },
                new Products() { Id = 2, Type = "Sok", Name = "Tymbark Jabłkowy 1L", Quantity = 8, Price = 5.40 },
                new Products() { Id = 3, Type = "Woda", Name = "Cisowianka 1,5 L", Quantity = 20, Price = 1.80 },
                new Products() { Id = 4, Type = "Przekąski", Name = "Lay's Paprykowe", Quantity = 6, Price = 7.20 },
                new Products() { Id = 5, Type = "Przekąski", Name = "Doritos Klasyczne", Quantity = 10, Price = 7.00 },
                new Products() { Id = 6, Type = "Przekąski", Name = "Orzeszki Ziemne", Quantity = 7, Price = 11.20 },
                new Products() { Id = 7, Type = "Napój gazowany", Name = "Coca-Cola 1,5 L", Quantity = 16, Price = 8.50 },
                new Products() { Id = 8, Type = "Warzywa", Name = "Marchewka Polska 1KG", Quantity = 16, Price = 15.00 },
                new Products() { Id = 9, Type = "Warzywa", Name = "Papryka Czerwona 1KG", Quantity = 20, Price = 26.00 },
                new Products() { Id = 10, Type = "Owoce", Name = "Jabłko 1KG", Quantity = 25, Price = 5.50 },
                new Products() { Id = 11, Type = "Owoce", Name = "Gruszka 1KG", Quantity = 10, Price = 12.80 },
                new Products() { Id = 12, Type = "Nabiał", Name = "Mleko Łaciate 1L", Quantity = 12, Price = 4.99 },
                new Products() { Id = 13, Type = "Nabiał", Name = "Ser Półtłusty 250G", Quantity = 12, Price = 3.99 },
                new Products() { Id = 14, Type = "Yoghurt", Name = "Bakoma Natrualny 400G", Quantity = 7, Price = 5.00 },
                new Products() { Id = 15, Type = "Mięso", Name = "Schab Bez Kości 1KG", Quantity = 20, Price = 19.50 },
                new Products() { Id = 16, Type = "Mięso", Name = "Szynka Drwala 1KG", Quantity = 15, Price = 37.50 }
                );
            modelBuilder.Entity<Departments>().HasData(
                new Departments() { Id = 1, Type = "Warzywno-Owocowy", Liability = "Janina Chrostowa" },
                new Departments() { Id = 2, Type = "Napoje i przekąski", Liability = "Jan Nowak" },
                new Departments() { Id = 3, Type = "Nabiał", Liability = "Kuba Krzyszczak" },
                new Departments() { Id = 4, Type = "Mięso i wędliny", Liability = "Krystyna Kowalska" }
                );
        }

        
    }   
}
