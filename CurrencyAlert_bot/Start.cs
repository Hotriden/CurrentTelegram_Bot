using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using CurrencyAlert_bot.Entities;
using AngleSharp;
using AngleSharp.Html.Parser;
using System.Net;
using System.IO;

namespace CurrencyAlert_bot
{
    public class Start
    {
        private static readonly TelegramBotClient Bot = new TelegramBotClient("987528104:AAGz3x4AggzIoG6pj7aYkXNcf23q2J56sm8");
        public static async Task Main(string[] args)
        {
            WebClient client = new WebClient();
            client.Headers.Add("user-agent", "Mozilla/5.0 (Windows; Windows NT 5.1; rv:1.9.2.4) Gecko/20100611 Firefox/3.6.4");
            string fullPage = client.DownloadString("https://minfin.com.ua/ua/currency/mb/");
            string[] some = fullPage.Split(new string[] { "<td data-title='Доллар' class='active'>" }, StringSplitOptions.None);
            foreach(var b in some)
            {
                Console.WriteLine(b);
            }


            Bot.OnMessage += Bot_OnMessage;
            Bot.StartReceiving();
            Bot.SendTextMessageAsync("@CurrencyAlert_Bot", "show");
            Console.ReadKey();
            Bot.StopReceiving();
        }

        private static void Bot_OnMessage(object sender, MessageEventArgs e)
        {
            Bot.SendTextMessageAsync(e.Message.Chat.Id, "shut ur fuck up, scam");
        }
    }
}
