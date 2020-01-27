
using RateIt.Services;
using RateIt.Services.Interfaces;
using RateIt.Utilities;
using RateItHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RateItHome.Controllers
{
    [Authorize]
    public class DashboardController : BaseController
    {
        private readonly ICurrencyService _currencyService;
        private readonly ICreditTransactionService _transactionService;
        private readonly IActivityService _activityService;
        private readonly INotificationService _notificationService;

        public DashboardController(ICurrencyService currencyService, IUserService userService, IActivityService activityService,
            ICreditTransactionService transactionService, INotificationService notificationService) :base(userService)
        {
            _currencyService = currencyService;
            _activityService = activityService;
            _notificationService = notificationService;
            _transactionService = transactionService;
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Dashboard";
            var user = GetUser();
            DashboardViewModel model = new DashboardViewModel();
            model.Notifications = GetNotifications(user.Id);
            model.Transactions = GetTransactions(user.Id);
            model.Activities = GetActivities(user.Id);
            model.AvgScore = user.OverallRating;
            model.EarnedDataset = new List<double>();
            model.ChatHistory = GetDummyChatHistory();
            ViewBag.TimePeriods = TimeSpanUtilities.GetBasicTimeSpans();
            return View("Index", model);
        }

        //Createw the Transaction view model
        private IList<RateItHome.Models.Transaction> GetTransactions(long userid)
        {
            var transactions = new List<Transaction>();
            var rawTransactions = _transactionService.GetTopTransactionsForUser(userid, 5, 0);
            foreach (var transaction in rawTransactions)
            {
                transactions.Add(new RateItHome.Models.Transaction()
                {
                    ActionType = (transaction.FromUserId == userid) ? Transaction.Action.Outgoing : Transaction.Action.Incoming,
                    Amount = transaction.Amount,
                    Timestamp = transaction.Timestamp
                });
            }
            return transactions;
        }

        private IList<string> GetDummyChatHistory()
        {
            IList<string> chatHistory = new List<string>();
            chatHistory.Add("www.bbc.co.uk");
            chatHistory.Add("www.channel4.co.uk");
            chatHistory.Add("www.reddit.com");
            return chatHistory;
        }

        private IList<Notification> GetActivities(long userid)
        {
            var model = new List<RateItHome.Models.Notification>();
            var activitys = _activityService.GetActivity(userid, 5, 0);
            foreach (var activity in activitys)
            {
                model.Add(new RateItHome.Models.Notification()
                {
                    Action = activity.ActivityText,
                    DateTimeAdded = activity.Timestamp
                });
            }
            return model;
        }

        private IList<RateItHome.Models.Notification> GetNotifications(long userId)
        {
            var model = new List<RateItHome.Models.Notification>();
            var notifications = _notificationService.GetNotifications(userId, 5, 0);
            foreach (var notification in notifications)
            {
                model.Add(new RateItHome.Models.Notification()
                {
                    Action = notification.NotificationText,
                    DateTimeAdded = notification.Timestamp
                });
            }
            return model;
        }
    }
}