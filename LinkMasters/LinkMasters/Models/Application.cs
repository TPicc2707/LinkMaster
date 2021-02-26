using LinkMasters.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkMasters.Models
{
    public class Application : ILinkEntity
    {
        public Application()
        {
            this.Links = new HashSet<Link>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime? Created_DateTime { get; set; }
        public DateTime? Modified_DateTime { get; set; }

        public virtual ICollection<Link> Links { get; set; }
    }
}
