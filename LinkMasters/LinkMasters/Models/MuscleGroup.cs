﻿using LinkMasters.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkMasters.Models
{
    public class MuscleGroup: IFitnessEntity
    {
        public int Id { get; set; }

        public string Muscle_Group { get; set; }

        public DateTime Created_DateTime { get; set; }

        public DateTime Modified_DateTime { get; set; }
    }
}
