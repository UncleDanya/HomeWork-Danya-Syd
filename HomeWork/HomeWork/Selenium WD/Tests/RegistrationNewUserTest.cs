using HomeWork.Selenium_WD.Base;
using HomeWork.Selenium_WD.Extensions;
using HomeWork.Selenium_WD.Pages;
using NUnit.Framework;

namespace HomeWork
{
    public class RegistrationNewUserTest : BaseTest
    {

        [Test]
        public void TestRegistrationNewUserTest()
        {
            var mainPage = driver.GetPage<MainPage>();

            mainPage.CreateNewUserAccount();
            mainPage.VerifyLoginAccount();
        }

        [TearDown]
        public void AfterTest()
        {
            var userPage = driver.GetPage<UserPage>();
            userPage.DeleteUserAccount();
        }
    }
}