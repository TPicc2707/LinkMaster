using LinkMasters.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkMasters.Data.Interface
{
    public interface IBudgetRepository : IBudgetBaseRepository<Budget>
    {
        IQueryable<Budget> GetAllMonthlyBudgets();

        IQueryable<Budget> GetAllMonthsBudgetsByPersonGuid(Guid personGuid);

        IQueryable<Budget> FindMonthlyBudgetByPersonGuid(Guid personGuid);

        IQueryable<Budget> FindMonthBudgetBySpecificMonth(int calendarMonth, Guid personGuid);
    }
}
