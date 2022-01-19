using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace HomeWork.Selenium_WD.Pages
{
    public class BasePage
    {
        public IWebDriver Driver { get; set; }
        public void InitElement()
        {
            PageFactory.InitElements(Driver, this);
        }
    }
}
