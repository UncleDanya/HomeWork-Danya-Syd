using HomeWork.Selenium_WD.Functional;
using HomeWork.Selenium_WD.Pages;
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
        
        [SetUp]
        public void Setup()
        {
            driver = BrowserFactory.CreateDriver();
            // driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            driver.Navigate().GoToUrl("https://ek.ua/");
            driver.Manage().Window.Maximize();
            mainPage = new MainPage();
            userPage = new UserPage();
            PageFactory.InitElements(driver, mainPage);
            PageFactory.InitElements(driver, userPage);
        }

        [Test]
        public void Test1()
        {
            mainPage.CreateNewUserAccount();
        }

        [TearDown]
        public void Test2()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}