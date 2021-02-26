using LinkMasters.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkMasters.Data.Interface
{
    public interface ILinkBaseRepository<TEntity>
        where TEntity: class
    {
        IQueryable<TEntity> GetAll();

        Task<TEntity> GetByIdAsync(int id);

        Task Create(TEntity entity);

        Task Update(int id, TEntity entity);

        Task Delete(int id);

        SelectList CalendarMonths(Calendar thisMonth);

        SelectList DaysOfMonth();

        SelectList Applications();

        SelectList Images();

    }
}
