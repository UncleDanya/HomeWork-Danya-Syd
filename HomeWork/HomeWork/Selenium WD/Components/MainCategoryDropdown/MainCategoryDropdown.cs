using HomeWork.Selenium_WD.Components.Utils;
using HomeWork.Selenium_WD.Utils;
using OpenQA.Selenium;

namespace HomeWork.Selenium_WD.Components.FolderIcon
{
    class MainCategoryDropDown : BaseComponent
    {
        public override By Construct()
        {
            var selector = $".//li[@class='mainmenu-item']/a[text()='{Identifier}']";
            return By.XPath(selector);
        }

        public void SelectCategoryFromDropdown(string subItemMenu)
        {
            Instance.Click();
            WaitUtils.WaitForElementToBeClickable(Driver, Driver.FindElement(By.PartialLinkText(subItemMenu)));
            Driver.FindElement(By.PartialLinkText(subItemMenu)).Click();
        }
    }
}
