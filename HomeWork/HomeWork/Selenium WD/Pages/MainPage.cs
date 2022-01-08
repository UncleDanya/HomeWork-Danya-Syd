using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Threading;

namespace HomeWork.Selenium_WD.Pages
{
    internal class MainPage : BasePage
    {
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
            var randomLogin = randomUser.CreateRandomLogin();

            // var signIn = driver.FindElement((By)LoginButton);
            LoginButton.Click();
            // signIn.Click();

            Thread.Sleep(2000);

            // var registrationButton = driver.FindElement((By)registrationNewUserButton).Click;
            //registrationButton.Click();
            RegistrationNewUserButton.Click();

            /*var inputName = driver.FindElement((By)nameFieldInputButton);
            inputName.SendKeys(randomLogin);*/
            NameFieldInputButton.SendKeys(randomLogin);

            /*var emailInput = driver.FindElement((By)emailFieldInputButton);
            emailInput.SendKeys(randomUser.CreateRandomEmail());*/
            EmailFieldInputButton.SendKeys(randomUser.CreateRandomEmail());

            /*var passwordInput = driver.FindElement((By)passwordFieldInputButton);
            passwordInput.SendKeys(randomUser.CreateRandomPassword());*/
            PasswordFieldInputButton.SendKeys(randomUser.CreateRandomPassword());

            /*var acceptRegistration = driver.FindElement((By)acceptRegistrationNewUserButton);
            acceptRegistration.Submit();*/
            RegistationButton.Click();
            Thread.Sleep(1000);
            AcceptRegistrationNewUserButton.Click();
            // acceptRegistration.Click();

            Thread.Sleep(2000);

            // var acceptButton = driver.FindElement((By)acceptRegistrationNewUserButton).Click;
            // acceptButton.Click();

            /*var actualLogin = driver.FindElement(_acceptLogin);
            actualLogin.Click();*/

            // var actualLoginForCompare = driver.FindElement(By.ClassName("info-nick")).Text;
            var actualLoginForCompare = ActualLogin.Text;

            Assert.AreEqual(actualLoginForCompare, randomLogin, "The actual login does not match the expected");
        }

        /*public void EntryIntoCategoryByName(string folderName, string pixelFolderName)
        {
            Actions actions = new Actions(driver);
            var searchFolderByName = driver.FindElement(By.XPath($"//ul[@class='mainmenu-list ff-roboto']//li[@class='mainmenu-item']//a[text()='{folderName}']"));
            actions.MoveToElement(searchFolderByName).Perform();
            Thread.Sleep(1000);
            var seachInsideFolderByName = driver.FindElement(By.PartialLinkText(pixelFolderName));
            seachInsideFolderByName.Click();
            Thread.Sleep(2000);
        }*/
    }

}
