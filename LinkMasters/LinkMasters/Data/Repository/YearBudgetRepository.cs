using LinkMasters.Data.Interface;
using LinkMasters.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkMasters.Data.Repository
{
    public class YearBudgetRepository : LinkBaseRepository<YearBudget>, IYearBudgetRepository
    {
        public YearBudgetRepository(LinkMastersContext dbContext)
            : base(dbContext)
        {

        }

        public IQueryable<YearBudget> GetAllYearlyBudgets()
        {
            return _db.YearBudget.OrderBy(y => y.CalendarId);
        }
        public async Task<List<YearBudget>> GetAllMontlyBudgetsByYearFromPersonGuid(Guid personGuid)
        {
            return await _db.YearBudget.Where(y => y.PersonGuid == personGuid).OrderBy(y => y.CalendarId).ToListAsync();
        }

        public double GetTotalStartingAllowanceYearBudgetFromPersonGuid(Guid personGuid)
        {
            var startedAllowanceTotal = _db.YearBudget.Where(y => y.PersonGuid == personGuid).Select(y => y.StartedAllowance).Sum();

            return startedAllowanceTotal;
        }

        public double GetTotalAllowanceLeftYearBudgetFromPersonGuid(Guid personGuid)
        {
            var allowanceLeftTotal = _db.YearBudget.Where(y => y.PersonGuid == personGuid).Select(y => y.AllowanceLeft).Sum();

            return allowanceLeftTotal;
        }

        public double GetTotalAllowanceSpentYearBudgetFromPersonGuid(Guid personGuid)
        {
            var allowanceSpentTotal = _db.YearBudget.Where(y => y.PersonGuid == personGuid).Select(y => y.AllowanceSpent).Sum();

            return allowanceSpentTotal;
        }

        public async Task<YearBudget> GetOneMonthBudgetFromPersonGuid(Guid personGuid)
        {
            var years = await _db.YearBudget.Where(y => y.PersonGuid == personGuid).ToListAsync();

            foreach(var month in years)
            {
                if(month.Calendar.MonthNumber == DateTime.Today.Month && month.Calendar.Year == DateTime.Today.Year)
                {
                    return month;
                }
            }

            return null;
        }
    }
}
