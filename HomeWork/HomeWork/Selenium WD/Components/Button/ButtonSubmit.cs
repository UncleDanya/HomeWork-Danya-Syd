using HomeWork.Selenium_WD.Components.Utils;
using HomeWork.Selenium_WD.Utils;
using OpenQA.Selenium;

namespace HomeWork.Selenium_WD.Components.Button
{
    class ButtonSubmit : BaseComponent
    {
        public override By Construct()
        {
            var selector = ".//button[@type='submit']";
            return By.XPath(selector);
        }

        public void Wait()
        {
            WaitUtils.WaitForElementToBeClickable(Driver, Instance);
        }
    }
}
