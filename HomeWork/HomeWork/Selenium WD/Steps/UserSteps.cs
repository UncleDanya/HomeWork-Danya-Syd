using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeWork.Selenium_WD.Extensions;
using HomeWork.Selenium_WD.Pages;
using HomeWork.Selenium_WD.RuntimeVariables;
using NUnit.Framework;
using OpenQA.Selenium;

namespace HomeWork.Selenium_WD.Steps
{
    class UserSteps : BasePage
    {
        RandomLoginVariable login = new RandomLoginVariable();
        private NameProductVariable name = new NameProductVariable();

        public void WhenUserRename()
        {
            RandomUser randomUser = new RandomUser();
            var userPage = Driver.GetPage<UserPage>();
            login.Value = randomUser.CreateRandomLogin();
            userPage.EditProfileButton.Click();
            userPage.NickFieldInputButton.Clear();
            var enabledNickField = userPage.NickFieldInputButton.Enabled;
            userPage.NickFieldInputButton.SendKeys(login.Value);
            userPage.SaveChangeButton.Click();
        }

        public void ThenVerifyActualLoginAfterRename()
        {
            var userPage = Driver.GetPage<UserPage>();
            var nameActualUserAccount = userPage.TextActualNameUser.Text;
            Assert.AreEqual(login.Value, nameActualUserAccount, "The changed login does not match the profile login");
        }

        public void ThenVerifySaveListProductForListInUserPage()
        {
            var nameMobileItemInList = Driver.FindElement(By.XPath("//u[@class='nobr' and text()='Apple iPhone 13 Pr...']")).Text.Remove(16);
            var nameConsoleItemInList = Driver.FindElement(By.XPath("//u[@class='nobr' and text()='Sony PlayStation 5']")).Text;
            var nameAudioItemInList = Driver.FindElement(By.XPath("//u[@class='nobr' and text()='Logitech G Pro X']")).Text;

            Assert.IsTrue(name.Value.First().Contains(nameMobileItemInList));
            Assert.IsTrue(name.Value[1].Contains(nameConsoleItemInList));
            Assert.IsTrue(name.Value[2].Contains(nameAudioItemInList));
        }
    }
}
