using HomeWork.Selenium_WD.Components.Utils;
using OpenQA.Selenium;

namespace HomeWork.Selenium_WD.Components
{
    class TableRegistrationWith : BaseComponent
    {
        public override By Construct()
        {
            var selector = $".//div[@class='signin-with-wrap clearfix']//*[text()='{Identifier}']";
            return By.XPath(selector);
        }
    }
}
