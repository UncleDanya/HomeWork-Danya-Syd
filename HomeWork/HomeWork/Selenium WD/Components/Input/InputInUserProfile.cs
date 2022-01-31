using HomeWork.Selenium_WD.Components.Utils;
using OpenQA.Selenium;

namespace HomeWork.Selenium_WD.Components
{
    class InputInUserProfile : BaseComponent
    {
        public override By Construct()
        {
            var selector = $".//label[text()='{Identifier}']/following-sibling::input";
            return By.XPath(selector);
        }
    }
}
