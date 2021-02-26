using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkMasters.Data.Interface
{
    public interface IBudgetBaseRepository<TEntity>
        where TEntity : class
    {
        IQueryable<TEntity> GetAll();

        Task<TEntity> GetByGuidAsync(Guid guid);

        Task Create(TEntity entity);

        Task Update(Guid guid, TEntity entity);

        Task Delete(Guid guid);

        SelectList People(Guid personGuid);
    }
}
