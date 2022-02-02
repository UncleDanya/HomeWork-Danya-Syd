using HomeWork.Selenium_WD.Components.Utils;
using OpenQA.Selenium;

namespace HomeWork.Selenium_WD.Components
{
    class ButtonIcon : BaseComponent
    {
        public override By Construct()
        {
            var selector = $".//a[@title='{Identifier}']";
            return By.XPath(selector);
        }
    }
}
