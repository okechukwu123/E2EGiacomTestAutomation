using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E2EGiacomTestAutomation.Pages.AdvertisementPages
{
    public partial class AdvertisementPage
    {
        public By EntryAdLink => By.XPath("//a[text()='Entry Ad']");

        public By EntryAd => By.Id("restart - ad");

        public By CloseButton => By.XPath("//*[@id='modal']/div[2]/div[3]/p");

        public By EntryAdDropdown => By.Id("dropdown");
        public By ModalWindowTitle => By.XPath("//h3[text()='This is a modal window']");
        public By EntryAdDropDown =>By.Id("dropdown");


    }
}
