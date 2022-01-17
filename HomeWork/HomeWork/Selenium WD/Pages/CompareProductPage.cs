using OpenQA.Selenium;

namespace HomeWork.Selenium_WD.Pages
{
    internal class CompareProductPage : BasePage
    {
        private IWebDriver driver;
        public CompareProductPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement NameProductForCompare(string nameProduct) => driver.FindElement(By.XPath($".//table[@id='compare_table']//child::a[contains(text(),'{nameProduct}')]"));
    }
}
