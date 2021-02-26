using LinkMasters.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkMasters.Data.Interface
{
    public interface IAllowanceRepository : IBudgetBaseRepository<Allowance>
    {
        Task<List<Allowance>> GetAllAllowanceOrderByPeople();
        Task<List<Allowance>> GetAllAllowanceOrderByStartingAllowance();
        Task<List<Allowance>> GetAllAllowanceOrderByAllowanceRemaining();
        Task<Allowance> GetAllowanceByPersonGuid(Guid personGuid);
    }
}
