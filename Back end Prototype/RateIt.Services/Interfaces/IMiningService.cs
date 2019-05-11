using RateIt.Common.Models;
using RateIt.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateIt.Services.Interfaces
{
    public interface IMiningService
    {
        IList<Investigation> GetTopInvestigations(int limit, long userId);
        bool AddReview(long userid, long commentId, Mining confirmData);
        bool TryToConcludeInvestigation(long investigationId);
    }
}
