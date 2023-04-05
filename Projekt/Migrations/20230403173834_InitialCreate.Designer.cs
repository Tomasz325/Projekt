﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Projekt.Models;

#nullable disable

namespace Projekt.Migrations
{
    [DbContext(typeof(DBContext))]
    [Migration("20230403173834_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.15");

            modelBuilder.Entity("Projekt.Models.Departments", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Liability")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Liability = "Janina Chrostowa",
                            Type = "Warzywno-Owocowy"
                        },
                        new
                        {
                            Id = 2,
                            Liability = "Jan Nowak",
                            Type = "Napoje i przekąski"
                        },
                        new
                        {
                            Id = 3,
                            Liability = "Kuba Krzyszczak",
                            Type = "Nabiał"
                        },
                        new
                        {
                            Id = 4,
                            Liability = "Krystyna Kowalska",
                            Type = "Mięso i wędliny"
                        });
                });

            modelBuilder.Entity("Projekt.Models.Products", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.Property<double>("Quantity")
                        .HasColumnType("REAL");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Pepsi 2L",
                            Price = 6.5,
                            Quantity = 12.0,
                            Type = "Napój gazowany"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Tymbark Jabłkowy 1L",
                            Price = 5.4000000000000004,
                            Quantity = 8.0,
                            Type = "Sok"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Cisowianka 1,5 L",
                            Price = 1.8,
                            Quantity = 20.0,
                            Type = "Woda"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Lay's Paprykowe",
                            Price = 7.2000000000000002,
                            Quantity = 6.0,
                            Type = "Przekąski"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Doritos Klasyczne",
                            Price = 7.0,
                            Quantity = 10.0,
                            Type = "Przekąski"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Orzeszki Ziemne",
                            Price = 11.199999999999999,
                            Quantity = 7.0,
                            Type = "Przekąski"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Coca-Cola 1,5 L",
                            Price = 8.5,
                            Quantity = 16.0,
                            Type = "Napój gazowany"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Marchewka Polska 1KG",
                            Price = 15.0,
                            Quantity = 16.0,
                            Type = "Warzywa"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Papryka Czerwona 1KG",
                            Price = 26.0,
                            Quantity = 20.0,
                            Type = "Warzywa"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Jabłko 1KG",
                            Price = 5.5,
                            Quantity = 25.0,
                            Type = "Owoce"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Gruszka 1KG",
                            Price = 12.800000000000001,
                            Quantity = 10.0,
                            Type = "Owoce"
                        },
                        new
                        {
                            Id = 12,
                            Name = "Mleko Łaciate 1L",
                            Price = 4.9900000000000002,
                            Quantity = 12.0,
                            Type = "Nabiał"
                        },
                        new
                        {
                            Id = 13,
                            Name = "Ser Półtłusty 250G",
                            Price = 3.9900000000000002,
                            Quantity = 12.0,
                            Type = "Nabiał"
                        },
                        new
                        {
                            Id = 14,
                            Name = "Bakoma Natrualny 400G",
                            Price = 5.0,
                            Quantity = 7.0,
                            Type = "Yoghurt"
                        },
                        new
                        {
                            Id = 15,
                            Name = "Schab Bez Kości 1KG",
                            Price = 19.5,
                            Quantity = 20.0,
                            Type = "Mięso"
                        },
                        new
                        {
                            Id = 16,
                            Name = "Szynka Drwala 1KG",
                            Price = 37.5,
                            Quantity = 15.0,
                            Type = "Mięso"
                        });
                });

            modelBuilder.Entity("Projekt.Models.Shifts", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Fhours")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Shours")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Shifts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Fhours = "14:00",
                            Shours = "6:00",
                            Type = "Dzienna"
                        },
                        new
                        {
                            Id = 2,
                            Fhours = "22:00",
                            Shours = "14:00",
                            Type = "Nocna"
                        });
                });

            modelBuilder.Entity("Projekt.Models.Suppliers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Carsize")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Suppliers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Carsize = "Duże",
                            Name = "Sokołów",
                            Type = "Dostawcze"
                        },
                        new
                        {
                            Id = 2,
                            Carsize = "Średnie",
                            Name = "Mlekovita",
                            Type = "Dostawcze"
                        },
                        new
                        {
                            Id = 3,
                            Carsize = "Małe",
                            Name = "Sadowcy",
                            Type = "Osobowe"
                        },
                        new
                        {
                            Id = 4,
                            Carsize = "Duże",
                            Name = "Eurocash",
                            Type = "Tir"
                        });
                });

            modelBuilder.Entity("Projekt.Models.Worker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Age")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Postalcode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Workers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "ul.Krakowska",
                            Age = 30,
                            Lastname = "Nowak",
                            Name = "Jan",
                            Postalcode = "31-004 Kraków"
                        },
                        new
                        {
                            Id = 2,
                            Address = "ul.Parkowa",
                            Age = 25,
                            Lastname = "Krzyszczak",
                            Name = "Kuba",
                            Postalcode = "31-004 Kraków"
                        },
                        new
                        {
                            Id = 3,
                            Address = "ul.Bocheńska",
                            Age = 50,
                            Lastname = "Chrostowa",
                            Name = "Janina",
                            Postalcode = "32-000 Niepołomice"
                        },
                        new
                        {
                            Id = 4,
                            Address = "ul.Kazimierza Wielkiego",
                            Age = 42,
                            Lastname = "Kowalska",
                            Name = "Krystyna",
                            Postalcode = "32-700 Bochnia"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}