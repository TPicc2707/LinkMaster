using LinkMasters.Data.Interface;
using LinkMasters.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkMasters.Data.Repository
{
    public class SpongebobCharacterRepository: SpongebobRepository<SpongebobCharacter>, ISpongebobCharacterRepository
    {
        public SpongebobCharacterRepository(LinkMastersContext dbContext)
            : base(dbContext)
        {

        }
    }
}
