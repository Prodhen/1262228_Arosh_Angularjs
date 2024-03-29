﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using _1262228_Arosh_NGJs.Data;

namespace _1262228_Arosh_NGJs.Migrations
{
    [DbContext(typeof(NgDbContext))]
    [Migration("20211217192855_AddedDateTime")]
    partial class AddedDateTime
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("_1262228_Arosh_NGJs.Models.AcademicResult", b =>
                {
                    b.Property<int>("AcademicResultID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Examination")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Group")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PassingYear")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Result")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("RollNo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AcademicResultID");

                    b.ToTable("AcademicResults");
                });

            modelBuilder.Entity("_1262228_Arosh_NGJs.Models.Payment", b =>
                {
                    b.Property<int>("PaymentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Transaction")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PaymentID");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("_1262228_Arosh_NGJs.Models.Result", b =>
                {
                    b.Property<int>("ResultID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Bangla")
                        .HasColumnType("int");

                    b.Property<int?>("English")
                        .HasColumnType("int");

                    b.Property<int?>("GeneralKnowlede")
                        .HasColumnType("int");

                    b.Property<int?>("Ict")
                        .HasColumnType("int");

                    b.HasKey("ResultID");

                    b.ToTable("Results");
                });

            modelBuilder.Entity("_1262228_Arosh_NGJs.Models.Student", b =>
                {
                    b.Property<int>("StudentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<string>("FatherName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MotherName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Status")
                        .HasColumnType("bit");

                    b.Property<int?>("UnitID")
                        .HasColumnType("int");

                    b.HasKey("StudentID");

                    b.HasIndex("UnitID");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("_1262228_Arosh_NGJs.Models.Unit", b =>
                {
                    b.Property<int>("UnitID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Seat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UnitName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UnitID");

                    b.ToTable("Units");
                });

            modelBuilder.Entity("_1262228_Arosh_NGJs.Models.Student", b =>
                {
                    b.HasOne("_1262228_Arosh_NGJs.Models.Unit", "Unit")
                        .WithMany("Students")
                        .HasForeignKey("UnitID");
                });
#pragma warning restore 612, 618
        }
    }
}
