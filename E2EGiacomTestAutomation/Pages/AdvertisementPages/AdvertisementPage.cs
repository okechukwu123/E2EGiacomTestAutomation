
namespace E2EGiacomTestAutomation.Pages.AdvertisementPages
{
   
    using E2EGiacomTestAutomation.Pages.CommonPage;
    using System.Threading;
    using Utilities.Extensions;
    public partial class AdvertisementPage : CommonPage
    {
        public void ClickOnAdLink()
        {

            this.EntryAdLink.ClickWithWait();      
        }
        public void CloseModalWindow()
        {

            this.CloseButton.ClickWithWait();      
        }
        public void SelectFromDropDown(string text) 
        {
          this.EntryAdDropDown.SelectText(text);

        }
        
        public bool ModalWindow()
        {
            
            return this.ModalWindowTitle.IsDisplayedAfterWait();
        }
    }
}
