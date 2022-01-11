using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Threading;

namespace HomeWork.Selenium_WD.Functional
{
    internal class EntryCategory
    {
        private IWebDriver driver;

        public EntryCategory(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void EntryIntoCategoryByName(string folderName, string pixelFolderName)
        {
            Actions actions = new Actions(driver);
            
            var searchFolderByName = driver.FindElement(By.XPath($"//ul[@class='mainmenu-list ff-roboto']//li[@class='mainmenu-item']//a[text()='{folderName}']"));
            actions.MoveToElement(searchFolderByName).Perform();
            
            Thread.Sleep(1000);
            
            var seachInsideFolderByName = driver.FindElement(By.PartialLinkText(pixelFolderName));
            var displayedElemnt = seachInsideFolderByName.Displayed;
            
            Assert.IsTrue(displayedElemnt);
            
            seachInsideFolderByName.Click();
            
            Thread.Sleep(2000);
        }
    }
}
