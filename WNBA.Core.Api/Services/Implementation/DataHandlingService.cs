using Microsoft.EntityFrameworkCore;
using WNBA.Core.Api.Configuration;
using WNBA.Core.Api.DataModels;
using WNBA.Core.Api.DbHelper;
using WNBA.Core.Api.JsonModels;

namespace WNBA.Core.Api.Services.Implementation
{
    internal sealed class DataHandlingService : IDataHandlingService
    {
        private readonly ApplicationDbContext context;
        public DataHandlingService(ApplicationDbContext context)
        {
            this.context = context;
        }

        ///<inheritdoc/>
        public async Task<bool> HandleTeamRosterAsync(string id, TeamDto team)
        {
            if (string.IsNullOrEmpty(id)) { throw new ArgumentNullException(nameof(id)); };
            ArgumentNullException.ThrowIfNull(team, nameof(team));

            //Ids should match for consistency with the Sportsradar Api.
            var teamId = team.Id.ToString();
            if (!id.Equals(teamId)) { return false; }

            try
            {
                var newTeam = Team.ToModel(team);
                await CreateOrUpdateEntityAsync(newTeam).ConfigureAwait(false);
                await CreateOrUpdateEntityAsync(team.Venue).ConfigureAwait(false);

                var coaches = team.Coaches;
                var newCoaches = new List<Coach>();
                var newTeamCoaches = new List<TeamCoach>();
                foreach (var coach in coaches)
                {
                    newCoaches.Add(coach);

                    newTeamCoaches.Add(new TeamCoach()
                    {
                        Id = Guid.NewGuid(), 
                        TeamId = newTeam.Id,
                        CoachId = coach.Id 
                    });
                }
                await CreateOrUpdateEntityListAsync(newCoaches).ConfigureAwait(false);
                await CreateOrUpdateEntityListAsync(newTeamCoaches).ConfigureAwait(false);

                var players = team.Players;
                var newPlayers = new List<DataModels.Player>();
                var newTeamPlayers = new List<TeamPlayer>();
                foreach (var player in players)
                {
                    newPlayers.Add(Player.ToModel(player));
                    newTeamPlayers.Add(new TeamPlayer()
                    {
                        Id = Guid.NewGuid(),
                        PlayerId = player.Id,
                        TeamId = newTeam.Id,
                    });
                }
                await CreateOrUpdateEntityListAsync(newPlayers).ConfigureAwait(false);
                await CreateOrUpdateEntityListAsync(newTeamPlayers).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        private async Task<bool> EntityExists<T>(T entity) where T : EntityBaseClass
        {
            return await context.Set<T>().AnyAsync(x => x.Id == entity.Id).ConfigureAwait(false);
        }        

        private async Task CreateOrUpdateEntityAsync<T>(T entity) where T : EntityBaseClass
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

        private async Task CreateOrUpdateEntityListAsync<T>(List<T> entities) where T : EntityBaseClass
        {
            var addList = new List<T>();
            var updateList = new List<T>();
            foreach (var entity in entities)
            {
                var entityExists = await EntityExists(entity);
                if (entityExists)
                {
                    updateList.Add(entity);
                }
                else
                {
                    addList.Add(entity);

                }                
            }
            context.UpdateRange(updateList);
            await context.AddRangeAsync(addList).ConfigureAwait(false);
            await context.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
