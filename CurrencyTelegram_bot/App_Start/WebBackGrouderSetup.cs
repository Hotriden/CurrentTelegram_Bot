using System;
using CurrencyTelegram_bot.WebBackGroud;

namespace CurrencyTelegram_bot.App_Start
{
    public class WebBackGrouderSetup
    {
        public static class ParseMonitorConfig
        {
            private static BackGroundWorker bgWorker;

            public static void Start()
            {
                bgWorker = new BackGroundWorker(TimeSpan.FromSeconds(300));
            }

            public static void Shutdown()
            {
                bgWorker.Dispose();
            }
        }
    }
}