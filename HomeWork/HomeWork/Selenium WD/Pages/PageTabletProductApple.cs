using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace HomeWork.Selenium_WD.Pages
{
    internal class PageTabletProductApple : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//a[@data-url='/APPLE-IPAD-2021-64GB.htm']")]
        public IWebElement FirstTabletToCompare { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@data-url='/APPLE-IPAD-AIR-2020-64GB.htm']")]
        public IWebElement SecondTabletToCompate { get; set; }
    }
}
