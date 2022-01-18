using OpenQA.Selenium;

namespace HomeWork.Selenium_WD.Pages
{
    internal class CompareProductPage : BasePage
    {
        public IWebElement NameProductForCompare(string nameProduct) => Driver.FindElement(By.XPath($".//table[@id='compare_table']//child::a[contains(text(),'{nameProduct}')]"));
    }
}
