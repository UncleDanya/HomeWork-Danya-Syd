using HomeWork.Selenium_WD.Pages;
using HomeWork.Selenium_WD.Utils;
using NUnit.Framework;
using OpenQA.Selenium;

namespace HomeWork.Selenium_WD.Steps
{
    class CategorySteps : BasePage
    {
        public void WhenUserSelectNeededCategoryInFolderMenu(string nameCategory, string nameCategoryInFolder)
        {
            var searchFolderByName = Driver.FindElement(By.XPath($"//ul[@class='mainmenu-list ff-roboto']//li[@class='mainmenu-item']//a[text()='{nameCategory}']"));
            searchFolderByName.Click();
            var searchInsideFolderByName = Driver.FindElement(By.PartialLinkText(nameCategoryInFolder));
            var displayedElement = searchInsideFolderByName.Displayed;
            Assert.IsTrue(displayedElement);
            WaitUtils.WaitForElementToBeClickable(Driver, searchInsideFolderByName);
            searchInsideFolderByName.Click();
        }
        
        public void WhenUserSelectBrandByNameAsFilterOption(string brandToLook)
        {
            Driver.FindElement(By.XPath($"//label[@class='brand-best']//a[text()='{brandToLook}']")).Click();
            var checkBoxElement = Driver.FindElement(By.XPath($"//label[@class='brand-best']//a[text()='{brandToLook}']//ancestor::li//input")).Selected;
            Assert.IsTrue(checkBoxElement, $"Button {brandToLook} is not selected");
            IJavaScriptExecutor executor = (IJavaScriptExecutor)Driver;

            try
            {
                var showBrandsFilterButton = Driver.FindElement(By.LinkText("Показать"));
                WaitUtils.WaitForElementToBeClickable(Driver, showBrandsFilterButton);
                executor.ExecuteScript("arguments[0].click();", showBrandsFilterButton);
            }
            catch
            {
                var showBrandsFilterButton = Driver.FindElement(By.LinkText("Показать"));
                WaitUtils.WaitForElementToBeClickable(Driver, showBrandsFilterButton);
                executor.ExecuteScript("arguments[0].click();", showBrandsFilterButton);
            }
        }
    }
}
