using System;
using System.Threading;
using CurrencyTelegram_bot.Models.Commands;

namespace CurrencyTelegram_bot.Models.Parser
{
    /// <summary>
    /// Simple logic of schedule parse and 
    /// generate string for response on check bot
    /// command
    /// </summary>
    public class StartParse
    {
        public static string StartParseResult;
        public static void StartParser()
        {
            Parse parse = new Parse();

            string lastResult = parse.ParseByXpathObmenka("Обменка", "https://obmenka.kharkov.ua/usd-uah") + "\r\n" +
                parse.ParseByXpathMinfin("Минфин", "https://minfin.com.ua/currency/mb/") + "\r\n" +
                parse.ParseByXpathGoverla("Говерла", "https://goverla.ua/") + "\r\n" +
                parse.ParseByXpathSigma("Sigma", "https://sigma.ua/");
            if (StartParseResult != lastResult)
            {
                StartParseResult = lastResult;
            }
        }
    }
}  