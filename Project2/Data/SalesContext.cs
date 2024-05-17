using Microsoft.EntityFrameworkCore;
using P02_SalesDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace P02_SalesDatabase.Data
{
    internal class SalesContext : DbContext
    {
        public virtual DbSet<Customers> Customer { get; set; }
        public virtual DbSet<Products> Product { get; set; }
        public virtual DbSet<Sales> Sale { get; set; }
        public virtual DbSet<Stores> Store { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=SaleSystem;Integrated Security=True;TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Relations
            //Has many

            modelBuilder.Entity<Sales>()
              .HasMany(e => e.products)
              .WithMany(e => e.sales)
              .UsingEntity(
                 "ProductSales",
                l => l.HasOne(typeof(Sales)).WithMany().HasForeignKey("SalesId").HasPrincipalKey(nameof(Sales.SalesId)),
                r => r.HasOne(typeof(Products)).WithMany().HasForeignKey("ProductsId").HasPrincipalKey(nameof(Products.ProductsId)),
                j => j.HasKey("SalesId", "ProductsId"));


            modelBuilder.Entity<Sales>()
               .HasMany(e => e.stores)
               .WithMany(e => e.sales)
               .UsingEntity(
                 "StoresSales",
                l => l.HasOne(typeof(Sales)).WithMany().HasForeignKey("SalesId").HasPrincipalKey(nameof(Sales.SalesId)),
                r => r.HasOne(typeof(Stores)).WithMany().HasForeignKey("StoresId").HasPrincipalKey(nameof(Stores.StoresId)),
                j => j.HasKey("SalesId", "StoresId"));

            modelBuilder.Entity<Customers>()
               .HasMany(e => e.sales)
               .WithOne(e => e.customer)
               .HasForeignKey(e => e.CustomersId)
               .HasPrincipalKey(e => e.CustomersId);

            modelBuilder.Entity<Stores>()
               .HasMany(e => e.sales)
               .WithMany(e => e.stores)
               .UsingEntity(
                 "StoresSales",
                l => l.HasOne(typeof(Sales)).WithMany().HasForeignKey("SalesId").HasPrincipalKey(nameof(Sales.SalesId)),
                r => r.HasOne(typeof(Stores)).WithMany().HasForeignKey("StoresId").HasPrincipalKey(nameof(Stores.StoresId)),
                j => j.HasKey("SalesId", "StoresId"));

            modelBuilder.Entity<Products>()
               .HasMany(e => e.sales)
               .WithMany(e => e.products)
                .UsingEntity(
                 "ProductSales",
                l => l.HasOne(typeof(Sales)).WithMany().HasForeignKey("SalesId").HasPrincipalKey(nameof(Sales.SalesId)),
                r => r.HasOne(typeof(Products)).WithMany().HasForeignKey("ProductsId").HasPrincipalKey(nameof(Products.ProductsId)),
                j => j.HasKey("SalesId", "ProductsId"));

            //Has one

            modelBuilder.Entity<Sales>()
               .HasOne(e => e.customer)
               .WithMany(e => e.sales)
               .HasForeignKey(e => e.CustomersId)
               .HasPrincipalKey(e => e.CustomersId);

            //Characters
            modelBuilder.Entity<Products>()
            .Property(e => e.Name)
            .HasColumnType("nvarchar(50)");

            modelBuilder.Entity<Stores>()
            .Property(e => e.Name)
            .HasColumnType("nvarchar(80)");

            modelBuilder.Entity<Customers>(
            eb =>
            {
                eb.Property(b => b.Name).HasColumnType("nvarchar(100)");
                eb.Property(b => b.Email).HasColumnType("varchar(80)");
            });
            modelBuilder.Entity<Products>(
           sp =>
           {
               sp.Property(s => s.Name).HasColumnType("nvarchar(50)");
               sp.Property(s => s.Price).HasColumnType("decimal(5,2)");
           });
        }
    }   
}
