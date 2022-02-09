using HomeWork.Selenium_WD.Components;
using HomeWork.Selenium_WD.Components.Button;
using HomeWork.Selenium_WD.Components.TabsInUser;
using HomeWork.Selenium_WD.Extensions;
using HomeWork.Selenium_WD.Pages;
using HomeWork.Selenium_WD.RuntimeVariables;
using HomeWork.Selenium_WD.Utils;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace HomeWork.Selenium_WD.Steps
{
    [Binding]
    class UserAccountSteps : SpecFlowContext
    {
        private readonly IWebDriver driver;
        private RandomLoginVariable randomLoginVariable = new RandomLoginVariable();

        public UserAccountSteps(IWebDriver driver)
        {
            this.driver = driver;
        }


        [Given(@"User create new user account")]
        public void GivenUserCreateNewUserAccount()
        {
            var mainPage = driver.GetPage<MainPage>();
            RandomUser randomUser = new RandomUser();

            randomLoginVariable.Value = randomUser.CreateRandomLogin();
            mainPage.LoginButton.Click();
            var buttonRegistration = driver.GetComponent<TableRegistrationWith>("Или зарегистрируйтесь");
            WaitUtils.WaitForElementToBeClickable(driver, buttonRegistration);

            buttonRegistration.Click();
            var tableRegistration = driver.GetPage<MainPage>().WindowRegistration;
            driver.GetComponent<Input>("Имя", tableRegistration).SendKeys(randomLoginVariable.Value);
            driver.GetComponent<Input>("E-Mail", tableRegistration).SendKeys(randomUser.CreateRandomEmail());
            driver.GetComponent<Input>("Пароль", tableRegistration).SendKeys(randomUser.CreateRandomPassword());
            driver.GetComponent<ButtonWithText>("ЗАРЕГИСТРИРОВАТЬСЯ", tableRegistration).Click();
            var acceptButton = driver.GetComponent<ButtonWithText>("Подтвердить");
            WaitUtils.WaitForElementToBeClickable(driver, acceptButton);
            acceptButton.Click();
        }

        [When(@"User go to profile")]
        public void WhenUserGoToProfile()
        {
            var mainPage = driver.GetPage<MainPage>();
            WaitUtils.WaitForElementToBeClickable(driver, mainPage.ActualLogin);
            mainPage.ActualLogin.Click();
        }

        [When(@"User click on tabs in user page '(.*)'")]
        public void WhenUserClickOnTabsInUserPage(string nameTabs)
        {
            driver.GetComponent<UserProfileTabs>(nameTabs).Click();
        }

        [Then(@"Verify actual login equal random login entered")]
        public void ThenVerifyActualLoginEqualRandomLoginEntered()
        {
            var mainPage = driver.GetPage<MainPage>();
            var userNameElement = WaitUtils.WaitForElementToBeDisplayed(driver, mainPage.ActualLogin);
            var actualLoginForCompare = userNameElement.Text;
            Assert.AreEqual(actualLoginForCompare, randomLoginVariable.Value, "The actual login does not match the expected");
        }

        [Then(@"Verify actual login equal the changed random login '(.*)'")]
        public void ThenVerifyActualLoginEqualTheChangedRandomLogin(string nameUser)
        {
            var userPage = driver.GetPage<UserPage>();
            driver.Navigate().Refresh();
            var actualNameUser = userPage.TextActualNameUser.Text;
            Assert.AreEqual(nameUser, actualNameUser, "The changed login does not match the profile login");
        }
    }
}
