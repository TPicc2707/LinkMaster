using LinkMasters.Data.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LinkMasters.Models
{
    public class Allowance : IBudgetEntity
    {
        [Key]
        public Guid Guid { get; set; }

        public double AllowanceRemaining { get; set; }

        public bool IsAllowanceRemainingPositive { get; set; }

        [Required]
        [DisplayName("Starting Allowance")]
        [Range(0, 999999.99)]
        public double StartingAllowance { get; set; }

        public DateTime? Created_DateTime { get; set; }

        public DateTime? Modified_DateTime { get; set; }

        public Guid? PersonGuid { get; set; }

        public virtual Person Person { get; set; }
    }
}
