using HomeWork.Selenium_WD.Components.Utils;
using OpenQA.Selenium;

namespace HomeWork.Selenium_WD.Components
{
    class BottomBar : BaseComponent
    {
        public override By Construct()
        {
            var selector = $".//ul[@class='bottom-goods-bar fl-r']//*[text()='{Identifier}']";
            return By.XPath(selector);
        }
    }
}
