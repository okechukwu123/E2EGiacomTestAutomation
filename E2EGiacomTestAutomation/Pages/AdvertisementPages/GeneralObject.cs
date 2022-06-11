using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E2EGiacomTestAutomation.Pages
{
    public class GeneralObject
    {
        IWebDriver driver;
        public GeneralObject(IWebDriver driver)
        {
            this.driver = driver;   

        }
        public IWebElement EntryAdDropDown => driver.FindElement(By.Id("dropdown"));
        public void SelectFromDropDown(string adDropDown) 
        {
            EntryAdDropDown.Click();
            SelectElement option = new SelectElement(EntryAdDropDown);
            option.SelectByText(adDropDown);
        
        
        }
    }
}
