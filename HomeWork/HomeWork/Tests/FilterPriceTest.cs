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
            service.EntryIntoCategoryByName("Гаджеты", "Мобильные");
            service.PriceFilter();
            service.DescendingPriceFilter();
        }

        [TearDown]
        public void Test2()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}
