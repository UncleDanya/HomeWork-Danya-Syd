using HomeWork.Selenium_WD.Components.Utils;
using OpenQA.Selenium;

namespace HomeWork.Selenium_WD.Components.Links
{
    class LinkedText : BaseComponent
    {
        
        public override By Construct()
        {
            var selector = $".//*[text()='{Identifier}']//ancestor::a[@href]";
            return By.XPath(selector);
        }
    }
}
