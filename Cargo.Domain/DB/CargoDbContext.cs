using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Cargo.Domain.Entities;

namespace Cargo.Domain.Context
{
    public partial class CargoDbContext : DbContext
    {
        public CargoDbContext()
            : base("name=CargoDbContext")
        {
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Application> Applications { get; set; }
        public virtual DbSet<Bank> Banks { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<CurrencyRate> CurrencyRates { get; set; }
        public virtual DbSet<DocumentTemplate> DocumentTemplates { get; set; }
        public virtual DbSet<Driver> Drivers { get; set; }
        public virtual DbSet<ExternalSpending> ExternalSpendings { get; set; }
        public virtual DbSet<FuelSpending> FuelSpendings { get; set; }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<ReceiptItem> ReceiptItems { get; set; }
        public virtual DbSet<Receipt> Receipts { get; set; }
        public virtual DbSet<RouteReport> RouteReports { get; set; }
        public virtual DbSet<ServiceSpending> ServiceSpendings { get; set; }
        public virtual DbSet<Vehicle> Vehicles { get; set; }
        public virtual DbSet<WarehouseItem> WarehouseItems { get; set; }
        public virtual DbSet<ApplicationShortView> ApplicationShortViews { get; set; }
        public virtual DbSet<RouteReportShortView> RouteReportShortViews { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>()
                .HasMany(e => e.Applications)
                .WithRequired(e => e.Client)
                .HasForeignKey(e => e.fClientCompany)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Company>()
                .HasMany(e => e.Receipts)
                .WithRequired(e => e.Supplier)
                .HasForeignKey(e => e.fSupplierCompany)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Driver>()
                .HasMany(e => e.RouteReports)
                .WithRequired(e => e.Driver)
                .HasForeignKey(e => e.fDriver)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Receipt>()
                .HasMany(e => e.ReceiptItems)
                .WithRequired(e => e.Receipt)
                .HasForeignKey(e => e.fReceipt);

            modelBuilder.Entity<RouteReport>()
                .HasMany(e => e.Applications)
                .WithOptional(e => e.RouteReport)
                .HasForeignKey(e => e.fRouteReport);

            modelBuilder.Entity<RouteReport>()
                .HasMany(e => e.ExternalSpendings)
                .WithRequired(e => e.RouteReport)
                .HasForeignKey(e => e.fRouteReport)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RouteReport>()
                .HasMany(e => e.FuelSpendings)
                .WithOptional(e => e.RouteReport)
                .HasForeignKey(e => e.fRouteReport);

            modelBuilder.Entity<Vehicle>()
                .HasMany(e => e.RouteReports)
                .WithRequired(e => e.Vehicle)
                .HasForeignKey(e => e.fVehicle)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Vehicle>()
                .HasMany(e => e.ServiceSpendings)
                .WithRequired(e => e.Vehicle)
                .HasForeignKey(e => e.fVehicle);
        }
    }
}
