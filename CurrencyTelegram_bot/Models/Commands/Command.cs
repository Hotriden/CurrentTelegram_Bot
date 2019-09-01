using Telegram.Bot;
using Telegram.Bot.Types;
using System.Threading.Tasks;

namespace CurrencyTelegram_bot.Models.Commands
{
    /// <summary>
    /// Main functions of telegrambot command
    /// </summary>
    public abstract class Command
    {
        public abstract string Name { get; }

        public abstract Task Execute(Message message, TelegramBotClient client);

        public abstract bool Contains(Message message);
    }
}