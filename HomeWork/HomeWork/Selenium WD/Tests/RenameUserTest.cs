using HomeWork.Selenium_WD.Base;
using HomeWork.Selenium_WD.Extensions;
using HomeWork.Selenium_WD.Pages;
using HomeWork.Selenium_WD.Steps;
using NUnit.Framework;

namespace HomeWork
{
    internal class RenameUserTest : BaseTest
    {

        [Test]
        public void TestRenameUser()
        {
            var mainPage = driver.GetPage<MainPage>();
            var user = driver.GetPage<UserSteps>();
            
            mainPage.CreateNewUserAccount();
            mainPage.ActualLogin.Click();
            user.WhenUserRename();
            user.ThenVerifyActualLoginAfterRename();
        }

        [TearDown]
        public void AfterTest()
        {
            var userPage = driver.GetPage<UserPage>();
            userPage.DeleteUserAccount();
        }
    }
}
