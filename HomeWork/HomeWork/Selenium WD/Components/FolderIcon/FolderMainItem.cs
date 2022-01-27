using HomeWork.Selenium_WD.Components.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace HomeWork.Selenium_WD.Components.FolderIcon
{
    class FolderMainItem : BaseComponent
    {
        public override By Construct()
        {
            var selector = By.XPath($".//li[@class='mainmenu-item']/a[text()='{Identifier}']");
            return selector;
        }

        public void MoveToElement()
        {
            Actions actions = new Actions(Driver);
            actions.MoveToElement(Instance).Perform();
        }
    }
}
