using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WNBA.Core.Api.Configuration;
using WNBA.Core.Api.DataModels;
using WNBA.Core.Api.DbHelper;

namespace WNBA.Core.Api.Repositories.Implementation
{
    internal sealed class DatabaseRepository : IDatabaseRepository
    {
        private readonly ApplicationDbContext context;
        public DatabaseRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        private async Task<bool> EntityExists<T>(T entity) where T : EntityBaseClass
        {
            return await context.Set<T>().AnyAsync(x => x.Id == entity.Id).ConfigureAwait(false);
        }

        public async Task CreateOrUpdateEntityAsync<T>(T entity) where T : EntityBaseClass
        {
            var entityExists = await EntityExists(entity);
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

        public async Task CreateOrUpdateTeamPlayerAsync(Guid playerId, Guid teamId)
        {
            var teamPlayer = await context.TeamPlayers
                    .FirstOrDefaultAsync(x => x.TeamId == teamId &&
                            x.PlayerId == playerId)
                        .ConfigureAwait(false);
            if (teamPlayer is null)
            {
                await context.TeamPlayers.Where(x => x.PlayerId == playerId).ForEachAsync(x => x.IsActive = false).ConfigureAwait(false);

                context.TeamPlayers.Add(new TeamPlayer()
                {
                    Id = Guid.NewGuid(),
                    PlayerId = playerId,
                    TeamId = teamId,
                    IsActive = true
                });

                await context.SaveChangesAsync().ConfigureAwait(false);
            }
            else if (teamPlayer is not null && !teamPlayer.IsActive)
            {
                //it already exists but we need to make sure it is active, and it's the only active team for that player
                await context.TeamPlayers.ForEachAsync(x => x.IsActive = false);
                teamPlayer.IsActive = true;
                await context.SaveChangesAsync();
            }
            //else it already exists and is active nothing needs to be done
        }
    }
}
