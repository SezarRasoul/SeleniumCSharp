using System;
using EvityJuno;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace Consent.Test.Automation
{
    [TestClass]
    public class SignupTest : BaseTest
    {
        internal TestUser TheTestUser { get; private set; }

        internal SignupPage SignupForm { get; private set; }

        [TestMethod]
        [TestProperty("Author", "SezarRasoul")]
        [Description("Validate that user can create a signup form for CR")]
        public void TCID3()
        {
            SignupPage signupPage = new SignupPage(Driver);
            signupPage.GoTo();
            TestUser();
            SignupForm = signupPage.FillOutFormCR(TheTestUser);
            Assert.IsTrue(signupPage.IsVisible, "ConsentForm for CR is not visible");
        }

        public void TestUser()
        {
            TheTestUser = new TestUser
            {
                Title = "TestTitle",
                FirstName = "Testobject",
                SurName = "ObjectTest",
            };
        }
    }
}