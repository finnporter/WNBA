﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WNBA.Core.Api.Configuration;

#nullable disable

namespace WNBA.Core.Api.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WNBA.Core.Api.DataModels.Arena", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Capacity")
                        .HasColumnType("float");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Arenas");
                });

            modelBuilder.Entity("WNBA.Core.Api.DataModels.Player", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("College")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Height")
                        .HasColumnType("float");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("WNBA.Core.Api.DataModels.Team", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Conference")
                        .HasColumnType("int");

                    b.Property<DateTime>("FoundedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("WNBA.Core.Api.DataModels.TeamArena", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ArenaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TeamId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UsedSince")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UsedUntil")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ArenaId");

                    b.HasIndex("TeamId");

                    b.ToTable("TeamArenas");
                });

            modelBuilder.Entity("WNBA.Core.Api.DataModels.TeamPlayer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("JerseyNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("JoinedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LeftOn")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("PlayerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TeamId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.HasIndex("TeamId");

                    b.ToTable("TeamPlayers");
                });

            modelBuilder.Entity("WNBA.Core.Api.DataModels.TeamArena", b =>
                {
                    b.HasOne("WNBA.Core.Api.DataModels.Arena", "Arena")
                        .WithMany()
                        .HasForeignKey("ArenaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WNBA.Core.Api.DataModels.Team", "Team")
                        .WithMany()
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Arena");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("WNBA.Core.Api.DataModels.TeamPlayer", b =>
                {
                    b.HasOne("WNBA.Core.Api.DataModels.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WNBA.Core.Api.DataModels.Team", "Team")
                        .WithMany()
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Player");

                    b.Navigation("Team");
                });
#pragma warning restore 612, 618
        }
    }
}
