using HomeWork.Selenium_WD.RuntimeVariables;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using HomeWork.Selenium_WD.Utils;

namespace HomeWork.Selenium_WD.Pages
{
    internal class CategoryPage : BasePage
    {
        private CheckboxRuntimeVariable _checkboxRuntimeVariables = new CheckboxRuntimeVariable();
        
        public void SearchBrandByFilter(string brandToLook)
        {
            Actions actions = new Actions(Driver);

            var tableWithBrands = Driver.FindElement(By.XPath($"//label[@class='brand-best']//a[text()='{brandToLook}']"));
            _checkboxRuntimeVariables.Value = tableWithBrands;
            actions.Click(tableWithBrands).Perform();
        }

        public void VerifyThatCheckboxIsSelected(string brandToLook)
        {
            var checkBoxVariable = _checkboxRuntimeVariables.Value;

            var color = checkBoxVariable.GetCssValue("Color");
            Assert.AreEqual(color, "rgb(255, 141, 2)");
            var checkBoxElement = Driver.FindElement(By.XPath($"//label[@class='brand-best']//a[text()='{brandToLook}']//ancestor::li//input")).Selected;

            Assert.IsTrue(checkBoxElement, $"Button {brandToLook} is not selected");
        }

        public void ClickOnShowFilterButton()
        {
            /*var showButtonElement = Driver.FindElement(By.LinkText("Показать"));
            WaitUtils.WaitForElementToBeClickable(Driver, showButtonElement);
            showButtonElement.Click();*/
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
