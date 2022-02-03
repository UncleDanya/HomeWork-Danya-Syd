using System;
using HomeWork.Selenium_WD.Components;
using HomeWork.Selenium_WD.Components.Button;
using HomeWork.Selenium_WD.Components.Links;
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
        private RandomLoginVariable randomLoginVariable = new RandomLoginVariable();
        
        public void WhenUserSetTextInputWithHeader(string inputName ,string nameUser)
        {
            Driver.GetComponent<InputInWithHeader>(inputName).SendKeys(nameUser);
        }

        public void ThenVerifyActualLoginAfterRename(string nameUser)
        {
            var userPage = Driver.GetPage<UserPage>();
            Driver.Navigate().Refresh();
            var actualNameUser = userPage.TextActualNameUser.Text;
            Assert.AreEqual(nameUser, actualNameUser, "The changed login does not match the profile login");
        }

        public void WhenUserClickActualLogin()
        {
            var mainPage = Driver.GetPage<MainPage>();
            mainPage.ActualLogin.Click();
        }

        public void WhenUserClickButtonIcon(string buttonName)
        {
            Driver.GetComponent<ButtonIcon>(buttonName).Click();
        }

        public void WhenUserClearInputWithHeader(string inputName)
        {
            Driver.GetComponent<InputInWithHeader>(inputName).Clear();
        }

        public void WhenUserClickOnButtonWithText(string buttonName)
        {
            Driver.GetComponent<ButtonWithText>(buttonName).Click();
        }

        public void WhenUserClickOnTabsInUserPage(string nameTabs)
        {
            Driver.GetComponent<UserProfileTabs>(nameTabs).Click();
        }

        public void GivenUserCreateNewUserAccount()
        {
            var mainPage = Driver.GetPage<MainPage>();
            RandomUser randomUser = new RandomUser();

            randomLoginVariable.Value = randomUser.CreateRandomLogin();
            mainPage.LoginButton.Click();
            var buttonRegistration = Driver.GetComponent<TableRegistrationWith>("Или зарегистрируйтесь");
            WaitUtils.WaitForElementToBeClickable(Driver, buttonRegistration);
            
            buttonRegistration.Click();
            var tableRegistration = Driver.GetPage<MainPage>().WindowRegistration;
            Driver.GetComponent<Input>("Имя", tableRegistration).SendKeys(randomLoginVariable.Value);
            Driver.GetComponent<Input>("E-Mail", tableRegistration).SendKeys(randomUser.CreateRandomEmail());
            Driver.GetComponent<Input>("Пароль", tableRegistration).SendKeys(randomUser.CreateRandomPassword());
            Driver.GetComponent<ButtonWithText>("ЗАРЕГИСТРИРОВАТЬСЯ", tableRegistration).Click();
            var acceptButton = Driver.GetComponent<ButtonWithText>("Подтвердить");
            WaitUtils.WaitForElementToBeClickable(Driver, acceptButton);
            acceptButton.Click();
        }

        public void ThenVerifyAccountLoginEqualExpected()
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
            Driver.GetComponent<ButtonIcon>("Редактировать").Click();
            Driver.GetComponent<ElementWithText>("УДАЛИТЬ АККАУНТ").Click();
            
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Driver.GetComponent<LinkedText>("УДАЛИТЬ").Click();
            Driver.SwitchTo().Alert().Accept();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
        }
    }
}
