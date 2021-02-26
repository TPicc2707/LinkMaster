using LinkMasters.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkMasters.Models
{
    public class Calendar : ILinkEntity
    {
        public int Id { get; set; }
        public int MonthNumber { get; set; }
        public string Month { get; set; }
        public int Year { get; set; }

        public DateTime? Created_DateTime { get; set; }

        public DateTime? Modified_DateTime { get; set; }
    }
}
