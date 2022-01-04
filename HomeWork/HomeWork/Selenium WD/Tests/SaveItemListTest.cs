﻿using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;

namespace HomeWork
{
    internal class SaveItemListTest
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
            service.CreateNewUserAccount();
            service.EntryIntoCategoryByName("Аудио", "Наушники");
            service.SearchBrandsByFilter("Logitech");
            service.ItemList();
        }

        [TearDown]
        public void Test2()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}