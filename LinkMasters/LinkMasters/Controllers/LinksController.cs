using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LinkMasters.Models;
using LinkMasters.Data.Interface;
using System.Diagnostics;
using LinkMasters.Domain.Service;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace LinkMasters.Controllers
{
    public class LinksController : Controller
    {
        private ILinksRepository _linkRepository;
        private IApplicationRepository _applicationRepository;
        private IImageRepository _imageRepository;
        private IHostingEnvironment _hostingEnvironment;

        public LinksController(ILinksRepository linkRepository, IApplicationRepository applicationRepository, IImageRepository imageRepository, IHostingEnvironment hostingEnvironment)
        {
            _linkRepository = linkRepository;
            _applicationRepository = applicationRepository;
            _imageRepository = imageRepository;
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<IActionResult> JROTC()
        {
            var getJROTCLinks = _linkRepository.GetAll();
            return View(await getJROTCLinks.ToListAsync());
        }

        public async Task<IActionResult> HandyLinks(int applicationId)
        {
            var getWorkLinks = _linkRepository.GetLinksByApplicationId(applicationId);
            return View(await getWorkLinks);
        }

        public async Task<IActionResult> SpecificLinks(int applicationId)
        {
            var getApplicationLinks = _linkRepository.GetLinksByApplicationId(applicationId);
            var application = await _applicationRepository.GetApplicationById(applicationId);
            ViewBag.ApplicationName = application.Name;
            return View(await getApplicationLinks);
        }


        public async Task<IActionResult> FileOpenerAsync(int applicationId, int linkId)
        {
            await OpenFolderAsync(linkId);

            return RedirectToAction("HandyLinks", new { applicationId = applicationId });
        }

        public IActionResult CreateLink()
        {
            ViewData["Applications"] = _applicationRepository.Applications();
            return View();
        }

        public async Task<IActionResult> SelectAnImage()
        {
            var links = await _linkRepository.GetLinksWithNoImageAsync();

            return View(links);
        }

        public IActionResult CreateImage()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateImage(Image image)
        {
            LinkBaseService linkService = new LinkBaseService(_linkRepository, _applicationRepository, _imageRepository);

            await linkService.AddImage(image);

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> ChooseImage(int id)
        {
            ViewBag.LinkId = id;

            var getLink = await _linkRepository.GetByIdAsync(id);

            ViewBag.LinkTitle = getLink.Name;

            ViewData["Images"] = _applicationRepository.Images();


            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChooseImage(Link link)
        {
            var getLink = await _linkRepository.GetByIdAsync(link.Id);

            getLink.ImageId = link.ImageId;
            getLink.Modified_DateTime = DateTime.UtcNow;

            await _linkRepository.Update(getLink.Id, getLink);

            return RedirectToAction("SelectAnImage", "Links");

        }

        public async Task<IActionResult> SelectHandyLink(int applicationId)
        {
            var getApplicationLinks = _linkRepository.GetLinksByApplicationId(applicationId);
            return View(await getApplicationLinks);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateLink(Link link)
        {
            if(link.Name != null && link.Nickname != null)
            {
                LinkBaseService linkService = new LinkBaseService(_linkRepository, _applicationRepository, _imageRepository);
                await linkService.AddLink(link);
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("CreateLink", "Links");
             
        }

        public async Task<IActionResult> OpenFile(int id)
        {
            var getLinkById = await _linkRepository.GetByIdAsync(id);

            getLinkById.Url = "/Links/FileOpenerAsync?applicationId=" + getLinkById.ApplicationId + "&linkId=" + getLinkById.Id;

            await _linkRepository.Update(getLinkById.Id, getLinkById);

            Process.Start(new ProcessStartInfo()
            {
                FileName = getLinkById.FilePath,
                UseShellExecute = true,
                Verb = "open"
            });

            return RedirectToAction("HandyLinks", "Links", new { applicationId = getLinkById.ApplicationId });
        }

        public async Task OpenFolderAsync(int linkId)
        {
            var getLinkById = await _linkRepository.GetByIdAsync(linkId);

            Process.Start(new ProcessStartInfo()
            {
                FileName = getLinkById.FilePath,
                UseShellExecute = true,
                Verb = "open"
            });
        }

        public void UploadImage(Image image)
        {
            //string uploadPath = "~/Images/FromSite";
           
            //var fileName = Path.GetFileName(image.ImagePath);

            //var path = Path.Combine(Server.MapPath);
        }

//        GET: Links/Create
//        public IActionResult Create()
//        {
//            ViewData["ApplicationId"] = new SelectList(_context.Set<Application>(), "Id", "Id");
//            ViewData["ImageId"] = new SelectList(_context.Set<Image>(), "Id", "Id");
//            return View();
//        }

//        POST: Links/Create
//        To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//         more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("Id,Name,Url,Created_DateTime,Modified_DateTime,ApplicationId,ImageId")] Link link)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Add(link);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            ViewData["ApplicationId"] = new SelectList(_context.Set<Application>(), "Id", "Id", link.ApplicationId);
//            ViewData["ImageId"] = new SelectList(_context.Set<Image>(), "Id", "Id", link.ImageId);
//            return View(link);
//        }

//        GET: Links/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var link = await _context.Link.FindAsync(id);
//            if (link == null)
//            {
//                return NotFound();
//            }
//            ViewData["ApplicationId"] = new SelectList(_context.Set<Application>(), "Id", "Id", link.ApplicationId);
//            ViewData["ImageId"] = new SelectList(_context.Set<Image>(), "Id", "Id", link.ImageId);
//            return View(link);
//        }

//        POST: Links/Edit/5
//         To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//         more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Url,Created_DateTime,Modified_DateTime,ApplicationId,ImageId")] Link link)
//        {
//            if (id != link.Id)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(link);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!LinkExists(link.Id))
//                    {
//                        return NotFound();
//                    }
//                    else
//                    {
//                        throw;
//                    }
//                }
//                return RedirectToAction(nameof(Index));
//            }
//            ViewData["ApplicationId"] = new SelectList(_context.Set<Application>(), "Id", "Id", link.ApplicationId);
//            ViewData["ImageId"] = new SelectList(_context.Set<Image>(), "Id", "Id", link.ImageId);
//            return View(link);
//        }

//        GET: Links/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var link = await _context.Link
//                .Include(l => l.Application)
//                .Include(l => l.Image)
//                .FirstOrDefaultAsync(m => m.Id == id);
//            if (link == null)
//            {
//                return NotFound();
//            }

//            return View(link);
//        }

//        POST: Links/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            var link = await _context.Link.FindAsync(id);
//            _context.Link.Remove(link);
//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool LinkExists(int id)
//        {
//            return _context.Link.Any(e => e.Id == id);
//        }
//    }
//}//        public async Task<IActionResult> Index()
//        {
//            var linkMaster2Context = _context.Link.Include(l => l.Application).Include(l => l.Image);
//            return View(await linkMaster2Context.ToListAsync());
//        }

//        GET: Links/Details/5
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var link = await _context.Link
//                .Include(l => l.Application)
//                .Include(l => l.Image)
//                .FirstOrDefaultAsync(m => m.Id == id);
//            if (link == null)
//            {
//                return NotFound();
//            }

//            return View(link);
//        }

//        GET: Links/Create
//        public IActionResult Create()
//        {
//            ViewData["ApplicationId"] = new SelectList(_context.Set<Application>(), "Id", "Id");
//            ViewData["ImageId"] = new SelectList(_context.Set<Image>(), "Id", "Id");
//            return View();
//        }

//        POST: Links/Create
//        To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//         more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("Id,Name,Url,Created_DateTime,Modified_DateTime,ApplicationId,ImageId")] Link link)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Add(link);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            ViewData["ApplicationId"] = new SelectList(_context.Set<Application>(), "Id", "Id", link.ApplicationId);
//            ViewData["ImageId"] = new SelectList(_context.Set<Image>(), "Id", "Id", link.ImageId);
//            return View(link);
//        }

//        GET: Links/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var link = await _context.Link.FindAsync(id);
//            if (link == null)
//            {
//                return NotFound();
//            }
//            ViewData["ApplicationId"] = new SelectList(_context.Set<Application>(), "Id", "Id", link.ApplicationId);
//            ViewData["ImageId"] = new SelectList(_context.Set<Image>(), "Id", "Id", link.ImageId);
//            return View(link);
//        }

//        POST: Links/Edit/5
//         To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//         more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Url,Created_DateTime,Modified_DateTime,ApplicationId,ImageId")] Link link)
//        {
//            if (id != link.Id)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(link);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!LinkExists(link.Id))
//                    {
//                        return NotFound();
//                    }
//                    else
//                    {
//                        throw;
//                    }
//                }
//                return RedirectToAction(nameof(Index));
//            }
//            ViewData["ApplicationId"] = new SelectList(_context.Set<Application>(), "Id", "Id", link.ApplicationId);
//            ViewData["ImageId"] = new SelectList(_context.Set<Image>(), "Id", "Id", link.ImageId);
//            return View(link);
//        }

//        GET: Links/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var link = await _context.Link
//                .Include(l => l.Application)
//                .Include(l => l.Image)
//                .FirstOrDefaultAsync(m => m.Id == id);
//            if (link == null)
//            {
//                return NotFound();
//            }

//            return View(link);
//        }

//        POST: Links/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            var link = await _context.Link.FindAsync(id);
//            _context.Link.Remove(link);
//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool LinkExists(int id)
//        {
//            return _context.Link.Any(e => e.Id == id);
//        }
    }
}
