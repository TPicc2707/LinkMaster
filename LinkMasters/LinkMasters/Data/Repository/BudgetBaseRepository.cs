using LinkMasters.Data.Interface;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkMasters.Data.Repository
{
    public class BudgetBaseRepository<TEntity> : IBudgetBaseRepository<TEntity>
        where TEntity : class, IBudgetEntity
    {
        protected readonly LinkMastersContext _db;

        public BudgetBaseRepository(LinkMastersContext dbContext)
        {
            _db = dbContext;
        }

        public IQueryable<TEntity> GetAll()
        {
            return _db.Set<TEntity>();
        }

        public async Task<TEntity> GetByGuidAsync(Guid guid)
        {
            return await _db.Set<TEntity>()
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Guid == guid);
        }

        public async Task Create(TEntity entity)
        {
            await _db.Set<TEntity>().AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public async Task Update(Guid guid, TEntity entity)
        {
            _db.Set<TEntity>().Update(entity);
            await _db.SaveChangesAsync();
        }

        public async Task Delete(Guid guid)
        {
            var entity = await _db.Set<TEntity>().FindAsync(guid);
            _db.Set<TEntity>().Remove(entity);
            await _db.SaveChangesAsync();
        }

        public SelectList People(Guid personGuid)
        {
            var people = new SelectList(_db.Person, "Guid", "FullName", personGuid);

            return people;
        }
    }
}
