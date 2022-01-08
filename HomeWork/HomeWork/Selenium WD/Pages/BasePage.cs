using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace HomeWork.Selenium_WD.Pages
{
    internal class BasePage
    {
        public IWebDriver driver { get; set; }

        public void InitElement()
        {
            PageFactory.InitElements(driver, this);
        }
    }
}
