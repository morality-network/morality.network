using RateIt.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RateIt.Services.Interfaces;
using RateIt.Repositories.Interfaces;

namespace RateIt.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IUserRatingService _userRatingService;
        private readonly IUserReportService _userReportService;

        public UserService(IRepository<User> userRepository, IUserRatingService userRatingService,
            IUserReportService userReportService)
        {
            _userRepository = userRepository;
            _userRatingService = userRatingService;
            _userReportService = userReportService;
        }

        public User GetUserByEmail(string email)
        {
            if (string.IsNullOrEmpty(email)) return null;
            return _userRepository.GetAll()
                .FirstOrDefault(x => x.Email == email.Trim().ToLower());
        }

        public int GetAllUsersCount(RateIt.Utilities.TimeSpan lastActiveSince)
        {
            return _userRepository.GetAll().Where(x => x.LastActiveAt >= lastActiveSince.StartDate
                       && x.LastActiveAt <= lastActiveSince.EndDate).Count();
        }

        public IList<User> GetRandomUsers(int sampleSize, DateTime startDate)
        {
            return _userRepository.GetAll()
                .Where(x => x.Active && x.LastActiveAt > startDate)
                .OrderBy(x => Guid.NewGuid())
                .Take(sampleSize)
                .ToList();
        }

        public User GetUserById(long userId)
        {
            return _userRepository.GetAll()
                .FirstOrDefault(x => x.Id == userId);
        }

        public bool CalculateAndUpdateUserRatingStatistics(long userId)
        {
            var user = GetUserById(userId);
            if (user != null)
            {
                user.OverallRatingCount = _userRatingService.GetAllUsersRatingsCount(userId);
                user.OverallRating = _userRatingService.GetUsersOverallRating(userId);
                _userRepository.Update(user);
                return Convert.ToBoolean(_userRepository.Save());
            }
            return false;
        }

        public bool CalculateAndUpdateUserReportStatistics(long userId)
        {
            var user = GetUserById(userId);
            if (user != null)
            {
                user.OverallReportCount = _userReportService.GetAllUsersReportsCount(userId);
                _userRepository.Update(user);
                return Convert.ToBoolean(_userRepository.Save());
            }
            return false;
        }

        public bool UpdateUserInfo(long userId, string bio, string fullname, string profilePicUrl)
        {
            var existingUser = GetUserById(userId);
            if (existingUser != null)
            {
                existingUser.Bio = bio;
                existingUser.Fullname = fullname;
                existingUser.ProfilePictureUrl = profilePicUrl;
                _userRepository.Update(existingUser);
                return Convert.ToBoolean(_userRepository.Save());
            }
            return false;
        }

        public bool UpdateAppKey(string aspUserId, string newKey)
        {
            var existingUser = GetUserByAspUserId(aspUserId);
            if (existingUser != null)
            {
                existingUser.CurrentApp = newKey;
                return Convert.ToBoolean(_userRepository.Save());
            }
            return false;
        }

        public User GetUserByAspUserId(string aspUserId)
        {
            return _userRepository.GetAll()
                .FirstOrDefault(x => x.IdentityId == aspUserId);
        }

        public bool HasAlreadyRegistered(string email)
        {
            var user = GetUserByEmail(email);
            if (user != null) return true;
            return false;
        }

        public bool AddUser(string email, string name, string aspUserId, string currentApp)
        {
            _userRepository.Add(new User()
            {
                Active = true,
                CreatedAt = DateTime.Now,
                CurrentApp = currentApp,
                Email = email,
                IdentityId = aspUserId,
                Fullname = name,
                OverallCommentCount = 0,
                OverallRating = 0,
                OverallRatingCount = 0,
                OverallReportCount = 0,
                LastActiveAt = DateTime.Now,
                ProfilePictureUrl = string.Empty
            });
            return Convert.ToBoolean(_userRepository.Save());
        }

        public bool DeactivateUser(long userId)
        {
            var user = GetUserById(userId);
            if(user != null)
            {
                user.Active = false;
                _userRepository.Update(user);
                return Convert.ToBoolean(_userRepository.Save());
            }
            return false;
        }
    }
}
