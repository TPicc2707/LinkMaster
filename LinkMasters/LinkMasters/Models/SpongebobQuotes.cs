using LinkMasters.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkMasters.Models
{
    public class SpongebobQuotes : ISpongebobEntity
    {
        public int Id { get; set; }

        public string Quote { get; set; }

        public string Episode_Number { get; set; }

        public DateTime Created_DateTime { get; set; }

        public DateTime Modified_DateTime { get; set; }

        public virtual SpongebobCharacter SpongebobCharacter { get; set; }
    }
}
