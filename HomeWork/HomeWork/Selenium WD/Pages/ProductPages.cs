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

        [FindsBy(How = How.XPath, Using = ".//span[@id='num_bm_compared']")]
        public IWebElement SwitchToComparePage { get; set; }

        [FindsBy(How = How.XPath, Using = ".//a[@link='/list/30/apple/']")]
        public IWebElement SwitchToPageWithTablet { get; set; }

        [FindsBy(How = How.XPath, Using = ".//u[text()='Cравнить цены']")]
        public IWebElement ShowAllPriceOnProductButton { get; set; }

        [FindsBy(How = How.XPath, Using = ".//span[@class='u' and text()]")]
        public IList<IWebElement> NamesOfAllProductsOnPage { get; set; }

        [FindsBy(How = How.XPath, Using = ".//span[text()='Сохранить список']")]
        public IWebElement SaveListProductOnPage { get; set; }

        [FindsBy(How = How.XPath, Using = ".//button[@type='submit']")]
        public IWebElement SubmitButtonSaveList { get; set; }

        public IWebElement SelectProductOnPage(string nameProduct) => Driver.FindElement(By.XPath($".//span[@class='u' and text()='{nameProduct}']"));

        public IWebElement NameShopLinkText(string nameShop) => Driver.FindElement(By.LinkText($"{nameShop}"));

        public void VerifyFilterShowActualBrand(string nameBrand)
        {
            var lastPage = Driver.FindElements(By.XPath(".//div[@class='ib page-num']//a")).Last();
            var neededElementText = Int32.Parse(lastPage.Text);

            for (int i = 0; i < neededElementText; i++)
            {
                var allNameProduct = Driver.FindElements(By.XPath($"//a/span[contains(text(),'{nameBrand}')]"));

                foreach (var oneItemAcer in allNameProduct)
                {
                    var oneItem = oneItemAcer.Text;
                    Assert.IsTrue(oneItem.Contains($"{nameBrand}"), "Not found");
                }

                try
                {
                    var nextPageButton = Driver.FindElement(By.XPath("//a[@id='pager_next']"));
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
