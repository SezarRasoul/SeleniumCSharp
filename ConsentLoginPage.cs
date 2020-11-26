using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace EvityJuno
{
    internal class ConsentLoginPage : BaseApplicationPage
    {
        public ConsentLoginPage(IWebDriver driver) : base(driver)
        {
        }

        //Verify that Wrong username or Passworf alert is displayed
        public bool WrongCredentials
        {
            get
            {
                try
                {
                    return ConsentError.Displayed;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            }
        }

        public IWebElement ConsentError => Driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[1]/form[1]/p[1]"));

        //Verify that text "Evity" is diplayed
        public bool IsVisible
        {
            get
            {
                return Driver.Title.Contains(PageTitle);
            }
            internal set { }
        }

        private string PageTitle => "Juno";

        //public IWebElement AlertError => Driver.FindElement(By.XPath)
        public IWebElement EmailField => Driver.FindElement(By.Name("email"));

        public IWebElement PasswordField => Driver.FindElement(By.Name("password"));

        public IWebElement LoginButton => Driver.FindElement(By.XPath("//span[contains(text(),'Log in')]"));

        //Points to website and verify that correct page title is displayed
        internal void GoTo()
        {
            Driver.Navigate().GoToUrl("https://consent.evity-dev.com/login");
            Assert.IsTrue(IsVisible, $" page was not visible. Expected={PageTitle}. "
                 + $"Actual=>{Driver.Title}");
        }

        internal ConsentLoginPage FillOutCredentialsAndLogin(TestUser user)
        {
            EmailField.SendKeys(user.Email);
            PasswordField.SendKeys(user.Password);
            LoginButton.Click();
            return new ConsentLoginPage(Driver);
        }

        internal ConsentLoginPage ReturnWrongErrorMessage(TestUser user)
        {
            EmailField.SendKeys(user.WrongEmail);
            PasswordField.SendKeys(user.WrongPassword);
            LoginButton.Click();
            return new ConsentLoginPage(Driver);
        }
    }
}