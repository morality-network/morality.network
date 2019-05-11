using RateIt.Common.Models.Enums;
using RateIt.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateIt.Services.Interfaces
{
    public interface INotificationService
    {
        bool AddNotification(NotificationTypeMap notificationType, long contentId, long userId, long subDirectoryId, string notifierName);
        void AddNotificationMessageText(Notification notification, NotificationTypeMap notificationType, string notifierName);
        NotificationType GetNotificationTypeFromEnum(NotificationTypeMap notificationType);
        IList<Notification> GetNotifications(long userid, int perPage, int page);
        bool NotifyAllUserValidators(string message, IList<long> userIds, long contentId, long subDirectoryId);
    }
}
