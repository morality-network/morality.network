using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateIt.Common.Models.Enums
{
    public enum NotificationTypeMap
    {
        None = 0,
        Reply = 1,
        Report = 2,
        Like = 3,
        Tip = 4,
        Mention = 5,
        Rate = 6,
        ValidatedContent = 7
    }
}
