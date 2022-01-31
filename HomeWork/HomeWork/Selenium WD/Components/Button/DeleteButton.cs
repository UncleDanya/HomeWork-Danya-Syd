using HomeWork.Selenium_WD.Components.Utils;
using OpenQA.Selenium;

namespace HomeWork.Selenium_WD.Components.Button
{
    class DeleteButton : BaseComponent
    {
        public override By Construct()
        {
            var selector = "//a[text()='УДАЛИТЬ АККАУНТ']";
            return By.XPath(selector);
        }
    }
}
