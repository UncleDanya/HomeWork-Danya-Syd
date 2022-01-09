using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace HomeWork.Selenium_WD.Pages
{
    internal class PageMobileProductApple : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//a//span[@class='u' and text()='Apple iPhone 13']")]
        public IWebElement NameProductLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//h1[@class='t2 no-mobile' and text()='Мобильный телефон Apple iPhone 13 ']")]
        public IWebElement NameTitleProduct { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[@title='Добавить в список']")]
        public IWebElement AddedProductInList { get; set; }

        [FindsBy(How= How.XPath, Using = "//li[@id='bar_bm_marked' and @class='goods-bar-section']")]
        public IWebElement OpenListWithProduct { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='side-list-label ' and text()='Apple iPhone 13 128GB']")]
        public IWebElement NameProductInList { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[text()='Apple iPhone 13 Pro']")]
        public IWebElement NameProProductLink { get; set; }
    }
}
