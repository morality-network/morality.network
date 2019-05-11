using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateIt.Services.Interfaces
{
    public interface ILoggingService
    {
        bool Log(string message, string associatedEmail = null);
    }
}
