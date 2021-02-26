using LinkMasters.Data.Interface;
using LinkMasters.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkMasters.Data.Repository
{
    public class LinkBaseRepository<TEntity> : ILinkBaseRepository<TEntity>
        where TEntity : class, ILinkEntity
    {
        protected readonly LinkMastersContext _db;

        public LinkBaseRepository(LinkMastersContext dbContext)
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

        public SelectList CalendarMonths(Calendar thisMonth)
        {
            var months = new SelectList(_db.Calendar, "Id", "Month", thisMonth.Id);

            return months;
        }

        public SelectList DaysOfMonth()
        {
            var today = DateTime.Today.Day;
            var daysOftheMonth = new SelectList(_db.Day, "Id", "DayOfMonth", today);

            return daysOftheMonth;
        }

        public SelectList Applications()
        {
            var applications = new SelectList(_db.Application, "Id", "Name");

            return applications;
        }

        public SelectList Images()
        {
            var images = new SelectList(_db.Image, "Id", "ImageName");

            return images;
        }
    }
}
