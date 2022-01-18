using HomeWork.Selenium_WD.Base;
using HomeWork.Selenium_WD.Extensions;
using HomeWork.Selenium_WD.Pages;
using NUnit.Framework;

namespace HomeWork
{
    internal class RenameUserTest : BaseTest
    {

        [Test]
        public void TestRenameUser()
        {
            var mainPage = driver.GetPage<MainPage>();
            var userPage = driver.GetPage<UserPage>();

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
            var userPage = driver.GetPage<UserPage>();
            userPage.DeleteUserAccount();
        }
    }
}
