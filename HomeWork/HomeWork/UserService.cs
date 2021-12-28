using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HomeWork
{
    internal class UserService
    {
        private IWebDriver driver;

        public UserService(IWebDriver driver)
        {
            this.driver = driver;
        }

        /*IJavaScriptExecutor executor;

        public UserService(IJavaScriptExecutor executor)
        {
            this.executor = executor;
        }*/

        /*private UserService service;

        public UserService(UserService service)
        {
            this.service = service;
        }*/

        /*private Actions actions;
        public UserService(Actions actions)
        {
            this.actions = actions;
        }*/

        private readonly By _signInButton = By.XPath("//span[@jtype='click']");
        private readonly By _registrationButton = By.XPath("//span[@class='j-wrap orange']");
        private readonly By _nameInputButton = By.XPath("//input[@name='p_[NikName]']");
        private readonly By _emailInputButton = By.XPath("//input[@name='p_[EMail]']");
        private readonly By _passwordInputButton = By.XPath("//input[@name='p_[PW0]']");
        private readonly By _acceptRegistrationButton = By.XPath("//button[text()='ЗАРЕГИСТРИРОВАТЬСЯ']");
        private readonly By _searchInputButton = By.XPath("//input[@id='ek-search']");
        private readonly By _searchItemButton = By.XPath("//button[@name='search_but_']");
        private readonly By _acceptButton = By.XPath("//button[text()='Подтвердить']");
        private readonly By _computerPage = By.XPath("//a[text()='Компьютеры']");
        private readonly By _dropComputer = By.XPath("//a[@class='mainmenu-subitem mainmenu-icon298']");
        private readonly By _brandLaptop = By.XPath("//label[@for='br189']");
        private readonly By _showFilter = By.XPath("//a[text()='Показать']");
        private readonly By _nextPageButton = By.XPath("//a[@id='pager_next']");
        private readonly By _computerDropButton = By.XPath("//a[text()='Компьютеры']");
        private readonly By _tabletPage = By.XPath("//a[@class='mainmenu-subitem mainmenu-icon30']");
        private readonly By _tabletBrand = By.XPath("//label[@for='br116']");
        private readonly By _addFirstCompareTablet = By.XPath("//span[text()='Apple iPad 2021']");
        private readonly By _goToTabletPage = By.XPath("//a[@link='/list/30/apple/']");
        private readonly By _addSecondCompareTablet = By.XPath("//span[text()='Apple iPad Air 2020']");
        private readonly By _toSecondCompareTablet = By.XPath("//label[@id='label_1870142']");
        private readonly By _compareButton = By.XPath("//span[@id='num_bm_compared']");
        private readonly By _firstExpectedItem = By.XPath("//table[@id='compare_table']//child::a[contains(text(),'Apple iPad 2021')]");
        private readonly By _secondExpectedItem = By.XPath("//table[@id='compare_table']//child::a[contains(text(),'Apple iPad Air')]");
        private readonly By _gadjetItemButton = By.XPath("//a[text()='Гаджеты']");
        private readonly By _gadjetDropButton = By.XPath("//a[@href='/k122.htm' and @class='mainmenu-subitem mainmenu-icon122']");
        private readonly By _moBileBrandFilterButton = By.XPath("//label[@class='brand-best' and @for='br116']");
        private readonly By _appleMobileItem = By.XPath("//a//span[@class='u' and text()='Apple iPhone 13']");
        private readonly By _mobilePageItem = By.XPath("//tr[@class='tr-odd shop-97974']//a[@class='it-shop']");
        private readonly By _appleTitleText = By.XPath("//tr[@class='tr-odd shop-97974']//td//h3[text()=' Смартфон Apple iPhone 13 128Gb Midnight']");
        private readonly By _pageVodaItem = By.XPath("//span[@class='base' and text()='Смартфон Apple iPhone 13 128Gb Midnight']");
        private readonly By _nameMagazine = By.XPath("//a[text()='Vodafone.ua']");
        private readonly By _priceAllItem = By.XPath("//b[text()]//parent::a");
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
        private readonly By _audioPageButton = By.XPath("//a[@href='/k10.htm' and text()='Аудио']");
        private readonly By _audioPageDropButton = By.XPath("//li[@class='mainmenu-item']//a[text()='Аудио']//following-sibling::div//a[@href='/k239.htm']");
        private readonly By _audioBrandFilter = By.XPath("//label[@for='br124']");
        private readonly By _saveListButton = By.XPath("//span[text()='Сохранить список']");
        private readonly By _acceptSaveListButton = By.XPath("//button[@type='submit']");
        private readonly By _showSaveList = By.XPath("//a[@class='user-menu__section wu_bookmarks ']");
        private readonly By _nameBrandSaveList = By.XPath("//span[@class='u' and text()]");
        private readonly By _consoleDropButton = By.XPath("//li[@class='mainmenu-item']//a[text()='Компьютеры']//following-sibling::div//a[@href='/k33.htm']");
        private readonly By _filterOnConsolePage = By.XPath("//label[@class='brand-best' and @for='br156']");
        private readonly By _nameConsoleItem = By.XPath("//span[@class='u' and text()='Sony PlayStation 5']");
        private readonly By _nameAudioItem = By.XPath("//span[@class='u' and text()='Logitech G Pro X']");
        private readonly By _searchingItems = By.XPath("//td[@class='where-buy-description']//h3[text()]");


        private const string _registrationName = "User1";
        private const string _registrationEmail = "danya.sydortsov@tech-stack.io";
        private const string _registrationPassword = "Password123";
        private const string _searchingItem = "iPhone 13 Pro 256";

        //public By Computer => By.XPath("//a[@class='cancel-click mainmenu-link']");
        public By ToCompareTablet => By.XPath("//label[@id='label_2090044']");

        RandomUser rndUs = new RandomUser();

        public void Create()
        {
            var rndLg = rndUs.CreateRandomLogin();

            var signIn = driver.FindElement(_signInButton);
            signIn.Click();

            Thread.Sleep(2000);

            var registrationButton = driver.FindElement(_registrationButton);
            registrationButton.Click();

            Thread.Sleep(1000);

            var inputName = driver.FindElement(_nameInputButton);
            inputName.SendKeys(rndLg);

            var emailInput = driver.FindElement(_emailInputButton);
            emailInput.SendKeys(rndUs.CreateRandomEmail());

            var passwordInput = driver.FindElement(_passwordInputButton);
            passwordInput.SendKeys(rndUs.CreateRandomPassword());

            var acceptRegistration = driver.FindElement(_acceptRegistrationButton);
            acceptRegistration.Click();

            Thread.Sleep(2000);

            var acceptButton = driver.FindElement(_acceptButton);
            acceptButton.Click();

            var actualLogin = driver.FindElement(_acceptLogin).Text;

            Assert.AreEqual(actualLogin, rndLg, "Wrong!");
        }

        public void Search()
        {
            var searchInput = driver.FindElement(_searchInputButton);
            searchInput.SendKeys(_searchingItem);

            var searchButton = driver.FindElement(_searchItemButton);
            searchButton.Click();

            Thread.Sleep(2000);

            var searchingItems = driver.FindElements(_searchingItems)/*Select(element => element.Text).ToList()*/;

            foreach (var searchingItem in searchingItems)
            {
                var a = searchingItem.Text;

                Assert.IsTrue(a.Contains(_searchingItem));
            }

            // var textItems = searchingItems.ElementAt(0).Text;

            // Assert.IsTrue(_searchingItem.Contains(searchingItems), "Wrong!");
        }

        public void EnterComputer()
        {
            Actions actions = new Actions(driver);

            var enterComputer = driver.FindElement(_computerPage);
            actions.MoveToElement(enterComputer).Perform();

            Thread.Sleep(3000);

            var dropComputer = driver.FindElement(_dropComputer);
            dropComputer.Click();

            var filterBrands = driver.FindElement(_brandLaptop);
            filterBrands.Click();

            Thread.Sleep(2000);

            var showFilter = driver.FindElement(_showFilter);
            showFilter.Click();
        }

        public void AddTablet()
        {
            Actions actions = new Actions(driver);

            var computerDrop = driver.FindElement(_computerDropButton);
            actions.MoveToElement(computerDrop).Perform();

            Thread.Sleep(2000);

            var tabletPage = driver.FindElement(_tabletPage);
            tabletPage.Click();

            var tabletBrand = driver.FindElement(_tabletBrand);
            tabletBrand.Click();

            Thread.Sleep(1000);

            var showFilterTabler = driver.FindElement(_showFilter);
            showFilterTabler.Click();
        }

        /*public void AddCompareFirstTablet()
        {
            var firstCompareTablet = driver.FindElement(_addFirstCompareTablet);
            firstCompareTablet.Click();
            driver.FindElement(ToCompareTablet).Click();
        }

        public void AddCompareSecondTablet()
        {
            var backTabletPage = driver.FindElement(_goToTabletPage);
            backTabletPage.Click();
            var secondCompareTablet = driver.FindElement(_addSecondCompareTablet);
            secondCompareTablet.Click();
            var toSecondCompTablet = driver.FindElement(_toSecondCompareTablet);
            toSecondCompTablet.Click();
            Thread.Sleep(1000);
        }

        public void CompareItem()
        {
            var compButton = driver.FindElement(_compareButton);
            compButton.Click();
            var getFirstTablet = 
        }*/

        public void CompareTest()
        {
            var firstCompareTablet = driver.FindElement(_addFirstCompareTablet);
            var oneTabler = driver.FindElement(_addFirstCompareTablet).Text;
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

            // Thread.Sleep(5000);

            var a = driver.WindowHandles;

            driver.SwitchTo().Window(a[1]);

            var getFirstTablet = driver.FindElement(_firstExpectedItem).Text;
            var getSecondTablet = driver.FindElement(_secondExpectedItem).Text;

            Assert.IsTrue(getFirstTablet.Contains(oneTabler), "Wronh!!");
            Assert.IsTrue(getSecondTablet.Contains(twoTablet), "Wronh2!!");
        }

        public void SwitchToPage()
        {
            Actions actions = new Actions(driver);

            var gadjetItem = driver.FindElement(_gadjetItemButton);
            actions.MoveToElement(gadjetItem).Perform();

            Thread.Sleep(1000);

            var gadjetDropBut = driver.FindElement(_gadjetDropButton);
            gadjetDropBut.Click();

            var filterMobileBrand = driver.FindElement(_moBileBrandFilterButton);
            filterMobileBrand.Click();

            Thread.Sleep(1000);

            var showFilter = driver.FindElement(_showFilter);
            showFilter.Click();

            var appleMobItem = driver.FindElement(_appleMobileItem);
            appleMobItem.Click();

            Thread.Sleep(2000);

            var linkToMagazine = driver.FindElement(_mobilePageItem);
            actions.MoveToElement(linkToMagazine);

            var nameMagaz = driver.FindElement(_nameMagazine).Text;

            var textItem = driver.FindElement(_appleTitleText).Text;

            linkToMagazine.Click();

            var a = driver.WindowHandles;
            driver.SwitchTo().Window(a[1]);

            var pageWithItem = driver.FindElement(_pageVodaItem).Text;

            Assert.AreEqual(textItem, pageWithItem, "Wrong!!");
        }

        public void PriceFilter()
        {
            Actions actions = new Actions(driver);

            var gadjetItem = driver.FindElement(_gadjetItemButton);
            actions.MoveToElement(gadjetItem).Perform();

            Thread.Sleep(1000);

            var gadjetDropButton = driver.FindElement(_gadjetDropButton);
            gadjetDropButton.Click();

            var filterMobileBrand = driver.FindElement(_moBileBrandFilterButton);
            filterMobileBrand.Click();

            Thread.Sleep(1000);

            var showFilter = driver.FindElement(_showFilter);
            showFilter.Click();

            // Thread.Sleep(2000);

            var itemPro = driver.FindElement(_proItemApple);
            // actions.MoveToElement(itemPro).Perform();
            itemPro.Click();

            var showAllPr = driver.FindElement(_showAllPriceButton);
            showAllPr.Click();

            // Thread.Sleep(2000);

            var sortPrice = driver.FindElement(_sortPriceOnPageButton);
            sortPrice.Click();

            Thread.Sleep(2000);

            // var listAllPrice = driver.FindElements(_priceAllItem);
        }

        public void AddToBookmarks()
        {
            Actions actions = new Actions(driver);

            var gadjetMenu = driver.FindElement(_gadjetItemButton);
            actions.MoveToElement(gadjetMenu).Perform();

            Thread.Sleep(1000);

            var mobileMenu = driver.FindElement(_gadjetDropButton);
            mobileMenu.Click();

            var filterMobileBrand = driver.FindElement(_moBileBrandFilterButton);
            filterMobileBrand.Click();

            Thread.Sleep(1000);

            var showFilter = driver.FindElement(_showFilter);
            showFilter.Click();

            var appleMobItem = driver.FindElement(_appleMobileItem);
            appleMobItem.Click();

            var nameTitleItem = driver.FindElement(By.XPath("//h1[@class='t2 no-mobile' and text()='Мобильный телефон Apple iPhone 13 ']")).Text;

            // Thread.Sleep(2000);

            var addToBookmarks = driver.FindElement(_addToBookmarksButton);
            addToBookmarks.Click();

            // Thread.Sleep(1000);

            var bookMarksBut = driver.FindElement(_addToBookmarksButton);
            bookMarksBut.Click();

            // Thread.Sleep(1000);

            var bookmarksBut = driver.FindElement(_bookmarksButton);
            bookmarksBut.Click();

            Thread.Sleep(2000);

            var textItemInBookmarks = driver.FindElement(By.XPath("//div[@class='side-list-label ' and text()='Apple iPhone 13 128GB']")).Text;
            var nameItemInBooksmarks = textItemInBookmarks.Replace("GB", "");

            Assert.IsTrue(nameTitleItem.Contains(nameItemInBooksmarks), "Wrong");
        }

        public void RenameUser()
        {
            // Actions actions = new Actions(driver);

            var rndLog = rndUs.CreateRandomLogin();

            var loginMenu = driver.FindElement(_acceptLogin);
            loginMenu.Click();

            var editProfileButton = driver.FindElement(_editProfileButton);
            editProfileButton.Click();

            var userField = driver.FindElement(_nikUserField);
            userField.Clear();

            // Thread.Sleep(1000);

            userField.SendKeys(rndLog);

            // Thread.Sleep(2000);

            var saveChange = driver.FindElement(_saveChangeUserMenu);
            saveChange.Click();

            var mainPage = driver.FindElement(_mainPageButton);
            mainPage.Click();

            // Thread.Sleep(4000);

            var renameLoginActual = driver.FindElement(_acceptLogin).Text;

            // var verActLog = rndLog;

            Assert.AreEqual(renameLoginActual, rndLog, "Wrong!");
        }

        public void ItemList()
        {
            Actions actions = new Actions(driver);

            var audioPage = driver.FindElement(_audioPageButton);
            actions.MoveToElement(audioPage).Perform();

            Thread.Sleep(1000);

            var audioDropButton = driver.FindElement(_audioPageDropButton);
            audioDropButton.Click();

            var audioBrandFilter = driver.FindElement(_audioBrandFilter);
            audioBrandFilter.Click();

            Thread.Sleep(1000);

            var showFilter = driver.FindElement(_showFilter);
            showFilter.Click();

            // Thread.Sleep(2000);

            var nameList = driver.FindElements(_nameBrandSaveList).SkipLast(4).Select(element => element.Text).ToList();
            nameList.Sort();

            var saveList = driver.FindElement(_saveListButton);
            saveList.Click();

            Thread.Sleep(1000);

            var acceprSaveList = driver.FindElement(_acceptSaveListButton);
            acceprSaveList.Click();

            // Thread.Sleep(3000);

            var userPage = driver.FindElement(_acceptLogin);
            userPage.Click();

            var showSaveList = driver.FindElement(_showSaveList);
            showSaveList.Click();

            var brandSaveList = driver.FindElements(_nameBrandSaveList).Select(element => element.Text).ToList();
            brandSaveList.Sort();

            Assert.AreEqual(nameList, brandSaveList, "Wrong");
        }

        public void SaveInViewedProducts()
        {
            Actions actions = new Actions(driver);

            var gadjetPage = driver.FindElement(_gadjetItemButton);
            actions.MoveToElement(gadjetPage).Perform();

            Thread.Sleep(1000);

            var gadjetButton = driver.FindElement(_gadjetDropButton);
            gadjetButton.Click();

            var selectBrandMob = driver.FindElement(_moBileBrandFilterButton);
            selectBrandMob.Click();

            // Thread.Sleep(1000);

            var showFilte = driver.FindElement(_showFilter);
            showFilte.Click();

            // Thread.Sleep(1000);

            var nameTextMobileItem = driver.FindElement(_proItemApple).Text;
            var selectItemMob = driver.FindElement(_proItemApple);
            selectItemMob.Click();

            // Thread.Sleep(1000);

            var computerItems = driver.FindElement(_computerPage);

            // Thread.Sleep(1000);

            computerItems.Click();

            var consolePage = driver.FindElement(_consoleDropButton);
            consolePage.Click();
            driver.Navigate().Refresh();

            var filterBrandConsole = driver.FindElement(_filterOnConsolePage);
            filterBrandConsole.Click();

            // Thread.Sleep(3000);

            var showFiletConsole = driver.FindElement(_showFilter);

            // Thread.Sleep(3000);

            showFiletConsole.Click();

            var nameTextConsoleItem = driver.FindElement(_nameConsoleItem).Text;
            var selectConsoleItem = driver.FindElement(_nameConsoleItem);
            selectConsoleItem.Click();

            var audioPage = driver.FindElement(_audioPageButton);
            audioPage.Click();

            var audioPageTo = driver.FindElement(_audioPageDropButton);
            audioPageTo.Click();

            driver.Navigate().Refresh();

            var filterOnAudioPage = driver.FindElement(_audioBrandFilter);

            // Thread.Sleep(3000);

            filterOnAudioPage.Click();

            var showFilterAudio = driver.FindElement(_showFilter);

            // Thread.Sleep(3000);

            showFilterAudio.Click();

            // Thread.Sleep(1000);

            var nameTextAudioItem = driver.FindElement(_nameAudioItem).Text;

            var audioItem = driver.FindElement(_nameAudioItem);
            audioItem.Click();

            var userProfilePage = driver.FindElement(_acceptLogin);
            userProfilePage.Click();

            var nameMobItWgLi = driver.FindElement(By.XPath("//u[@class='nobr' and text()='Apple iPhone 13 Pr...']")).Text.ElementAt(15);
            var nameConsItWgLi = driver.FindElement(By.XPath("//u[@class='nobr' and text()='Sony PlayStation 5']")).Text;
            var nameAudioItWgLi = driver.FindElement(By.XPath("//u[@class='nobr' and text()='Logitech G Pro X']")).Text;

            Assert.IsTrue(nameTextMobileItem.Contains(nameMobItWgLi));
            Assert.IsTrue(nameTextConsoleItem.Contains(nameConsItWgLi));
            Assert.IsTrue(nameTextAudioItem.Contains(nameAudioItWgLi));
        }

    }
}
