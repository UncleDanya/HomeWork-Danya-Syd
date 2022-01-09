using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace HomeWork.Selenium_WD.Pages
{
    internal class PageMobileiPhone13Pro : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//u[text()='Cравнить цены']")]
        public IWebElement ShowAllPriceProductButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@jtype='click' and text()='по цене']")]
        public IWebElement SortByPrice { get; set; }
    }
}
