using HomeWork.Selenium_WD.Functional;
using HomeWork.Selenium_WD.Pages;
using HomeWork.Selenium_WD.RuntimeVariables;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace HomeWork
{
    internal class RenameUserTest
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
            PageFactory.InitElements(driver, mainPage);
            userPage = new UserPage(driver);
            PageFactory.InitElements(driver, userPage);
        }

        [Test]
        public void TestRenameUser()
        {
            RandomUser randomUser = new RandomUser();
            
            mainPage.CreateNewUserAccount();
            mainPage.ActualLogin.Click();
            var randomLogin = randomUser.CreateRandomLogin();
            userPage.EditProfileButton.Click();
            userPage.NickFieldInputButton.Clear();
            var enabledNickField = userPage.NickFieldInputButton.Enabled;
            userPage.NickFieldInputButton.SendKeys(randomLogin);
            userPage.SaveChangeButton.Click();
            var nameActualUserAccount = userPage.TextActualNameUser.Text;

            Assert.AreEqual(randomLogin, nameActualUserAccount, "The changed login does not match the profile login");
            Assert.IsTrue(enabledNickField);
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
