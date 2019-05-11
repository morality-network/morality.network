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
    public class UserMessageService : IUserMessageService
    {
        private readonly IRepository<UserMessage> _userMessageRepository;

        public UserMessageService(IRepository<UserMessage> userMessageRepository)
        {
            _userMessageRepository = userMessageRepository;
        }

        public bool AddUserMessage(string message, long userId, string status)
        {
            _userMessageRepository.Add(new UserMessage()
            {
                Message = message,
                Read = false,
                Status = status,
                Timestamp = DateTime.Now,
                UserId = userId
            });
            return Convert.ToBoolean(_userMessageRepository.Save());
        }

        public IList<UserMessage> GetMessagesForUser(long userId, int from, int perPage)
        {
            return _userMessageRepository.GetAll()
                .Where(x => x.UserId == userId)
                .OrderByDescending(x => x.Timestamp)
                .Skip(from)
                .Take(perPage)
                .ToList();
        }
    }
}
