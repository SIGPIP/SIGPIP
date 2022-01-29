﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SIGPIP.Context;

namespace SIGPIP.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SIGPIP.Models.CategoryModel", b =>
                {
                    b.Property<Guid>("categoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("categoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("categoryParentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("subCategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("categoryId");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("SIGPIP.Models.ExperienceModel", b =>
                {
                    b.Property<int>("experienceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("experienceDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("experienceEndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("experienceEntity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("experienceName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("experiencePlace")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("experienceStartDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("studentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("experienceId");

                    b.ToTable("Experience");
                });

            modelBuilder.Entity("SIGPIP.Models.HabilityModel", b =>
                {
                    b.Property<int>("habilityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("habilityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("studentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("habilityId");

                    b.ToTable("Hability");
                });

            modelBuilder.Entity("SIGPIP.Models.InterestModel", b =>
                {
                    b.Property<int>("interestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("interestName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("studentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("interestId");

                    b.ToTable("Interest");
                });

            modelBuilder.Entity("SIGPIP.Models.PendingProjectModel", b =>
                {
                    b.Property<Guid>("pendingProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("pendingProjectDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("pendingProjectName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("pendingProjectId");

                    b.ToTable("PendingProject");
                });

            modelBuilder.Entity("SIGPIP.Models.ProjectModel", b =>
                {
                    b.Property<Guid>("projectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("projectDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("projectFramework")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("projectImageData")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("projectLanguages")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("projectLastUpdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("projectLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("projectName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("projectRepoLink")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("projectUploadDate")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("projectZipData")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<Guid>("studentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("projectId");

                    b.ToTable("Project");
                });

            modelBuilder.Entity("SIGPIP.Models.ReferenceModel", b =>
                {
                    b.Property<Guid>("referenceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("referenceAgent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("referenceCompany")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("referenceName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("referencePhone")
                        .HasColumnType("bigint");

                    b.Property<Guid>("studentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("referenceId");

                    b.ToTable("Reference");
                });

            modelBuilder.Entity("SIGPIP.Models.StudentModel", b =>
                {
                    b.Property<Guid>("studentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("studentBio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("studentCareer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("studentConfirmPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("studentCountry")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("studentEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("studentLastNames")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("studentNames")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("studentPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("studentSemester")
                        .HasColumnType("int");

                    b.HasKey("studentId");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("SIGPIP.Models.StudyModel", b =>
                {
                    b.Property<Guid>("studyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("studentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("studyCity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("studyCountry")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("studyGrade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("studyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("studyPlace")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("studyYear")
                        .HasColumnType("int");

                    b.HasKey("studyId");

                    b.ToTable("Study");
                });

            modelBuilder.Entity("SIGPIP.Models.UniversityModel", b =>
                {
                    b.Property<Guid>("universityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("universityCountry")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("universityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("universityId");

                    b.ToTable("University");
                });
#pragma warning restore 612, 618
        }
    }
}
