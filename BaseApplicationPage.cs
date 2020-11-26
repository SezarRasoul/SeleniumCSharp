using OpenQA.Selenium;

namespace EvityJuno
{
    internal class BaseApplicationPage
    {
        protected IWebDriver Driver;

        public BaseApplicationPage(IWebDriver driver)
        {
            Driver = driver;
        }
    }
}