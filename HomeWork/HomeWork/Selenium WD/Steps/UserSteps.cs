using System;
using HomeWork.Selenium_WD.Components;
using HomeWork.Selenium_WD.Components.Button;
using HomeWork.Selenium_WD.Components.Links;
using HomeWork.Selenium_WD.Components.Tables;
using HomeWork.Selenium_WD.Components.TabsInUser;
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
            /*var userPage = Driver.GetPage<UserPage>();
            userPage.NickFieldInputButton.SendKeys(nameUser);*/
            Driver.GetComponent<InputInUserProfile>("Ваш ник").SendKeys(nameUser);
        }

        public void ThenVerifyActualLoginAfterRename(string nameUser)
        {
            // var userPage = Driver.GetPage<UserPage>();
            Driver.Navigate().Refresh();
            var actualNameUser = /*userPage.TextActualNameUser.Text;*/Driver.GetComponent<LogIn>().Text;
            Assert.AreEqual(nameUser, actualNameUser, "The changed login does not match the profile login");
        }

        public void WhenUserClickActualLogin()
        {
            /*var mainPage = Driver.GetPage<MainPage>();
            mainPage.ActualLogin.Click();*/
            Driver.GetComponent<LogIn>().Click();
        }

        public void WhenUserClickEditProfileButton()
        {
            /*var userPage = Driver.GetPage<UserPage>();
            userPage.EditProfileButton.Click();*/
            Driver.GetComponent<EditTabs>().Click();
        }

        public void WhenUserClearFieldNickInputButton()
        {
            /*var userPage = Driver.GetPage<UserPage>();
            userPage.NickFieldInputButton.Clear();*/
            Driver.GetComponent<InputInUserProfile>("Ваш ник").Clear();
        }

        public void WhenUserClickOnSaveChangeUserFieldButton()
        {
            /*var userPage = Driver.GetPage<UserPage>();
            userPage.SaveChangeButton.Click();*/
            Driver.GetComponent<Button>("СОХРАНИТЬ").Click();
        }

        public void WhenUserClickOnButtonShowSaveProductList()
        {
            /*var userPage = Driver.GetPage<UserPage>();
            userPage.ShowSaveProductList.Click();*/
            Driver.GetComponent<Tabs>("Наушники Logitech").Click();
        }

        public void WhenUserCreateNewUserAccount()
        {
            // var mainPage = Driver.GetPage<MainPage>();
            RandomUser randomUser = new RandomUser();

            randomLoginVariable.Value = randomUser.CreateRandomLogin();
            // mainPage.LoginButton.Click();
            Driver.GetComponent<LogIn>().Click();
            var buttonRegistration = Driver.GetComponent<TableRegistrationWith>("Или зарегистрируйтесь");
            WaitUtils.WaitForElementToBeClickable(Driver, /*mainPage.RegistrationNewUserButton*/buttonRegistration);

            // mainPage.RegistrationNewUserButton.Click();
            buttonRegistration.Click();
            var tableRegistration = Driver.GetComponent<WindowRegistration>();
            // mainPage.NameFieldInputButton.SendKeys(randomLoginVariable.Value);
            Driver.GetComponent<Input>("Имя", tableRegistration).SendKeys(randomLoginVariable.Value);
            // mainPage.EmailFieldInputButton.SendKeys(randomUser.CreateRandomEmail());
            Driver.GetComponent<Input>("E-Mail", tableRegistration).SendKeys(randomUser.CreateRandomEmail());
            // mainPage.PasswordFieldInputButton.SendKeys(randomUser.CreateRandomPassword());
            Driver.GetComponent<Input>("Пароль", tableRegistration).SendKeys(randomUser.CreateRandomPassword());
            // mainPage.RegistationButton.Click();
            Driver.GetComponent<Button>("ЗАРЕГИСТРИРОВАТЬСЯ", tableRegistration).Click();
            var acceptButton = Driver.GetComponent<Button>("Подтвердить");
            WaitUtils.WaitForElementToBeClickable(Driver, /*mainPage.AcceptRegistrationNewUserButton*/acceptButton);
            // mainPage.AcceptRegistrationNewUserButton.Click();
            acceptButton.Click();
        }

        public void ThenVerifyAccountLoginEqualExpected()
        {
            var mainPage = /*Driver.GetPage<MainPage>();*/Driver.GetComponent<LogIn>();
            var userNameElement = WaitUtils.WaitForElementToBeDisplayed(Driver, mainPage);
            var actualLoginForCompare = userNameElement.Text;
            Assert.AreEqual(actualLoginForCompare, randomLoginVariable.Value, "The actual login does not match the expected");
        }

        public void WhenUserDeleteUserAccount()
        {
            // var userPage = Driver.GetPage<UserPage>();
            // userPage.ActualNameUser.Click();
            Driver.GetComponent<LogIn>().Click();
            // userPage.EditProfileButton.Click();
            Driver.GetComponent<EditTabs>().Click();
            // userPage.UserDeleteAccountButton.Click();
            Driver.GetComponent<DeleteButton>().Click();

            /*WaitUtils.WaitForElementToBeClickable(Driver, userPage.SubmitDeleteUserAccountButton);
            userPage.SubmitDeleteUserAccountButton.Click();*/
            // Thread.Sleep(3000);
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Driver.GetComponent<LinkedText>("УДАЛИТЬ").Click();
            // Driver.Component<LinkedText>("УДАЛИТЬ").Click();
            // Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Driver.SwitchTo().Alert().Accept();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
        }
    }
}
