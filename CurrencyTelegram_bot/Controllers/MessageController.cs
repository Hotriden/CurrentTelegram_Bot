using System.Web.Http;
using System.Web.Http.Results;
using Telegram.Bot.Types;
using CurrencyTelegram_bot.Models;
using System.Threading.Tasks;

namespace CurrencyTelegram_bot.Controllers
{
    public class MessageController : ApiController
    {
        [HttpPost]
        public async Task<OkResult> Post([FromBody]Update update)
        {
            if (update == null) return Ok();

            var commands = Bot.Commands;
            var message = update.Message;
            var botClient = await Bot.Get();

            foreach (var command in commands)
            {
                if (command.Contains(message))
                {
                    await command.Execute(message, botClient);
                    break;
                }
            }
            return Ok();
        }
    }
}
