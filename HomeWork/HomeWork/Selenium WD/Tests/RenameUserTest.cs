using HomeWork.Selenium_WD.Base;
using HomeWork.Selenium_WD.Extensions;
using HomeWork.Selenium_WD.Pages;
using HomeWork.Selenium_WD.RuntimeVariables;
using HomeWork.Selenium_WD.Steps;
using NUnit.Framework;

namespace HomeWork
{
    internal class RenameUserTest : BaseTest
    {
        RandomLoginVariable login = new RandomLoginVariable();

        [Test]
        public void TestRenameUser()
        {
            RandomUser randomUser = new RandomUser();
            login.Value = randomUser.CreateRandomLogin();
            var mainPage = driver.GetPage<MainPage>();
            var user = driver.GetPage<UserSteps>();
            
            mainPage.CreateNewUserAccount();
            user.WhenUserClickActualLogin();
            user.WhenUserClickEditProfileButton();
            user.WhenUserClearFieldNickInputButton();
            user.WhenUserSetTextToUserNameField(login.Value);
            user.WhenUserClickOnSaveChangeUserFieldButton();
            user.ThenVerifyActualLoginAfterRename(login.Value);
        }

        [TearDown]
        public void AfterTest()
        {
            var userPage = driver.GetPage<UserPage>();
            userPage.DeleteUserAccount();
        }
    }
}
