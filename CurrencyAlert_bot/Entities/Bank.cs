using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyAlert_bot.Entities
{
    public class Bank
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }

        public Currency currency { get; set; }

        public int SellRate { get; set; }
        public int BuyRate { get; set; }
    }
}
