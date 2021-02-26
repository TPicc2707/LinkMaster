using LinkMasters.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkMasters.Models
{
    public class SpongebobMeme : ISpongebobEntity
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Meme_Name { get; set; }

        public string Url { get; set; }

        public DateTime Created_DateTime { get; set; }

        public DateTime Modified_DateTime { get; set; }

        public virtual SpongebobCharacter SpongebobCharacter { get; set; }
    }
}
