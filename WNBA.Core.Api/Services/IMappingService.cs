using WNBA.Core.Api.DataModels;
using WNBA.Core.Api.JsonModels;

namespace WNBA.Core.Api.Services
{
    public interface IMappingService
    {
        Team MapTeam(TeamRoster teamRosterData);
        DataModels.Player MapPlayer(JsonModels.Player playerData);
    }
}
