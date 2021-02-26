﻿// <auto-generated />
using System;
using LinkMasters.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LinkMasters.Migrations
{
    [DbContext(typeof(LinkMastersContext))]
    [Migration("20190822122125_addBudgetApplicationTables")]
    partial class addBudgetApplicationTables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LinkMasters.Models.Application", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("Created_DateTime");

                    b.Property<DateTime?>("Modified_DateTime");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Application");
                });

            modelBuilder.Entity("LinkMasters.Models.Calendar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("Created_DateTime");

                    b.Property<DateTime?>("Modified_DateTime");

                    b.Property<string>("Month");

                    b.Property<int>("MonthNumber");

                    b.Property<int>("Year");

                    b.HasKey("Id");

                    b.ToTable("Calendar");
                });

            modelBuilder.Entity("LinkMasters.Models.Day", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("Created_DateTime");

                    b.Property<string>("DayOfMonth");

                    b.Property<DateTime?>("Modified_DateTime");

                    b.HasKey("Id");

                    b.ToTable("Day");
                });

            modelBuilder.Entity("LinkMasters.Models.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("Created_DateTime");

                    b.Property<string>("ImageName");

                    b.Property<string>("ImagePath");

                    b.Property<DateTime?>("Modified_DateTime");

                    b.HasKey("Id");

                    b.ToTable("Image");
                });

            modelBuilder.Entity("LinkMasters.Models.Link", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ApplicationId");

                    b.Property<DateTime?>("Created_DateTime");

                    b.Property<string>("FilePath");

                    b.Property<int?>("ImageId");

                    b.Property<DateTime?>("Modified_DateTime");

                    b.Property<string>("Name");

                    b.Property<string>("Nickname");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationId");

                    b.HasIndex("ImageId");

                    b.ToTable("Link");
                });

            modelBuilder.Entity("LinkMasters.Models.Person", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("Created_DateTime");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<DateTime?>("Modified_DateTime");

                    b.HasKey("Guid");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("LinkMasters.Models.Link", b =>
                {
                    b.HasOne("LinkMasters.Models.Application", "Application")
                        .WithMany("Links")
                        .HasForeignKey("ApplicationId");

                    b.HasOne("LinkMasters.Models.Image", "Image")
                        .WithMany("Links")
                        .HasForeignKey("ImageId");
                });
#pragma warning restore 612, 618
        }
    }
}
