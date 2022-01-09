using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace HomeWork.Selenium_WD.Pages
{
    internal class PageTabletAppleiPad2021 : BasePage
    {
        [FindsBy(How = How.Id, Using = "label_2090044")]
        public IWebElement AddedToCompareButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@link='/list/30/apple/']")]
        public IWebElement SwitchToPageWithTablet { get; set; }
    }
}
