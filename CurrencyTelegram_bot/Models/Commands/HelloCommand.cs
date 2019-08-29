﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace CurrencyTelegram_bot.Models.Commands
{
    public class HelloCommand:Command
    {
        public override string Name => "/hello";

        public override bool Contains(Message message)
        {
            if(message.Type != Telegram.Bot.Types.Enums.MessageType.Text)
            {
                return false;
            }
            return message.Text.Contains(Name);
        }

        public override async Task Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            await client.SendTextMessageAsync(chatId, "It's tested command", parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown);
        }
    }
}