using HomeWork.Selenium_WD.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using HomeWork.Selenium_WD.Utils;

namespace HomeWork.Selenium_WD.Functional
{
    internal class ProductCategoryNavigation : BasePage
    {
        public void EntryIntoCategoryByName(string folderName, string pixelFolderName)
        {
            var searchFolderByName = Driver.FindElement(By.XPath($"//ul[@class='mainmenu-list ff-roboto']//li[@class='mainmenu-item']//a[text()='{folderName}']"));
            searchFolderByName.Click();
            
            var seachInsideFolderByName = Driver.FindElement(By.PartialLinkText(pixelFolderName));
            var displayedElemnt = seachInsideFolderByName.Displayed;
            
            Assert.IsTrue(displayedElemnt);
            
            WaitUtils.WaitForElementToBeClickable(Driver, seachInsideFolderByName);
            
            seachInsideFolderByName.Click();
        }
    }
}
