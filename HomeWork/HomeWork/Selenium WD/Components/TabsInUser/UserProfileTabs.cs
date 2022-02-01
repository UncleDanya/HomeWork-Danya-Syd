using HomeWork.Selenium_WD.Components.Utils;
using OpenQA.Selenium;

namespace HomeWork.Selenium_WD.Components.TabsInUser
{
    class UserProfileTabs : BaseComponent
    {
        public override By Construct()
        {
            // var selector = $".//div[@class='user-menu user-menu--yel ff-roboto']//*[contains(text(),'{Identifier}')]";
            var selector =
                $"//*[contains(text(),'{Identifier}')]//parent::*[starts-with(@class,'user-menu__section wu_')]";
            return By.XPath(selector);
        }
    }
}
