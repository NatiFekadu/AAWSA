﻿// <auto-generated />
using System;
using AAWSA.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AAWSA.Migrations.ComplaintDb
{
    [DbContext(typeof(ComplaintDbContext))]
    [Migration("20220126130753_ComplaintMigration3")]
    partial class ComplaintMigration3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AAWSA.Models.Complaint", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Branches")
                        .HasColumnType("int");

                    b.Property<string>("CaseType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ComplaintType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("First_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("House_number")
                        .HasColumnType("int");

                    b.Property<int>("Phone_number")
                        .HasColumnType("int");

                    b.Property<string>("Special_Place_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Subcity")
                        .HasColumnType("int");

                    b.Property<string>("Woreda")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime2");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Complaints");
                });
#pragma warning restore 612, 618
        }
    }
}
