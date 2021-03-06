﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RealEstateAPI.Data;

namespace RealEstateAPI.Migrations.GNAF
{
    [DbContext(typeof(GNAFContext))]
    [Migration("20210102225152_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RealEstateAPI.Domain.GNAFAddressData", b =>
                {
                    b.Property<string>("AddressDetailId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("FlatNumber")
                        .HasColumnType("int");

                    b.Property<string>("FlatNumberPrefix")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FlatNumberSuffix")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FlatType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Latitude")
                        .HasColumnType("decimal(8, 6)");

                    b.Property<int?>("LevelNumber")
                        .HasColumnType("int");

                    b.Property<string>("LevelNumberPrefix")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LevelNumberSuffix")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LevelType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LocalityPID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Longitude")
                        .HasColumnType("decimal(9, 6)");

                    b.Property<string>("LotNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LotPrefix")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LotSuffix")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("NumberFirst")
                        .HasColumnType("int");

                    b.Property<string>("NumberFirstPrefix")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumberFirstSuffix")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("NumberLast")
                        .HasColumnType("int");

                    b.Property<string>("NumberLastPrefix")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumberLastSuffix")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PostCode")
                        .HasColumnType("int");

                    b.Property<string>("StreetLocalityPID")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AddressDetailId");

                    b.ToTable("GNAF_AddressData");
                });

            modelBuilder.Entity("RealEstateAPI.Domain.GNAFLocalityDetails", b =>
                {
                    b.Property<string>("LocalityPID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("Latitude")
                        .HasColumnType("decimal(8, 6)");

                    b.Property<string>("LocalityName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Longitude")
                        .HasColumnType("decimal(9, 6)");

                    b.Property<int>("PostCode")
                        .HasColumnType("int");

                    b.HasKey("LocalityPID");

                    b.ToTable("GNAF_LocalityDetails");
                });

            modelBuilder.Entity("RealEstateAPI.Domain.GNAFStreetLocality", b =>
                {
                    b.Property<string>("StreetLocalityPid")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("Latitude")
                        .HasColumnType("decimal(8, 6)");

                    b.Property<string>("LocalityPID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Longitude")
                        .HasColumnType("decimal(9, 6)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Suffix")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StreetLocalityPid");

                    b.ToTable("GNAF_StreetLocalityDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
