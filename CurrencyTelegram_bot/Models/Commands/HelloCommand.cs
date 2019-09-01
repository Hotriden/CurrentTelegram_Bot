using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using System.Web.Hosting;
using System.IO;

namespace CurrencyTelegram_bot.Models.Commands
{
    public class HelloCommand:Command
    {
        public override string Name => "/hello";

        public override bool Contains(Message message)
        {
            if(message.Type != Telegram.Bot.Types.Enums.MessageType.Text)
            {
                return false;
            }
            return message.Text.Contains(Name);
        }

        public override async Task Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            await client.SendPhotoAsync(chatId, "https://res.cloudinary.com/teepublic/image/private/s--yIHIKchZ--/t_Resized%20Artwork/c_fit,g_north_west,h_1054,w_1054/co_ffffff,e_outline:53/co_ffffff,e_outline:inner_fill:53/co_bbbbbb,e_outline:3:1000/c_mpad,g_center,h_1260,w_1260/b_rgb:eeeeee/c_limit,f_jpg,h_630,q_90,w_630/v1536730407/production/designs/3142932_1.jpg", parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown);
            await client.SendTextMessageAsync(chatId, "Say hello to my little friend!", parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown);
        }
    }
}