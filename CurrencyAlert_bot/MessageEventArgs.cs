using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyAlert_bot
{
    public class AlertEventArgs:EventArgs
    {
        public AlertEventArgs(string message)
        {
            Message = message;
        }

        public string Message { get; private set; }
    }
}
