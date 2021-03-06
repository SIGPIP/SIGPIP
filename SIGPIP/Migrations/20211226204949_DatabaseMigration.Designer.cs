// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SIGPIP.Context;

namespace SIGPIP.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20211226204949_DatabaseMigration")]
    partial class DatabaseMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SIGPIP.Models.StudentModel", b =>
                {
                    b.Property<Guid>("studentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("studentBio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("studentCareer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("studentCountry")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("studentEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("studentLastNames")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("studentNames")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("studentSemester")
                        .HasColumnType("int");

                    b.HasKey("studentId");

                    b.ToTable("Student");
                });
#pragma warning restore 612, 618
        }
    }
}
