using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace CurrencyAlert_bot
{
    public class Parser
    {
        /// <summary>
        /// Minfin
        /// </summary>
        /// <param name="ClassToGet"></param>
        #region Minfin
        HtmlWeb parse = new HtmlWeb();
        private HttpClient httpClient;

        public void GetCurrentMinfin(string ClassToGet)
        {
            HtmlDocument document = parse.Load("https://minfin.com.ua/currency/mb/");
            foreach (HtmlNode node in document.DocumentNode.SelectNodes("//td[@class='" + ClassToGet + "']"))
            {
                string value = node.InnerText;
                Console.WriteLine("String - " + value);
            }
        }
        #endregion

        #region Obmenka
        public async Task GetCurrentObmenka()
        {
            string responseBodyAsText;
            string status = "Waiting for response ...";

            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("user-agent", "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; WOW64; Trident/6.0)");

            HttpResponseMessage response = await httpClient.GetAsync("https://obmenka.kharkov.ua/usd-uah");
            response.EnsureSuccessStatusCode();

            status = response.StatusCode + " " + response.ReasonPhrase + Environment.NewLine;
            responseBodyAsText = await response.Content.ReadAsStringAsync();

            //HttpWebRequest proxy_request = (HttpWebRequest)WebRequest.Create("https://obmenka.kharkov.ua/usd-uah");

            #endregion
        }

        #region Goverla
        public void GetCurrentGoverla(string ClassToGet)
        {
            HtmlDocument document = parse.Load("https://goverla.ua/");
            foreach (HtmlNode node in document.DocumentNode.SelectNodes("//div[@class='" + ClassToGet + "']"))
            {
                string value = node.InnerText;
                Console.WriteLine("String - " + value);
            }
        }
        #endregion
    }
}
