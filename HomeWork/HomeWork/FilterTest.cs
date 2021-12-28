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
    internal class FilterTest
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
            service.EnterComputer();

            var lastPage = driver.FindElements(By.XPath(".//div[@class='ib page-num']//a")).Last();
            var neededElementText = Int32.Parse(lastPage.Text);

            for (int i = 0; i < neededElementText; i++)
            {
                var allacer = driver.FindElements(By.XPath("//a/span[text()[contains(.,'Acer')]]"));

                foreach (var oneItemAcer in allacer)
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
