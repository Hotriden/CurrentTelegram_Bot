using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using HtmlAgilityPack;

namespace CurrencyTelegram_bot.Models.Parser
{
    /// <summary>
    /// A lot of hard code
    /// There is empty values for parsing value rates from
    /// different sites. Used Html.AgilityPack and Regex for
    /// get element by xpath
    /// </summary>
    class Parse
    {
        Regex regex = new Regex(@"[0-9]{2}\W[0-9]{2}");
        Regex regexGov = new Regex(@"[0-9]{4}");

        public string ParseByXpathObmenka(string name, string url)
        {
            var httpClient = new HttpClient(new HttpClientHandler { UseCookies = false });

            var message = new HttpRequestMessage(HttpMethod.Get, url);
            message.Headers.Add("User-Agent", "Mozilla/5.0");
            var contentAsString = GetHttpContentAsString(httpClient.SendAsync(message).GetAwaiter().GetResult());

            var siCookieValue = new Regex("var cookie_value = \"([^\"]*)\"").Matches(contentAsString)[0].Groups[1].Value;
            var werCookieValue = new Regex("var sid = \"([^\"]*)\"").Matches(contentAsString)[0].Groups[1].Value;

            message = new HttpRequestMessage(HttpMethod.Get, url);
            message.Headers.TryAddWithoutValidation("Cookie", $"_si={siCookieValue}; _wer={werCookieValue}");
            message.Headers.Add("User-Agent", "Mozilla/5.0");

            contentAsString = GetHttpContentAsString(httpClient.SendAsync(message).GetAwaiter().GetResult());

            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(contentAsString);
            string Result = string.Format(name + "\r\n");
            var buyElement1 = doc.DocumentNode.SelectNodes("/html/body/div[2]/section[1]/div/div[1]/div[1]/div[2]/div[2]/span[1]");
            var buyElement2 = doc.DocumentNode.SelectNodes("/html/body/div[2]/section[1]/div/div[1]/div[1]/div[2]/div[2]/span[2]");
            var saleElement1 = doc.DocumentNode.SelectNodes("/html/body/div[2]/section[1]/div/div[1]/div[1]/div[3]/div[2]/span[1]");
            var saleElement2 = doc.DocumentNode.SelectNodes("/html/body/div[2]/section[1]/div/div[1]/div[1]/div[3]/div[2]/span[2]");
            foreach (var b in buyElement1)
            {
                Result += string.Format("Покупка - {0}", b.InnerHtml);
            }
            foreach (var b in buyElement2)
            {
                Result += string.Format(b.InnerHtml + "\r\n");
            }
            foreach (var b in saleElement1)
            {
                Result += string.Format("Продажа - {0}", b.InnerHtml);
            }
            foreach (var b in saleElement2)
            {
                Result += string.Format(b.InnerHtml + "\r\n");
            }
            return Result;
        }

        public string ParseByXpathMinfin(string name, string url)
        {
            string PostUrl = url;
            WebResponse webResponse = WebRequest.Create(PostUrl).GetResponse();
            StreamReader source = new StreamReader(webResponse.GetResponseStream());

            string contentAsString = source.ReadToEnd().Trim();

            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(contentAsString);
            string Result = string.Format(name + "\r\n");
            var buyElement = doc.DocumentNode.SelectNodes("/html/body/main/div[2]/div/div[1]/div/div[2]/table/tbody/tr[1]/td[2]");
            var saleElement = doc.DocumentNode.SelectNodes("/html/body/main/div[2]/div/div[1]/div/div[2]/table/tbody/tr[2]/td[2]");
            foreach (var b in buyElement)
            {
                MatchCollection matches = regex.Matches(b.InnerHtml);
                foreach (var c in matches)
                {
                    Result += string.Format("Покупка - {0}", c + "\r\n");
                }
            }
            foreach (var b in saleElement)
            {
                MatchCollection matches = regex.Matches(b.InnerHtml);
                foreach (var c in matches)
                {
                    Result += string.Format("Продажа - {0}", c + "\r\n");
                }
            }
            return Result;
        }

        public string ParseByXpathGoverla(string name, string url)
        {
            string PostUrl = url;
            WebResponse webResponse = WebRequest.Create(PostUrl).GetResponse();
            StreamReader source = new StreamReader(webResponse.GetResponseStream());

            string contentAsString = source.ReadToEnd().Trim();

            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(contentAsString);
            string Result = string.Format(name + "\r\n");
            var buyElement = doc.DocumentNode.SelectNodes("/html/body/div/div/div[2]/div/div/div[2]/div/div/div/div/div[3]/div[1]/div[2]");
            var saleElement = doc.DocumentNode.SelectNodes("/html/body/div/div/div[2]/div/div/div[2]/div/div/div/div/div[3]/div[1]/div[3]");
            foreach (var b in buyElement)
            {
                MatchCollection matches = regexGov.Matches(b.InnerHtml);
                foreach (var c in matches)
                {
                    Result += string.Format("Покупка - {0}", c + "\r\n");
                }
            }
            foreach (var b in saleElement)
            {
                MatchCollection matches = regexGov.Matches(b.InnerHtml);
                foreach (var c in matches)
                {
                    Result += string.Format("Продажа - {0}", c + "\r\n");
                }
            }
            return Result;
        }

        public string ParseByXpathSigma(string name, string url)
        {
            string PostUrl = url;
            WebResponse webResponse = WebRequest.Create(PostUrl).GetResponse();
            StreamReader source = new StreamReader(webResponse.GetResponseStream());

            string contentAsString = source.ReadToEnd().Trim();

            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(contentAsString);
            string Result = string.Format(name + "\r\n");
            var buyElement = doc.DocumentNode.SelectNodes("/html/body/footer/div[1]/div[1]/div[2]/div[2]/span[2]/b/span/u");
            foreach (var b in buyElement)
            {
                MatchCollection matches = regex.Matches(b.InnerHtml);
                foreach (var c in matches)
                {
                    Result += string.Format("Курс - {0}", c + "\r\n");
                }
            }
            return Result;
        }

        string GetHttpContentAsString(HttpResponseMessage response)
        {
            var contentAsByteArray = response.Content.ReadAsByteArrayAsync().GetAwaiter().GetResult();
            return Encoding.UTF8.GetString(contentAsByteArray);
        }
    }
}
