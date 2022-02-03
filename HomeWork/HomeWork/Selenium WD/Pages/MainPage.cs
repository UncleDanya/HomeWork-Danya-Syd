using HomeWork.Selenium_WD.RuntimeVariables;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using HomeWork.Selenium_WD.Utils;

namespace HomeWork.Selenium_WD.Pages
{
    internal class MainPage : BasePage
    {
        private RandomLoginVariable randomLoginVariable = new RandomLoginVariable();
        
        RandomUser randomUser = new RandomUser();
        
        [FindsBy(How = How.XPath, Using = ".//span[@jtype='click']")]
        public IWebElement LoginButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "span[class='j-wrap orange']")]
        public IWebElement RegistrationNewUserButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@name='p_[NikName]']")]
        public IWebElement NameFieldInputButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@name='p_[EMail]']")]
        public IWebElement EmailFieldInputButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@name='p_[PW0]']")]
        public IWebElement PasswordFieldInputButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[text()='ЗАРЕГИСТРИРОВАТЬСЯ']")]
        public IWebElement RegistationButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[text()='Подтвердить']")]
        public IWebElement AcceptRegistrationNewUserButton { get; set; }

        [FindsBy(How = How.ClassName, Using = "info-nick")]
        public IWebElement EnterUserPageButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='ek-search']")]
        public IWebElement SearchFieldProductInputButton { get; set; }

        [FindsBy(How = How.Name, Using = "search_but_")]
        public IWebElement FindProductButton { get; set; }

        [FindsBy(How = How.ClassName, Using = "info-nick")]
        public IWebElement ActualLogin { get; set; }

        [FindsBy(How = How.XPath, Using = ".//div[@class='registration']")]
        public IWebElement WindowRegistration { get; set; }


        public void CreateNewUserAccount()
        {
            randomLoginVariable.Value = randomUser.CreateRandomLogin();
            LoginButton.Click();
            WaitUtils.WaitForElementToBeClickable(Driver, RegistrationNewUserButton);

            RegistrationNewUserButton.Click();
            NameFieldInputButton.SendKeys(randomLoginVariable.Value);
            EmailFieldInputButton.SendKeys(randomUser.CreateRandomEmail());
            PasswordFieldInputButton.SendKeys(randomUser.CreateRandomPassword());
            RegistationButton.Click();
            WaitUtils.WaitForElementToBeClickable(Driver, AcceptRegistrationNewUserButton);
            AcceptRegistrationNewUserButton.Click();
        }

        public void VerifyLoginAccount()
        {
            var userNameElement = WaitUtils.WaitForElementToBeDisplayed(Driver, ActualLogin);
            var actualLoginForCompare = userNameElement.Text;
            Assert.AreEqual(actualLoginForCompare, randomLoginVariable.Value, "The actual login does not match the expected");
        }
    }
}
