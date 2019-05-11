using RateIt.Common.Models.Enums;
using RateIt.Model;
using RateIt.Repositories.Interfaces;
using RateIt.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateIt.Services
{
    public class ContentService : ServiceBase, IContentService
    {
        private readonly IRepository<Content> _contentRepository;
        private readonly IContentTypeService _contentTypeService;
        private readonly IUserService _userService;

        public ContentService(IRepository<Content> contentRepository, IContentTypeService contentTypeService, 
            IUserService userService)
        {
            _contentRepository = contentRepository;
            _contentTypeService = contentTypeService;
            _userService = userService;
        }

        public Content AddContent(long subDirectoryId, ContentTypeMap type)
        {
            var resolvedType = _contentTypeService.GetContentTypeFromEnum(type);
            if(resolvedType != null)
            {
                var content = new Content()
                {
                    ContentTypeId = resolvedType.Id,
                    SubDirectoryId = subDirectoryId,
                    Timestamp = DateTime.Now,
                    ExistsOnBlockChain = false
                };
                _contentRepository.Add(content);
                return content;
            }
            return null;
        }

        public IEnumerable<Content> GetContentBySubDirectoryId(long subDirectoryId)
        {
            return _contentRepository.GetAll()
               .Where(x => x.SubDirectoryId == subDirectoryId);
        }

        public IList<Content> GetContentUpForValidation(long userId, int from, int perPage)
        {
            return _contentRepository.GetAll()
              .Where(x => x.EligableForPersistance && !x.ExistsOnBlockChain 
                && !(x.UserContentValidations.Select(y => y.UserId).Contains(userId))
               )
              .OrderByDescending(x => x.Timestamp)
              .Skip(from)
              .Take(perPage)
              .ToList();
        }

        public Content GetContentById(long contentId)
        {
            return _contentRepository.GetAll()
                .FirstOrDefault(x => x.Id == contentId);
        }

        public bool UpdateContent(Content content)
        {
            if (content != null)
            {
                _contentRepository.Update(content);
                return Convert.ToBoolean(_contentRepository.Save());
            }
            return false;
        }

        public IList<Content> GetContentBySubDirectory(long subdirectoryId, int page, int perPage)
        {
            var content = GetContentBySubDirectoryId(subdirectoryId);
            return content
                .Skip(page * perPage)
                .Take(perPage)
                .ToList();
        }

    }
}
