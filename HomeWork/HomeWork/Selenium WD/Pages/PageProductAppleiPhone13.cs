using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace HomeWork.Selenium_WD.Pages
{
    internal class PageProductAppleiPhone13 : BasePage
    {
        [FindsBy(How = How.LinkText, Using = "Avic.ua")]
        public IWebElement NameShopLinkText { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[text()='Мобильный телефон Apple iPhone 13 ']")]
        public IWebElement FullNameProductOnPage { get; set; }
    }
}
