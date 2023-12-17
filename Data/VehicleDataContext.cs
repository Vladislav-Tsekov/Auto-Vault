using Microsoft.EntityFrameworkCore;
using VehicleData.Data.Models;
using VehicleData.Utilities;

namespace VehicleData.Data;

public partial class VehicleDataContext : DbContext
{
    public VehicleDataContext(){}
    public VehicleDataContext(DbContextOptions<VehicleDataContext> options) : base(options){}

    public virtual DbSet<VehicleMake> Makes { get; set; }
    public virtual DbSet<VehicleModel> Models { get; set; }
    public virtual DbSet<VehicleBaseModel> BaseModels { get; set; }
    public virtual DbSet<DrivetrainType> DrivetrainTypes { get; set; }
    public virtual DbSet<VehicleEngine> Engines { get; set; }
    public virtual DbSet<TransmissionType> TransmissionTypes { get; set; }
    public virtual DbSet<Vehicle> Vehicles { get; set; }
    public virtual DbSet<VehicleClass> VehicleClasses { get; set; }
    public virtual DbSet<Year> Years { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer(GlobalConstants.ConnectionString);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<VehicleEngine>(e => e.Property(e => e.Engine)
                                          .HasColumnType("decimal(3,1)")
                                          .IsRequired(true));

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
