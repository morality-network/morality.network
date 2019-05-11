using RateIt.Model;
using RateIt.Repositories.Interfaces;
using RateIt.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RateIt.Utilities;

namespace RateIt.Services
{
    public class LoggingService : ILoggingService
    {
        private readonly IRepository<Log> _loggingRepository;

        public LoggingService(IRepository<Log> loggingRepository)
        {
            _loggingRepository = loggingRepository;
        }

        public bool Log(string message, string associatedEmail = null)
        {
            _loggingRepository.Add(new Log() {
                LogText = message.GetMaxString(2000),
                AssociatedEmail = associatedEmail,
                Timestamp = DateTime.Now
            });
            return Convert.ToBoolean(_loggingRepository.Save());
        }
    }
}
