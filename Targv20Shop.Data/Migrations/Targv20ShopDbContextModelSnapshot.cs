﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Targv20Shop.Data;

namespace Targv20Shop.Data.Migrations
{
    [DbContext(typeof(Targv20ShopDbContext))]
    partial class Targv20ShopDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Targv20Shop.Core.Domain.Car", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CarAmount")
                        .HasColumnType("int");

                    b.Property<DateTime>("CarCreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CarDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CarModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CarName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("CarPrice")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Car");
                });

            modelBuilder.Entity("Targv20Shop.Core.Domain.ExistingFilePath", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CarId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FilePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("ProductId");

                    b.ToTable("ExistingFilePath");
                });

            modelBuilder.Entity("Targv20Shop.Core.Domain.FileToDatabase", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("ImageData")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("ImageTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("SpaceshipId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("FileToDatabase");
                });

            modelBuilder.Entity("Targv20Shop.Core.Domain.Product", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("Targv20Shop.Core.Domain.Spaceship", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ConstructedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("Crew")
                        .HasColumnType("int");

                    b.Property<double>("Mass")
                        .HasColumnType("float");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Prize")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Spaceship");
                });

            modelBuilder.Entity("Targv20Shop.Core.Domain.ExistingFilePath", b =>
                {
                    b.HasOne("Targv20Shop.Core.Domain.Car", "Car")
                        .WithMany("ExistingFilePaths")
                        .HasForeignKey("CarId");

                    b.HasOne("Targv20Shop.Core.Domain.Product", "Product")
                        .WithMany("ExistingFilePaths")
                        .HasForeignKey("ProductId");

                    b.Navigation("Car");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Targv20Shop.Core.Domain.Car", b =>
                {
                    b.Navigation("ExistingFilePaths");
                });

            modelBuilder.Entity("Targv20Shop.Core.Domain.Product", b =>
                {
                    b.Navigation("ExistingFilePaths");
                });
#pragma warning restore 612, 618
        }
    }
}
