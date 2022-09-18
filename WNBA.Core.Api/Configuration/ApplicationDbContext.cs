using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WNBA.Core.Api.DataModels;

namespace WNBA.Core.Api.Configuration;

/// <summary>
/// The database context for this application
/// </summary>
public class ApplicationDbContext : DbContext
{
    /// <summary>
    /// Initiates a new instance of the ApplicationDbContext
    /// </summary>
    /// <param name="options"></param>
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Coach> Coaches { get; set; }
    public DbSet<Player> Players { get; set; }
    public DbSet<TeamCoach> TeamCoaches { get; set; }
    public DbSet<TeamPlayer> TeamPlayers { get; set; }
    public DbSet<TeamVenue> TeamVenue { get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<Venue> Venues { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}

