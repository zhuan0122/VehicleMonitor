using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace VehicleStatusMicroservice.Models;

public partial class VehicleStatusDbContext : DbContext
{
    public VehicleStatusDbContext()
    {
    }

    public VehicleStatusDbContext(DbContextOptions<VehicleStatusDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Vehicle> Vehicles { get; set; }

    public virtual DbSet<Vehiclestatus> Vehiclestatuses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySQL("Name=VehicleStatus");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PRIMARY");

            entity.ToTable("customers");

            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<Vehicle>(entity =>
        {
            entity.HasKey(e => e.VehicleId).HasName("PRIMARY");

            entity.ToTable("vehicles");

            entity.HasIndex(e => e.CustomerId, "CustomerID");

            entity.Property(e => e.VehicleId).HasColumnName("VehicleID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.RegNumber).HasMaxLength(255);
            entity.Property(e => e.Vin)
                .HasMaxLength(255)
                .HasColumnName("VIN");

            entity.HasOne(d => d.Customer).WithMany(p => p.Vehicles)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("vehicles_ibfk_1");
        });

        modelBuilder.Entity<Vehiclestatus>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("PRIMARY");

            entity.ToTable("vehiclestatus");

            entity.HasIndex(e => e.VehicleId, "VehicleID");

            entity.Property(e => e.StatusId).HasColumnName("StatusID");
            entity.Property(e => e.Status).HasMaxLength(255);
            entity.Property(e => e.Timestamp)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp");
            entity.Property(e => e.VehicleId).HasColumnName("VehicleID");

            entity.HasOne(d => d.Vehicle).WithMany(p => p.Vehiclestatuses)
                .HasForeignKey(d => d.VehicleId)
                .HasConstraintName("vehiclestatus_ibfk_1");
        });
    }
}