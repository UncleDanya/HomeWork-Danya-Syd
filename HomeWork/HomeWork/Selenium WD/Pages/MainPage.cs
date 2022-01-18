using HomeWork.Selenium_WD.RuntimeVariables;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Threading;

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

        public void CreateNewUserAccount()
        {
            randomLoginVariable.Value = randomUser.CreateRandomLogin();

            LoginButton.Click();
           
            Thread.Sleep(2000);

            RegistrationNewUserButton.Click();
            NameFieldInputButton.SendKeys(randomLoginVariable.Value);
            EmailFieldInputButton.SendKeys(randomUser.CreateRandomEmail());
            PasswordFieldInputButton.SendKeys(randomUser.CreateRandomPassword());
            RegistationButton.Click();
            
            Thread.Sleep(1000);
            
            AcceptRegistrationNewUserButton.Click();

            Thread.Sleep(2000);
        }

        public void VerifyLoginAccount()
        {
            var actualLoginForCompare = ActualLogin.Text;

            Assert.AreEqual(actualLoginForCompare, randomLoginVariable.Value, "The actual login does not match the expected");
        }
    }
}
