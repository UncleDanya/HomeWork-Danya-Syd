using HomeWork.Selenium_WD.Components.Utils;
using OpenQA.Selenium;

namespace HomeWork.Selenium_WD.Components.CheckboxComponents
{
    class Checkbox : BaseComponent
    {
        public override By Construct()
        {
            var selector = $".//*[text()='{Identifier}']//parent::label";
            // var selector = $".//label[@class='brand-best']//a[text()='{Identifier}']//ancestor::li//input";
            return By.XPath(selector);
        }


        public bool VerifySelectedCheckbox()
        {
            var element = Driver.FindElement(
                By.XPath($".//label[@class='brand-best']//a[text()='{Identifier}']//ancestor::li//input"));
            return element.Selected;
        }
    }
}
