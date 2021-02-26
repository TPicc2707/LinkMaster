using LinkMasters.Data.Interface;
using LinkMasters.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkMasters.Data.Repository
{
    public class AllowanceRepository : BudgetBaseRepository<Allowance>, IAllowanceRepository
    {
        public AllowanceRepository(LinkMastersContext dbContext)
            : base(dbContext)
        {

        }

        public async Task<List<Allowance>> GetAllAllowanceOrderByPeople()
        {
            return await _db.Allowance.OrderBy(a => a.Person.FirstName).ToListAsync();
        }

        public async Task<List<Allowance>> GetAllAllowanceOrderByStartingAllowance()
        {
            return await _db.Allowance.OrderByDescending(a => a.StartingAllowance).ToListAsync();
        }

        public async Task<List<Allowance>> GetAllAllowanceOrderByAllowanceRemaining()
        {
            return await _db.Allowance.OrderByDescending(a => a.AllowanceRemaining).ToListAsync();
        }

        public async Task<Allowance> GetAllowanceByPersonGuid(Guid personGuid)
        {
            return await _db.Allowance.LastOrDefaultAsync(a => a.PersonGuid == personGuid);
        }
    }
}
