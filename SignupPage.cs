using System;
using System.Collections.Generic;
using EvityJuno;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace Consent.Test.Automation
{
    internal class SignupPage : BaseApplicationPage
    {
        public SignupPage(IWebDriver driver) : base(driver)
        {
        }

        public bool IsVisible
        {
            get
            {
                return Driver.Title.Contains(PageTitle);
            }
            internal set { }
        }

        private string PageTitle => "Juno";

        public IWebElement SignUpForm => Driver.FindElement(By.ClassName("jss0407 jss0408"));

        public IWebElement TitleField => Driver.FindElement(By.CssSelector("jss0430:nth-child(1) > .jss0432:nth-child(3)"));
        public IWebElement NameField => Driver.FindElement(By.ClassName("jss0432"));
        public IWebElement SurNameField => Driver.FindElement(By.ClassName("jss0432"));

        public IWebElement CountryField => Driver.FindElement(By.ClassName
            ("jss0441 jss0438 jss0442 jss0453"));

        internal void GoTo()
        {
            Driver.Navigate().GoToUrl("http://consent.evity-dev.com/login");
            Driver.FindElement(By.Name("email")).SendKeys("holly.duce@org093813.com");
            Driver.FindElement(By.Name("password")).SendKeys("P4$$word!");
            Driver.FindElement(By.XPath("//span[contains(text(),'Log in')]")).Click();
            Assert.IsTrue(IsVisible, $" page was not visible. Expected={PageTitle}. "
             + $"Actual=>{Driver.Title}");
        }

        internal SignupPage FillOutFormCR(TestUser user)
        {
            TitleField.SendKeys(user.Title);
            NameField.SendKeys(user.FirstName);
            SurNameField.SendKeys(user.SurName);
            CountryField.GetAttribute("United Kingdom");
            return new SignupPage(Driver);
        }
    }
}