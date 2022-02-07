using HomeWork.Selenium_WD.RuntimeVariables;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace HomeWork.Selenium_WD.Steps
{
    [Binding]
    class BaseSteps : SpecFlowContext
    {
        // protected IWebDriver Driver { get; }
        // private readonly WebDriverVariables driver = new WebDriverVariables();
        // private IWebDriver Driver { get; }

        //public BaseSteps(IWebDriver driver)
        //{
        //    // Driver = driver;
        //    Driver = driver;
        //}
        private readonly IWebDriver Driver;

        public BaseSteps(IWebDriver driver)
        {
            Driver = driver;
        }


        [Given(@"User go to '(.*)'")]
        public void GivenUserGoTo(string uri)
        {
            //IWebDriver _driver;
            //_driver = BrowserFactory.CreateDriver();
            Driver.Navigate().GoToUrl(uri);
            Driver.Manage().Window.Maximize();
        }

        /*protected BaseSteps()
        {
            throw new System.NotImplementedException();
        }*/

    }
}
