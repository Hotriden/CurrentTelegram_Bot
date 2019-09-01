using System.Threading.Tasks;
using System.Web.Hosting;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace CurrencyTelegram_bot.Models.Commands
{
    public class StartCommand : Command
    {
        public override string Name => "/start";

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
            await client.SendPhotoAsync(chatId, "https://avatars2.githubusercontent.com/u/18319212?s=400&v=4", parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown);
            await client.SendTextMessageAsync(chatId, "Приветствую! Для вызова списка команда используй /commands", parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown);
        }
    }
}