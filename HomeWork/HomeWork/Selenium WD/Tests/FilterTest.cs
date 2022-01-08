using HomeWork.Selenium_WD.Functional;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Linq;

namespace HomeWork
{
    internal class FilterTest
    {
        private IWebDriver driver;
        private UserService service;
        private EntryCategory category;
        private FilterBrands filterBrands;

        [SetUp]
        public void Setup()
        {
            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            driver.Navigate().GoToUrl("https://ek.ua/");
            driver.Manage().Window.Maximize();
            service = new UserService(driver);
            category = new EntryCategory(driver);
            filterBrands = new FilterBrands(driver);
        }

        [Test]
        public void Test1()
        {
            // service.EntryIntoCategoryByName("Компьютеры", "Ноутбуки");
            category.EntryIntoCategoryByName("Компьютеры", "Ноутбуки");
            // service.SearchBrandsByFilter("Acer");
            filterBrands.SearchBrandsByFilter("Acer");
            // service.FilterProductsByBrand();
            var lastPage = driver.FindElements(By.XPath(".//div[@class='ib page-num']//a")).Last();
            var neededElementText = Int32.Parse(lastPage.Text);

            for (int i = 0; i < neededElementText; i++)
            {
                var allAcer = driver.FindElements(By.XPath("//a/span[contains(text(),'Acer')]"));

                foreach (var oneItemAcer in allAcer)
                {
                    var oneItem = oneItemAcer.Text;
                    Assert.IsTrue(oneItem.Contains("Acer"), "Not found");
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
