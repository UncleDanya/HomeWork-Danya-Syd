using HomeWork.Selenium_WD.RuntimeVariables;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Threading;

namespace HomeWork.Selenium_WD.Pages
{
    internal class CategoryPage : BasePage
    {
        private IWebDriver driver;
        private readonly CheckboxRuntimeVariable _checkboxRuntimeVariables;

        public CategoryPage(IWebDriver driver, CheckboxRuntimeVariable checkboxRuntimeVariables)
        {
            this.driver = driver;
            _checkboxRuntimeVariables = checkboxRuntimeVariables;
        }

        public void SearchBrandByFilter(string brandToLook)
        {
            Actions actions = new Actions(driver);

            var tableWithBrands = driver.FindElement(By.XPath($"//label[@class='brand-best']//a[text()='{brandToLook}']"));
            _checkboxRuntimeVariables.Value = tableWithBrands;
            actions.Click(tableWithBrands).Perform();

            Thread.Sleep(1000);
        }

        public void VerifyThatCheckboxIsSelected(string brandToLook)
        {
            var checkBoxVariable = _checkboxRuntimeVariables.Value;

            var color = checkBoxVariable.GetCssValue("Color");
            Assert.AreEqual(color, "rgb(255, 141, 2)");
            var checkBoxElement = driver.FindElement(By.XPath($"//label[@class='brand-best']//a[text()='{brandToLook}']//ancestor::li//input")).Selected;

            Assert.IsTrue(checkBoxElement, $"Button {brandToLook} is not selected");
        }

        public void ClickOnShowFilterButton()
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
