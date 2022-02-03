using HomeWork.Selenium_WD.Components.Utils;
using OpenQA.Selenium;

namespace HomeWork.Selenium_WD.Components.CheckboxComponents
{
    class Checkbox : BaseComponent
    {
        public override By Construct()
        {
            var selector = $".//*[text()='{Identifier}']//parent::label";
            return By.XPath(selector);
        }
    }
}
