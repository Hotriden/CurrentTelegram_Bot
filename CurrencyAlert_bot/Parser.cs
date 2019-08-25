using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using OpenQA.Selenium;
using System.Threading;
using OpenQA.Selenium.Interactions;

namespace CurrencyAlert_bot
{
    public delegate void ShowMessage(string message);
    public class Parser
    {
        IWebDriver browser1;
        IWebDriver browser2;
        IWebDriver browser3;

        public void StartParser(ShowMessage method)
        {
            browser1 = new OpenQA.Selenium.Chrome.ChromeDriver();
            browser1.Navigate().GoToUrl("https://minfin.com.ua/ua/currency/mb/");
            browser1.Manage().Window.Minimize();
            Thread.Sleep(2000);
            browser2 = new OpenQA.Selenium.Chrome.ChromeDriver();
            browser2.Navigate().GoToUrl("https://obmenka.kharkov.ua/usd-uah");
            browser2.Manage().Window.Minimize();
            Thread.Sleep(2000);
            browser3 = new OpenQA.Selenium.Chrome.ChromeDriver();
            browser3.Navigate().GoToUrl("https://goverla.ua/");
            browser3.Manage().Window.Minimize();
            string minfin = null;
            string obmenka = null;
            string goverla = null;

            try
            {
                for (int i = 0; i < 100000000; i++)
                {
                    Thread.Sleep(20000);
                    string one = GetCurrentMinfin();
                    if (minfin != one)
                    {
                        minfin = one;
                        method(minfin);
                    }
                    string two = GetCurrentObmenka();
                    if (obmenka != two)
                    {
                        obmenka = two;
                        method(minfin);
                    }
                    string three = GetCurrentGoverla();
                    if (goverla != three)
                    {
                        goverla = three;
                        method(minfin);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public string GetCurrentMinfin()
        {
            browser1.Navigate().Refresh();
            IWebElement SearchOne = browser1.FindElement(By.XPath("/html/body/main/div[2]/div/div[1]/div/div[2]/table/tbody/tr[1]/td[2]"));
            IWebElement SearchTwo = browser1.FindElement(By.XPath("/html/body/main/div[2]/div/div[1]/div/div[2]/table/tbody/tr[2]/td[2]"));
            string sell = SearchOne.Text.Substring(0,5);
            string buy = SearchTwo.Text.Substring(0,5);
            string result = "Межбанк: \r\nПокупка - " + sell + "\r\nПродажа - " + buy;
            Console.WriteLine("Межбанк");
            Console.WriteLine("Покупка " + sell + " " + "Продажа " + buy);
            Console.WriteLine();
            return result;
        }
        public string GetCurrentObmenka()
        {
            browser2.Navigate().Refresh();
            Thread.Sleep(1000);
            IWebElement SearchOne = browser2.FindElement(By.XPath("/html/body/div[2]/section[1]/div/div[1]/div[1]/div[2]/div[2]"));
            IWebElement SearchTwo = browser2.FindElement(By.XPath("/html/body/div[2]/section[1]/div/div[1]/div[1]/div[3]/div[2]"));
            string sell = SearchOne.Text;
            string buy = SearchTwo.Text;
            string result = "Обменка: \r\nПокупка - " + sell + "\r\nпродажа - " + buy;
            Console.WriteLine("Обменка");
            Console.WriteLine("Покупка " + sell + " " + "Продажа " + buy);
            Console.WriteLine();
            return result;
        }
        public string GetCurrentGoverla()
        {
            browser3.Navigate().Refresh();
            IWebElement SearchOne = browser3.FindElement(By.XPath("/html/body/div/div/div[2]/div/div/div[2]/div/div/div/div/div[3]/div[1]/div[2]"));
            IWebElement SearchTwo = browser3.FindElement(By.XPath("/html/body/div/div/div[2]/div/div/div[2]/div/div/div/div/div[3]/div[1]/div[3]"));
            string sell = SearchOne.Text;
            string buy = SearchTwo.Text;
            string result = "Обменка: \rПокупка - " + sell + "\r\nпродажа - " + buy;
            Console.WriteLine("Говерла");
            Console.WriteLine("Покупка " + sell + " " + "Продажа " + buy);
            Console.WriteLine();
            return result;
        }
    }
}
