using System;
using System.IO;
using System.Reflection;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace test7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // ChromeOptionsオブジェクトを生成します。
            var options = new ChromeOptions();
            // --headlessを追加します。
            //options.AddArgument("--headless");
            // ChromeOptions付きでChromeDriverオブジェクトを生成します。
            var chrome = new ChromeDriver(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), options);
            // URLに移動します。
            chrome.Url = @"https://qiita.com/Chanmoro";


            chrome.FindElementByXPath("//a[@rel=\"next\"]").Click();

            chrome.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            var article_links = chrome.FindElementsByXPath("//div[@class=\"AllArticleList__StyledItemBody-mhtjc8-5 fxUtDn\"]/a");
            Console.WriteLine(article_links[3].Text);

            // タイトルを表示します。
            Console.WriteLine(chrome.Title);
            // すぐ終了しないよう、キーが押されるまで待機します。
            Console.ReadKey();
            // ブラウザを閉じます。
            chrome.Quit();
        }
    }
}
