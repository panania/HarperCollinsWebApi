using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HarperCollinsWebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HarperCollinsWebApi.Data
{
    public class HarperCollinsWebApiDbContext : DbContext
    {
        public HarperCollinsWebApiDbContext(DbContextOptions<HarperCollinsWebApiDbContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Title> Titles { get; set; }
        public DbSet<SaleOrder> SaleOrders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToTable("Customer");
            modelBuilder.Entity<Title>().ToTable("Title");
            modelBuilder.Entity<SaleOrder>().ToTable("SaleOrder");
        }
    }
}
