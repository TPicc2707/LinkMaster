using LinkMasters.Data.Interface;
using LinkMasters.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkMasters.Data.Repository
{
    public class MuscleGroupRepository : FitnessBaseRepository<MuscleGroup>, IMuscleGroupRepository
    {
        public MuscleGroupRepository(LinkMastersContext dbContext)
            :base(dbContext)
        {

        }

        public SelectList Muscle_Groups()
        {
            var muscle_groups = new SelectList(_db.MuscleGroup, "Id", "Muscle_Group");

            return muscle_groups;
        }
    }
}
