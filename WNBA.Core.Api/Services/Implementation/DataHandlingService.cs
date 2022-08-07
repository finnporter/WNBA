using WNBA.Core.Api.Configuration;
using WNBA.Core.Api.DataModels;
using WNBA.Core.Api.JsonModels;

namespace WNBA.Core.Api.Services.Implementation
{
    internal sealed class DataHandlingService : IDataHandlingService
    {
        private readonly IMappingService mappingService;
        private readonly ApplicationDbContext context;
        public DataHandlingService(IMappingService mappingService, ApplicationDbContext context)
        {
            this.mappingService = mappingService;
            this.context = context;
        }
        public async Task<bool> HandleTeamRosterAsync(TeamRoster teamRosterData)
        {
            var newTeam = mappingService.MapTeam(teamRosterData);

            try
            {
                var newVenue = teamRosterData.Venue;                               

                context.Add<Team>(newTeam);
                context.Add<Venue>(newVenue);
                context.Add(new TeamVenue(Guid.NewGuid(), newVenue.Id, newTeam.Id));                

                var coaches = teamRosterData.Coaches;
                var newCoaches = new List<Coach>();
                var newTeamCoaches = new List<TeamCoach>();
                foreach (var coach in coaches)
                {
                    newCoaches.Add(coach);
                    newTeamCoaches.Add(new TeamCoach(Guid.NewGuid(), newTeam.Id, coach.Id));
                }
                context.AddRange(coaches);
                context.AddRange(newTeamCoaches);

                var players = teamRosterData.Players;
                var newPlayers = new List<DataModels.Player>();
                var newTeamPlayers = new List<TeamPlayer>();
                foreach (var player in players)
                {
                    newPlayers.Add(mappingService.MapPlayer(player));
                    newTeamPlayers.Add(new TeamPlayer(Guid.NewGuid(), player.Id, newTeam.Id));
                }
                context.AddRange(newPlayers);
                context.AddRange(newTeamPlayers);
                await context.SaveChangesAsync();
            }
            catch (Exception e)
            {

                throw;
            }

            return true;
        }
    }
}
