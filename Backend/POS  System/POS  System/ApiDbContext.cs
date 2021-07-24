using Microsoft.EntityFrameworkCore;
using POS__System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POS__System
{
    public class ApiDbContext : DbContext
    {
        public DbSet<Products> Products { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Invoice_Details> Invoice_Details { get; set; }
        public DbSet<Types> Types { get; set; }

        public ApiDbContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Invoice_Details>().HasKey(vf => new { vf.Product_ID, vf.Invoice_Number });

            base.OnModelCreating(modelBuilder);
        }
    }
}
