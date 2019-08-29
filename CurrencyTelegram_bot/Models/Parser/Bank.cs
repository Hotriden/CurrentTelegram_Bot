using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CurrencyTelegram_bot.Models.Parser
{
    public class Bank
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string XPathBuy { get; set; }
        public string XPathSell { get; set; }
        public string CurrentRates { get; set; }
        public string LastRates { get; set; }
    }
}