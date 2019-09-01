using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CurrencyTelegram_bot.Controllers;
using Telegram.Bot.Types;
using System.Web;

namespace Test_CurrencyTelegram_bot
{
    [TestClass]
    public class MessageControllerTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            MessageController controller = new MessageController();
            Update update = new Update();

            //controller.Post(update);
        }
    }
}
