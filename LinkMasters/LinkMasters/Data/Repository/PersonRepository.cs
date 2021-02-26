using LinkMasters.Data.Interface;
using LinkMasters.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkMasters.Data.Repository
{
    public class PersonRepository : BudgetBaseRepository<Person>, IPersonRepository
    {
        public PersonRepository(LinkMastersContext dbContext)
           : base(dbContext)
        {

        }

        public async Task<List<Person>> GetAllPeople()
        {
            return await _db.Person.OrderBy(p => p.FirstName).ToListAsync(); 
        }

        public async Task<Person> GetPersonByPersonGuid(Guid personGuid)
        {
            return await _db.Person.FirstOrDefaultAsync(p => p.Guid == personGuid);
        }
    }
}
