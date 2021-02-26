using LinkMasters.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkMasters.Models
{
    public class SpongebobCharacter: ISpongebobEntity
    {
        public int Id { get; set; }

        public string First_Name { get; set; }

        public string Last_Name { get; set; }

        public string Image_Url { get; set; }

        public DateTime Created_DateTime { get; set; }

        public DateTime Modified_DateTime { get; set; }
    }
}
