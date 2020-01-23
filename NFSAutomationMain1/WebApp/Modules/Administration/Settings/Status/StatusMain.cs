using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace WebApp.Modules.Administration.Settings.Status
{
    public class StatusMain
    {

        private IWebDriver driver;

       

        protected StatusReferences Map
        {
            get
            {
                return new StatusReferences(this.driver);
            }
        }

        public StatusMain(IWebDriver driver)
        {
            this.driver = driver;
        }

        public string StatusName; 
        public void AddNewStatus()
        {
            this.Map.AddnewStatusButton.Click();
            this.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Random ran = new Random();
            int i = ran.Next(0, 1000);
            int j = ran.Next(0, 50);
            this.Map.StatusNameTextBox.SendKeys("Test Status " + i);
            this.Map.DisplayNameTextBox.Click();
            this.Map.GauranteeStatusTextBox.SendKeys("8");
            this.Map.SequenceTextBox.SendKeys(""+j);
            this.Map.AffectsAvailabilityYes.Click();
            this.Map.ActiveYes.Click();
         StatusName = this.Map.DisplayNameTextBox.GetAttribute("value");
            //Console.WriteLine(StatusName);
            this.Map.SaveButton.Click(); 
        }

        
       
       


    }
}
