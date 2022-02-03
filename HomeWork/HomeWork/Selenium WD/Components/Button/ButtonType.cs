using HomeWork.Selenium_WD.Components.Utils;
using OpenQA.Selenium;

namespace HomeWork.Selenium_WD.Components.Button
{
    class ButtonType : BaseComponent
    {
        public override By Construct()
        {
            var selector = $".//button[@type='{Identifier}']";
            return By.XPath(selector);
        }
    }
}
