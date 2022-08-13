using System;
using EliteFlower.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace EliteFlower.Data.DataContext
{
    public partial class eliteflowerContext : DbContext
    {
        public eliteflowerContext()
        {
        }

        public eliteflowerContext(DbContextOptions<eliteflowerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Manufacture> Manufactures { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Manufacture>(entity =>
            {
                entity.ToTable("Manufacture");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
