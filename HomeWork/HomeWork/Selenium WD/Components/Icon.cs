using HomeWork.Selenium_WD.Components.Utils;
using OpenQA.Selenium;

namespace HomeWork.Selenium_WD.Components
{
    class Icon : BaseComponent
    {
        public override By Construct()
        {
            var selector = ".//span[contains(@class, 'heart')]//parent::div";
            return By.XPath(selector);
        }
    }
}
