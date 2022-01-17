using HomeWork.Selenium_WD.Helpers;
using System.IO;
using System.Text.Json;

namespace HomeWork.Selenium_WD.Providers
{
    static class BrowserProvider
    {
        public static string Browser => JsonReader.GetJsonString("browser");
    }
}
