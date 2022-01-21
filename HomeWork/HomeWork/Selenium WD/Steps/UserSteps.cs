using HomeWork.Selenium_WD.Extensions;
using HomeWork.Selenium_WD.Pages;
using HomeWork.Selenium_WD.RuntimeVariables;
using NUnit.Framework;

namespace HomeWork.Selenium_WD.Steps
{
    class UserSteps : BasePage
    {
        RandomLoginVariable login = new RandomLoginVariable();

        public void WhenUserRename()
        {
            RandomUser randomUser = new RandomUser();
            var userPage = Driver.GetPage<UserPage>();
            login.Value = randomUser.CreateRandomLogin();
            userPage.EditProfileButton.Click();
            userPage.NickFieldInputButton.Clear();
            userPage.NickFieldInputButton.SendKeys(login.Value);
            userPage.SaveChangeButton.Click();
        }

        public void ThenVerifyActualLoginAfterRename()
        {
            var userPage = Driver.GetPage<UserPage>();
            var nameActualUserAccount = userPage.TextActualNameUser.Text;
            Assert.AreEqual(login.Value, nameActualUserAccount, "The changed login does not match the profile login");
        }
    }
}
