using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication1.Models
{
    public partial class EshopApi_DBContext : DbContext
    {
        public EshopApi_DBContext()
        {
        }

        public EshopApi_DBContext(DbContextOptions<EshopApi_DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderItem> OrderItems { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<SalesPerson> SalesPeople { get; set; } = null!;

      

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.Address)
                    .HasMaxLength(150)
                    .IsFixedLength();

                entity.Property(e => e.City)
                    .HasMaxLength(150)
                    .IsFixedLength();

                entity.Property(e => e.Email)
                    .HasMaxLength(150)
                    .IsFixedLength();

                entity.Property(e => e.FirstNamr)
                    .HasMaxLength(150)
                    .IsFixedLength();

                entity.Property(e => e.LastName)
                    .HasMaxLength(150)
                    .IsFixedLength();

                entity.Property(e => e.Phone)
                    .HasMaxLength(150)
                    .IsFixedLength();

                entity.Property(e => e.State)
                    .HasMaxLength(150)
                    .IsFixedLength();

                entity.Property(e => e.ZipCode)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(150)
                    .IsFixedLength();

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_Customer");

                entity.HasOne(d => d.SalesPerson)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.SalesPersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_SalesPerson");
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderItems_Orders");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderItems_Products");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ProductName)
                    .HasMaxLength(150)
                    .IsFixedLength();

                entity.Property(e => e.Status)
                    .HasMaxLength(150)
                    .IsFixedLength();

                entity.Property(e => e.Varienty)
                    .HasMaxLength(150)
                    .IsFixedLength();
            });

            modelBuilder.Entity<SalesPerson>(entity =>
            {
                entity.ToTable("SalesPerson");

                entity.Property(e => e.Address)
                    .HasMaxLength(150)
                    .IsFixedLength();

                entity.Property(e => e.City)
                    .HasMaxLength(150)
                    .IsFixedLength();

                entity.Property(e => e.Email)
                    .HasMaxLength(150)
                    .IsFixedLength();

                entity.Property(e => e.FirstName)
                    .HasMaxLength(150)
                    .IsFixedLength();

                entity.Property(e => e.LastName)
                    .HasMaxLength(150)
                    .IsFixedLength();

                entity.Property(e => e.Phone)
                    .HasMaxLength(150)
                    .IsFixedLength();

                entity.Property(e => e.State)
                    .HasMaxLength(150)
                    .IsFixedLength();

                entity.Property(e => e.ZipCode)
                    .HasMaxLength(150)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
