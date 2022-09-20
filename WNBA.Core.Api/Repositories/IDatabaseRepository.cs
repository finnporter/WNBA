using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WNBA.Core.Api.DbHelper;

namespace WNBA.Core.Api.Repositories;

/// <summary>
/// Handles database interactions as much as possible
/// </summary>
public interface IDatabaseRepository
{

    /// <summary>
    /// Creates or updates an entity
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="entity"></param>
    Task CreateOrUpdateEntityAsync<T>(T entity) where T : EntityBaseClass;

    /// <summary>
    /// Gets an entity from the database by Id.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="id"></param>
    Task<T?> GetEntityAsync<T>(Guid id) where T : EntityBaseClass;

    /// <summary>
    /// Creates or updates a TeamPlayer identity specifically
    /// </summary>
    /// <param name="playerId"></param>
    /// <param name="teamId"></param>
    Task CreateOrUpdateTeamPlayerAsync(Guid playerId, Guid teamId)
}
