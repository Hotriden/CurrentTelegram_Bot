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
using System.Threading;

namespace CurrencyAlert_bot
{
    public class Start
    {
        static string message;
        private static readonly TelegramBotClient Bot = new TelegramBotClient("987528104:AAGz3x4AggzIoG6pj7aYkXNcf23q2J56sm8");
        public static void Main(string[] args)
        {
            Parser parser = new Parser();
            Bot.OnMessage += Bot_OnMessage;
            ShowMessage method = Show;
            Bot.StartReceiving();
            parser.StartParser(method);
            Console.ReadKey();
            Bot.StopReceiving();
        }

        static void Show(string Message)
        {
            message = Message;
        }

        private static void Bot_OnMessage(object sender, MessageEventArgs e)
        {
            if (e.Message.Text == "/help")
            {
                Bot.SendTextMessageAsync(e.Message.Chat.Id, "Вот перечень команд:\r\nCheck - проверка текущего курса");
            }
            else if(e.Message.Text == "Check")
            {
                Bot.SendTextMessageAsync(e.Message.Chat.Id, "");
            }
            else
            {
                if (message != null)
                {
                    Bot.SendTextMessageAsync(e.Message.Chat.Id, message);
                }
            }
        }
    }
}
