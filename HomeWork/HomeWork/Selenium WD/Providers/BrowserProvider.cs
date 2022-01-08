using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomationUtils.Extensions;
using AutomationUtils.Utils;
using HomeWork.Selenium_WD.Helpers;

namespace HomeWork.Selenium_WD.Providers
{
    static class BrowserProvider
    {
        public static string Browser => JsonReader.GetJsonString("browser");
    }
}
