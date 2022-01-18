using HomeWork.Selenium_WD.Helpers;

namespace HomeWork.Selenium_WD.Providers
{
    static class BrowserProvider
    {
        public static string Browser => JsonReader.GetJsonString("browser");
    }
}
