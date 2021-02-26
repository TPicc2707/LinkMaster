using LinkMasters.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkMasters.Models
{
    public class Image : ILinkEntity
    {
        public Image()
        {
            this.Links = new HashSet<Link>();
        }

        public int Id { get; set; }

        public string ImageName { get; set; }

        public string ImagePath { get; set; }

        public DateTime? Created_DateTime { get; set; }
        public DateTime? Modified_DateTime { get; set; }

        public virtual ICollection<Link> Links { get; set; }
    }
}
