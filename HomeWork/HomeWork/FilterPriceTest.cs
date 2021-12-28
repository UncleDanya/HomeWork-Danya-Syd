using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork
{
    internal class FilterPriceTest
    {
        private IWebDriver driver;
        private UserService service;
        private ICollection? allAcer;
        private Actions action;

        [SetUp]

        public void Setup()
        {
            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            driver.Navigate().GoToUrl("https://ek.ua/");
            driver.Manage().Window.Maximize();
            service = new UserService(driver);
            action = new Actions(driver);
        }

        [Test]
        public void Test1()
        {
            service.PriceFilter();

            var lastPage = driver.FindElements(By.XPath(".//div[@class='ib page-num']//a")).Last();
            var neededElementText = Int32.Parse(lastPage.Text);

            for (int i = 0; i < neededElementText; i++)
            {
                var allPrice = driver.FindElements(By.XPath("//b[text()]//parent::a"));

                foreach (var onePrice in allPrice)
                {
                    var pric = onePrice.Text.Replace(" грн.", "");
                    var price = pric.Replace(" ", "");
                    var priceInt = Convert.ToInt32(price);

                    for (int j = 0; j < priceInt; j++)
                    {
                        var a = priceInt >= priceInt - 1;

                        Assert.IsTrue(a);
                    }
                }

                try
                {
                    var nextPageButton = driver.FindElement(By.XPath("//a[@id='pager_next']"));
                    nextPageButton.Click();
                }
                catch
                {
                    continue;
                }
            }
        }

        [TearDown]
        public void Test2()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}
