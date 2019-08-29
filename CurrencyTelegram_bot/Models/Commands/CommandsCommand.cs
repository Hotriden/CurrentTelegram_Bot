using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
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
            await client.SendTextMessageAsync(chatId, "List of commands:\r\n/Current - check current rate\r\n/Hello - say hello to my little friend", parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown);
        }
    }
}