using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HomeWork.Selenium_WD.Functional
{
    internal class FilterBrands
    {
        private IWebDriver driver;

        public FilterBrands(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void SearchBrandsByFilter(string brandToLook)
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            Actions actions = new Actions(driver);
            driver.Navigate().Refresh();
            Thread.Sleep(3000);
            var tableWithBrands = driver.FindElement(By.XPath($"//div[@id='manufacturers_presets']//ul[@class='list']//li[@class='match-li-href open']//label[@class='brand-best']//a[text()='{brandToLook}']"));
            actions.Click(tableWithBrands).Perform();
            Thread.Sleep(1000);
            try
            {
                var showBrandsFilterButton = driver.FindElement(By.LinkText("Показать"));
                executor.ExecuteScript("arguments[0].click();", showBrandsFilterButton);
            }
            catch
            {
                var showBrandsFilterButton = driver.FindElement(By.LinkText("Показать"));
                executor.ExecuteScript("arguments[0].click();", showBrandsFilterButton);
            }
        }
    }
}
