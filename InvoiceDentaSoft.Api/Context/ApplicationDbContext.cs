using InvoiceDentaSoft.Api.Entities;
using InvoiceDentaSoft.Api.Entities.LoockUps;
using Microsoft.EntityFrameworkCore;

namespace InvoiceDentaSoft.Api.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<VendorType> VendorTypes { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceHistory> InvoiceHistories { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }
        public DbSet<InvoiceItemTax> InvoiceItemTaxes { get; set; }
        public DbSet<InvoiceTotal> InvoiceTotals { get; set; }
        public DbSet<Tax> Taxes { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<VendorType>().HasData(
                new VendorType()
                {
                    Id = 1,
                    Name = "Employee"
                },
                new VendorType()
                {
                    Id = 2,
                    Name = "Supplier"
                },
                new VendorType()
                {
                    Id = 3,
                    Name = "Patient"
                },
                new VendorType()
                {
                    Id = 4,
                    Name = "Other"
                }
                );
        }
    }
}
