using LinkMasters.Data.Interface;
using LinkMasters.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkMasters.Data.Repository
{
    public class ApplicationRepository : LinkBaseRepository<Application>, IApplicationRepository
    {
        public ApplicationRepository(LinkMastersContext dbContext)
            : base(dbContext)
        {

        }
        public async Task<Application> GetApplicationById(int applicationId)
        {
            return await GetAll().FirstOrDefaultAsync(a => a.Id == applicationId);

        }
    }
}
