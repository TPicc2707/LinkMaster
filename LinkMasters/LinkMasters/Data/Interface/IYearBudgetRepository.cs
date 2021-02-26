using LinkMasters.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkMasters.Data.Interface
{
    public interface IYearBudgetRepository : ILinkBaseRepository<YearBudget>
    {
        IQueryable<YearBudget> GetAllYearlyBudgets();
        Task<List<YearBudget>> GetAllMontlyBudgetsByYearFromPersonGuid(Guid personGuid);

        Task<YearBudget> GetOneMonthBudgetFromPersonGuid(Guid personGuid);

        double GetTotalStartingAllowanceYearBudgetFromPersonGuid(Guid personGuid);

        double GetTotalAllowanceLeftYearBudgetFromPersonGuid(Guid personGuid);

        double GetTotalAllowanceSpentYearBudgetFromPersonGuid(Guid personGuid);
    }
}
