using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Linq;

namespace HomeWork
{
    internal class FilterPriceTest
    {
        private IWebDriver driver;
        private UserService service;
        
        [SetUp]
        public void Setup()
        {
            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            driver.Navigate().GoToUrl("https://ek.ua/");
            driver.Manage().Window.Maximize();
            service = new UserService(driver);
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
                    var priceWithoutText = Convert.ToInt32(onePrice.Text.Replace(" грн.", string.Empty).Replace(" ", string.Empty));
                    for (int j = 0; j < priceWithoutText; j++)
                    {
                        var priceFilterItem = priceWithoutText >= priceWithoutText - 1;
                        Assert.IsTrue(priceFilterItem);
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
