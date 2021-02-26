using LinkMasters.Data.Interface;
using LinkMasters.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkMasters.Data.Repository
{
    public class BudgetRepository : BudgetBaseRepository<Budget>, IBudgetRepository
    {
        public BudgetRepository(LinkMastersContext dbContext)
           : base(dbContext)
        {

        }

        public IQueryable<Budget> GetAllMonthlyBudgets()
        {
            return _db.Budget.Where(b => b.Calendar.Year == DateTime.Today.Year).OrderBy(b => b.DayId);
        }

        public IQueryable<Budget> GetAllMonthsBudgetsByPersonGuid(Guid personGuid)
        {
            return _db.Budget.Where(b => b.PersonGuid == personGuid).OrderBy(b => b.DayId);
        }


        public IQueryable<Budget> FindMonthlyBudgetByPersonGuid(Guid personGuid)
        {
            return _db.Budget.Where(b => b.PersonGuid == personGuid
                                    && b.Calendar.MonthNumber == DateTime.Today.Month).OrderBy(b => b.DayId);

        }

        public IQueryable<Budget> FindMonthBudgetBySpecificMonth(int calendarMonth, Guid personGuid)
        {
            return _db.Budget.Where(b => b.PersonGuid == personGuid
                                    && b.Calendar.MonthNumber == calendarMonth).OrderBy(b => b.DayId);
        }
    }
}
