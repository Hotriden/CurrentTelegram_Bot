using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using CurrencyTelegram_bot.Models.Parser;

namespace CurrencyTelegram_bot.Models.Commands
{
    public class CheckCommand : Command
    {
        public override string Name => "/check";

        public override bool Contains(Message message)
        {
            if (message.Type != Telegram.Bot.Types.Enums.MessageType.Text)
            {
                return false;
            }
            return message.Text.Contains(Name);
        }

        public override async Task Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            await client.SendTextMessageAsync(chatId, StartParse.StartParseResult, parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown);
        }
    }
}