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
}
