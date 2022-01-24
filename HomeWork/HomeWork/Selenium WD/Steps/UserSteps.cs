using HomeWork.Selenium_WD.Extensions;
using HomeWork.Selenium_WD.Pages;
using HomeWork.Selenium_WD.RuntimeVariables;
using NUnit.Framework;

namespace HomeWork.Selenium_WD.Steps
{
    class UserSteps : BasePage
    {
        RandomLoginVariable login = new RandomLoginVariable();

        public void WhenUserRename(string nameUser)
        {
            var userPage = Driver.GetPage<UserPage>();
            userPage.NickFieldInputButton.SendKeys(nameUser);
        }

        public void ThenVerifyActualLoginAfterRename(string nameUser)
        {
            var userPage = Driver.GetPage<UserPage>();
            var nameActualUserAccount = userPage.TextActualNameUser.Text;
            Assert.AreEqual(nameUser, nameActualUserAccount, "The changed login does not match the profile login");
        }
    }
}
