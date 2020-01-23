using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using WebApp.Login;
using WebApp.Modules.Administration;
using NUnit;

namespace WebApp.Modules.Bookings.WaitlistBookings
{
    public class WaitlistBookingsMain
    {

        private IWebDriver driver;
        private WebAppLoginMain loginMain;
        private AdministrationMain admin;

        //Init Driver
        public WaitlistBookingsMain(IWebDriver driver)
        {
            this.driver = driver;
        }

        //Map References
        protected WaitlistBookingsReferences Map
        {
            get
            {
                return new WaitlistBookingsReferences(this.driver);
            }
        }


        public void waitlistNavigation()
        {
            Map.Bookings.Click();
            driver.Navigate().Refresh();
            WebDriverWait wait2 = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait2.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("span#ctl00_lblWaitlistbooking")));
            Map.waitlisttab.Click();
            //Assert.IsTrue(driver.FindElement(By.CssSelector("input#ctl00_MainContentPlaceHolder_btnSearchIn")).Enabled);
        }
















    }
}
