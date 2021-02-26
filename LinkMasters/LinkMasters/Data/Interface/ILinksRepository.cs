using LinkMasters.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkMasters.Data.Interface
{
    public interface ILinksRepository : ILinkBaseRepository<Link>
    {
        Task<List<Link>> GetLinksByApplicationId(int id);

        Task<List<Link>> GetLinksWithNoImageAsync();
    }
}
