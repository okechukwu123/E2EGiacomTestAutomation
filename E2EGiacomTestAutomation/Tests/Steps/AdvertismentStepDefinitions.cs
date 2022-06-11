using E2EGiacomTestAutomation.Pages;
using E2EGiacomTestAutomation.Pages.AdvertisementPages;
using E2EGiacomTestAutomation.Pages.CommonPage;
using E2EGiacomTestAutomation.Utilities;
using E2EGiacomTestAutomation.Utilities.Extensions;
using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace E2EGiacomTestAutomation
{
    [Binding]
    public class AdvertismentStepDefinitions
    {
       
        AdvertisementPage advertisementPage = new AdvertisementPage();
        private CommonPage commonPage = new CommonPage();
        
        [When(@"I click on link Entry Ad")]
        public void WhenIClickOnLinkEntryAd()
        {
            advertisementPage.ClickOnAdLink();
            
        }

        [Then(@"I see modal Window")]
        public void ThenISeeModalWindow()
        {
            var modalWindow = advertisementPage.ModalWindow();
           modalWindow.Should().BeTrue();    
        }

        [Then(@"I can close modal window")]
        public void ThenICanCloseModalWindow()
        {
            
            advertisementPage.CloseModalWindow();
        }
        [Then(@"I can select ""([^""]*)"" from dropdown menu")]
        public void ThenICanSelectFromDropdownMenu(string text)
        {
            advertisementPage.SelectFromDropDown(text);
        }




        
    }
}
