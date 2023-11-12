﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VehicleData.Data;

#nullable disable

namespace VehicleData.Migrations
{
    [DbContext(typeof(VehicleDataContext))]
    partial class VehicleDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("VehicleData.Data.Models.DrivetrainType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Drive")
                        .HasMaxLength(35)
                        .IsUnicode(false)
                        .HasColumnType("varchar(35)");

                    b.HasKey("Id")
                        .HasName("PK__DriveTyp__3214EC071020DF99");

                    b.ToTable("DrivetrainType", (string)null);
                });

            modelBuilder.Entity("VehicleData.Data.Models.Engine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double?>("Displacement")
                        .HasColumnType("float");

                    b.Property<int?>("Vehicle")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK__Engine__3214EC07D6C466BC");

                    b.HasIndex("Vehicle");

                    b.ToTable("Engine", (string)null);
                });

            modelBuilder.Entity("VehicleData.Data.Models.TransmissionType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Transmission")
                        .HasMaxLength(35)
                        .IsUnicode(false)
                        .HasColumnType("varchar(35)");

                    b.HasKey("Id")
                        .HasName("PK__Transmis__3214EC07F70BE21B");

                    b.ToTable("TransmissionType", (string)null);
                });

            modelBuilder.Entity("VehicleData.Data.Models.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BaseModel")
                        .HasMaxLength(75)
                        .IsUnicode(false)
                        .HasColumnType("varchar(75)");

                    b.Property<int?>("DrivetrainType")
                        .HasColumnType("int");

                    b.Property<string>("Make")
                        .HasMaxLength(75)
                        .IsUnicode(false)
                        .HasColumnType("varchar(75)");

                    b.Property<string>("Model")
                        .HasMaxLength(75)
                        .IsUnicode(false)
                        .HasColumnType("varchar(75)");

                    b.Property<int?>("TransmissionType")
                        .HasColumnType("int");

                    b.Property<int?>("VehicleSizeClass")
                        .HasColumnType("int");

                    b.Property<int?>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK__Vehicle__3214EC0792FBCB96");

                    b.HasIndex("DrivetrainType");

                    b.HasIndex("TransmissionType");

                    b.HasIndex("VehicleSizeClass");

                    b.HasIndex("Year");

                    b.ToTable("Vehicle", (string)null);
                });

            modelBuilder.Entity("VehicleData.Data.Models.VehicleClass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Class")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id")
                        .HasName("PK__VehicleC__3214EC071A710D73");

                    b.ToTable("VehicleClass", (string)null);
                });

            modelBuilder.Entity("VehicleData.Data.Models.Year", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ManufacturingYear")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK__Year__3214EC076BD48B66");

                    b.ToTable("Year", (string)null);
                });

            modelBuilder.Entity("VehicleData.Data.Models.Engine", b =>
                {
                    b.HasOne("VehicleData.Data.Models.Vehicle", "VehicleNavigation")
                        .WithMany("Engines")
                        .HasForeignKey("Vehicle")
                        .HasConstraintName("FK__Engine__Vehicle__4D94879B");

                    b.Navigation("VehicleNavigation");
                });

            modelBuilder.Entity("VehicleData.Data.Models.Vehicle", b =>
                {
                    b.HasOne("VehicleData.Data.Models.DrivetrainType", "DrivetrainTypeNavigation")
                        .WithMany("Vehicles")
                        .HasForeignKey("DrivetrainType")
                        .HasConstraintName("FK__Vehicle__DriveTy__47DBAE45");

                    b.HasOne("VehicleData.Data.Models.TransmissionType", "TransmissionTypeNavigation")
                        .WithMany("Vehicles")
                        .HasForeignKey("TransmissionType")
                        .HasConstraintName("FK__Vehicle__Transmi__48CFD27E");

                    b.HasOne("VehicleData.Data.Models.VehicleClass", "VehicleSizeClassNavigation")
                        .WithMany("Vehicles")
                        .HasForeignKey("VehicleSizeClass")
                        .HasConstraintName("FK__Vehicle__Vehicle__49C3F6B7");

                    b.HasOne("VehicleData.Data.Models.Year", "YearNavigation")
                        .WithMany("Vehicles")
                        .HasForeignKey("Year")
                        .HasConstraintName("FK__Vehicle__Year__4AB81AF0");

                    b.Navigation("DrivetrainTypeNavigation");

                    b.Navigation("TransmissionTypeNavigation");

                    b.Navigation("VehicleSizeClassNavigation");

                    b.Navigation("YearNavigation");
                });

            modelBuilder.Entity("VehicleData.Data.Models.DrivetrainType", b =>
                {
                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("VehicleData.Data.Models.TransmissionType", b =>
                {
                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("VehicleData.Data.Models.Vehicle", b =>
                {
                    b.Navigation("Engines");
                });

            modelBuilder.Entity("VehicleData.Data.Models.VehicleClass", b =>
                {
                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("VehicleData.Data.Models.Year", b =>
                {
                    b.Navigation("Vehicles");
                });
#pragma warning restore 612, 618
        }
    }
}
