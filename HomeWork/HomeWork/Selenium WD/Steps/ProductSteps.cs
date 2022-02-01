using System;
using System.Linq;
using HomeWork.Selenium_WD.Components;
using HomeWork.Selenium_WD.Components.Button;
using HomeWork.Selenium_WD.Components.CheckboxComponents;
using HomeWork.Selenium_WD.Components.FolderIcon;
using HomeWork.Selenium_WD.Components.Grid;
using HomeWork.Selenium_WD.Components.Links;
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

        public void WhenUserRememberNameProduct(string nameProduct)
        {
            var product = Driver.GetComponent<ProductsNameLink>(nameProduct);
            WaitUtils.WaitForElementToBeDisplayed(Driver, product);
            var productName = product.Text;
            name.Value.Add(productName);
        }
        
        public void WhenUserSelectNeededProductOnPage(string nameProduct)
        {
            Driver.GetComponent<LinkedText>(nameProduct).Click();
        }

        public void WhenUserAddedProductInList()
        {
            var productPage = Driver.GetPage<ProductPages>();
            WaitUtils.WaitForElementToBeClickable(Driver, productPage.HeartShapedIcon);
            productPage.HeartShapedIcon.Click();
        }

        public void WhenUserOpenBookmarksMenu()
        {
            var bar = Driver.GetComponent<BottomBar>("Закладки");
            WaitUtils.WaitForElementToBeClickable(Driver, bar);
            bar.Click();
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
            Driver.GetComponent<Checkbox>("добавить в сравнение").Click();
        }

        public void WhenUserSwitchToPageWithTablet()
        {
            Driver.GetComponent<LinkedText>("Apple").Click();
        }

        public void WhenUserSwitchToComparePage()
        {
            Driver.GetComponent<BottomBar>("Сравнить").Click();
        }

        public void WhenUserShowAllPriceOnProductButton()
        {
            Driver.GetComponent<LinkedText>("Cравнить цены").Click();
        }

        public void WhenUserClickOnSaveItemInList()
        {
            var productPages = Driver.GetPage<ProductPages>();
            productPages.HeartShapedIcon.Click();
        }

        public void WhenUserClickOnSubmitSaveListButton()
        {
            var productPages = Driver.GetComponent<ButtonSubmit>("submit");
            WaitUtils.WaitForElementToBeClickable(Driver, productPages);
            productPages.Click();
        }

        public void WhenUserSwitchToUserPage()
        {
            var mainPage = Driver.GetPage<MainPage>();
            WaitUtils.WaitForElementToBeClickable(Driver, mainPage.ActualLogin);
            mainPage.ActualLogin.Click();
        }

        public void WhenUserClickOnNameShop(string nameShop)
        {
            Driver.GetComponent<LinkedText>(nameShop).Click();
        }

        public void WhenUserEntryIntoCategoryByName(string folderName, string pixelFolderName)
        {Driver.GetComponent<MainCategoryDropDown>(folderName);
            Driver.Component<MainCategoryDropDown>(folderName).SelectCategoryFromDropdown(pixelFolderName);
        }

        public void WhenUserSelectBrandByFilter(string brandToLook)
        {
            /*IJavaScriptExecutor executor = (IJavaScriptExecutor) Driver;
            var linkShow = Driver.GetComponent<Checkbox>(brandToLook);
            executor.ExecuteScript("arguments[0].click();", *//*productPage.ShowFilterButton*//*linkShow);*/
            Driver.GetComponent<Checkbox>(brandToLook).Click();
        }

        public void ThenVerifyCheckboxIsSelected(string brandToLook)
        {
            var selectCheckbox =  Driver.Component<Checkbox>(brandToLook).VerifySelectedCheckbox();
            Assert.IsTrue(selectCheckbox, $"checkbox with name '{brandToLook}' is not selected");
        }

        public void WhenUserClickOnShowFilterButton()
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)Driver;
            var linkShow = Driver.GetComponent<LinkedText>("Показать");
            try
            {
                executor.ExecuteScript("arguments[0].click();", linkShow);
            }
            catch
            {
                executor.ExecuteScript("arguments[0].click();", linkShow);
            }
        }

        public void ThenVerifyDescendingPriceSorting()
        {
            var productPage = Driver.GetPage<ProductPages>();
            var
                sortDescendingPriceButton = 
                    Driver.GetComponent<LinkedText>("по цене");
            WaitUtils.WaitForElementToBeClickable(Driver, sortDescendingPriceButton);

            sortDescendingPriceButton.Click();
            WaitUtils.WaitForAllElementsInListIsVisible(Driver, By.XPath("//b[text()]//parent::a"));

            var lastPage = productPage.Pagenation.Last();
            var neededElementText = Int32.Parse(lastPage.Text);

            for (int i = 0; i < neededElementText; i++)
            {
                var allPrice = productPage.ListAllPriceOnPage;
                for (int j = 0; j < allPrice.Count - 1; j++)
                {
                    var priceWithoutText = Convert.ToInt32(allPrice[j].Text.Replace(" грн.", string.Empty).Replace(" ", string.Empty));
                    var nextPriceWithoutText = Convert.ToInt32(allPrice[j + 1].Text.Replace(" грн.", string.Empty).Replace(" ", string.Empty));

                    Assert.IsTrue(priceWithoutText <= nextPriceWithoutText, "Prices are not consistent");
                }

                try
                {
                    Driver.GetComponent<ButtonSwitchPage>("Следующая страница").Click();
                }
                catch
                {
                    continue;
                }
            }
        }

        public void ThenVerifyFilterShowActualBrand(string nameBrand)
        {
            var productPage = Driver.GetPage<ProductPages>();
            var lastPage = productPage.Pagenation.Last();
            var neededElementText = Int32.Parse(lastPage.Text);

            for (int i = 0; i < neededElementText; i++)
            {
                var allNameProduct =
                    Driver.GetComponents<ListProductsWithContainsName>(nameBrand);

                foreach (var oneItemProduct in allNameProduct)
                {
                    var oneItem = oneItemProduct.Text;
                    Assert.IsTrue(oneItem.Contains($"{nameBrand}"), "Not found");
                }

                try
                {
                    Driver.GetComponent<ButtonSwitchPage>("Следующая страница").Click();
                }
                catch
                {
                    continue;
                }
            }
        }

        public void WhenUserInputNameProductInSearchField(string productSearch)
        {
            Driver.GetComponent<Input>("Поиск товаров").SendKeys(productSearch);
            Driver.GetComponent<ButtonWithText>("Найти").Click();
        }

        public void  ThenVerifyItemForSeraching(string nameItem)
        {
            var productPage = Driver.GetPage<ProductPages>();
            var searchingItems = productPage.ListAllItemOnSearchPage;

            foreach (var searchingItem in searchingItems)
            {
                var searchResultsText = searchingItem.Text;
                Assert.IsTrue(searchResultsText.Contains(nameItem));
            }
        }
    }
}
