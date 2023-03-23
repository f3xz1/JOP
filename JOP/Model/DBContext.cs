using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace JOP
{
    public class DBContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; } /// /
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
//Scaffold-DbContext "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SHOP;Integrated Security=True;" Microsoft.EntityFrameworkCore.SqlServer - outputdir  Models - context SHOP DbContext - contextdir Repository - DataAnnotations - Force
//Scaffold-DbContext "Data Source=MSSQLLocalDB;Initial Catalog=SHOP;Integrated Security=True;" Microsoft.EntityFrameWorkCore.SqlServer - outputdir Repository / Models - context SHOPDBContext DbContext - contextdir Repository - DataAnnotations - Force
//Scaffold - DbContext "Server=(localdb)\MSSQLLocalDB;Database=SHOP;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Model
//Scaffold-DbContext "Server=(localdb)\\MSSQLLocalDB;Database=SHOP;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Model
//Scaffold-DbContext "Server=Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SHOP;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;Database=SHOP;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer