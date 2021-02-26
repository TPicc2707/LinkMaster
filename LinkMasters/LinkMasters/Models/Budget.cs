using LinkMasters.Data.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LinkMasters.Models
{
    public class Budget : IBudgetEntity
    {
        [Key]
        public Guid Guid { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Expense { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Place { get; set; }

        [Required]
        [Range(0, 999999.99)]
        public double? Cost { get; set; }

        public Guid AllowanceGuid { get; set; }

        public int DayId { get; set; }

        public int CalendarId { get; set; }

        public Guid? PersonGuid { get; set; }

        public DateTime? Created_DateTime { get; set; }

        public DateTime? Modified_DateTime { get; set; }

        public virtual Calendar Calendar { get; set; }

        public virtual Day Day { get; set; }

        public virtual Allowance Allowance { get; set; }

        public virtual Person Person { get; set; }
    }
}
