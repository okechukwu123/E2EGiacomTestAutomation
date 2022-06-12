
using E2EGiacomTestAutomation.Pages.AdvertisementPages;
using E2EGiacomTestAutomation.Pages.CommonPage;
using FluentAssertions;
using E2EGiacomTestAutomation.Utilities.Extensions;
using TechTalk.SpecFlow;

namespace E2EGiacomTestAutomation
{
    [Binding]
    public class AdvertismentStepDefinitions
    {
       
        AdvertisementPage advertisementPage = new AdvertisementPage();
       
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
