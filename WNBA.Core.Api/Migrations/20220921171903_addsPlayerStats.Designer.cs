﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WNBA.Core.Api.Configuration;

#nullable disable

namespace WNBA.Core.Api.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220921171903_addsPlayerStats")]
    partial class addsPlayerStats
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WNBA.Core.Api.DataModels.Coach", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("Experience")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Coaches");
                });

            modelBuilder.Entity("WNBA.Core.Api.DataModels.Player", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BirthDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BirthPlace")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("College")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CurrentTeamId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("DraftedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<float?>("DraftedYear")
                        .HasColumnType("real");

                    b.Property<string>("Experience")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("HeightInCm")
                        .HasColumnType("float");

                    b.Property<double?>("HeightInINches")
                        .HasColumnType("float");

                    b.Property<string>("HighSchool")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JerseyNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pick")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float?>("RookieYear")
                        .HasColumnType("real");

                    b.Property<string>("Round")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<double?>("WeightInKg")
                        .HasColumnType("float");

                    b.Property<double?>("WeightInPounds")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CurrentTeamId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("WNBA.Core.Api.DataModels.PlayerStats", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Assists")
                        .HasColumnType("int");

                    b.Property<float>("AssistsTurnoverRatio")
                        .HasColumnType("real");

                    b.Property<int>("BlockedAttempts")
                        .HasColumnType("int");

                    b.Property<int>("Blocks")
                        .HasColumnType("int");

                    b.Property<int>("CoachEjections")
                        .HasColumnType("int");

                    b.Property<int>("CoachTechsFouls")
                        .HasColumnType("int");

                    b.Property<int?>("DefRebounds")
                        .HasColumnType("int");

                    b.Property<int?>("DefensiveRebounds")
                        .HasColumnType("int");

                    b.Property<int>("DoubleDoubles")
                        .HasColumnType("int");

                    b.Property<double>("EffeciveFGPercent")
                        .HasColumnType("float");

                    b.Property<int>("Efficiency")
                        .HasColumnType("int");

                    b.Property<int>("Ejections")
                        .HasColumnType("int");

                    b.Property<int>("FastBreakAttempts")
                        .HasColumnType("int");

                    b.Property<int>("FastBreakMade")
                        .HasColumnType("int");

                    b.Property<int>("FastBreakPercent")
                        .HasColumnType("int");

                    b.Property<int>("FastBreakPoints")
                        .HasColumnType("int");

                    b.Property<int>("FieldGoalsAttempts")
                        .HasColumnType("int");

                    b.Property<int>("FieldGoalsMade")
                        .HasColumnType("int");

                    b.Property<int>("FieldGoalsPercent")
                        .HasColumnType("int");

                    b.Property<int>("FlagrantFouls")
                        .HasColumnType("int");

                    b.Property<int>("Foulouts")
                        .HasColumnType("int");

                    b.Property<int>("FoulsDrawn")
                        .HasColumnType("int");

                    b.Property<int>("FreeThrowsAttempts")
                        .HasColumnType("int");

                    b.Property<int>("FreeThrowsMade")
                        .HasColumnType("int");

                    b.Property<int>("FreeTrhowsPercent")
                        .HasColumnType("int");

                    b.Property<int?>("GamesPlayed")
                        .HasColumnType("int");

                    b.Property<int?>("GamesStarted")
                        .HasColumnType("int");

                    b.Property<int>("Minus")
                        .HasColumnType("int");

                    b.Property<int>("Minutes")
                        .HasColumnType("int");

                    b.Property<int?>("OffRebounds")
                        .HasColumnType("int");

                    b.Property<int>("OffensiveFouls")
                        .HasColumnType("int");

                    b.Property<int?>("OffensiveRebounds")
                        .HasColumnType("int");

                    b.Property<int>("PersonalFouls")
                        .HasColumnType("int");

                    b.Property<int>("Plus")
                        .HasColumnType("int");

                    b.Property<int>("Points")
                        .HasColumnType("int");

                    b.Property<int>("PointsInPaint")
                        .HasColumnType("int");

                    b.Property<double>("PointsInPaintAttempts")
                        .HasColumnType("float");

                    b.Property<double>("PointsInPaintMade")
                        .HasColumnType("float");

                    b.Property<double>("PointsInPaintPercent")
                        .HasColumnType("float");

                    b.Property<int>("PointsOffTurnovers")
                        .HasColumnType("int");

                    b.Property<int>("Rebounds")
                        .HasColumnType("int");

                    b.Property<int>("SecondChanceAttributes")
                        .HasColumnType("int");

                    b.Property<int>("SecondChanceMade")
                        .HasColumnType("int");

                    b.Property<int>("SecondChancePercent")
                        .HasColumnType("int");

                    b.Property<int>("SecondChancePoints")
                        .HasColumnType("int");

                    b.Property<int>("Steals")
                        .HasColumnType("int");

                    b.Property<Guid>("TeamPlayerSeasonId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("TechnicalFouls")
                        .HasColumnType("int");

                    b.Property<int>("ThreePointsAttempts")
                        .HasColumnType("int");

                    b.Property<int>("ThreePointsMade")
                        .HasColumnType("int");

                    b.Property<int>("ThreePointsPercent")
                        .HasColumnType("int");

                    b.Property<int>("TripleDoubles")
                        .HasColumnType("int");

                    b.Property<float>("TrueShootingAttempts")
                        .HasColumnType("real");

                    b.Property<float>("TrueShootingPercent")
                        .HasColumnType("real");

                    b.Property<int>("Turnovers")
                        .HasColumnType("int");

                    b.Property<int>("TwoPointsAttempts")
                        .HasColumnType("int");

                    b.Property<int>("TwoPointsMade")
                        .HasColumnType("int");

                    b.Property<int>("TwoPointsPercent")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TeamPlayerSeasonId");

                    b.ToTable("PlayerStats");
                });

            modelBuilder.Entity("WNBA.Core.Api.DataModels.Season", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Seasons");
                });

            modelBuilder.Entity("WNBA.Core.Api.DataModels.Team", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Alias")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Conference")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Founded")
                        .HasColumnType("datetime2");

                    b.Property<string>("Market")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("WNBA.Core.Api.DataModels.TeamCoach", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CoachId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("EndedOn")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("TeamId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CoachId");

                    b.HasIndex("TeamId");

                    b.ToTable("TeamCoaches");
                });

            modelBuilder.Entity("WNBA.Core.Api.DataModels.TeamPlayerSeason", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PlayerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SeasonId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TeamId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.HasIndex("SeasonId");

                    b.HasIndex("TeamId");

                    b.ToTable("TeamPlayerSeasons");
                });

            modelBuilder.Entity("WNBA.Core.Api.DataModels.TeamVenue", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TeamId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("VenueId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.HasIndex("VenueId");

                    b.ToTable("TeamVenue");
                });

            modelBuilder.Entity("WNBA.Core.Api.DataModels.Venue", b =>
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

                    b.ToTable("Venues");
                });

            modelBuilder.Entity("WNBA.Core.Api.DataModels.Player", b =>
                {
                    b.HasOne("WNBA.Core.Api.DataModels.Team", "CurrentTeam")
                        .WithMany()
                        .HasForeignKey("CurrentTeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CurrentTeam");
                });

            modelBuilder.Entity("WNBA.Core.Api.DataModels.PlayerStats", b =>
                {
                    b.HasOne("WNBA.Core.Api.DataModels.TeamPlayerSeason", "TeamPlayerSeason")
                        .WithMany()
                        .HasForeignKey("TeamPlayerSeasonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TeamPlayerSeason");
                });

            modelBuilder.Entity("WNBA.Core.Api.DataModels.TeamCoach", b =>
                {
                    b.HasOne("WNBA.Core.Api.DataModels.Coach", "Coach")
                        .WithMany()
                        .HasForeignKey("CoachId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WNBA.Core.Api.DataModels.Team", "Team")
                        .WithMany()
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Coach");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("WNBA.Core.Api.DataModels.TeamPlayerSeason", b =>
                {
                    b.HasOne("WNBA.Core.Api.DataModels.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WNBA.Core.Api.DataModels.Season", "Season")
                        .WithMany()
                        .HasForeignKey("SeasonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WNBA.Core.Api.DataModels.Team", "Team")
                        .WithMany()
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Player");

                    b.Navigation("Season");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("WNBA.Core.Api.DataModels.TeamVenue", b =>
                {
                    b.HasOne("WNBA.Core.Api.DataModels.Team", "Team")
                        .WithMany()
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WNBA.Core.Api.DataModels.Venue", "Venue")
                        .WithMany()
                        .HasForeignKey("VenueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Team");

                    b.Navigation("Venue");
                });
#pragma warning restore 612, 618
        }
    }
}
