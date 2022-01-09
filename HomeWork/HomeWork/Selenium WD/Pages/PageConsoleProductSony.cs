using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace HomeWork.Selenium_WD.Pages
{
    internal class PageConsoleProductSony : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//span[@class='u' and text()='Sony PlayStation 5']")]
        public IWebElement NameProductOnConsolePage { get; set; }
    }
}
