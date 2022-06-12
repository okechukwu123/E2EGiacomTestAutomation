namespace E2EGiacomTestAutomation.Tests.Steps
{
    using FluentAssertions;
    using Pages.LoginPage;
    using E2EGiacomTestAutomation.Utilities.Extensions;
    using TechTalk.SpecFlow;
    using Utilities;
    using Utilities.Helpers.TestDataGenerator;
    using Utilities.Enums;

    [Binding]
    public class LoginPageSteps
    {
        private readonly LoginPage loginPage = new LoginPage();

        [Given(@"I open The login page")]
        public void GivenIOpenTheLoginPage()
        {
            Browser.GoTo(Pages.Dashboard);
        }

        [When(@"I enter valid login credentials")]
        public void ThenIEnterValidLoginCredentials()
        {
            this.loginPage.Login(TestDataGenerator.GetTestData(Constants.Admin));
        }

        [Then(@"I see landing page")]
        public void ThenISeeLandingPage()
        {
            this.loginPage.PageHeader("Task to be automated").IsDisplayedAfterWait().Should().BeTrue();
            
        }


    }
}