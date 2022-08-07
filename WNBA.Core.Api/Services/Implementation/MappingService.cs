using WNBA.Core.Api.DataModels;
using WNBA.Core.Api.JsonModels;

namespace WNBA.Core.Api.Services.Implementation
{
    internal sealed class MappingService : IMappingService
    {
        public Team MapTeam(TeamRoster teamRosterData)
        {            
            return new Team(
                teamRosterData.Id,
                teamRosterData.Name,
                teamRosterData.Market,
                teamRosterData.Alias,
                new DateTime((int)teamRosterData.Founded,1, 1),
                teamRosterData.Conference.Name
                );
        }

        public DataModels.Player MapPlayer(JsonModels.Player playerData)
        {
            return new DataModels.Player()
            {
                Id = playerData.Id,
                FirstName = playerData.FirstName,
                LastName = playerData.LastName,
                HeightInINches = playerData.HeightInINches,
                HeightInCm = playerData.HeightInCm,
                WeightInPounds = playerData.WeightInPounds,
                WeightInKg = playerData.WeightInKg,
                Status = playerData.Status,
                Position = playerData.Position,
                JerseyNumber = playerData.JerseyNumber,
                BirthDate = playerData.BirthDate,
                BirthPlace = playerData.BirthPlace,
                Experience = playerData.Experience,
                HighSchool = playerData.HighSchool,
                College = playerData.College,
                RookieYear = playerData.RookieYear,
                DraftedBy = playerData.Draft?.TeamId,
                DraftedYear = playerData.Draft?.Year,
                Round = playerData.Draft?.Round,
                Pick = playerData.Draft?.Pick,
                UpdatedOn = playerData.UpdatedOn
            };
        }
    }
}
