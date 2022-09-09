using WNBA.Core.Api.JsonModels;

namespace WNBA.Core.Api.Connectors
{
    public interface ISportsradarConnector
    {
        Task<TeamDto> ReadTeamRosterEndpointAsync(string id);
    }
}
