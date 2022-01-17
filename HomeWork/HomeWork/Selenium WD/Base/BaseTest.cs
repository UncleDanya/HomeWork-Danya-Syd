﻿using HomeWork.Selenium_WD.Functional;
using NUnit.Framework;
using OpenQA.Selenium;

namespace HomeWork.Selenium_WD.Base
{
    internal class BaseTest
    {
        public RemoteWebDriver driver { get; set; }
        
        [SetUp]
        public void Setup()
        {
            driver = BrowserFactory.CreateDriver();
            driver.Navigate().GoToUrl("https://ek.ua/");
            driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void AfterTest()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}
