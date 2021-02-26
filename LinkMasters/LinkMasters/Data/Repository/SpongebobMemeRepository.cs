using LinkMasters.Data.Interface;
using LinkMasters.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkMasters.Data.Repository
{
    public class SpongebobMemeRepository : SpongebobRepository<SpongebobMeme>, ISpongebobMemeRepository
    {
        public SpongebobMemeRepository(LinkMastersContext dbContext)
            : base(dbContext)
        {

        }
    }
}
