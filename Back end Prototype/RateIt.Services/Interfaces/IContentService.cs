using RateIt.Common.Models.Enums;
using RateIt.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateIt.Services.Interfaces
{
    public interface IContentService
    {
        Content AddContent(long subDirectoryId, ContentTypeMap type);
        IEnumerable<Content> GetContentBySubDirectoryId(long subDirectoryId);
        Content GetContentById(long contentId);
        bool UpdateContent(Content content);
        IList<Content> GetContentUpForValidation(long userId, int from, int perPage);
        IList<Content> GetContentBySubDirectory(long subdirectoryId, int page, int perPage);
    }
}
