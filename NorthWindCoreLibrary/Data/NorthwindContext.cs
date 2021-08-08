using System;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using NorthWindCoreLibrary.Data.Configurations;
using NorthWindCoreLibrary.Models;
using SqlServerConnectionLibrary;

#nullable disable

namespace NorthWindCoreLibrary.Data
{
    public partial class NorthwindContext : DbContext
    {
        public NorthwindContext()
        {
        }

        public NorthwindContext(DbContextOptions<NorthwindContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<ContactDevices> ContactDevices { get; set; }
        public virtual DbSet<ContactType> ContactType { get; set; }
        public virtual DbSet<Contacts> Contacts { get; set; }
        public virtual DbSet<Countries> Countries { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<EmployeeTerritories> EmployeeTerritories { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<PhoneType> PhoneType { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Region> Region { get; set; }
        public virtual DbSet<Shippers> Shippers { get; set; }
        public virtual DbSet<Suppliers> Suppliers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                Helper.Initializer();
                NoLogging(optionsBuilder);
            }
        }
        private static void LogQueryInfoToDebugOutputWindow(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Helper.ConnectionString)
                .EnableSensitiveDataLogging()
                .LogTo(message => Debug.WriteLine(message));
        }
        private static void NoLogging(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Helper.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoriesConfiguration());
            modelBuilder.ApplyConfiguration(new ContactDevicesConfiguration());
            modelBuilder.ApplyConfiguration(new ContactTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ContactsConfiguration());
            modelBuilder.ApplyConfiguration(new CountriesConfiguration());
            modelBuilder.ApplyConfiguration(new CustomersConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeTerritoriesConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeesConfiguration());
            modelBuilder.ApplyConfiguration(new OrderDetailsConfiguration());
            modelBuilder.ApplyConfiguration(new OrdersConfiguration());
            modelBuilder.ApplyConfiguration(new PhoneTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ProductsConfiguration());
            modelBuilder.ApplyConfiguration(new RegionConfiguration());
            modelBuilder.ApplyConfiguration(new ShippersConfiguration());
            modelBuilder.ApplyConfiguration(new SuppliersConfiguration());

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
