using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace CurrencyTelegram_bot.Models.Commands
{
    public class CommandsCommand : Command
    {
        public override string Name => "/commands";

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
            await client.SendTextMessageAsync(chatId, "Перечень всех команд:\r\n/commands - Все команды бота\r\n/start - Начало работы с ботом\r\n/check - проверка текущего курса\r\n/hello - say hello to my little friend", parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown);
        }
    }
}