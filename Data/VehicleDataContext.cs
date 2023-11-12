using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using VehicleData.Data.Models;

namespace VehicleData.Data;

public partial class VehicleDataContext : DbContext
{
    public VehicleDataContext()
    {
    }

    public VehicleDataContext(DbContextOptions<VehicleDataContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DrivetrainType> DrivetrainTypes { get; set; }

    public virtual DbSet<Engine> Engines { get; set; }

    public virtual DbSet<TransmissionType> TransmissionTypes { get; set; }

    public virtual DbSet<Vehicle> Vehicles { get; set; }

    public virtual DbSet<VehicleClass> VehicleClasses { get; set; }

    public virtual DbSet<Year> Years { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=VehicleData;Integrated Security=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DrivetrainType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DriveTyp__3214EC071020DF99");

            entity.ToTable("DrivetrainType");

            entity.Property(e => e.Drive)
                .HasMaxLength(35)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Engine>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Engine__3214EC07D6C466BC");

            entity.ToTable("Engine");

            entity.HasOne(d => d.VehicleNavigation).WithMany(p => p.Engines)
                .HasForeignKey(d => d.Vehicle)
                .HasConstraintName("FK__Engine__Vehicle__4D94879B");
        });

        modelBuilder.Entity<TransmissionType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Transmis__3214EC07F70BE21B");

            entity.ToTable("TransmissionType");

            entity.Property(e => e.Transmission)
                .HasMaxLength(35)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Vehicle>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Vehicle__3214EC0792FBCB96");

            entity.ToTable("Vehicle");

            entity.Property(e => e.BaseModel)
                .HasMaxLength(75)
                .IsUnicode(false);
            entity.Property(e => e.Make)
                .HasMaxLength(75)
                .IsUnicode(false);
            entity.Property(e => e.Model)
                .HasMaxLength(75)
                .IsUnicode(false);

            entity.HasOne(d => d.DrivetrainTypeNavigation).WithMany(p => p.Vehicles)
                .HasForeignKey(d => d.DrivetrainType)
                .HasConstraintName("FK__Vehicle__DriveTy__47DBAE45");

            entity.HasOne(d => d.TransmissionTypeNavigation).WithMany(p => p.Vehicles)
                .HasForeignKey(d => d.TransmissionType)
                .HasConstraintName("FK__Vehicle__Transmi__48CFD27E");

            entity.HasOne(d => d.VehicleSizeClassNavigation).WithMany(p => p.Vehicles)
                .HasForeignKey(d => d.VehicleSizeClass)
                .HasConstraintName("FK__Vehicle__Vehicle__49C3F6B7");

            entity.HasOne(d => d.YearNavigation).WithMany(p => p.Vehicles)
                .HasForeignKey(d => d.Year)
                .HasConstraintName("FK__Vehicle__Year__4AB81AF0");
        });

        modelBuilder.Entity<VehicleClass>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__VehicleC__3214EC071A710D73");

            entity.ToTable("VehicleClass");

            entity.Property(e => e.Class)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Year>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Year__3214EC076BD48B66");

            entity.ToTable("Year");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
