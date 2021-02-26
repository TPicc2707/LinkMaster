using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LinkMasters.Data.Interface;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace LinkMasters.Controllers
{
    public class SpongebobFanaticsController : Controller
    {
        ISpongebobCharacterRepository _spongebobCharacterRepository;
        ISpongebobMemeRepository _spongebobMemeRepository;
        ISpongebobQuoteRepository _spongebobQuoteRepository;
        public SpongebobFanaticsController(ISpongebobCharacterRepository spongebobCharacterRepository, ISpongebobMemeRepository spongebobMemeRepository, ISpongebobQuoteRepository spongebobQuoteRepository)
        {
            _spongebobCharacterRepository = spongebobCharacterRepository;
            _spongebobMemeRepository = spongebobMemeRepository;
            _spongebobQuoteRepository = spongebobQuoteRepository;
        }

        public IActionResult Home()
        {
            var characters = _spongebobCharacterRepository.GetAll();
            return View(characters);
        }

        public IActionResult Memes()
        {
            var memes = _spongebobMemeRepository.GetAll();
            return View(memes);
        }

        public IActionResult Quotes(int characterId)
        {
            var quote = _spongebobQuoteRepository.GetRandomQuoteFromCharacter(characterId);
            return View(quote);
        }
    }
}