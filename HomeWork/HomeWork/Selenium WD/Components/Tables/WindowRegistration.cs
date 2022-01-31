using HomeWork.Selenium_WD.Components.Utils;
using OpenQA.Selenium;

namespace HomeWork.Selenium_WD.Components.Tables
{
    class WindowRegistration : BaseComponent
    {
        public override By Construct()
        {
            var selector = ".//div[@class='registration']";
            return By.XPath(selector);
        }
    }
}
