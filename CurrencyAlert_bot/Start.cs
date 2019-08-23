using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using CurrencyAlert_bot.Entities;
using System.Net;
using System.IO;

namespace CurrencyAlert_bot
{
    public class Start
    {
        private static readonly TelegramBotClient Bot = new TelegramBotClient("987528104:AAGz3x4AggzIoG6pj7aYkXNcf23q2J56sm8");
        public static void Main(string[] args)
        {
            Parser parser = new Parser();
            parser.GetCurrentGoverla("gvrl-table-cell bid");
            parser.GetCurrentMinfin("active");
            CheckObmenka();
            Bot.OnMessage += Bot_OnMessage;
            Bot.StartReceiving();
            Bot.SendTextMessageAsync("@CurrencyAlert_Bot", "show");
            Console.ReadKey();
            Bot.StopReceiving();
        }

        static async void CheckObmenka()
        {
            Parser parser = new Parser();
            await parser.GetCurrentObmenka();
        }

        private static void Bot_OnMessage(object sender, MessageEventArgs e)
        {
            Bot.SendTextMessageAsync(e.Message.Chat.Id, "shut ur fuck up, scam");
        }
    }
}
