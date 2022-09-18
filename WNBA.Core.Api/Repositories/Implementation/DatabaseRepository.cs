using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WNBA.Core.Api.Configuration;
using WNBA.Core.Api.DbHelper;

namespace WNBA.Core.Api.Repositories.Implementation
{
    internal sealed class DatabaseRepository : IDatabaseRepository
    {
        private readonly ApplicationDbContext context;
        public DatabaseRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        private async Task<bool> EntityExists<T>(T entity) where T : EntityBaseClass
        {
            return await context.Set<T>().AnyAsync(x => x.Id == entity.Id).ConfigureAwait(false);
        }

        public async Task CreateOrUpdateEntityAsync<T>(T entity) where T : EntityBaseClass
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
