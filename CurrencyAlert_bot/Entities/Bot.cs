using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;

namespace CurrencyAlert_bot.Entities
{
    public class Bot
    {
        private readonly TelegramBotClient bot;
        public Bot(string key)
        {
            bot = new TelegramBotClient(key);
        }
    }
}
