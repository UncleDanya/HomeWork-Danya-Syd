using System.Collections.Generic;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using HomeWork.Selenium_WD.Utils;

namespace HomeWork.Selenium_WD.Pages
{
    internal class UserPage : BasePage
    {
        [FindsBy(How = How.ClassName, Using = "info-nick")]
        public IWebElement ActualNameUser { get; set; }

        [FindsBy(How = How.ClassName, Using = "user-menu__name")]
        public IWebElement TextActualNameUser { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@class='user-menu__edit' and @title='Редактировать']")]
        public IWebElement EditProfileButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@class='ek-form-control' and @name='p_[NikName]']")]
        public IWebElement NickFieldInputButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@class='ek-form-btn blue' and text()='СОХРАНИТЬ']")]
        public IWebElement SaveChangeButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@class='user-menu__section wu_bookmarks ']")]
        public IWebElement ShowSaveProductList { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[text()='УДАЛИТЬ АККАУНТ']")]
        public IWebElement UserDeleteAccountButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[text()='УДАЛИТЬ']")]
        public IWebElement SubmitDeleteUserAccountButton { get; set; }

        [FindsBy(How = How.XPath, Using = ".//u[@class='nobr']")]
        public IList<IWebElement> NameViewedProduct { get; set; }

        public void DeleteUserAccount()
        {
            ActualNameUser.Click();
            EditProfileButton.Click();
            UserDeleteAccountButton.Click();
            WaitUtils.WaitForElementToBeClickable(Driver, SubmitDeleteUserAccountButton);
            SubmitDeleteUserAccountButton.Click();
            WaitUtils.WaitForAlertIsPresent(Driver);

            Driver.SwitchTo().Alert().Accept();
        }
    }
}
