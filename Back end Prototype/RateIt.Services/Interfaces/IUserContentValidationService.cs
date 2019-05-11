using RateIt.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateIt.Services.Interfaces
{
    public interface IUserContentValidationService
    {
        bool HasUserValidatedAlready(long userId, long contentId);
        bool AddValidationRecord(long userId, long contentId, bool shouldBePersisted);
        bool DeleteAllValidationRecordsForContent(long contentId);
        IList<UserContentValidation> GetValidationsForContent(long contentId, bool activeOnly);
        bool DeactivateAllValidationsForContent(long contentId);
    }
}
