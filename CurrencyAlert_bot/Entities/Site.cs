using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyAlert_bot.Entities
{
    public class Site
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public Currency currency { get; set; }
    }
}
