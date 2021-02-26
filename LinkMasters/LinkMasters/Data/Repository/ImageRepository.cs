using LinkMasters.Data.Interface;
using LinkMasters.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkMasters.Data.Repository
{
    public class ImageRepository : LinkBaseRepository<Image>, IImageRepository
    {
        public ImageRepository(LinkMastersContext dbContext)
            : base(dbContext)
        {

        }
    }
}
