using HomeWork.Selenium_WD.Components.Utils;
using OpenQA.Selenium;

namespace HomeWork.Selenium_WD.Components.Button
{
    class ButtonSubmit : BaseComponent
    {
        public override By Construct()
        {
            var selector = $".//button[@type='{Identifier}']";
            return By.XPath(selector);
        }
    }
}
