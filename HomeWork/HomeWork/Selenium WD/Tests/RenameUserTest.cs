using HomeWork.Selenium_WD.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;

namespace HomeWork
{
    internal class RenameUserTest
    {
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
            mainPage = new MainPage();
            PageFactory.InitElements(driver, mainPage);
            userPage = new UserPage();
            PageFactory.InitElements(driver, userPage);
        }

        [Test]
        public void Test1()
        {
            RandomUser randomUser = new RandomUser();
            // service.CreateNewUserAccount();
            mainPage.CreateNewUserAccount();
            mainPage.ActualLogin.Click();
            var randomLogin = randomUser.CreateRandomLogin();
            userPage.EditProfileButton.Click();
            userPage.NikFieldInputButton.Clear();
            userPage.NikFieldInputButton.SendKeys(randomLogin);
            userPage.SaveChangeButton.Click();
            var nameActualUserAccount = userPage.TextActualNameUser.Text;

            Assert.AreEqual(randomLogin, nameActualUserAccount, "The changed login does not match the profile login");
            // service.RenameUser();

        }

        [TearDown]
        public void Test2()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}
