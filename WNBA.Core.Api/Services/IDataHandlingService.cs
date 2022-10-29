using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WNBA.Core.Api.JsonModels;

namespace WNBA.Core.Api.Services;

public interface IDataHandlingService
{
    /// <summary>
    /// Handles the saving of a teamroster to the database
    /// </summary>
    /// <param name="id"></param>
    /// <param name="team"></param>
    Task<bool> HandleTeamRosterAsync(string id, TeamDto team);

    /// <summary>
    /// Handles the saving of multiple seasons to the database.
    /// </summary>
    /// <param name="seasons"></param>
    /// <returns></returns>
    Task HandleSeasonsAsync(List<SeasonDto> seasons);

    /// <summary>
    /// Handles the saving of players to the database.
    /// </summary>
    /// <param name="seasons">
    Task HandlePlayerAsync(string id, PlayerDto player);

    /// <summary>
    /// Handles the saving of base data like team Ids and venues.
    /// Mostly used for initial setup.
    /// </summary>
    /// <returns></returns>
    Task<List<string>> HandleLeagueHierarchyAsync(LeagueHierarchyDto leagueHierarchy);
}
