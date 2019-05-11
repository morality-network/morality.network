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
    public class UserContentValidationService : IUserContentValidationService
    {
        private readonly IRepository<UserContentValidation> _userValidationsRepository;

        public UserContentValidationService(IRepository<UserContentValidation> userValidationsRepository)
        {
            _userValidationsRepository = userValidationsRepository;
        }

        public bool HasUserValidatedAlready(long userId, long contentId)
        {
            return _userValidationsRepository.GetAll()
                .Where(x => x.UserId == userId && x.ContentId == contentId)
                .Any();
        }

        public bool AddValidationRecord(long userId, long contentId, bool shouldBePersisted)
        {
            _userValidationsRepository.Add(new UserContentValidation()
            {
                ContentId = contentId,
                UserId = userId,
                ShouldBePersisted = shouldBePersisted,
                Timestamp = DateTime.Now
            });
            return Convert.ToBoolean(_userValidationsRepository.Save());
        }

        public bool DeleteAllValidationRecordsForContent(long contentId)
        {
            var validations = _userValidationsRepository.GetAll()
                .Where(x => x.ContentId == contentId)
                .ToList();
            _userValidationsRepository.RemoveList(validations);
            return Convert.ToBoolean(_userValidationsRepository.Save());
        }

        public bool DeactivateAllValidationsForContent(long contentId)
        {
            var validations = GetValidationsForContent(contentId, true);
            foreach (var validation in validations)
            {
                validation.Active = false;
                _userValidationsRepository.Update(validation);
            }
            return Convert.ToBoolean(_userValidationsRepository.Save());
        }

        public IList<UserContentValidation> GetValidationsForContent(long contentId, bool activeOnly)
        {
            var validations = _userValidationsRepository.GetAll()
                .Where(x => x.ContentId == contentId);
            if (activeOnly)
                validations = validations.Where(x => x.Active);
            return validations.ToList();
        }
    }
}
