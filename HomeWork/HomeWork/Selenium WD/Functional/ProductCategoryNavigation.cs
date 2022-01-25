using System;
using HomeWork.Selenium_WD.Pages;
using NUnit.Framework;
using OpenQA.Selenium;

namespace HomeWork.Selenium_WD.Functional
{
    internal class ProductCategoryNavigation : BasePage
    {
        public void EntryIntoCategoryByName(string folderName, string pixelFolderName)
        {
            var searchFolderByName = Driver.FindElement(By.XPath($"//ul[@class='mainmenu-list ff-roboto']//li[@class='mainmenu-item']//a[text()='{folderName}']"));
            searchFolderByName.Click();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            
            var seachInsideFolderByName = Driver.FindElement(By.PartialLinkText(pixelFolderName));
            seachInsideFolderByName.Click();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
        }
    }
}
