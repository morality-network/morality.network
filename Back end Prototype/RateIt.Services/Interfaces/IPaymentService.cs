using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RateIt.Services.Interfaces
{
    public interface IPaymentService
    {
        bool MakeRandomMoCPayment(Utilities.TimeSpan timeSpan);
    }
}
