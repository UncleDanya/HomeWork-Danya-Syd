using HomeWork.Selenium_WD.Components.Utils;
using OpenQA.Selenium;

namespace HomeWork.Selenium_WD.Components
{
    class Input : BaseComponent
    {
        public override By Construct()
        {
            var selector = $".//input[@placeholder='{Identifier}']";
            return By.XPath(selector);
        }
    }
}
