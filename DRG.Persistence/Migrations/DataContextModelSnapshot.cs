﻿// <auto-generated />
using System;
using DRG.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DRG.Persistence.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DRG.Domain.APRDRGV36", b =>
                {
                    b.Property<string>("APRDRG")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CombinedSOI")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DayOutlierThreshold")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<double?>("MLOS")
                        .HasColumnType("float");

                    b.Property<int>("SOIScore")
                        .HasColumnType("int");

                    b.Property<decimal?>("V36RelativeWeight")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("APRDRG");

                    b.ToTable("APRDRGV36s");
                });

            modelBuilder.Entity("DRG.Domain.APRDRGV38", b =>
                {
                    b.Property<string>("APRDRG")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CombinedSOI")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DayOutlierThreshold")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<double?>("MLOS")
                        .HasColumnType("float");

                    b.Property<int>("SOIScore")
                        .HasColumnType("int");

                    b.Property<decimal?>("V38RelativeWeight")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("APRDRG");

                    b.ToTable("APRDRGV38s");
                });

            modelBuilder.Entity("DRG.Domain.CHIRPHospital", b =>
                {
                    b.Property<string>("TIN")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CHIRPCLASS")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("IP")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("NPI")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("OP")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("SDA")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("TIN");

                    b.HasIndex("NPI");

                    b.ToTable("CHIRPHospitals");
                });

            modelBuilder.Entity("DRG.Domain.Hospital", b =>
                {
                    b.Property<string>("HospitalNPI")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("HospitalClass")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HospitalName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HospitalPhysicalCity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HospitalPhysicalStreetAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("TIN")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("HospitalNPI");

                    b.HasIndex("TIN");

                    b.ToTable("Hospitals");
                });

            modelBuilder.Entity("DRG.Domain.HospitalRate", b =>
                {
                    b.Property<string>("NPI")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("CHIRP")
                        .HasColumnType("bit");

                    b.Property<decimal?>("CHIRPRate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Contract")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeliverySDA")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("HHSCPublishDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("HospitalNPI")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("IPRate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("Month")
                        .HasColumnType("int");

                    b.Property<string>("NPIMonthYear")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PPRPPC")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PercentageThreshold")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ProviderName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SDA")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("NPI");

                    b.HasIndex("HospitalNPI");

                    b.ToTable("HospitalRates");
                });

            modelBuilder.Entity("DRG.Domain.CHIRPHospital", b =>
                {
                    b.HasOne("DRG.Domain.Hospital", "Hospital")
                        .WithMany()
                        .HasForeignKey("NPI");

                    b.Navigation("Hospital");
                });

            modelBuilder.Entity("DRG.Domain.Hospital", b =>
                {
                    b.HasOne("DRG.Domain.CHIRPHospital", "CHIRPHospital")
                        .WithMany()
                        .HasForeignKey("TIN");

                    b.Navigation("CHIRPHospital");
                });

            modelBuilder.Entity("DRG.Domain.HospitalRate", b =>
                {
                    b.HasOne("DRG.Domain.Hospital", "Hospital")
                        .WithMany("HospitalRates")
                        .HasForeignKey("HospitalNPI");

                    b.Navigation("Hospital");
                });

            modelBuilder.Entity("DRG.Domain.Hospital", b =>
                {
                    b.Navigation("HospitalRates");
                });
#pragma warning restore 612, 618
        }
    }
}
