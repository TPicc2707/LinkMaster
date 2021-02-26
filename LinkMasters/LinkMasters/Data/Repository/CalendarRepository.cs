using LinkMasters.Data.Interface;
using LinkMasters.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkMasters.Data.Repository
{
    public class CalendarRepository : LinkBaseRepository<Calendar>, ICalendarRepository
    {
        public CalendarRepository(LinkMastersContext dbContext)
            : base(dbContext)
        {

        }

        public async Task<Calendar> GetCalendarMonth()
        {
            var month = DateTime.Today.Month;

            var months = await _db.Calendar.Where(c => c.MonthNumber == month).ToListAsync();

            foreach (var oneMonth in months)
            {
                if (oneMonth.Year == DateTime.Today.Year)
                {
                    return oneMonth;
                }
            }

            return null;
        }

        public async Task<Calendar> GetCalendarMonthBySpecificMonth(int calendarMonth)
        {
            return await _db.Calendar.FirstOrDefaultAsync(c => c.MonthNumber == calendarMonth);
        }

        public async Task<Calendar> GetCalendarYear()
        {
            var year = DateTime.Today.Year;

            return await _db.Calendar.FirstOrDefaultAsync(c => c.Year == year);
        }

        public Task<Calendar> GetCalendarYearById()
        {
            throw new NotImplementedException();
        }
    }
}
