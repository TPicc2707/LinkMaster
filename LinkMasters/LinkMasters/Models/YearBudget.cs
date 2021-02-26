using LinkMasters.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkMasters.Models
{
    public class YearBudget : ILinkEntity
    {
        public int Id { get; set; }

        public double StartedAllowance { get; set; }

        public double AllowanceLeft { get; set; }

        public bool PositiveAllowance { get; set; }

        public double AllowanceSpent { get; set; }

        public int? CalendarId { get; set; }

        public Guid? PersonGuid { get; set; }

        public virtual Calendar Calendar { get; set; }

        public virtual Person Person { get; set; }
    }
}
