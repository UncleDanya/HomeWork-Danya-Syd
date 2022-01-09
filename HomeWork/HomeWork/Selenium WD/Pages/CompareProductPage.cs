using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace HomeWork.Selenium_WD.Pages
{
    internal class CompareProductPage : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//table[@id='compare_table']//child::a[contains(text(),'Apple iPad 2021')]")]
        public IWebElement NameFirstCompareProduct { get; set; }

        [FindsBy(How = How.XPath, Using = "//table[@id='compare_table']//child::a[contains(text(),'Apple iPad Air')]")]
        public IWebElement NameSecondCompareProduct { get; set; }
    }
}
