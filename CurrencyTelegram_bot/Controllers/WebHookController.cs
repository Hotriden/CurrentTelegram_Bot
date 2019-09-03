using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace CurrencyTelegram_bot.Controllers
{
    public class WebHookController : ApiController
    {
        [HttpPost]
        public void HookProcess()
        {
            Stream s = HttpContext.Current.Request.InputStream;
            s.Position = 0;
            StreamReader reader = new StreamReader(s);
            string jsontext = reader.ReadToEnd();
        }
    }
}
