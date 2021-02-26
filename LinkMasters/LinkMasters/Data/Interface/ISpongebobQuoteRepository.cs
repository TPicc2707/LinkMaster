using LinkMasters.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkMasters.Data.Interface
{
    public interface ISpongebobQuoteRepository : ISpongebobBaseRepository<SpongebobQuotes>
    {
        IQueryable<SpongebobQuotes> GetAllCharacterQuotes(int characterId);

        SpongebobQuotes GetRandomQuoteFromCharacter(int characterId);
    }
}
