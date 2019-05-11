using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateIt.Common.Models.Enums
{
    public enum ActivityTypeMap
    {
        Commented = 0,
        Replied = 1,
        Reported = 2,
        Liked = 3,
        Tipped = 4,
        Mentioned = 5,
        Rated = 6,
        AnsweredPoll = 7,
        AnsweredSurvey = 8,
        GaveToCrowdfund = 9,
        ValidatedContent = 10
    }
}
