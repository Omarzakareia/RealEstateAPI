﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RealEstate.Repository.Data;

#nullable disable

namespace RealEstate.Repository.Data.Migrations
{
    [DbContext(typeof(RealContext))]
    [Migration("20241125190818_add locationimage")]
    partial class addlocationimage
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RealEstate.Core.Entities.Amenity", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProjectId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("Amenities");
                });

            modelBuilder.Entity("RealEstate.Core.Entities.CallRequest", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int?>("ProjectId")
                        .HasColumnType("int");

                    b.Property<int?>("PropertyId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("RequestDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.HasIndex("PropertyId");

                    b.ToTable("CallRequests");
                });

            modelBuilder.Entity("RealEstate.Core.Entities.Developer", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Logo")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("LogoName")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Developers");
                });

            modelBuilder.Entity("RealEstate.Core.Entities.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BackgroundImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Latitude")
                        .HasColumnType("decimal(9,6)");

                    b.Property<decimal?>("Longitude")
                        .HasColumnType("decimal(9,6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("RealEstate.Core.Entities.Project", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<string>("About")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BackgroundImage")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int?>("DeveloperId")
                        .HasColumnType("int");

                    b.Property<int?>("LocationId")
                        .HasColumnType("int");

                    b.Property<string>("PaymentMethods")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("PricePerMeter")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("PricePerSquareMeter")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("ProjectArea")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("ProjectName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("ProjectTitle")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int?>("ProjectTypeId")
                        .HasColumnType("int");

                    b.Property<string>("StartingPrice")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UnitAreas")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("UnitPrice")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("UnitTypes")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("DeveloperId");

                    b.HasIndex("LocationId");

                    b.HasIndex("ProjectTypeId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("RealEstate.Core.Entities.ProjectHighlight", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Paragraph")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProjectId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("ProjectHighlights");
                });

            modelBuilder.Entity("RealEstate.Core.Entities.ProjectImage", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<int?>("ProjectId")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("ProjectImages");
                });

            modelBuilder.Entity("RealEstate.Core.Entities.ProjectType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProjectTypes");
                });

            modelBuilder.Entity("RealEstate.Core.Entities.Property", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<int?>("Area")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("BackgroundImage")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int?>("Bathrooms")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("Bedrooms")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("ContactNumber")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int?>("DeveloperId")
                        .HasColumnType("int");

                    b.Property<bool?>("IsFeatured")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<int?>("LocationId")
                        .HasColumnType("int");

                    b.Property<string>("PaymentPlan")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("ProjectId")
                        .HasColumnType("int");

                    b.Property<int?>("PropertyTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("DeveloperId");

                    b.HasIndex("LocationId");

                    b.HasIndex("ProjectId");

                    b.HasIndex("PropertyTypeId");

                    b.ToTable("Properties");
                });

            modelBuilder.Entity("RealEstate.Core.Entities.PropertyImage", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<int?>("PropertyId")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.HasIndex("PropertyId");

                    b.ToTable("PropertyImages");
                });

            modelBuilder.Entity("RealEstate.Core.Entities.PropertyType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PropertyTypes");
                });

            modelBuilder.Entity("RealEstate.Core.Entities.Amenity", b =>
                {
                    b.HasOne("RealEstate.Core.Entities.Project", "Project")
                        .WithMany("Amenities")
                        .HasForeignKey("ProjectId");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("RealEstate.Core.Entities.CallRequest", b =>
                {
                    b.HasOne("RealEstate.Core.Entities.Project", "Project")
                        .WithMany("CallRequests")
                        .HasForeignKey("ProjectId");

                    b.HasOne("RealEstate.Core.Entities.Property", "Property")
                        .WithMany("CallRequests")
                        .HasForeignKey("PropertyId");

                    b.Navigation("Project");

                    b.Navigation("Property");
                });

            modelBuilder.Entity("RealEstate.Core.Entities.Project", b =>
                {
                    b.HasOne("RealEstate.Core.Entities.Developer", "Developer")
                        .WithMany("Projects")
                        .HasForeignKey("DeveloperId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("RealEstate.Core.Entities.Location", "Location")
                        .WithMany("Projects")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("RealEstate.Core.Entities.ProjectType", "ProjectType")
                        .WithMany()
                        .HasForeignKey("ProjectTypeId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Developer");

                    b.Navigation("Location");

                    b.Navigation("ProjectType");
                });

            modelBuilder.Entity("RealEstate.Core.Entities.ProjectHighlight", b =>
                {
                    b.HasOne("RealEstate.Core.Entities.Project", null)
                        .WithMany("ProjectHighlights")
                        .HasForeignKey("ProjectId");
                });

            modelBuilder.Entity("RealEstate.Core.Entities.ProjectImage", b =>
                {
                    b.HasOne("RealEstate.Core.Entities.Project", "Project")
                        .WithMany("ProjectImages")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Project");
                });

            modelBuilder.Entity("RealEstate.Core.Entities.Property", b =>
                {
                    b.HasOne("RealEstate.Core.Entities.Developer", "Developer")
                        .WithMany("Properties")
                        .HasForeignKey("DeveloperId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RealEstate.Core.Entities.Location", "Location")
                        .WithMany("Properties")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("RealEstate.Core.Entities.Project", "Project")
                        .WithMany("Properties")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("RealEstate.Core.Entities.PropertyType", "PropertyType")
                        .WithMany()
                        .HasForeignKey("PropertyTypeId");

                    b.Navigation("Developer");

                    b.Navigation("Location");

                    b.Navigation("Project");

                    b.Navigation("PropertyType");
                });

            modelBuilder.Entity("RealEstate.Core.Entities.PropertyImage", b =>
                {
                    b.HasOne("RealEstate.Core.Entities.Property", "Property")
                        .WithMany("Images")
                        .HasForeignKey("PropertyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Property");
                });

            modelBuilder.Entity("RealEstate.Core.Entities.Developer", b =>
                {
                    b.Navigation("Projects");

                    b.Navigation("Properties");
                });

            modelBuilder.Entity("RealEstate.Core.Entities.Location", b =>
                {
                    b.Navigation("Projects");

                    b.Navigation("Properties");
                });

            modelBuilder.Entity("RealEstate.Core.Entities.Project", b =>
                {
                    b.Navigation("Amenities");

                    b.Navigation("CallRequests");

                    b.Navigation("ProjectHighlights");

                    b.Navigation("ProjectImages");

                    b.Navigation("Properties");
                });

            modelBuilder.Entity("RealEstate.Core.Entities.Property", b =>
                {
                    b.Navigation("CallRequests");

                    b.Navigation("Images");
                });
#pragma warning restore 612, 618
        }
    }
}
