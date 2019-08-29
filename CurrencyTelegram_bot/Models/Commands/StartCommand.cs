using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
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
            await client.SendPhotoAsync(chatId, "http://www.morningkids.net/coloriages/1026/g/futurama-g-2.jpg");
            await client.SendTextMessageAsync(chatId, "Greatings stranger! I have couple commands. Wanna know what kind of? Use /commands for know what i can!", parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown);
        }
    }
}