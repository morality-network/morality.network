using RateIt.Common.Models.Enums;
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
    public class NotificationService : ServiceBase, INotificationService
    {
        private readonly IRepository<Notification> _notificationRepository;
        private readonly IRepository<NotificationType> _notificationTypeRepository;

        public NotificationService(IRepository<Notification> notificationRepository, 
            IRepository<NotificationType> notificationTypeRepository)
        {
            _notificationRepository = notificationRepository;
            _notificationTypeRepository = notificationTypeRepository;
        }

        public bool AddNotification(NotificationTypeMap notificationType,
            long contentId, long userId, long subDirectoryId, string notifierName)
        {
            var notificationTypeObj = GetNotificationTypeFromEnum(notificationType);
            if(notificationTypeObj != null)
            {
                var notification = new Notification()
                {
                    ContentId = contentId,
                    NotificationTypeId = notificationTypeObj.Id,
                    Timestamp = DateTime.Now,
                    SubDirectoryId = subDirectoryId
                };
                AddNotificationMessageText(notification, notificationType, notifierName);
                _notificationRepository.Add(notification);
                return Convert.ToBoolean(_notificationRepository.Save());
            }
            return false;
        }

        public void AddNotificationMessageText(Notification notification, NotificationTypeMap notificationType, 
            string notifierName)
        {
            var message = string.Empty;
            switch (notificationType)
            {
                case NotificationTypeMap.Like:
                    message = $"User {notifierName} upvoted your comment";
                    break;
                case NotificationTypeMap.Mention:
                    message = $"User {notifierName} mentioned you";
                    break;
                case NotificationTypeMap.Rate:
                    message = $"User {notifierName} rated your content";
                    break;
                case NotificationTypeMap.Reply:
                    message = $"User {notifierName} replied to your comment";
                    break;
                case NotificationTypeMap.Tip:
                    message = $"User {notifierName} tipped you";
                    break;
                case NotificationTypeMap.Report:
                    message = $"Somebody reported your content";
                    break;
                case NotificationTypeMap.ValidatedContent:
                    message = $"You got paid {notifierName} for validating content";
                    break;
            }
            notification.NotificationText = message;
        }

        public IList<Notification> GetNotifications(long userid, int perPage, int page)
        {
            return _notificationRepository.GetAll().Where(x => x.UserId == userid)
               .OrderByDescending(x => x.Timestamp)
               .Skip(page * perPage)
               .Take(perPage)
               .ToList();
        }

        public NotificationType GetNotificationTypeFromEnum(NotificationTypeMap notificationType)
        {
             return _notificationTypeRepository.GetAll()
                    .FirstOrDefault(x => x.TypeName == notificationType.ToString());
        }

        public bool NotifyAllUserValidators(string message, IList<long> userIds, long contentId, 
            long subDirectoryId)
        {
            if (userIds != null && userIds.Any())
            {
                var notificationTypeObj = GetNotificationTypeFromEnum(NotificationTypeMap.ValidatedContent);
                foreach (var userId in userIds)
                {
                    _notificationRepository.Add(new Notification()
                    {
                        ContentId = contentId,
                        NotificationText = message,
                        NotificationTypeId = notificationTypeObj.Id,
                        SubDirectoryId = subDirectoryId,
                        Timestamp = DateTime.Now,
                        UserId = userId
                    });
                }
                return Convert.ToBoolean(_notificationRepository.Save());
            }
            return false;
        }
    }
}
