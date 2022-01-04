using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Linq;
using System.Threading;

namespace HomeWork
{
    internal class UserService
    {
        private IWebDriver driver;

        public UserService(IWebDriver driver)
        {
            this.driver = driver;
        }

        private readonly By _signInButton = By.XPath("//span[@jtype='click']");
        private readonly By _registrationButton = By.XPath("//span[@class='j-wrap orange']");
        private readonly By _nameInputButton = By.XPath("//input[@name='p_[NikName]']");
        private readonly By _emailInputButton = By.XPath("//input[@name='p_[EMail]']");
        private readonly By _passwordInputButton = By.XPath("//input[@name='p_[PW0]']");
        private readonly By _acceptRegistrationButton = By.XPath("//button[text()='ЗАРЕГИСТРИРОВАТЬСЯ']");
        private readonly By _searchInputButton = By.XPath("//input[@id='ek-search']");
        private readonly By _searchItemButton = By.XPath("//button[@name='search_but_']");
        private readonly By _acceptButton = By.XPath("//button[text()='Подтвердить']");
        private readonly By _showFilter = By.XPath("//a[text()='Показать']");
        private readonly By _addFirstCompareTablet = By.XPath("//span[text()='Apple iPad 2021']");
        private readonly By _goToTabletPage = By.XPath("//a[@link='/list/30/apple/']");
        private readonly By _addSecondCompareTablet = By.XPath("//span[text()='Apple iPad Air 2020']");
        private readonly By _toSecondCompareTablet = By.XPath("//label[@id='label_1870142']");
        private readonly By _compareButton = By.XPath("//span[@id='num_bm_compared']");
        private readonly By _firstExpectedItem = By.XPath("//table[@id='compare_table']//child::a[contains(text(),'Apple iPad 2021')]");
        private readonly By _secondExpectedItem = By.XPath("//table[@id='compare_table']//child::a[contains(text(),'Apple iPad Air')]");
        private readonly By _appleMobileItem = By.XPath("//a//span[@class='u' and text()='Apple iPhone 13']");
        private readonly By _proItemApple = By.XPath("//span[text()='Apple iPhone 13 Pro']");
        private readonly By _showAllPriceButton = By.XPath("//u[text()='Cравнить цены']");
        private readonly By _sortPriceOnPageButton = By.XPath("//a[@jtype='click' and text()='по цене']");
        private readonly By _addToBookmarksButton = By.XPath("//span[@title='Добавить в список']");
        private readonly By _bookmarksButton = By.XPath("//li[@id='bar_bm_marked' and @class='goods-bar-section']");
        private readonly By _acceptLogin = By.XPath("//a[@class='info-nick']");
        private readonly By _editProfileButton = By.XPath("//a[@class='user-menu__edit' and @title='Редактировать']");
        private readonly By _nikUserField = By.XPath("//input[@class='ek-form-control' and @name='p_[NikName]']");
        private readonly By _saveChangeUserMenu = By.XPath("//button[@class='ek-form-btn blue' and text()='СОХРАНИТЬ']");
        private readonly By _mainPageButton = By.XPath("//a[@title='E-Katalog']");
        private readonly By _saveListButton = By.XPath("//span[text()='Сохранить список']");
        private readonly By _acceptSaveListButton = By.XPath("//button[@type='submit']");
        private readonly By _showSaveList = By.XPath("//a[@class='user-menu__section wu_bookmarks ']");
        private readonly By _nameBrandSaveList = By.XPath("//span[@class='u' and text()]");
        private readonly By _nameConsoleItem = By.XPath("//span[@class='u' and text()='Sony PlayStation 5']");
        private readonly By _nameAudioItem = By.XPath("//span[@class='u' and text()='Logitech G Pro X']");
        private readonly By _searchingItems = By.XPath("//td[@class='where-buy-description']//h3[text()]");
        public By ToCompareTablet => By.XPath("//label[@id='label_2090044']");

        RandomUser randomUser = new RandomUser();

        public void CreateNewUserAccount()
        {
            var randomLogin = randomUser.CreateRandomLogin();

            var signIn = driver.FindElement(_signInButton);
            signIn.Click();

            Thread.Sleep(2000);

            var registrationButton = driver.FindElement(_registrationButton);
            registrationButton.Click();

            var inputName = driver.FindElement(_nameInputButton);
            inputName.SendKeys(randomLogin);

            var emailInput = driver.FindElement(_emailInputButton);
            emailInput.SendKeys(randomUser.CreateRandomEmail());

            var passwordInput = driver.FindElement(_passwordInputButton);
            passwordInput.SendKeys(randomUser.CreateRandomPassword());

            var acceptRegistration = driver.FindElement(_acceptRegistrationButton);
            acceptRegistration.Click();

            Thread.Sleep(2000);

            var acceptButton = driver.FindElement(_acceptButton);
            acceptButton.Click();

            var actualLogin = driver.FindElement(_acceptLogin).Text;

            Assert.AreEqual(actualLogin, randomLogin, "The actual login does not match the expected");
        }

        public void SearchFieldProductInput(string productSearch)
        {
            var searchInput = driver.FindElement(_searchInputButton);
            searchInput.SendKeys(productSearch);

            var searchButton = driver.FindElement(_searchItemButton);
            searchButton.Click();

            var searchingItems = driver.FindElements(_searchingItems);

            foreach (var searchingItem in searchingItems)
            {
                var searchResultsText = searchingItem.Text;
                Assert.IsTrue(searchResultsText.Contains(productSearch));
            }
        }

        public void CompareTest()
        {
            var firstCompareTablet = driver.FindElement(_addFirstCompareTablet);
            var oneTablet = driver.FindElement(_addFirstCompareTablet).Text;
            firstCompareTablet.Click();
            driver.FindElement(ToCompareTablet).Click();

            var backTabletPage = driver.FindElement(_goToTabletPage);
            backTabletPage.Click();

            var secondCompareTablet = driver.FindElement(_addSecondCompareTablet);
            var twoTablet = driver.FindElement(_addSecondCompareTablet).Text;
            secondCompareTablet.Click();

            var toSecondCompTablet = driver.FindElement(_toSecondCompareTablet);
            toSecondCompTablet.Click();

            Thread.Sleep(1000);

            var compButton = driver.FindElement(_compareButton);
            compButton.Click();

            var connectWindowHandles = driver.WindowHandles;

            driver.SwitchTo().Window(connectWindowHandles[1]);

            var getFirstTablet = driver.FindElement(_firstExpectedItem).Text;
            var getSecondTablet = driver.FindElement(_secondExpectedItem).Text;

            Assert.IsTrue(getFirstTablet.Contains(oneTablet), "The added item does not match the item on the list");
            Assert.IsTrue(getSecondTablet.Contains(twoTablet), "The added item does not match the item in the second list");
        }

        public void SwitchToPage()
        {
            var appleMobItem = driver.FindElement(_appleMobileItem);
            appleMobItem.Click();

            Thread.Sleep(2000);

            var linkToShop = driver.FindElement(By.XPath("//div//u[text()='Avic.ua']"));
            var textItem = driver.FindElement(By.XPath("//*[text()='Мобильный телефон Apple iPhone 13 ']")).Text;
            var nameOnlyModelItem = textItem.Replace("Мобильный телефон ", string.Empty).Replace(" ГБ", string.Empty);
            linkToShop.Click();

            var connectWindowHandles = driver.WindowHandles;
            driver.SwitchTo().Window(connectWindowHandles[1]);
            var pageShopWithItemText = driver.FindElement(By.XPath("//h1[@class='page-title']")).Text;

            Assert.IsTrue(pageShopWithItemText.Contains(nameOnlyModelItem));
        }

        public void PriceFilter()
        {
            var itemPro = driver.FindElement(_proItemApple);
            itemPro.Click();

            var showAllPr = driver.FindElement(_showAllPriceButton);
            showAllPr.Click();

            var sortPrice = driver.FindElement(_sortPriceOnPageButton);
            sortPrice.Click();

            Thread.Sleep(2000);
        }

        public void DescendingPriceFilter()
        {
            var lastPage = driver.FindElements(By.XPath(".//div[@class='ib page-num']//a")).Last();
            var neededElementText = Int32.Parse(lastPage.Text);

            for (int i = 0; i < neededElementText; i++)
            {
                var allPrice = driver.FindElements(By.XPath("//b[text()]//parent::a"));

                for (int j = 0; j < allPrice.Count - 1; j++)
                {
                    var priceWithoutText = Convert.ToInt32(allPrice[j].Text.Replace(" грн.", string.Empty).Replace(" ", string.Empty));
                    var nextPriceWithoutText = Convert.ToInt32(allPrice[j + 1].Text.Replace(" грн.", string.Empty).Replace(" ", string.Empty));
                    Assert.IsTrue(priceWithoutText <= nextPriceWithoutText, "Prices are not consistent");
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

        public void FilterProductsByBrand()
        {
            var lastPage = driver.FindElements(By.XPath(".//div[@class='ib page-num']//a")).Last();
            var neededElementText = Int32.Parse(lastPage.Text);

            for (int i = 0; i < neededElementText; i++)
            {
                var allAcer = driver.FindElements(By.XPath("//a/span[contains(text(),'Acer')]"));

                foreach (var oneItemAcer in allAcer)
                {
                    var oneItem = oneItemAcer.Text;
                    Assert.IsTrue(oneItem.Contains("Acer"), "Not found");
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

        public void AddToBookmarks()
        {
            Actions actions = new Actions(driver);

            var appleMobItem = driver.FindElement(_appleMobileItem);
            appleMobItem.Click();

            var nameTitleItem = driver.FindElement(By.XPath("//h1[@class='t2 no-mobile' and text()='Мобильный телефон Apple iPhone 13 ']")).Text;

            var addToBookmarks = driver.FindElement(_addToBookmarksButton);
            addToBookmarks.Click();

            Thread.Sleep(3000);

            var bookmarksBut = driver.FindElement(_bookmarksButton);
            bookmarksBut.Click();

            Thread.Sleep(2000);

            var textItemInBookmarks = driver.FindElement(By.XPath("//div[@class='side-list-label ' and text()='Apple iPhone 13 128GB']")).Text;
            var nameItemInBooksmarks = textItemInBookmarks.Replace("GB", string.Empty);

            Assert.IsTrue(nameTitleItem.Contains(nameItemInBooksmarks), "The item added to the bookmark does not match the item in the bookmark");
        }

        public void RenameUser()
        {
            var randomLogin = randomUser.CreateRandomLogin();

            var loginMenu = driver.FindElement(_acceptLogin);
            loginMenu.Click();

            var editProfileButton = driver.FindElement(_editProfileButton);
            editProfileButton.Click();

            var userField = driver.FindElement(_nikUserField);
            userField.Clear();

            userField.SendKeys(randomLogin);

            var saveChange = driver.FindElement(_saveChangeUserMenu);
            saveChange.Click();

            Thread.Sleep(1000);

            var mainPage = driver.FindElement(_mainPageButton);
            mainPage.Click();

            var renameLoginActual = driver.FindElement(_acceptLogin).Text;

            Assert.AreEqual(randomLogin, renameLoginActual, "The changed login does not match the profile login");
        }

        public void ItemList()
        {
            Actions actions = new Actions(driver);

            var nameList = driver.FindElements(_nameBrandSaveList).SkipLast(4).Select(element => element.Text).ToList();
            nameList.Sort();

            var saveList = driver.FindElement(_saveListButton);
            saveList.Click();

            Thread.Sleep(1000);

            var acceprSaveList = driver.FindElement(_acceptSaveListButton);
            acceprSaveList.Click();

            var userPage = driver.FindElement(_acceptLogin);
            userPage.Click();

            var showSaveList = driver.FindElement(_showSaveList);
            showSaveList.Click();

            var brandSaveList = driver.FindElements(_nameBrandSaveList).Select(element => element.Text).ToList();
            brandSaveList.Sort();

            Assert.AreEqual(nameList, brandSaveList, "The saved item sheet does not match the sheet in the profile");
        }

        public void SaveInViewedProducts()
        {
            UserService userService = new UserService(driver);
            
            userService.EntryIntoCategoryByName("Гаджеты", "Мобильные");

            userService.SearchBrandsByFilter("Apple");

            var nameTextMobileItem = driver.FindElement(_proItemApple).Text;
            var selectItemMob = driver.FindElement(_proItemApple);
            selectItemMob.Click();

            userService.EntryIntoCategoryByName("Компьютеры", "Приставки");
            userService.SearchBrandsByFilter("Sony");

            var nameTextConsoleItem = driver.FindElement(_nameConsoleItem).Text;
            var selectConsoleItem = driver.FindElement(_nameConsoleItem);
            selectConsoleItem.Click();

            userService.EntryIntoCategoryByName("Аудио", "Наушники");

            userService.SearchBrandsByFilter("Logitech");

            var nameTextAudioItem = driver.FindElement(_nameAudioItem).Text;

            var audioItem = driver.FindElement(_nameAudioItem);
            audioItem.Click();

            var userProfilePage = driver.FindElement(_acceptLogin);
            userProfilePage.Click();

            var nameMobileItemInList = driver.FindElement(By.XPath("//u[@class='nobr' and text()='Apple iPhone 13 Pr...']")).Text.Remove(16);
            var nameConsoleItemInList = driver.FindElement(By.XPath("//u[@class='nobr' and text()='Sony PlayStation 5']")).Text;
            var nameAudioItemInList = driver.FindElement(By.XPath("//u[@class='nobr' and text()='Logitech G Pro X']")).Text;

            Assert.IsTrue(nameTextMobileItem.Contains(nameMobileItemInList));
            Assert.IsTrue(nameTextConsoleItem.Contains(nameConsoleItemInList));
            Assert.IsTrue(nameTextAudioItem.Contains(nameAudioItemInList));
        }

        public void EntryIntoCategoryByName(string folderName, string pixelFolderName)
        {
            Actions actions = new Actions(driver);
            var searchFolderByName = driver.FindElement(By.XPath($"//ul[@class='mainmenu-list ff-roboto']//li[@class='mainmenu-item']//a[text()='{folderName}']"));
            actions.MoveToElement(searchFolderByName).Perform();
            Thread.Sleep(1000);
            var seachInsideFolderByName = driver.FindElement(By.PartialLinkText(pixelFolderName));
            seachInsideFolderByName.Click();
            Thread.Sleep(2000);
        }

        public void SearchBrandsByFilter(string brandToLook)
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            Actions actions = new Actions(driver);
            driver.Navigate().Refresh();
            Thread.Sleep(3000);
            var tableWithBrands = driver.FindElement(By.XPath($"//div[@id='manufacturers_presets']//ul[@class='list']//li[@class='match-li-href open']//label[@class='brand-best']//a[text()='{brandToLook}']"));
            actions.Click(tableWithBrands).Perform();
            Thread.Sleep(1000);
            try
            {
                var showBrandsFilterButton = driver.FindElement(_showFilter);
                executor.ExecuteScript("arguments[0].click();", showBrandsFilterButton);
            }
            catch
            {
                var showBrandsFilterButton = driver.FindElement(_showFilter);
                executor.ExecuteScript("arguments[0].click();", showBrandsFilterButton);
            }
        }
    }
}
