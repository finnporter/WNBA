using Microsoft.EntityFrameworkCore;
using WNBA.Core.Api.Configuration;
using WNBA.Core.Api.DataModels;
using WNBA.Core.Api.DbHelper;
using WNBA.Core.Api.JsonModels;
using WNBA.Core.Api.Repositories;

namespace WNBA.Core.Api.Services.Implementation
{
    internal sealed class DataHandlingService : IDataHandlingService
    {
        private readonly ApplicationDbContext context;
        private readonly IDatabaseRepository databaseRepository;
        public DataHandlingService(ApplicationDbContext context, IDatabaseRepository databaseRepository)
        {
            this.context = context;
            this.databaseRepository = databaseRepository;
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
                await databaseRepository.CreateOrUpdateEntityAsync(newTeam).ConfigureAwait(false);
                await databaseRepository.CreateOrUpdateEntityAsync(team.Venue).ConfigureAwait(false);

                var coaches = team.Coaches;
                var newTeamCoaches = new List<TeamCoach>();
                foreach (var coach in coaches)
                {
                    await databaseRepository.CreateOrUpdateEntityAsync(coach).ConfigureAwait(false);

                    //TODO rethink. do coaches need to be treated like teamplayers?
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
                    await databaseRepository.CreateOrUpdateEntityAsync(Player.ToModel(player)).ConfigureAwait(false);

                    await databaseRepository.CreateOrUpdateTeamPlayerAsync(player.Id, newTeam.Id);
                }
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        public async Task HandleSeasonsAsync(List<SeasonDto> seasons)
        {
            ArgumentNullException.ThrowIfNull(seasons, nameof(seasons));

            foreach (var season in seasons)
            {
                await databaseRepository.CreateOrUpdateEntityAsync(Season.ToModel(season)).ConfigureAwait(false);
            }
        }

        public async Task HandlePlayerAsync(string id, PlayerDto player)
        {
            await databaseRepository.CreateOrUpdateEntityAsync(Player.ToModel(player));

            if (player.CurrentTeamId is not null)
            {
                await databaseRepository.CreateOrUpdateTeamPlayerAsync(player.Id, player.CurrentTeamId.Id);                
            }

            if (player.Seasons.Any())
            {

            }
            //player seasons...?

        }
    }
}
