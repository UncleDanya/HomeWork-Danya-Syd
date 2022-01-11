using HomeWork.Selenium_WD.RuntimeVariables;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Threading;

namespace HomeWork.Selenium_WD.Functional
{
    internal class FilterBrands
    {
        private IWebDriver driver;
        private readonly CheckboxRuntimeVariable _checkboxRuntimeVariables;

        public FilterBrands(IWebDriver driver, CheckboxRuntimeVariable checkboxRuntimeVariables)
        {
            this.driver = driver;
            _checkboxRuntimeVariables = checkboxRuntimeVariables;
        }

        public void SearchBrandsByFilter(string brandToLook)
        {
            Actions actions = new Actions(driver);
            
            var tableWithBrands = driver.FindElement(By.XPath($"//label[@class='brand-best']//a[text()='{brandToLook}']"));
            _checkboxRuntimeVariables.Value = tableWithBrands;
            actions.Click(tableWithBrands).Perform();
            
            Thread.Sleep(1000);
        }

        public void VerifyThatButtonIsCheckboxIsSelected(string brandToLook)
        {
            var checkBoxVariable = _checkboxRuntimeVariables.Value;
            
            var locationButton = checkBoxVariable.Location.X;
            var sizeButton = checkBoxVariable.Size.Width + locationButton;
            
            var color = checkBoxVariable.GetCssValue("value");
            var checkBoxElement = driver.FindElement(By.XPath($"//label[@class='brand-best']//a[text()='{brandToLook}']//ancestor::li//input")).Selected;
            
            Assert.AreEqual(1204, sizeButton, "Checkbox size is not equal to expected");
            Assert.IsTrue(checkBoxElement, $"Button {brandToLook} is not selected");

        }


        public void ClickOnShowFilter()
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;

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
