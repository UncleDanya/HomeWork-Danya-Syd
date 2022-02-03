using System;
using System.Collections.ObjectModel;
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

        public void WhenUserClickOnLinkedText(string linkedText)
        {
            WaitUtils.WaitForElementToBeDisplayed(Driver, Driver.GetComponent<LinkedText>(linkedText));
            Driver.GetComponent<LinkedText>(linkedText).Click();
        }

        public void WhenUserAddedProductInList()
        {
            var productPage = Driver.GetPage<ProductPages>();
            WaitUtils.WaitForElementToBeClickable(Driver, productPage.HeartShapedIcon);
            productPage.HeartShapedIcon.Click();
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
            var nameFirstTabletInComparePage = compareProduct.NameProductForCompare(nameFirstProduct).Text;
            var nameSecondTabletInComparePage = compareProduct.NameProductForCompare(nameSecondProduct).Text;
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

        public void WhenUserClickOnCheckbox(string checkboxName)
        {
            Driver.GetComponent<Checkbox>(checkboxName).Click();
        }

        public void WhenUserSwitchToBottomBarMenuPage(string barName)
        {
            Driver.GetComponent<BottomBar>(barName).Click();
        }

        public void WhenUserClickOnTypeButton(string typeButton)
        {
            var productPages = Driver.GetComponent<ButtonType>(typeButton);
            WaitUtils.WaitForElementToBeClickable(Driver, productPages);
            productPages.Click();
        }

        public void WhenUserSwitchToUserPage()
        {
            var mainPage = Driver.GetPage<MainPage>();
            WaitUtils.WaitForElementToBeClickable(Driver, mainPage.ActualLogin);
            mainPage.ActualLogin.Click();
        }

        public void WhenUserEntryIntoCategoryByName(string folderName, string pixelFolderName)
        {
            Driver.Component<MainCategoryDropDown>(folderName).SelectCategoryFromDropdown(pixelFolderName);
        }

        public void WhenUserSelectBrandByFilter(string brandToLook)
        {
            var categoryPage = Driver.GetPage<CategoryPage>();
            categoryPage.ClickCheckboxByBrand(brandToLook);
        }

        public void ThenVerifyFilterCheckboxIsSelected(string brandToLook)
        {
            var categoryPage = Driver.GetPage<CategoryPage>();
            Assert.IsTrue(categoryPage.SelectedCheckboxByBrand(brandToLook), $"checkbox with name '{brandToLook}' is not selected");
        }

        public void ThenVerifyDescendingPriceSorting()
        {
            var productPage = Driver.GetPage<ProductPages>();
            var allPrice = productPage.ListAllPriceOnPage;
            var listReadOnly = new ReadOnlyCollection<IWebElement>(allPrice);
            WaitUtils.WaitForAllElementsInListIsVisible(Driver, listReadOnly);


            var lastPage = productPage.Pagenation.Last();
            var neededElementText = Int32.Parse(lastPage.Text);

            for (int i = 0; i < neededElementText; i++)
            {
                for (int j = 0; j < allPrice.Count - 1; j++)
                {
                    var priceWithoutText = Convert.ToInt32(allPrice[j].Text.Replace(" грн.", string.Empty).Replace(" ", string.Empty));
                    var nextPriceWithoutText = Convert.ToInt32(allPrice[j + 1].Text.Replace(" грн.", string.Empty).Replace(" ", string.Empty));

                    Assert.IsTrue(priceWithoutText <= nextPriceWithoutText, "Prices are not consistent");
                }

                try
                {
                    Driver.GetComponent<ButtonIcon>("Следующая страница").Click();
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
                var allNameProduct = Driver.GetComponents<ListProductsWithContainsName>(nameBrand);

                foreach (var oneItemProduct in allNameProduct)
                {
                    var oneItem = oneItemProduct.Text;
                    Assert.IsTrue(oneItem.Contains(nameBrand), "Not found");
                }

                try
                {
                    Driver.GetComponent<ButtonIcon>("Следующая страница").Click();
                }
                catch
                {
                    continue;
                }
            }
        }

        public void WhenUserInputNameProductInSearchField(string productSearch, string nameButton)
        {
            Driver.GetComponent<Input>("Поиск товаров").SendKeys(productSearch);
            Driver.GetComponent<ButtonWithText>(nameButton).Click();
        }

        public void ThenVerifyItemForSearching(string nameItem)
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
