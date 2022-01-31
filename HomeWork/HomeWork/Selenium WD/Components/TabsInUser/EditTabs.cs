using HomeWork.Selenium_WD.Components.Utils;
using OpenQA.Selenium;

namespace HomeWork.Selenium_WD.Components.TabsInUser
{
    class EditTabs : BaseComponent
    {
        public override By Construct()
        {
            var selector = ".//a[@title='Редактировать']";
            return By.XPath(selector);
        }
    }
}
