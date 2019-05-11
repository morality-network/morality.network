using RateIt.Common.Models.Enums;
using RateIt.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateIt.Services.Interfaces
{
    public interface IContentTypeService
    {
        ContentType GetContentTypeFromEnum(ContentTypeMap type);
        ContentTypeMap GetContentTypeEnumFromName(string contentType);
    }
}
