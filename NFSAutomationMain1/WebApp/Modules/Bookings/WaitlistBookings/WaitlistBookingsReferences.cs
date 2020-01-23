using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace WebApp.Modules.Bookings.WaitlistBookings
{
    public class WaitlistBookingsReferences
    {

        public IWebDriver driver;

        public WaitlistBookingsReferences(IWebDriver driver)
        {
            this.driver = driver;
        }
        public IWebElement Bookings
        {
            get
            {

                return this.driver.FindElement(By.XPath(("//*[@id='bookingsSpan']")));
            }
        }


        public IWebElement waitlisttab
        {
            get
            {

                return this.driver.FindElement(By.CssSelector("span#ctl00_lblWaitlistbooking"));
            }
        }


        public IWebElement PropertyTab
        {
            get
            {

                return this.driver.FindElement(By.CssSelector("input#ctl00_MainContentPlaceHolder_ddlProperty_Input"));
            }
        }



        public IWebElement CheckALL
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='ctl00_MainContentPlaceHolder_ddlProperty_DropDown']/div/div/label"));
                //return this.driver.FindElement(By.CssSelector("div#rcbCheckAllItems"));
            }
        }

        public IWebElement SearchButton
        {
            get
            {

                return this.driver.FindElement(By.CssSelector("input#ctl00_MainContentPlaceHolder_btnSearchIn"));
            }
        }
        public IWebElement BookingHyperlink
        {
            get
            {

                return this.driver.FindElement(By.XPath("//*[@id='ctl00_MainContentPlaceHolder_grdList_ctl00_ctl05_lnkGoToSummary']"));
            }
        }
        public IWebElement ConfirmationTickMark
        {
            get
            {

                return this.driver.FindElement(By.XPath("//*[@id='ctl00_MainContentPlaceHolder_grdList_ctl00_ctl05_imgbtnConfirm']"));
            }
        }
        public IWebElement AcceptConfirmationMessageforwaitlistConfirm
        {
            get
            {

                return this.driver.FindElement(By.CssSelector("span.ui-button-text"));
            }
        }



    }
}
