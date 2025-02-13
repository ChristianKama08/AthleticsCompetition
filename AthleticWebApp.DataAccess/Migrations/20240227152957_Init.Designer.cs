﻿// <auto-generated />
using System;
using AthleticWebApp.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AthleticWebApp.DataAccess.Migrations
{
    [DbContext(typeof(AthleteContext))]
    [Migration("20240227152957_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AthleticWebApp.DataAccess.Entities.Athlete", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfBirthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Height")
                        .HasColumnType("float");

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.Property<double>("Weigth")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.HasIndex("TeamId");

                    b.ToTable("Athletes");
                });

            modelBuilder.Entity("AthleticWebApp.DataAccess.Entities.Competition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AthleteId")
                        .HasColumnType("int");

                    b.Property<string>("CompetitionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AthleteId");

                    b.ToTable("Competitions");
                });

            modelBuilder.Entity("AthleticWebApp.DataAccess.Entities.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("AthleticWebApp.DataAccess.Entities.Result", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CompetitionId")
                        .HasColumnType("int");

                    b.Property<string>("MeasurementType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CompetitionId");

                    b.ToTable("Results");
                });

            modelBuilder.Entity("AthleticWebApp.DataAccess.Entities.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("AthleticWebApp.DataAccess.Entities.Athlete", b =>
                {
                    b.HasOne("AthleticWebApp.DataAccess.Entities.Country", "Country")
                        .WithMany("Athletes")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AthleticWebApp.DataAccess.Entities.Team", "Team")
                        .WithMany("Athletes")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("AthleticWebApp.DataAccess.Entities.Competition", b =>
                {
                    b.HasOne("AthleticWebApp.DataAccess.Entities.Athlete", "Athlete")
                        .WithMany("Competitions")
                        .HasForeignKey("AthleteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Athlete");
                });

            modelBuilder.Entity("AthleticWebApp.DataAccess.Entities.Result", b =>
                {
                    b.HasOne("AthleticWebApp.DataAccess.Entities.Competition", "Competition")
                        .WithMany("Results")
                        .HasForeignKey("CompetitionId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Competition");
                });

            modelBuilder.Entity("AthleticWebApp.DataAccess.Entities.Athlete", b =>
                {
                    b.Navigation("Competitions");
                });

            modelBuilder.Entity("AthleticWebApp.DataAccess.Entities.Competition", b =>
                {
                    b.Navigation("Results");
                });

            modelBuilder.Entity("AthleticWebApp.DataAccess.Entities.Country", b =>
                {
                    b.Navigation("Athletes");
                });

            modelBuilder.Entity("AthleticWebApp.DataAccess.Entities.Team", b =>
                {
                    b.Navigation("Athletes");
                });
#pragma warning restore 612, 618
        }
    }
}
