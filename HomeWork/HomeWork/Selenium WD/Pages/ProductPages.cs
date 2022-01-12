using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HomeWork.Selenium_WD.Pages
{
    internal class ProductPages : BasePage
    {
        IWebDriver driver;
        public ProductPages(IWebDriver driver)
        {
            this.driver = driver;
        }
        
        [FindsBy(How = How.XPath, Using = ".//h1[@itemprop='name']")]
        public IWebElement FooterWithNameOnPage { get; set; }

        [FindsBy(How = How.XPath, Using = ".//span[@title='Добавить в список']")]
        public IWebElement AddedProductInList { get; set; }

        [FindsBy(How = How.XPath, Using = ".//li[@id='bar_bm_marked' and @class='goods-bar-section']")]
        public IWebElement OpenListWithProduct { get; set; }

        [FindsBy(How = How.XPath, Using = ".//a[@class='touchcarousel-item side-list-block block-selected ']//child::div[@class='panel-item-close']//following-sibling::div[@class='side-list-label ' and text()]")]
        public IWebElement NameProductInSaveList { get; set; }

        [FindsBy(How = How.XPath, Using = ".//div[@class='ib toggle-off']//following-sibling::label")]
        public IWebElement AddedToCompareCheckboxProduct { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[@id='num_bm_compared']")]
        public IWebElement SwitchToComparePage { get; set; }

        [FindsBy(How = How.XPath, Using = ".//a[@link='/list/30/apple/']")]
        public IWebElement SwitchToPageWithTablet { get; set; }

        [FindsBy(How = How.XPath, Using = ".//u[text()='Cравнить цены']")]
        public IWebElement ShowAllPriceOnProductButton { get; set; }

        [FindsBy(How = How.XPath, Using = ".//a[@jtype='click' and text()='по цене']")]
        public IWebElement SortByPrice { get; set; }

        [FindsBy(How = How.XPath, Using = ".//span[@class='u' and text()]")]
        public IList<IWebElement> NamesOfAllProductsOnPage { get; set; }


        public void SelectProductOnPage(string nameProduct) => driver.FindElement(By.XPath($".//span[@class='u' and text()='{nameProduct}']")).Click();

        public string NameProductOnPage(string nameProduct) => driver.FindElement(By.XPath($".//span[@class='u' and text()='{nameProduct}']")).Text;

        // public void SaveAllProductOnPageInList() => driver.FindElement(By.XPath(".//span[text()='Сохранить список']"));
        public void SaveProductOnPage()
        {
            driver.FindElement(By.XPath(".//span[text()='Сохранить список']")).Click();
            driver.FindElement(By.XPath(".//button[@type='submit']")).Click();
        }

        // public void FooterWithNameOnPage() => driver.FindElement(By.XPath(".//h1[@itemprop='name']"));

        // public void AddedProductInList() => driver.FindElement(By.XPath(".//span[@title='Добавить в список']")).Click();

        // public void AddedToCompareCheckboxProduct() => driver.FindElement(By.XPath(".//div[@class='ib toggle-off']//child::input[@type='checkbox' and @class='custom-checkbox']")).Click();

        // public void ShowAllPriceOnProductButton() => driver.FindElement(By.XPath(".//u[text()='Cравнить цены']")).Click();

        public void NameShopLinkText(string nameShop) => driver.FindElement(By.LinkText($"{nameShop}")).Click();

        // public void SortByPrice() => driver.FindElement(By.XPath(".//a[@jtype='click' and text()='по цене']")).Click();

        // public void OpenListWithProducts() => driver.FindElement(By.XPath(".//li[@id='bar_bm_marked' and @class='goods-bar-section']")).Click();

        // public void NameProductInSaveList(string nameProduct) => driver.FindElement(By.XPath($".//div[@class='side-list-label ' and text()='{nameProduct}']"));

        public void VerifyFilterShowActualBrand(string nameBrand)
        {
            var lastPage = driver.FindElements(By.XPath(".//div[@class='ib page-num']//a")).Last();
            var neededElementText = Int32.Parse(lastPage.Text);

            for (int i = 0; i < neededElementText; i++)
            {
                var allAcer = driver.FindElements(By.XPath($"//a/span[contains(text(),'{nameBrand}')]"));

                foreach (var oneItemAcer in allAcer)
                {
                    var oneItem = oneItemAcer.Text;
                    Assert.IsTrue(oneItem.Contains($"{nameBrand}"), "Not found");
                }

                try
                {
                    var nextPageButton = driver.FindElement(By.XPath("//a[@id='pager_next']"));
                    nextPageButton.Click();
                }
                catch
                {
                    continue;
                }
            }
        }
    }
}
