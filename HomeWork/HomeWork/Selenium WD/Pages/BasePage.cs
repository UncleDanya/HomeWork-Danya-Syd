using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using SeleniumExtras.PageObjects;

namespace HomeWork.Selenium_WD.Pages
{
    internal class BasePage
    {
        public RemoteWebDriver Driver { get; set; }

        public void InitElement()
        {
            PageFactory.InitElements(Driver, this);
        }
    }
}
