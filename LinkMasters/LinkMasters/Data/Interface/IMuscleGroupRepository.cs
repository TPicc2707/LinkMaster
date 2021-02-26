using LinkMasters.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkMasters.Data.Interface
{
    public interface IMuscleGroupRepository: IFitnessBaseRepository<MuscleGroup>
    {
        SelectList Muscle_Groups();
    }
}
