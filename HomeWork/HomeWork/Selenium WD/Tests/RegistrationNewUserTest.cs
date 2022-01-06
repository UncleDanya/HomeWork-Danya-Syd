using HomeWork.Selenium_WD.Pages;
using NUnit.Framework;
using OpenQA.Selenium;

namespace HomeWork
{
    public class RegistrationNewUserTest
    {
        private readonly object PageFactory;
        private IWebDriver driver;
        private UserService service;
        private MainPage mainPage;
        private UserPage userPage;
        
        [SetUp]
        public void Setup()
        {
            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            driver.Navigate().GoToUrl("https://ek.ua/");
            driver.Manage().Window.Maximize();
            service = new UserService(driver);
            // MainPage mainPage = new MainPage();
            mainPage = new MainPage(driver);
            userPage = new UserPage();
        }

        [Test]
        public void Test1()
        {
            mainPage.LoginButton.Click();
            // mainPage.CreateNewUserAccount();
            // mainPage.LoginButton.Click();
            // userPage.actualNameUser.Click();
            // _ = userPage.textActualNameUser.Text;
            // service.CreateNewUserAccount();
        }

        [TearDown]
        public void Test2()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}