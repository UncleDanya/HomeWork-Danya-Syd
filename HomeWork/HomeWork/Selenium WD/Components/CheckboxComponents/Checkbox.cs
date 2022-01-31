using HomeWork.Selenium_WD.Components.Utils;
using NUnit.Framework;
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

        public void VerifySelectedCheckbox()
        {
            Instance.Click();
            var element = Instance.FindElement(
                By.XPath($"//label[@class='brand-best']//a[text()='{Identifier}']//ancestor::li//input"));
            Assert.IsTrue(element.Selected);
        }
    }
}
