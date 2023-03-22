using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JOP
{
    class DBContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Product { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany()
                .HasForeignKey(p => p.IdCategory)
                .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Products_Category"); ;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SHOP;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SHOP;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
    }
}

//Scaffold-DbContext "Server=(localdb)\\MSSQLLocalDB;Database=SHOP;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models
//Scaffold-DbContext "Server="Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SHOP;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;Database=SHOP;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer