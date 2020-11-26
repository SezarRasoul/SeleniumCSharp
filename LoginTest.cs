using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace EvityJuno
{
    [TestClass]
    [TestCategory("LoginConsent")]
    public class SampleLoginTest : BaseTest
    {
        internal TestUser ThetestUser { get; private set; }

        [TestMethod]
        [TestProperty("Author", "SezarRasoul")]
        [Description("Validate that user can login with correct credentials, importamat that cred is true")]
        public void TCID1()
        {
            var consentLoginPage = new ConsentLoginPage(Driver);
            consentLoginPage.GoTo();
            TestUser();
            var consentLogin = consentLoginPage.FillOutCredentialsAndLogin(ThetestUser);
            Assert.IsTrue(consentLogin.IsVisible, "Login page not visible");
        }

        [TestMethod]
        [Description("Validate that user can not login with incorrect credentials")]
        [TestProperty("Author", "SezarRasoul")]
        public void TCID2()
        {
            var consentFailLoginpage = new ConsentLoginPage(Driver);
            consentFailLoginpage.GoTo();
            TestUser();
            ConsentLoginPage loginPageAlert = consentFailLoginpage.ReturnWrongErrorMessage(ThetestUser);
            Assert.IsTrue(loginPageAlert.WrongCredentials, "Error message not visible");
        }

        public void TestUser()
        {
            ThetestUser = new TestUser
            {
                //Correct login credentials
                Email = "test@rxample.com",
                Password = "P4$$word!",
                //Incorrect login credentials
                WrongEmail = "testfail@example.com",
                WrongPassword = "tjoflöjt"
            };
        }
    }
}