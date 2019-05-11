using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateIt.Utilities
{
    public class TelegramClient
    {
        public static bool SendMessageAsync(string message, string telegramApiId, string telegramApiHash, string telegramChannelTitle)
        {
            string urlString = "https://api.telegram.org/bot{0}/sendMessage?chat_id={1}&text={2}";
            urlString = String.Format(urlString, $"{telegramApiId}:{telegramApiHash}",
                telegramChannelTitle, message);
            var response = WebUtility.MakeWebCall(urlString);
            return response;
        }
    }
}
