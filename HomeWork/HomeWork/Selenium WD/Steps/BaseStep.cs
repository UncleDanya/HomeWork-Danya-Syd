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
            driver.Manage().Window.Maximize();
        }
    }
}
