using System;
using HomeWork.Selenium_WD.Extensions;
using HomeWork.Selenium_WD.Pages;
using HomeWork.Selenium_WD.RuntimeVariables;
using HomeWork.Selenium_WD.Utils;
using NUnit.Framework;

namespace HomeWork.Selenium_WD.Steps
{
    class UserSteps : BasePage
    {
        RandomLoginVariable login = new RandomLoginVariable();
        private RandomLoginVariable randomLoginVariable = new RandomLoginVariable();
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

        public void WhenUserCreateNewUserAccount()
        {
            var mainPage = Driver.GetPage<MainPage>();
            RandomUser randomUser = new RandomUser();

            randomLoginVariable.Value = randomUser.CreateRandomLogin();
            mainPage.LoginButton.Click();
            WaitUtils.WaitForElementToBeClickable(Driver, mainPage.RegistrationNewUserButton);

            mainPage.RegistrationNewUserButton.Click();
            mainPage.NameFieldInputButton.SendKeys(randomLoginVariable.Value);
            mainPage.EmailFieldInputButton.SendKeys(randomUser.CreateRandomEmail());
            mainPage.PasswordFieldInputButton.SendKeys(randomUser.CreateRandomPassword());
            mainPage.RegistationButton.Click();
            WaitUtils.WaitForElementToBeClickable(Driver, mainPage.AcceptRegistrationNewUserButton);
            mainPage.AcceptRegistrationNewUserButton.Click();
        }

        public void ThenVerifyLoginAccountEqualExpected()
        {
            var mainPage = Driver.GetPage<MainPage>();
            var userNameElement = WaitUtils.WaitForElementToBeDisplayed(Driver, mainPage.ActualLogin);
            var actualLoginForCompare = userNameElement.Text;
            Assert.AreEqual(actualLoginForCompare, randomLoginVariable.Value, "The actual login does not match the expected");
        }

        public void WhenUserDeleteUserAccount()
        {
            var userPage = Driver.GetPage<UserPage>();
            userPage.ActualNameUser.Click();
            userPage.EditProfileButton.Click();
            userPage.UserDeleteAccountButton.Click();
            WaitUtils.WaitForElementToBeClickable(Driver, userPage.SubmitDeleteUserAccountButton);
            userPage.SubmitDeleteUserAccountButton.Click();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Driver.SwitchTo().Alert().Accept();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
        }
    }
}
