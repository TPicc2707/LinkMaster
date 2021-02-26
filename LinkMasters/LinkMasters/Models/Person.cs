using LinkMasters.Data.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LinkMasters.Models
{
    public class Person : IBudgetEntity
    {
        [Key]
        public Guid Guid { get; set; }

        [Required]
        [DisplayName("First Name")]
        [StringLength(100, MinimumLength = 2)]
        public string FirstName { get; set; }
        [Required]
        [DisplayName("Last Name")]
        [StringLength(100, MinimumLength = 2)]
        public string LastName { get; set; }

        public DateTime? Created_DateTime { get; set; }

        public DateTime? Modified_DateTime { get; set; }

        public string FullName { get { return FirstName + " " + LastName; } }

        public int NextMonthUpdateAllowance { get; set; }
    }
}
