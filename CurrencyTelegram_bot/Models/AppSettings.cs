namespace CurrencyTelegram_bot.Models
{
    /// <summary>
    /// Basic telegram bot settings
    /// </summary>
    public static class AppSettings
    {
        public static string Url { get; set; } = "https://currencytelegrambot.azurewebsites.net:443/{0}";

        public static string Name { get; set; } = "CurrencyAlert_Bot";

        public static string Key { get; set; } = "987528104:AAGz3x4AggzIoG6pj7aYkXNcf23q2J56sm8";
    }
}