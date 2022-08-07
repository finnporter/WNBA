using WNBA.Core.Api.JsonModels;

namespace WNBA.Core.Api.Connectors
{
    public interface ISportsradarConnector
    {
        Task<TeamRoster> ReadTeamRosterEndpointAsync(string id);
    }
}
