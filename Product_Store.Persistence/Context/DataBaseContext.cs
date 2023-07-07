using Microsoft.EntityFrameworkCore;
using Product_Store.Domain.Entities.Products;
using Product_Store.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Product_Store.Application.Interfaces.Contexts;

namespace Product_Store.Persistence.Context
{
    public class DataBaseContext : DbContext, IDataBaseContext
    {
        public DataBaseContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Manufacture> Manufactures { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(k => new { k.ManufactureEmail, k.ProduceDate });
                entity.Property(e => e.Name)
                     .HasMaxLength(20)
                     .IsUnicode(true); ;
                entity.Property(e => e.IsAvailable);
                entity.Property(e => e.ProduceDate); 
                entity.Property(e => e.ManufactureEmail)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
                entity.Property(e => e.ManufacturePhone)
                    .HasMaxLength(30)
                    .IsUnicode(false);
                entity.HasOne(m => m.Manufacture)
                     .WithMany(p => p.Product)
                     .HasForeignKey(m => m.ManufactureId)
                     .OnDelete(DeleteBehavior.NoAction)
                     .HasConstraintName("FK_Product_Manufacture");
            });

            modelBuilder.Entity<Manufacture>(entity =>
            {
                entity.HasKey(k => new { k.ManufactureId });
                entity.Property(e => e.ManufactureFirstName)
                    .HasMaxLength(20)
                    .IsUnicode(true);
                entity.Property(e => e.ManufactureLastName)
                    .HasMaxLength(30)
                    .IsUnicode(true);
                entity.Property(e => e.ManufactureEmail)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
                entity.Property(e => e.ManufacturePhone)
                    .HasMaxLength(30)
                    .IsUnicode(false);
                entity.Property(e => e.ManufacturePassword)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(true);
            });

            // اعمال ایندکس بر روی فیلد ایمیل
            // اعمال عدم تکراری بودن ایمیل
            modelBuilder.Entity<Manufacture>().HasIndex(u => u.ManufactureEmail).IsUnique();

     
        }

    }
}
