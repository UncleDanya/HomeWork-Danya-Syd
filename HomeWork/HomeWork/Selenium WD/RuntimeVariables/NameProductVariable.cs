using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace HomeWork.Selenium_WD.RuntimeVariables
{
    class NameProductVariable
    {
        // public string Value { get; set; }
        public List<string> Value { get; set; }

        public NameProductVariable()
        {
            Value = new List<string>();
        }
    }
}
