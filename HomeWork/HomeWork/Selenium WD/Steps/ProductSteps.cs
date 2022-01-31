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
        private CheckboxRuntimeVariable _checkboxRuntimeVariables = new CheckboxRuntimeVariable();

        public void WhenUserRememberNameProduct(string nameProduct)
        {
            /*var productPage = Driver.GetPage<ProductPages>();
            WaitUtils.WaitForElementToBeDisplayed(Driver, productPage.SelectProductOnPage($"{nameProduct}"));
            string nameProductText = productPage.SelectProductOnPage($"{nameProduct}").Text;
            name.Value.Add(nameProductText);*/
            var product = /*Driver.GetComponent<LinkedText>(nameProduct);*/Driver.GetComponent<ProductsNameLink>(nameProduct);
            WaitUtils.WaitForElementToBeDisplayed(Driver, product);
            var productName = product.Text;
            name.Value.Add(productName);
        }
        
        public void WhenUserSelectNeededProductOnPage(string nameProduct)
        {
            /*var productPage = Driver.GetPage<ProductPages>();
            WaitUtils.WaitForElementToBeDisplayed(Driver, productPage.SelectProductOnPage($"{nameProduct}"));
            productPage.SelectProductOnPage($"{nameProduct}").Click();*/
            //var gridProductOnPage = Driver.GetComponent<GridProducts>();
            Driver.GetComponent<LinkedText>(nameProduct).Click();
        }

        public void WhenUserAddedProductInList()
        {
            /*var productPage = Driver.GetPage<ProductPages>();
            WaitUtils.WaitForElementToBeClickable(Driver, productPage.AddedProductInList);
            productPage.AddedProductInList.Click();*/
            Driver.GetComponent<Icon>().Click();
        }

        public void WhenUserOpenBookmarksMenu()
        {
            /*var productPage = Driver.GetPage<ProductPages>();
            WaitUtils.WaitForElementToBeClickable(Driver, productPage.OpenListWithProduct);
            productPage.OpenListWithProduct.Click();*/
            var bar = Driver.GetComponent<BottomBar>("Закладки");
            WaitUtils.WaitForElementToBeClickable(Driver, bar);
            bar.Click();
        }

        // This method is using only for the item's that has memory value in nameShop text
        public void ThenVerifyThatProductNameInBookmarksMenuEqualsToActualProductNameForMobileDevices()
        {
            /*var productPage = Driver.GetPage<ProductPages>();
            WaitUtils.WaitForElementToBeClickable(Driver, productPage.NameProductInSaveList);
            var productNameInSaveList = productPage.NameProductInSaveList;
            var nameProductInSaveList = productNameInSaveList.Text;
            var newProductName = String.Join(" ", nameProductInSaveList.Split(' ').SkipLast(1));
            Assert.IsTrue(name.Value.Contains(newProductName), "The item added to the bookmark does not match the item in the bookmark");*/
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            /*var slide = */Driver.GetComponent<BottomSideSlide>();
            // WaitUtils.WaitForElementToBeClickable(Driver, slide);
            var newProductName = Driver.Component<BottomSideSlide>().TextProductInSlide();
            // WaitUtils.WaitForElementToBeClickable(Driver, newProductName);
            // var nameProduct = newProductName.Text.Replace(" 128GB", String.Empty);
            var nameProductInSaveList = newProductName.Text;
            var nameProduct = String.Join(" ", nameProductInSaveList.Split(' ').SkipLast(1));
            // WaitUtils.WaitForElementToBeClickable(Driver, newProductName);
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
            Assert.IsTrue(name.Value.Contains(nameProduct), "The item added to the bookmark does not match the item in the bookmark");
        }

        public void ThenVerifyProductNameForCompareTwoItems(string nameFirstProduct, string nameSecondProduct)
        {
            /*var compareProduct = Driver.GetPage<CompareProductPage>();
            var nameFirstTabletInComparePage = compareProduct.NameProductForCompare($"{nameFirstProduct}").Text;
            var nameSecondTabletInComparePage = compareProduct.NameProductForCompare($"{nameSecondProduct}").Text;*/
            var nameFirstTabletInComparePage =
                Driver.Component<LinkedText>("Планшеты").ForCompareNameProducts(nameFirstProduct).Text;
            var nameSecondTabletInComparePage =
                Driver.Component<LinkedText>("Планшеты").ForCompareNameProducts(nameSecondProduct).Text;
            Assert.IsTrue(nameFirstTabletInComparePage.Contains(name.Value.First()), "The added item does not match the item on the list");
            Assert.IsTrue(nameSecondTabletInComparePage.Contains(name.Value.Last()), "The added item does not match the item on the list");
        }

        public void WhenUserSaveAllProductOnPageInList()
        {
            // var productPages = Driver.GetPage<ProductPages>();
            var listWithNameProductOnPage = /*productPages.NamesOfAllProductsOnPage*/Driver.Component<GridProducts>().ListNameProdcuts().SkipLast(4).Select(element => element.Text).ToList();
            listWithNameProductOnPage.Sort();
            name.Value = listWithNameProductOnPage;
        }

        public void ThenVerifyListSaveInProductPageForListInUserPage()
        {
            var productPages = /*Driver.GetPage<ProductPages>();*/Driver.Component<NameProduct>().ListNameProducts();
            var listWithSaveProductInUserPage = productPages/*.NamesOfAllProductsOnPage*/.Select(element => element.Text).ToList();
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
            var product = /*Driver.GetPage<ProductPages>();*/Driver.GetComponent<TitleProductOnOtherShop>();
            var pageShopWithItemText = product/*.PageShopWithItemText*/.Text;
            Assert.IsTrue(pageShopWithItemText.Contains(name.Value.First()));
        }

        public void ThenVerifySaveListProductForListInUserPage()
        {
            var user = /*Driver.GetPage<UserPage>();*/Driver.Component<NameProductsViewed>().ListNameProductsViewe();
            var listProducts = user/*.NameViewedProduct*/.Select(element => element.Text).ToList();
            listProducts.Sort();
            name.Value.Sort();
            Assert.AreEqual(name.Value, listProducts);
        }

        public void WhenUserAddedToCompareCheckboxProduct()
        {
            /*var productPages = Driver.GetPage<ProductPages>();
            productPages.AddedToCompareCheckboxProduct.Click();*/
            Driver.GetComponent<Checkbox>("добавить в сравнение").Click();
        }

        public void WhenUserSwitchToPageWithTablet()
        {
            /*var productPages = Driver.GetPage<ProductPages>();
            WaitUtils.WaitForElementToBeClickable(Driver, productPages.SwitchToPageWithTablet);
            productPages.SwitchToPageWithTablet.Click();*/
            Driver.GetComponent<LinkedText>("Apple").Click();
        }

        public void WhenUserSwitchToComparePage()
        {
            /*var productPages = Driver.GetPage<ProductPages>();
            WaitUtils.WaitForElementToBeClickable(Driver, productPages.SwitchToComparePage);
            productPages.SwitchToComparePage.Click();*/
            Driver.GetComponent<BottomBar>("Сравнить").Click();
        }

        public void WhenUserShowAllPriceOnProductButton()
        {
            /*var productPages = Driver.GetPage<ProductPages>();
            productPages.ShowAllPriceOnProductButton.Click();*/
            Driver.GetComponent<LinkedText>("Cравнить цены").Click();
        }

        public void WhenUserClickOnSaveItemInList()
        {
            /*var productPages = Driver.GetPage<ProductPages>();
            productPages.SaveListProductOnPage.Click();*/
            Driver.GetComponent<Icon>().Click();
        }

        public void WhenUserClickOnSubmitSaveListButton()
        {
            var productPages = Driver.GetComponent<ButtonSubmit>();
            Driver.Component<ButtonSubmit>().Wait();
            WaitUtils.WaitForElementToBeClickable(Driver, productPages);
            productPages.Click();
        }

        public void WhenUserSwitchToUserPage()
        {
            var mainPage = /*Driver.GetPage<MainPage>();*/Driver.GetComponent<LogIn>();
            WaitUtils.WaitForElementToBeClickable(Driver, mainPage);
            mainPage.Click();
        }

        public void WhenUserClickOnNameShop(string nameShop)
        {
            /*var productPage = Driver.GetPage<ProductPages>();
            productPage.NameShopLinkText(nameShop).Click();*/
            Driver.GetComponent<LinkedText>("Avic.ua").Click();
        }

        public void WhenUserEntryIntoCategoryByName(string folderName, string pixelFolderName)
        {
            /*var searchFolderByName = Driver.FindElement(By.XPath($"//ul[@class='mainmenu-list ff-roboto']//li[@class='mainmenu-item']//a[text()='{folderName}']"));
            searchFolderByName.Click();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            
            var seachInsideFolderByName = Driver.FindElement(By.PartialLinkText(pixelFolderName));
            seachInsideFolderByName.Click();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);*/
            /*var mainDropdown = */Driver.GetComponent<MainCategoryDropDown>(folderName);
            // mainDropdown.Click();
            Driver.Component<MainCategoryDropDown>(folderName).SelectCategoryFromDropdown(pixelFolderName);
            /*var folderMainItem = Driver.GetComponent<MainCategoryDropDown>($"{folderName}");
            folderMainItem.Click();
            var folderSublictItem = Driver.GetComponent<FolderSublistItem>($"{pixelFolderName}");
            folderSublictItem.Click();*/
        }

        public void WhenUserSelectBrandByFilter(string brandToLook)
        {
            /*Actions actions = new Actions(Driver);

            var tableWithBrands = Driver.FindElement(By.XPath($"//label[@class='brand-best']//a[text()='{brandToLook}']"));
            _checkboxRuntimeVariables.Value = tableWithBrands;
            actions.Click(tableWithBrands).Perform();*/
            Driver.GetComponent<Checkbox>(brandToLook);
        }

        public void ThenVerifyCheckboxIsSelected(string brandToLook)
        {
            /*var checkBoxVariable = _checkboxRuntimeVariables.Value;

            var color = checkBoxVariable.GetCssValue("Color");
            var checkBoxElement = Driver.FindElement(By.XPath($"//label[@class='brand-best']//a[text()='{brandToLook}']//ancestor::li//input")).Selected;
            
            Assert.AreEqual(color, "rgb(255, 141, 2)");
            Assert.IsTrue(checkBoxElement, $"Button {brandToLook} is not selected");*/
            Driver.GetComponent<Checkbox>(brandToLook);
            Driver.Component<Checkbox>(brandToLook).VerifySelectedCheckbox();
        }

        public void WhenUserClickOnShowFilterButton()
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)Driver;
            // var productPage = Driver.GetPage<ProductPages>();
            var linkShow = Driver.GetComponent<LinkedText>("Показать");
            try
            {
                // WaitUtils.WaitForElementToBeClickable(Driver, /*productPage.ShowFilterButton*/linkShow);
                executor.ExecuteScript("arguments[0].click();", /*productPage.ShowFilterButton*/linkShow);
            }
            catch
            {
                // WaitUtils.WaitForElementToBeClickable(Driver, /*productPage.ShowFilterButton*/linkShow);
                executor.ExecuteScript("arguments[0].click();", /*productPage.ShowFilterButton*/linkShow);
            }
        }

        public void ThenVerifyDescendingPriceSorting()
        {
            // var productPage = Driver.GetPage<ProductPages>();
            var
                sortDescendingPriceButton = /*Driver.FindElement(By.XPath(".//a[@jtype='click' and text()='по цене']"));*/
                    Driver.GetComponent<LinkedText>("по цене");
            /*var listPriceOnPage = */Driver.Component<GridWhereBuyPorducts>().PriceList();
            WaitUtils.WaitForElementToBeClickable(Driver, sortDescendingPriceButton);

            sortDescendingPriceButton.Click();
            //WaitUtils.WaitForAllElementsInListIsVisible(Driver, By.XPath("//b[text()]//parent::a"));
            Driver.Component<GridWhereBuyPorducts>().Waiter();

            var lastPage = /*Driver.FindElements(By.XPath(".//div[@class='ib page-num']//a")).Last();*/
            Driver.Component<Pagenation>().ListPages().Last();
            var neededElementText = Int32.Parse(lastPage.Text);

            for (int i = 0; i < neededElementText; i++)
            {
                var allPrice = /*productPage.ListAllPriceOnPage;*/ /*Driver.Component<Price>().ListPrice();*/
                    Driver.Component<GridWhereBuyPorducts>().PriceList();
                for (int j = 0; j < allPrice.Count - 1; j++)
                {
                    var priceWithoutText = Convert.ToInt32(allPrice[j].Text.Replace(" грн.", string.Empty).Replace(" ", string.Empty));
                    var nextPriceWithoutText = Convert.ToInt32(allPrice[j + 1].Text.Replace(" грн.", string.Empty).Replace(" ", string.Empty));

                    Assert.IsTrue(priceWithoutText <= nextPriceWithoutText, "Prices are not consistent");
                }

                try
                {
                    /*var nextPageButton = Driver.FindElement(By.XPath("//a[@id='pager_next']"));
                    nextPageButton.Click();*/
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
            var lastPage = /*Driver.FindElements(By.XPath(".//div[@class='ib page-num']//a")).Last();*/
                Driver.Component<Pagenation>().ListPages().Last();
            var neededElementText = Int32.Parse(lastPage.Text);

            for (int i = 0; i < neededElementText; i++)
            {
                // var a = Driver.GetComponent<GridProducts>();
                var allNameProduct = /*Driver.FindElements(By.XPath($"//a/span[contains(text(),'{nameBrand}')]"));*/
                    /*Driver.Component<LinkedText>(nameBrand ,a).ListContainsName(nameBrand);*/
                    Driver.Component<GridProducts>().ListProducts(nameBrand);

                foreach (var oneItemAcer in allNameProduct)
                {
                    var oneItem = oneItemAcer.Text;
                    Assert.IsTrue(oneItem.Contains($"{nameBrand}"), "Not found");
                }

                try
                {
                    /*var nextPageButton = Driver.FindElement(By.XPath("//a[@id='pager_next']"));
                    nextPageButton.Click();*/
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
            // Driver.FindElement(By.XPath("//input[@id='ek-search']")).SendKeys(productSearch);
            Driver.GetComponent<Input>("Поиск товаров").SendKeys(productSearch);
            Driver.GetComponent<Button>("Найти").Click();

            /*var searchButton = Driver.FindElement(By.Name("search_but_"));
            searchButton.Click();*/
        }

        public void  ThenVerifyItemForSeraching(string nameItem)
        {
            var productPage = /*Driver.GetPage<ProductPages>();*/Driver.Component<ProductsNameLink>(nameItem).ListName();
            var searchingItems = productPage/*.ListAllItemOnSearchPage*/;

            foreach (var searchingItem in searchingItems)
            {
                var searchResultsText = searchingItem.Text;
                Assert.IsTrue(searchResultsText.Contains(nameItem));
            }
        }
    }
}
