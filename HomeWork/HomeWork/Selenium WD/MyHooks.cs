using System;
using BoDi;
using HomeWork.Selenium_WD.Components;
using HomeWork.Selenium_WD.Components.Button;
using HomeWork.Selenium_WD.Components.Links;
using HomeWork.Selenium_WD.Extensions;
using HomeWork.Selenium_WD.Functional;
using HomeWork.Selenium_WD.Pages;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace HomeWork.Selenium_WD
{
    [Binding]
    public sealed class MyHooks
    {
        private readonly IObjectContainer container;
        
        public MyHooks(IObjectContainer container)
        {
            this.container = container;
        }
        
        [BeforeScenario]
        
        public void BeforeScenario()
        {
            IWebDriver driver = BrowserFactory.CreateDriver();
            container.RegisterInstanceAs(driver);
        }

        [AfterScenario(Order = 1)]
        
        public void AfterScenario()
        {
            IWebDriver driver = container.Resolve<IWebDriver>();
            driver.Close();
            driver.Dispose();
        }

        [AfterScenario("deleteUser", Order = 0)]
        
        public void DeleteUser()
        {
            IWebDriver driver = container.Resolve<IWebDriver>();
            var userPage = driver.GetPage<UserPage>();
            userPage.ActualNameUser.Click();
            driver.GetComponent<ButtonIcon>("Редактировать").Click();
            driver.GetComponent<ElementWithText>("УДАЛИТЬ АККАУНТ").Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.GetComponent<LinkedText>("УДАЛИТЬ").Click();
            driver.SwitchTo().Alert().Accept();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
        }
    }
}
