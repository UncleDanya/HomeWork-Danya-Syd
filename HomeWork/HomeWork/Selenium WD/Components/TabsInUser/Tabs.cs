using HomeWork.Selenium_WD.Components.Utils;
using OpenQA.Selenium;

namespace HomeWork.Selenium_WD.Components.TabsInUser
{
    class Tabs : BaseComponent
    {
        public override By Construct()
        {
            var selector = $".//div[@class='user-menu user-menu--yel ff-roboto']//*[contains(text(),'{Identifier}')]";
            return By.XPath(selector);
        }
    }
}
