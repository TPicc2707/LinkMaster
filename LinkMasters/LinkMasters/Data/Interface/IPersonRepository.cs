using LinkMasters.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkMasters.Data.Interface
{
    public interface IPersonRepository : IBudgetBaseRepository<Person>
    {
        Task<List<Person>> GetAllPeople();
        Task<Person> GetPersonByPersonGuid(Guid personGuid);
    }
}
