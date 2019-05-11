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
    public class ContentTypeService : ServiceBase, IContentTypeService
    {
        private readonly IRepository<Model.ContentType> _contentTypeRepository;

        public ContentTypeService(IRepository<Model.ContentType> contentTypeRepository)
        {
            _contentTypeRepository = contentTypeRepository;
        }

        public ContentTypeMap GetContentTypeEnumFromName(string contentType)
        {
            return GetEnumFromString<ContentTypeMap>(contentType);
        }

        public ContentType GetContentTypeFromEnum(ContentTypeMap type)
        {
            return _contentTypeRepository.GetAll()
                .FirstOrDefault(x => x.TypeName == type.ToString());
        }
    }
}
