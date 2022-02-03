using HomeWork.Selenium_WD.Components.Utils;
using OpenQA.Selenium;

namespace HomeWork.Selenium_WD.Components.Button
{
    class ElementWithText : BaseComponent
    {
        public override By Construct()
        {
            var selector = $".//a[text()='{Identifier}']";
            return By.XPath(selector);
        }
    }
}
