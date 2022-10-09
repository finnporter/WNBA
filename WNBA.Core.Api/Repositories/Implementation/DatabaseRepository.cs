using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WNBA.Core.Api.Configuration;
using WNBA.Core.Api.DataModels;
using WNBA.Core.Api.DbHelper;
using WNBA.Core.Api.JsonModels;

namespace WNBA.Core.Api.Repositories.Implementation
{
    internal sealed class DatabaseRepository : IDatabaseRepository
    {
        private readonly ApplicationDbContext context;
        public DatabaseRepository(ApplicationDbContext context)
        {
            this.context = context;
        }        

        public async Task CreateOrUpdateEntityAsync<T>(T entity) where T : EntityBaseClass
        {
            var entityExists = await EntityExists<T>(entity.Id);
            if (entityExists)
            {
                context.Update(entity);
            }
            else
            {
                await context.AddAsync(entity).ConfigureAwait(false);
            }
            await context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<T?> GetEntityAsync<T>(Guid id) where T : EntityBaseClass
        {
            return await context.Set<T>().FirstOrDefaultAsync(x => x.Id == id).ConfigureAwait(false);

        }

        public async Task CreateOrUpdatePlayerSeasonStatsAsync(PlayerSeasonDto playerSeason, Guid playerId)
        {
            foreach (var playerStats in playerSeason.PlayerStats)
            {
                var teamExists = await context.Teams.AnyAsync(x => x.Id == playerStats.Id).ConfigureAwait(false);
                if (!teamExists)
                {
                    var newTeam = new Team()
                    {
                        Id = playerStats.Id,
                        Alias = playerStats.Alias,
                        Name = playerStats.Name,
                        Market = playerStats.Market
                    };
                    await context.AddAsync(newTeam).ConfigureAwait(false);
                }
                var teamPlayerSeason = await CreateOrUpdateTeamPlayerSeasonAsync(playerSeason.Id, playerId, playerStats.Id).ConfigureAwait(false);

                await CreateOrUpdatePlayerStatsAsync(playerStats.PlayerTotalStats, teamPlayerSeason.Id, playerSeason.Id, true);
                await CreateOrUpdatePlayerStatsAsync(playerStats.PlayerAverageStats, teamPlayerSeason.Id, playerSeason.Id, false);
            }
        }

        private async Task<bool> EntityExists<T>(Guid id) where T : EntityBaseClass
        {
            return await context.Set<T>().AnyAsync(x => x.Id == id).ConfigureAwait(false);
        }

        private async Task<TeamPlayerSeason> CreateOrUpdateTeamPlayerSeasonAsync(Guid seasonId, Guid playerId, Guid teamId)
        {
            var teamPlayerSeason = await context.TeamPlayerSeasons.FirstOrDefaultAsync(x => x.SeasonId == seasonId && x.PlayerId == playerId && x.TeamId == teamId).ConfigureAwait(false);            
            if (teamPlayerSeason is not null) { return teamPlayerSeason; }
            teamPlayerSeason = new TeamPlayerSeason()
            {
                Id = Guid.NewGuid(),
                PlayerId = playerId,
                TeamId = teamId,
                SeasonId = seasonId
            };
            await context.AddAsync(teamPlayerSeason);
            await context.SaveChangesAsync().ConfigureAwait(false);
            return teamPlayerSeason;
        }

        private async Task CreateOrUpdatePlayerStatsAsync(PlayerSeasonStatsDto statsDto, Guid statsId, Guid seasonId, bool isTotal)
        {            
            var existingStatsId = await context.PlayerStats.Where(x => x.TeamPlayerSeasonId == statsId && x.IsTotal == isTotal).Select(x => x.Id).FirstOrDefaultAsync().ConfigureAwait(false);
            var newStats = PlayerStats.ToModel(statsDto, statsId, isTotal);
            if (existingStatsId != Guid.Empty)
            {
                newStats.Id = existingStatsId;

                context.Update(newStats);
            }
            if (existingStatsId == Guid.Empty)
            {
                newStats.TeamPlayerSeasonId = statsId;
                await context.PlayerStats.AddAsync(newStats).ConfigureAwait(false);                
            }
            await context.SaveChangesAsync().ConfigureAwait(false);
        }        
    }
}
