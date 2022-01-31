using HomeWork.Selenium_WD.Components.Utils;
using OpenQA.Selenium;

namespace HomeWork.Selenium_WD.Components
{
    class ButtonSwitchPage : BaseComponent
    {
        public override By Construct()
        {
            var selector = $".//a[starts-with(@class,'ib pager') and @title='{Identifier}']";
            return By.XPath(selector);
        }
    }
}
