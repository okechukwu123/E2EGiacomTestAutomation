namespace E2EGiacomTestAutomation.Pages.LoginPage
{
    using System;
    using OpenQA.Selenium;
    using E2EGiacomTestAutomation.Utilities;
    using Utilities.Extensions;
    using PGSWebsite.Configuration.TestDataSection;
    using Pages.CommonPage;
    using FluentAssertions;
    using Utilities.Helpers.TestDataGenerator;
    using Utilities.Enums;

    public partial class LoginPage : CommonPage
    {
        public void Login(TestData user)
        {
            this.EnterUsername(user.Username);
            this.EnterPassword(user.Password);
            this.ClickLoginButton();
        }

        public void EnterUsername(string email)
        {
            this.UsernameInput.SendKeys(email);
            
        }

        public void EnterPassword(string email)
        {
            this.PasswordInput.SendKeys(email);
        }

        public void ClickLoginButton()
        {
            this.LoginButton.ClickWithWait();
        }

       public void LogOut()
        {
           
          this.LogoutButton.ClickWithWait();
       }
    }
}
