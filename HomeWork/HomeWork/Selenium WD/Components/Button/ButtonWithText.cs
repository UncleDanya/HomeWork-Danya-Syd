using HomeWork.Selenium_WD.Components.Utils;
using OpenQA.Selenium;

namespace HomeWork.Selenium_WD.Components.Button
{
    class ButtonWithText : BaseComponent
    {
        public override By Construct()
        {
            var selector = $".//button[text()='{Identifier}']";
            return By.XPath(selector);
        }
    }
}
