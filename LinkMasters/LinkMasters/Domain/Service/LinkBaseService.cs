using LinkMasters.Data.Interface;
using LinkMasters.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkMasters.Domain.Service
{
    public class LinkBaseService
    {
        private ILinksRepository _linkRepository;
        private IApplicationRepository _applicationRepository;
        private IImageRepository _imageRepository;

        public LinkBaseService(ILinksRepository linkRepository, IApplicationRepository applicationRepository, IImageRepository imageRepository)
        {
            _linkRepository = linkRepository;
            _applicationRepository = applicationRepository;
            _imageRepository = imageRepository;
        }

        public async Task AddLink(Link link)
        {
            if(link.ApplicationId == 13)
            {
                link.FilePath = link.Url;
            }
            link.Created_DateTime = DateTime.UtcNow;
            link.Modified_DateTime = DateTime.UtcNow;
            await _linkRepository.Create(link);

            if(link.ApplicationId == 13)
            {
                link.Url = "/Links/FileOpenerAsync?applicationId=" + link.ApplicationId + "&linkId=" + link.Id;
            }

            await _linkRepository.Update(link.Id, link);
        }

        public async Task AddImageToLink(Link link, Image image)
        {
            link.ImageId = image.Id;
            link.Modified_DateTime = DateTime.UtcNow;

            await _linkRepository.Update(link.Id, link);
        }

        public async Task AddImage(Image image)
        {
            image.Created_DateTime = DateTime.UtcNow;
            image.Modified_DateTime = DateTime.UtcNow;
            await _imageRepository.Create(image);
        }
    }
}
