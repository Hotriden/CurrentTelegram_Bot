using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace CurrencyTelegram_bot.Models.Parser
{
    public class StartParse
    {
        public static string StartParseResult;
        public static void StartParser()
        {
            Parse parse = new Parse();

            int hours = DateTime.Now.Hour;
            while (hours != 0)
            {
                if (hours >= 9 ) // && hours <= 23
                {
                    parse.ParseByXpathObmenka("Обменка", "https://obmenka.kharkov.ua/usd-uah");
                    parse.ParseByXpathMinfin("Минфин", "https://minfin.com.ua/currency/mb/");
                    parse.ParseByXpathGoverla("Говерла", "https://goverla.ua/");
                    string lastResult = parse.ObmenkaRates + parse.MinfinRates + parse.GoverlaRates;
                    if (StartParseResult != lastResult)
                    {
                        StartParseResult = lastResult;
                        Console.WriteLine("Изменился курс: " + DateTime.Now + "\r\n" + lastResult);
                    }
                    Thread.Sleep(60000);
                }
            }
        }
    }
}  