using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using CurrencyTelegram_bot.Models;
using CurrencyTelegram_bot.App_Start;

namespace CurrencyTelegram_bot
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            Bot.Get().Wait();
            WebBackGrouderSetup.ParseMonitorConfig.Start();
        }
    }
}
