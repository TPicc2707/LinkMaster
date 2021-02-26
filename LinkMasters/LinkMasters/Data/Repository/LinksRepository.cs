using LinkMasters.Data.Interface;
using LinkMasters.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkMasters.Data.Repository
{
    public class LinksRepository : LinkBaseRepository<Link>, ILinksRepository
    {
        public LinksRepository(LinkMastersContext dbContext)
           : base(dbContext)
        {

        }

        public async Task<List<Link>> GetLinksByApplicationId(int id)
        {
            return await GetAll()
                .Where(l => l.ApplicationId == id)
                .ToListAsync();
        }

        public async Task<List<Link>> GetLinksWithNoImageAsync()
        {
            return await _db.Link.Where(l => l.ImageId == null).ToListAsync();
        }
    }
}
