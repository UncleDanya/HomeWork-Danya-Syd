using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeWork.Selenium_WD.Components.Utils;
using OpenQA.Selenium;

namespace HomeWork.Selenium_WD.Components.FolderIcon
{
    class FolderSublistItem : BaseComponent
    {
        public override By Construct()
        {
            var selector = By.PartialLinkText($"{Identifier}");
            return selector;
        }
    }
}
