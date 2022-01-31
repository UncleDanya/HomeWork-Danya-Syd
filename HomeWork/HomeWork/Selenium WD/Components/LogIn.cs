using HomeWork.Selenium_WD.Components.Utils;
using OpenQA.Selenium;

namespace HomeWork.Selenium_WD.Components
{
    class LogIn : BaseComponent
    {
        public override By Construct()
        {
            // var selector = ".//span[@jtype='click']";
            var selector = ".//div[@class='header_action_login']//*[text()]";
            return By.XPath(selector);
        }
    }
}
