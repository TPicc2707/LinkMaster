using LinkMasters.Data.Interface;
using LinkMasters.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkMasters.Data.Repository
{
    public class SpongebobQuoteRepository : SpongebobRepository<SpongebobQuotes>, ISpongebobQuoteRepository
    {
        public SpongebobQuoteRepository(LinkMastersContext _db)
            :base(_db)
        {

        }

        public IQueryable<SpongebobQuotes> GetAllCharacterQuotes(int characterId)
        {
            return _db.SpongebobQuotes.Where(s => s.SpongebobCharacter.Id == characterId);
        }

        public SpongebobQuotes GetRandomQuoteFromCharacter(int characterId)
        {
            Random rand = new Random();

            List<SpongebobQuotes> quotes = _db.SpongebobQuotes.Where(s => s.SpongebobCharacter.Id == characterId).ToList();

            int index = rand.Next(quotes.Count);

            return quotes[index];
            //List<SpongebobQuotes> quotes = _db.SpongebobQuotes.Where(s => s.SpongebobCharacter.Id == characterId).ToList();

            //var randomizedList = from item in quotes orderby rand.Next() select item;

            //return randomizedList;
        }
    }
}
