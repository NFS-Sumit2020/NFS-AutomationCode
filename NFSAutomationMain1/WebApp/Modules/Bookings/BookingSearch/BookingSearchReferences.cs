using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace WebApp.Modules.Bookings.BookingSearch
{
   public class BookingSearchReferences
    {

        private readonly IWebDriver driver;

        public BookingSearchReferences(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement NewBookingButton
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_btnAdd"));
            }
        }

        public IWebElement ResourceTypeDropDown
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_ddlResourceType"));
            }
        }

        public IWebElement BookingTitle
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_txtBookingTitle"));
            }
        }

        public IWebElement BookingRefNumber
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_txtRefNumber"));
            }
        }


        public IWebElement BookingLinkWhenSearchByRefNumber
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_grdSearchedBookingItems_ctl00_ctl05_lnkGoToSummary"));
            }
        }

        public IWebElement BookingSearchSearchButton
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_btnSearch"));
            }
        }

    }
}
