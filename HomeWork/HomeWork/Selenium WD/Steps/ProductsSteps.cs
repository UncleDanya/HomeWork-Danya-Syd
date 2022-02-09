using System;
using System.Collections.ObjectModel;
using System.Linq;
using HomeWork.Selenium_WD.Components;
using HomeWork.Selenium_WD.Components.Button;
using HomeWork.Selenium_WD.Components.CheckboxComponents;
using HomeWork.Selenium_WD.Components.FolderIcon;
using HomeWork.Selenium_WD.Components.Grid;
using HomeWork.Selenium_WD.Extensions;
using HomeWork.Selenium_WD.Pages;
using HomeWork.Selenium_WD.RuntimeVariables;
using HomeWork.Selenium_WD.Utils;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace HomeWork.Selenium_WD.Steps
{
    [Binding]
    class ProductsSteps : SpecFlowContext
    {
        private readonly IWebDriver driver;
        private NameProductVariable name = new NameProductVariable();

        public ProductsSteps(IWebDriver driver)
        {
            this.driver = driver;
        }


        [When(@"User choose category '(.*)' and type of product '(.*)'")]
        public void WhenUserChooseCategoryAndOfProduct(string folderName, string pixelFolderName)
        {
            driver.Component<MainCategoryDropDown>(folderName).SelectCategoryFromDropdown(pixelFolderName);
        }

        [When(@"User input name product in search field '(.*)', '(.*)'")]
        public void WhenUserInputNameProductInSearchField(string productSearch, string nameButton)
        {
            driver.GetComponent<Input>("Поиск товаров").SendKeys(productSearch);
            driver.GetComponent<ButtonWithText>(nameButton).Click();
        }

        [When(@"User select brand '(.*)' by filter")]
        public void WhenUserSelectBrandByFilter(string brandToLook)
        {
            var categoryPage = driver.GetPage<CategoryPage>();
            categoryPage.ClickCheckboxByBrand(brandToLook);
        }

        [When(@"User remember product name '(.*)'")]
        public void WhenUserRememberNameProduct(string nameProduct)
        {
            var product = driver.GetComponent<ProductsNameLink>(nameProduct);
            WaitUtils.WaitForElementToBeDisplayed(driver, product);
            var productName = product.Text;
            name.Value.Add(productName);
        }

        // The method is only used to remember a few products
        [When(@"User save all product on page in list")]
        public void WhenUserSaveAllProductOnPageInList()
        {
            var productPages = driver.GetPage<ProductPages>();
            var listWithNameProductOnPage = productPages.NamesOfAllProductsOnPage.SkipLast(4).Select(element => element.Text).ToList();
            listWithNameProductOnPage.Sort();
            name.Value = listWithNameProductOnPage;
        }

        [When(@"User add product in list")]
        public void WhenUserAddProductInList()
        {
            var productPage = driver.GetPage<ProductPages>();
            WaitUtils.WaitForElementToBeClickable(driver, productPage.HeartShapedIcon);
            productPage.HeartShapedIcon.Click();
        }

        [When(@"User navigate to '(.*)' folder on bottom bar")]
        public void WhenUserNavigateToFolderOnBottomBar(string barName)
        {
            driver.GetComponent<BottomBar>(barName).Click();
        }

        [When(@"User click on checkbox '(.*)'")]
        public void WhenUserClickOnCheckbox(string checkboxName)
        {
            driver.GetComponent<Checkbox>(checkboxName).Click();
        }
        
        [Then(@"Verify product name '(.*)' equal the product name in comparison '(.*)'")]
        public void ThenVerifyProductNameEqualTheProductNameInComprasion(string nameFirstProduct, string nameSecondProduct)
        {
            var compareProduct = driver.GetPage<CompareProductPage>();
            var nameFirstTabletInComparePage = compareProduct.NameProductForCompare(nameFirstProduct).Text;
            var nameSecondTabletInComparePage = compareProduct.NameProductForCompare(nameSecondProduct).Text;
            Assert.IsTrue(nameFirstTabletInComparePage.Contains(name.Value.First()), "The added item does not match the item on the list");
            Assert.IsTrue(nameSecondTabletInComparePage.Contains(name.Value.Last()), "The added item does not match the item on the list");
        }

        [Then(@"Verify each next price is greater than or equal to the previous one")]
        public void ThenVerifyEachNextPriceIsGreaterThanOrEqualToThePreviousOne()
        {
            var productPage = driver.GetPage<ProductPages>();
            var allPrice = productPage.ListAllPriceOnPage;
            var listReadOnly = new ReadOnlyCollection<IWebElement>(allPrice);
            WaitUtils.WaitForAllElementsInListIsVisible(driver, listReadOnly);


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
                    driver.GetComponent<ButtonIcon>("Следующая страница").Click();
                }
                catch
                {
                    continue;
                }
            }
        }

        [Then(@"Verify filter show actual brand '(.*)'")]
        public void ThenVerifyFilterShowActualBrand(string nameBrand)
        {
            var productPage = driver.GetPage<ProductPages>();
            var lastPage = productPage.Pagenation.Last();
            var neededElementText = Int32.Parse(lastPage.Text);

            for (int i = 0; i < neededElementText; i++)
            {
                var allNameProduct = driver.GetComponents<ListProductsWithContainsName>(nameBrand);

                foreach (var oneItemProduct in allNameProduct)
                {
                    var oneItem = oneItemProduct.Text;
                    Assert.IsTrue(oneItem.Contains(nameBrand), "Not found");
                }

                try
                {
                    driver.GetComponent<ButtonIcon>("Следующая страница").Click();
                }
                catch
                {
                    continue;
                }
            }
        }
        
        [Then(@"Verify list of product names matches the list of product names in bookmarks in profile")]
        public void ThenVerifyListOfProductNamesMatchesTheListOfProductNamesInBookmarksInProfile()
        {
            var productPages = driver.GetPage<ProductPages>();
            var listWithSaveProductInUserPage = productPages.NamesOfAllProductsOnPage.Select(element => element.Text).ToList();
            listWithSaveProductInUserPage.Sort();
            Assert.AreEqual(name.Value, listWithSaveProductInUserPage, "The saved item list does not match the list in the profile");
        }

        // This method is using only for the item's that has memory value in nameShop text
        [Then(@"Verify that product name in bookmarks menu equals to actual product name for mobile devices")]
        public void ThenVerifyThatProductNameInBookmarksMenuEqualsToActualProductNameForMobileDevices()
        {
            var productPage = driver.GetPage<ProductPages>();
            WaitUtils.WaitForElementToBeClickable(driver, productPage.NameProductInSaveList);
            var productNameInSaveList = productPage.NameProductInSaveList;
            var nameProductInSaveList = productNameInSaveList.Text;
            var newProductName = String.Join(" ", nameProductInSaveList.Split(' ').SkipLast(1));
            Assert.IsTrue(name.Value.Contains(newProductName), "The item added to the bookmark does not match the item in the bookmark");
        }

        [Then(@"Verify item for searching '(.*)'")]
        public void ThenVerifyItemForSearching(string nameItem)
        {
            var productPage = driver.GetPage<ProductPages>();
            var searchingItems = productPage.ListAllItemOnSearchPage;

            foreach (var searchingItem in searchingItems)
            {
                var searchResultsText = searchingItem.Text;
                Assert.IsTrue(searchResultsText.Contains(nameItem));
            }
        }

        [Then(@"Verify checkbox with brand '(.*)' is selected")]
        public void ThenVerifyNeededCheckboxWithBrandIsSelected(string brandToLook)
        {
            var categoryPage = driver.GetPage<CategoryPage>();
            Assert.IsTrue(categoryPage.SelectedCheckboxByBrand(brandToLook), $"checkbox with name '{brandToLook}' is not selected");
        }

        [Then(@"Verify that product name in other shop equals to actual product name for mobile devices")]
        public void ThenVerifyThatProductNameInOtherShopEqualsToActualProductNameForMobileDevices()
        {
            var product = driver.GetPage<ProductPages>();
            var pageShopWithItemText = product.PageShopWithItemText.Text;
            Assert.IsTrue(pageShopWithItemText.Contains(name.Value.First()));
        }
        
        [Then(@"Verify that names of the viewed products matches to the names in the viewed products in profile")]
        public void ThenVerifyNamesViewedProductsMatchesTheNamesInTheViewedProductsInProfile()
        {
            var user = driver.GetPage<UserPage>();
            var listProducts = user.NameViewedProduct.Select(element => element.Text).ToList();
            listProducts.Sort();
            name.Value.Sort();
            Assert.AreEqual(name.Value, listProducts);
        }
    }
}
