using HomeWork.Selenium_WD.Components.Utils;
using OpenQA.Selenium;

namespace HomeWork.Selenium_WD.Components.Button
{
    class Button : BaseComponent
    {
        public override By Construct()
        {
            var selector = $".//button[text()='{Identifier}']";
            return By.XPath(selector);
        }
    }
}
