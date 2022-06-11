using E2EGiacomTestAutomation.Pages.CommonPage;
using E2EGiacomTestAutomation.Pages.LoginPage;
using E2EGiacomTestAutomation.Utilities.Extensions;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace E2EGiacomTestAutomation.Tests.Steps
{
    [Binding]
    public class LogOutPage
    {
        private CommonPage commonPage = new CommonPage();
        private readonly LoginPage loginPage = new LoginPage();
        [When(@"I click logout button")]
        public void WhenIClickLogoutButton()
        {
            loginPage.LogOut();
         

        }
        ////[Then(@"I  see login page")]
        ////public void ThenISeeLoginPage()
        ////{
        ////    this.commonPage.PageHeader("Login Page").IsDisplayedAfterWait().Should().BeTrue();
        ////}
        [Then(@"I  see ""([^""]*)""")]
        public void ThenISee(string headerText)
        {
            this.commonPage.PageHeader(headerText).IsDisplayedAfterWait().Should().BeTrue();
        }

        [Then(@"I cannot reach landing page without login")]
        public void ThenICannotReachLandingPageWithoutLogin()
        {
            this.commonPage.PageHeader("Logout").IsDisplayedAfterWait().Should().BeFalse();
        }


    }
}
