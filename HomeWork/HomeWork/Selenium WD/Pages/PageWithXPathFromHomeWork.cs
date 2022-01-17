using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace HomeWork.Selenium_WD.Pages
{
    internal class PageWithXPathFromHomeWork : BasePage
    {
        [FindsBy(How = How.XPath, Using = ".//*[contains(text(),'Харь')]")]
        public IWebElement FindElementWithContains { get; set; }

        [FindsBy(How = How.XPath, Using = ".//input[starts-with(@id, 'ek-search')]")]
        public IWebElement FindElementWithStartsWith { get; set; }

        [FindsBy(How = How.XPath, Using = ".//td[@class='s-catalog-td'][last()]")]
        public IWebElement FindElementWithLast { get; set; }

        [FindsBy(How = How.XPath, Using = ".//a[@class='model-short-title no-u' and not (contains (@data-idgood, '2090045'))]")]
        public IWebElement FindElementWithNotAndAnd { get; set; }

        [FindsBy(How = How.XPath, Using = ".//a[@data-lang='ru' or @data-lang='ua']")]
        public IWebElement FindElementWithOr { get; set; }

        [FindsBy(How = How.XPath, Using = ".//div[@class='mainmenu-subwrap']//ancestor::a")]
        public IWebElement FindElementWithAncestor { get; set; }

        [FindsBy(How = How.XPath, Using = ".//a[text()='Телевизоры']//parent::span")]
        public IWebElement FindElementWithParent { get; set; }

        [FindsBy(How = How.XPath, Using = ".//span[@class='ib']//preceding::div[@class='s-catalog-subcat']")]
        public IWebElement FindElementWithPreceding { get; set; }

        [FindsBy(How = How.XPath, Using = ".//div[@class='s-catalog-block']//preceding-sibling::div")]
        public IWebElement FindElementWithPrecedingSibling { get; set; }

        [FindsBy(How = How.XPath, Using = ".//div[@class='s-catalog-subcat']//descendant::span[@class='ib']")]
        public IWebElement FindElementWithDescendant { get; set; }

        [FindsBy(How = How.XPath, Using = ".//li[@class='mainmenu-item']//following-sibling::li")]
        public IWebElement FindElementWithFollowingSibling { get; set; }

        [FindsBy(How = How.XPath, Using = ".//div[@class='s-catalog-subcat' and count(span)]")]
        public IWebElement FindElementWithCount { get; set; }

        [FindsBy(How = How.XPath, Using = ".//div/span[position()= 5 mod 3]")]
        public IWebElement FindElementWithMod { get; set; }

        [FindsBy(How = How.XPath, Using = ".//div/span[position()>= 3]")]
        public IWebElement FindElementWithMoreOrEqual { get; set; }

        [FindsBy(How = How.XPath, Using = ".//div[@class='m-c-f1-pl--button']/span[position()<= 3]")]
        public IWebElement FindElementWithLessOrEqual { get; set; }

        [FindsBy(How = How.XPath, Using = ".//a[text()='Связь и гаджеты'] | //a[text()='TV и видео']")]
        public IWebElement FindElementWithOrChar { get; set; }
    }
}
