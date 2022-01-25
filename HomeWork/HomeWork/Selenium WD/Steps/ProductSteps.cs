using System;
using System.Linq;
using HomeWork.Selenium_WD.Extensions;
using HomeWork.Selenium_WD.Pages;
using HomeWork.Selenium_WD.RuntimeVariables;
using HomeWork.Selenium_WD.Utils;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace HomeWork.Selenium_WD.Steps
{
    class ProductSteps : BasePage
    {
        private NameProductVariable name = new NameProductVariable();
        private CheckboxRuntimeVariable _checkboxRuntimeVariables = new CheckboxRuntimeVariable();

        public void WhenUserRememberNameProduct(string nameProduct)
        {
            var productPage = Driver.GetPage<ProductPages>();
            WaitUtils.WaitForElementToBeDisplayed(Driver, productPage.SelectProductOnPage($"{nameProduct}"));
            string nameProductText = productPage.SelectProductOnPage($"{nameProduct}").Text;
            name.Value.Add(nameProductText);
        }
        
        public void WhenUserSelectNeededProductOnPage(string nameProduct)
        {
            var productPage = Driver.GetPage<ProductPages>();
            WaitUtils.WaitForElementToBeDisplayed(Driver, productPage.SelectProductOnPage($"{nameProduct}"));
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

        // This method is using only for the item's that has memory value in nameShop text
        public void ThenVerifyThatProductNameInBookmarksMenuEqualsToActualProductNameForMobileDevices()
        {
            var productPage = Driver.GetPage<ProductPages>();
            WaitUtils.WaitForElementToBeClickable(Driver, productPage.NameProductInSaveList);
            var productNameInSaveList = productPage.NameProductInSaveList;
            var nameProductInSaveList = productNameInSaveList.Text;
            var newProductName = String.Join(" ", nameProductInSaveList.Split(' ').SkipLast(1));
            Assert.IsTrue(name.Value.Contains(newProductName), "The item added to the bookmark does not match the item in the bookmark");
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

        public void WhenUserSwitchToSecondPage()
        {
            var connectWindowHandles = Driver.WindowHandles;
            Driver.SwitchTo().Window(connectWindowHandles[1]);
        }

        public void ThenVerifyThatProductNameInOtherShopEqualsToActualProductNameForMobileDevices()
        {
            var product = Driver.GetPage<ProductPages>();
            var pageShopWithItemText = product.PageShopWithItemText.Text;
            Assert.IsTrue(pageShopWithItemText.Contains(name.Value.First()));
        }

        public void ThenVerifySaveListProductForListInUserPage()
        {
            var user = Driver.GetPage<UserPage>();
            var listProducts = user.NameViewedProduct.Select(element => element.Text).ToList();
            listProducts.Sort();
            name.Value.Sort();
            Assert.AreEqual(name.Value, listProducts);
        }

        public void WhenUserAddedToCompareCheckboxProduct()
        {
            var productPages = Driver.GetPage<ProductPages>();
            productPages.AddedToCompareCheckboxProduct.Click();
        }

        public void WhenUserSwitchToPageWithTablet()
        {
            var productPages = Driver.GetPage<ProductPages>();
            WaitUtils.WaitForElementToBeClickable(Driver, productPages.SwitchToPageWithTablet);
            productPages.SwitchToPageWithTablet.Click();
        }

        public void WhenUserSwitchToComparePage()
        {
            var productPages = Driver.GetPage<ProductPages>();
            WaitUtils.WaitForElementToBeClickable(Driver, productPages.SwitchToComparePage);
            productPages.SwitchToComparePage.Click();
        }

        public void WhenUserShowAllPriceOnProductButton()
        {
            var productPages = Driver.GetPage<ProductPages>();
            productPages.ShowAllPriceOnProductButton.Click();
        }

        public void WhenUserClickOnSaveItemInList()
        {
            var productPages = Driver.GetPage<ProductPages>();
            productPages.SaveListProductOnPage.Click();
        }

        public void WhenUserClickOnSubmitSaveListButton()
        {
            var productPages = Driver.GetPage<ProductPages>();
            WaitUtils.WaitForElementToBeClickable(Driver, productPages.SubmitButtonSaveList);
            productPages.SubmitButtonSaveList.Click();
        }

        public void WhenUserSwitchToUserPage()
        {
            var mainPage = Driver.GetPage<MainPage>();
            WaitUtils.WaitForElementToBeClickable(Driver, mainPage.EnterUserPageButton);
            mainPage.EnterUserPageButton.Click();
        }

        public void WhenUserClickOnNameShop(string nameShop)
        {
            var productPage = Driver.GetPage<ProductPages>();
            productPage.NameShopLinkText(nameShop).Click();
        }

        public void WhenUserEntryIntoCategoryByName(string folderName, string pixelFolderName)
        {
            var searchFolderByName = Driver.FindElement(By.XPath($"//ul[@class='mainmenu-list ff-roboto']//li[@class='mainmenu-item']//a[text()='{folderName}']"));
            searchFolderByName.Click();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            var seachInsideFolderByName = Driver.FindElement(By.PartialLinkText(pixelFolderName));
            var displayedElemnt = seachInsideFolderByName.Displayed;

            Assert.IsTrue(displayedElemnt);

            seachInsideFolderByName.Click();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
        }

        public void WhenUserSelectBrandByFilter(string brandToLook)
        {
            Actions actions = new Actions(Driver);

            var tableWithBrands = Driver.FindElement(By.XPath($"//label[@class='brand-best']//a[text()='{brandToLook}']"));
            _checkboxRuntimeVariables.Value = tableWithBrands;
            actions.Click(tableWithBrands).Perform();
        }

        public void ThenVerifyCheckboxIsSelected(string brandToLook)
        {
            var checkBoxVariable = _checkboxRuntimeVariables.Value;

            var color = checkBoxVariable.GetCssValue("Color");
            Assert.AreEqual(color, "rgb(255, 141, 2)");
            var checkBoxElement = Driver.FindElement(By.XPath($"//label[@class='brand-best']//a[text()='{brandToLook}']//ancestor::li//input")).Selected;

            Assert.IsTrue(checkBoxElement, $"Button {brandToLook} is not selected");
        }

        public void WhenUserClickOnShowFilterButton()
        {
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

        public void ThenVerifyDescendingPriceSorting()
        {
            var sortDescendingPriceButton = Driver.FindElement(By.XPath(".//a[@jtype='click' and text()='по цене']"));

            WaitUtils.WaitForElementToBeClickable(Driver, sortDescendingPriceButton);

            sortDescendingPriceButton.Click();

            WaitUtils.WaitForAllElementsInListIsVisible(Driver, By.XPath("//b[text()]//parent::a"));

            var lastPage = Driver.FindElements(By.XPath(".//div[@class='ib page-num']//a")).Last();
            var neededElementText = Int32.Parse(lastPage.Text);

            for (int i = 0; i < neededElementText; i++)
            {
                var allPrice = Driver.FindElements(By.XPath("//b[text()]//parent::a"));

                for (int j = 0; j < allPrice.Count - 1; j++)
                {
                    var priceWithoutText = Convert.ToInt32(allPrice[j].Text.Replace(" грн.", string.Empty).Replace(" ", string.Empty));
                    var nextPriceWithoutText = Convert.ToInt32(allPrice[j + 1].Text.Replace(" грн.", string.Empty).Replace(" ", string.Empty));

                    Assert.IsTrue(priceWithoutText <= nextPriceWithoutText, "Prices are not consistent");
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

        public void ThenVerifyFilterShowActualBrand(string nameBrand)
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

        public void WhenUserInputNameProductInSearchField(string productSearch)
        {
            var searchInput = Driver.FindElement(By.XPath("//input[@id='ek-search']"));
            searchInput.SendKeys(productSearch);

            var searchButton = Driver.FindElement(By.Name("search_but_"));
            searchButton.Click();
        }

        public void ThenVerifyItemForSeraching(string nameItem)
        {
            var searchingItems = Driver.FindElements(By.XPath("//td[@class='where-buy-description']//h3[text()]"));

            foreach (var searchingItem in searchingItems)
            {
                var searchResultsText = searchingItem.Text;

                Assert.IsTrue(searchResultsText.Contains(nameItem));
            }
        }
    }
}
