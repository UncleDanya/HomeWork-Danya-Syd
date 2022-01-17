using HomeWork.Selenium_WD.Functional;
using HomeWork.Selenium_WD.Pages;
using HomeWork.Selenium_WD.RuntimeVariables;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace HomeWork
{
    public class RegistrationNewUserTest
    {
        private IWebDriver driver;
        private MainPage mainPage;
        private UserPage userPage;
        private RandomLoginVariable randomLoginVariable = new RandomLoginVariable();
        
        [SetUp]
        public void Setup()
        {
            driver = BrowserFactory.CreateDriver();
            driver.Navigate().GoToUrl("https://ek.ua/");
            driver.Manage().Window.Maximize();
            mainPage = new MainPage(randomLoginVariable);
            userPage = new UserPage(driver);
            PageFactory.InitElements(driver, mainPage);
            PageFactory.InitElements(driver, userPage);
        }

        [Test]
        public void TestRegistrationNewUserTest()
        {
            mainPage.CreateNewUserAccount();
            mainPage.VerifyLoginAccount();
        }

        [TearDown]
        public void AfterTest()
        {
            userPage.DeleteUserAccount();
            driver.Quit();
            driver.Dispose();
        }
    }
}