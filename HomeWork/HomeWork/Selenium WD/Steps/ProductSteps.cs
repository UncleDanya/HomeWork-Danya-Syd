using System;
using System.Linq;
using HomeWork.Selenium_WD.Extensions;
using HomeWork.Selenium_WD.Pages;
using HomeWork.Selenium_WD.RuntimeVariables;
using HomeWork.Selenium_WD.Utils;
using NUnit.Framework;
using OpenQA.Selenium;

namespace HomeWork.Selenium_WD.Steps
{
    class ProductSteps : BasePage
    {
        private NameProductVariable name = new NameProductVariable();
        public void WhenUserSelectNeededProductOnPage(string nameProduct)
        {
            var productPage = Driver.GetPage<ProductPages>();
            WaitUtils.WaitForElementToBeDisplayed(Driver, productPage.SelectProductOnPage($"{nameProduct}"));
            string nameProductText = productPage.SelectProductOnPage($"{nameProduct}").Text;
            name.Value.Add(nameProductText);
            productPage.SelectProductOnPage($"{nameProduct}").Click();
        }

        public void WhenUserAddedProductInList()
        {
            var productPage = Driver.GetPage<ProductPages>();
            WaitUtils.WaitForElementToBeClickable(Driver, productPage.AddedProductInList);
            productPage.AddedProductInList.Click();
        }

        public void WhenUserOpenBookmarksMenu()
        {
            var productPage = Driver.GetPage<ProductPages>();
            WaitUtils.WaitForElementToBeClickable(Driver, productPage.OpenListWithProduct);
            productPage.OpenListWithProduct.Click();
        }
        
        // This method is using only for the item's that has memory value in name text
        public void ThenVerifyThatProductNameInBookmarksMenuEqualsToActualProductNameForMobileDevices()
        {
            var productPage = Driver.GetPage<ProductPages>();
            WaitUtils.WaitForElementToBeClickable(Driver, productPage.NameProductInSaveList);
            var productNameInSaveList = productPage.NameProductInSaveList;
            var nameProductInSaveList = productNameInSaveList.Text;
            var newProductName =String.Join(" ", nameProductInSaveList.Split(' ').SkipLast(1));
            Assert.IsTrue(name.Value.Contains(/*(IWebElement)*/ newProductName), "The item added to the bookmark does not match the item in the bookmark");
        }

        public void ThenVerifyProductNameForCompareTwoItems(string nameFirstProduct, string nameSecondProduct)
        {
            var compareProduct = Driver.GetPage<CompareProductPage>();
            var nameFirstTabletInComparePage = compareProduct.NameProductForCompare($"{nameFirstProduct}").Text;
            var nameSecondTabletInComparePage = compareProduct.NameProductForCompare($"{nameSecondProduct}").Text;
            Assert.IsTrue(nameFirstTabletInComparePage.Contains(name.Value.First()), "The added item does not match the item on the list");
            Assert.IsTrue(nameSecondTabletInComparePage.Contains(name.Value.Last()), "The added item does not match the item on the list");
        }

        public void WhenUserSaveAllProductOnPageInList()
        {
            var productPages = Driver.GetPage<ProductPages>();
            var listWithNameProductOnPage = productPages.NamesOfAllProductsOnPage.SkipLast(4).Select(element => element.Text).ToList();
            listWithNameProductOnPage.Sort();
            name.Value = listWithNameProductOnPage;
        }

        public void ThenVerifyListSaveInProductPageForListInUserPage()
        {
            var productPages = Driver.GetPage<ProductPages>();
            var listWithSaveProductInUserPage = productPages.NamesOfAllProductsOnPage.Select(element => element.Text).ToList();
            listWithSaveProductInUserPage.Sort();
            Assert.AreEqual(name.Value, listWithSaveProductInUserPage, "The saved item list does not match the sheet in the profile");
        }

        public void WhenUserSwitchToNextPage()
        {
            var connectWindowHandles = Driver.WindowHandles;
            Driver.SwitchTo().Window(connectWindowHandles[1]);
        }

        public void ThenVerifyThatProductNameInOtherShopEqualsToActualProductNameForMobileDevices()
        {
            var pageShopWithItemText = Driver.FindElement(By.XPath("//h1[@class='page-title']")).Text;
            Assert.IsTrue(pageShopWithItemText.Contains(name.Value.First()));
        }

        public void ThenVerifySaveListProductForListInUserPage()
        {
            var nameMobileItemInList = Driver.FindElement(By.XPath("//u[@class='nobr' and text()='Apple iPhone 13 Pr...']")).Text.Remove(16);
            var nameConsoleItemInList = Driver.FindElement(By.XPath("//u[@class='nobr' and text()='Sony PlayStation 5']")).Text;
            var nameAudioItemInList = Driver.FindElement(By.XPath("//u[@class='nobr' and text()='Logitech G Pro X']")).Text;
            Assert.IsTrue(name.Value[0].Contains(nameMobileItemInList));
            Assert.IsTrue(name.Value[1].Contains(nameConsoleItemInList));
            Assert.IsTrue(name.Value[2].Contains(nameAudioItemInList));
        }
    }
}
