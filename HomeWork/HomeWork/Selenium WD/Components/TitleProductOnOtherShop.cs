using HomeWork.Selenium_WD.Components.Utils;
using OpenQA.Selenium;

namespace HomeWork.Selenium_WD.Components
{
    class TitleProductOnOtherShop : BaseComponent
    {
        public override By Construct()
        {
            var selector = "//h1[@class='page-title']";
            return By.XPath(selector);
        }
    }
}
