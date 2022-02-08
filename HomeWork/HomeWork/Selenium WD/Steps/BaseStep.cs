using HomeWork.Selenium_WD.Components;
using HomeWork.Selenium_WD.Components.Button;
using HomeWork.Selenium_WD.Components.Links;
using HomeWork.Selenium_WD.Extensions;
using HomeWork.Selenium_WD.Utils;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace HomeWork.Selenium_WD.Steps
{
    [Binding]
    class BaseSteps : SpecFlowContext
    {
        private readonly IWebDriver driver;

        public BaseSteps(IWebDriver driver)
        {
            this.driver = driver;
        }


        [Given(@"User go to '(.*)'")]
        public void GivenUserGoTo(string uri)
        {
            driver.Navigate().GoToUrl(uri);
        }

        [When(@"User click on linked text '(.*)'")]
        public void WhenUserClickOnLinkedText(string linkedText)
        {
            WaitUtils.WaitForElementToBeDisplayed(driver, driver.GetComponent<LinkedText>(linkedText));
            driver.GetComponent<LinkedText>(linkedText).Click();
        }

        [When(@"User click on button with type '(.*)'")]
        public void WhenUserClickOnButtonWithType(string typeButton)
        {
            var productPages = driver.GetComponent<ButtonType>(typeButton);
            WaitUtils.WaitForElementToBeClickable(driver, productPages);
            productPages.Click();
        }

        [When(@"User switch to second page")]
        public void WhenUserSwitchToSecondPage()
        {
            var connectWindowHandles = driver.WindowHandles;
            driver.SwitchTo().Window(connectWindowHandles[1]);
        }

        [When(@"User click button icon '(.*)'")]
        public void WhenUserClickButtonIcon(string buttonName)
        {
            driver.GetComponent<ButtonIcon>(buttonName).Click();
        }

        [When(@"User click on button with text '(.*)'")]
        public void WhenUserClickOnButtonWithText(string buttonName)
        {
            driver.GetComponent<ButtonWithText>(buttonName).Click();
        }

        [When(@"User clear input with header '(.*)'")]
        public void WhenUserClearInputWithHeader(string inputName)
        {
            driver.GetComponent<InputInWithHeader>(inputName).Clear();
        }

        [When(@"User set text input with header '(.*)' , '(.*)'")]
        public void WhenUserSetTextInputWithHeader(string inputName, string nameUser)
        {
            driver.GetComponent<InputInWithHeader>(inputName).SendKeys(nameUser);
        }
    }
}
