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
                var newTeamCoaches = new List<TeamCoach>();
                foreach (var coach in coaches)
                {
                    await CreateOrUpdateEntityAsync(coach).ConfigureAwait(false);

                    var existingTeamCoach = await context.TeamCoaches
                        .FirstOrDefaultAsync(x => x.CoachId == coach.Id &&
                            x.TeamId == newTeam.Id &&
                            x.EndedOn == null)
                        .ConfigureAwait(false);

                    if (existingTeamCoach is null)
                    {
                        context.TeamCoaches.Add(new TeamCoach()
                        {
                            Id = Guid.NewGuid(),
                            TeamId = newTeam.Id,
                            CoachId = coach.Id,
                        });

                        await context.SaveChangesAsync().ConfigureAwait(false);
                    }
                    //else it already exists and nothing needs to be done.                
                }

                var players = team.Players;
                foreach (var player in players)
                {
                    await CreateOrUpdateEntityAsync(Player.ToModel(player)).ConfigureAwait(false);

                    var existingTeamPlayer = await context.TeamPlayers
                        .FirstOrDefaultAsync(x => x.TeamId == newTeam.Id &&
                            x.PlayerId == player.Id &&
                            x.EndedOn == null)
                        .ConfigureAwait(false);

                    if ( existingTeamPlayer is null)
                    {
                        context.TeamPlayers.Add(new TeamPlayer()
                        {
                            Id = Guid.NewGuid(),
                            PlayerId = player.Id,
                            TeamId = newTeam.Id,
                        });
                    }
                    //else it already exists and nothing needs to be done
                }
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
    }
}
