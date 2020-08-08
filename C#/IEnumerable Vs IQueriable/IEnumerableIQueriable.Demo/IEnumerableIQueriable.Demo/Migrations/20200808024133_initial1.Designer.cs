﻿// <auto-generated />
using System;
using IEnumerableIQueriable.Demo.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace IEnumerableIQueryable.Demo.Migrations
{
    [DbContext(typeof(EmployeesDbContext))]
    [Migration("20200808024133_initial1")]
    partial class initial1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("IEnumerableIQueriable.Demo.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthDay")
                        .HasColumnType("datetime2");

                    b.Property<string>("Department")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Salary")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BirthDay = new DateTime(2020, 8, 8, 2, 41, 32, 572, DateTimeKind.Utc).AddTicks(5156),
                            Department = "Mobile",
                            Name = "Mona",
                            Salary = 7000f
                        },
                        new
                        {
                            Id = 2,
                            BirthDay = new DateTime(2020, 8, 8, 2, 41, 32, 572, DateTimeKind.Utc).AddTicks(5824),
                            Department = "Web",
                            Name = "Ahmed",
                            Salary = 50000f
                        },
                        new
                        {
                            Id = 3,
                            BirthDay = new DateTime(2020, 8, 8, 2, 41, 32, 572, DateTimeKind.Utc).AddTicks(5847),
                            Department = "IOS",
                            Name = "Khalid",
                            Salary = 50000f
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
