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
            service.EntryIntoCategoryByName("Компьютеры", "Ноутбуки");
            service.SearchBrandsByFilter("Acer");
            service.FilterProductsByBrand();
        }

        [TearDown]
        public void Test2()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}
