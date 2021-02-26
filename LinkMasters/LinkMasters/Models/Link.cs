using LinkMasters.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkMasters.Models
{
    public class Link : ILinkEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Nickname { get; set; }

        public string Url { get; set; }

        public DateTime? Created_DateTime { get; set; }

        public DateTime? Modified_DateTime { get; set; }

        public int? ApplicationId { get; set; }

        public int? ImageId { get; set; }

        public string FilePath { get; set; }

        public virtual Application Application { get; set; }

        public virtual Image Image { get; set; }
    }
}
