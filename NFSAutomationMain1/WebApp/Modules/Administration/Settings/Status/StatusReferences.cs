using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace WebApp.Modules.Administration.Settings.Status
{
   public class StatusReferences
    {

        private readonly IWebDriver driver;

        public StatusReferences(IWebDriver driver)
        {
            this.driver = driver;

        }

        public IWebElement AddnewStatusButton
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_btnAdd"));
            }
        }


        public IWebElement StatusNameTextBox
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_txtStatus"));
            }
        }

        public IWebElement DisplayNameTextBox
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_txtDisplayName"));
            }
        }

        public IWebElement GauranteeStatusTextBox
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_txtGuaranteeStatus"));
            }
        }


        public IWebElement SequenceTextBox
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_txtSequence"));
            }
        }


        public IWebElement AffectsAvailabilityYes
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_rbtnAvailYes"));
            }
        }

        public IWebElement AffectsAvailabilityNo
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_rbtnAvailNo"));
            }
        }

        public IWebElement ActiveYes
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_rbtnActiveYes"));
            }
        }


        public IWebElement ActiveNo
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_rbtnActiveNo"));
            }
        }

        public IWebElement SaveButton
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_Button1"));
            }
        }


        public IWebElement CancelButton
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_Button2"));
            }
        }


        public IWebElement SaveAddMoreButton
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_Button3"));
            }
        }

    }
}
