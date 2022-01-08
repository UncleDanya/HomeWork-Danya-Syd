﻿using HomeWork.Selenium_WD.Functional;
using HomeWork.Selenium_WD.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Linq;
using System.Threading;

namespace HomeWork
{
    internal class FilterPriceTest
    {
        private IWebDriver driver;
        private UserService service;
        private EntryCategory category;
        private FilterBrands filterBrands;
        private PageMobileProductApple pageMobileProductApple;
        private PageMobileiPhone13Pro pageMobileiPhone13Pro;
        private SortByDescendingPrice priceSortByDescendingPrice;

        [SetUp]
        public void Setup()
        {
            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            driver.Navigate().GoToUrl("https://ek.ua/");
            driver.Manage().Window.Maximize();
            service = new UserService(driver);
            category = new EntryCategory(driver);
            filterBrands = new FilterBrands(driver);
            pageMobileProductApple = new PageMobileProductApple();
            PageFactory.InitElements(driver, pageMobileProductApple);
            pageMobileiPhone13Pro = new PageMobileiPhone13Pro();
            PageFactory.InitElements(driver, pageMobileiPhone13Pro);
            priceSortByDescendingPrice = new SortByDescendingPrice(driver);
        }

        [Test]
        public void Test1()
        {
            // service.EntryIntoCategoryByName("Гаджеты", "Мобильные");
            category.EntryIntoCategoryByName("Гаджеты", "Мобильные");
            // service.SearchBrandsByFilter("Apple");
            filterBrands.SearchBrandsByFilter("Apple");
            // service.PriceFilter();
            pageMobileProductApple.NameProProductLink.Click();
            
            pageMobileiPhone13Pro.ShowAllPriceProductButton.Click();
            pageMobileiPhone13Pro.SortByPrice.Click();
            Thread.Sleep(1000);
            // service.DescendingPriceFilter();
            priceSortByDescendingPrice.DescendingPriceFilter();

        }

        [TearDown]
        public void Test2()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}
