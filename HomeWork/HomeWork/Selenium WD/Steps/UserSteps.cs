using HomeWork.Selenium_WD.Extensions;
using HomeWork.Selenium_WD.Pages;
using HomeWork.Selenium_WD.RuntimeVariables;
using NUnit.Framework;

namespace HomeWork.Selenium_WD.Steps
{
    class UserSteps : BasePage
    {
        RandomLoginVariable login = new RandomLoginVariable();

        public void WhenUserSetTextToUserNameField(string nameUser)
        {
            var userPage = Driver.GetPage<UserPage>();
            userPage.NickFieldInputButton.SendKeys(nameUser);
        }

        public void ThenVerifyActualLoginAfterRename(string nameUser)
        {
            var userPage = Driver.GetPage<UserPage>();
            var actualNameUser = userPage.TextActualNameUser.Text;
            Assert.AreEqual(nameUser, actualNameUser, "The changed login does not match the profile login");
        }

        public void WhenUserClickActualLogin()
        {
            var mainPage = Driver.GetPage<MainPage>();
            mainPage.ActualLogin.Click();
        }

        public void WhenUserClickEditProfileButton()
        {
            var userPage = Driver.GetPage<UserPage>();
            userPage.EditProfileButton.Click();
        }

        public void WhenUserClearFieldNickInputButton()
        {
            var userPage = Driver.GetPage<UserPage>();
            userPage.NickFieldInputButton.Clear();
        }

        public void WhenUserClickOnSaveChangeUserFieldButton()
        {
            var userPage = Driver.GetPage<UserPage>();
            userPage.SaveChangeButton.Click();
        }

        public void WhenUserClickOnButtonShowSaveProductList()
        {
            var userPage = Driver.GetPage<UserPage>();
            userPage.ShowSaveProductList.Click();
        }
    }
}
