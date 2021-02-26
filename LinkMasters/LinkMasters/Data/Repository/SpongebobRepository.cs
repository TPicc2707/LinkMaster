using LinkMasters.Data.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkMasters.Data.Repository
{
    public class SpongebobRepository<TEntity> : ISpongebobBaseRepository<TEntity>
        where TEntity : class, ISpongebobEntity
    {
        protected readonly LinkMastersContext _db;

        public SpongebobRepository(LinkMastersContext dbContext)
        {
            _db = dbContext;
        }

        public IQueryable<TEntity> GetAll()
        {
            return _db.Set<TEntity>();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _db.Set<TEntity>()
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task Create(TEntity entity)
        {
            await _db.Set<TEntity>().AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public async Task Update(int id, TEntity entity)
        {
            _db.Set<TEntity>().Update(entity);
            await _db.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await _db.Set<TEntity>().FindAsync(id);
            _db.Set<TEntity>().Remove(entity);
            await _db.SaveChangesAsync();
        }
    }
}
