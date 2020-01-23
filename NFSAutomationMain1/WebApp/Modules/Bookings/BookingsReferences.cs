using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace WebApp.Modules.Bookings
{
    public class BookingsReferences
    {
        private readonly IWebDriver driver;

        public BookingsReferences(IWebDriver driver)
        {
            this.driver = driver;
        }

        //START
        public IWebElement BookingsIcon
        {
            get
            {
                return this.driver.FindElement(By.Id("bookingsSpan"));
            }
        }

        public IWebElement NewBookingTab
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_spanbookingeditLink"));
            }
        }

        public IWebElement NewBookingLink
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_sub_BookingeEdit"));
            }
        }

        public IWebElement BookingSearchTab
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_lblBookingsearch"));
            }
        }

        public IWebElement BookingSearchLink
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_subLblBookingSearch"));
            }
        }

        public IWebElement BackgroundBookingsTab
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_lblBackgroundBookings"));
            }
        }

        public IWebElement BackgroundBookingsLink
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_subLblBackgroundBookings"));
            }
        }

        public IWebElement AuthorisationRequestTab
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_spanAuthorizationrequest"));
            }
        }

        public IWebElement AuthorisationRequestLink
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_sub_AuthorizationRequest"));
            }
        }

        public IWebElement WaitlistBookingsTab
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_lblWaitlistbooking"));
            }
        }

        public IWebElement WaitlistBookingLink
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_subLblWaitlistBookings"));
            }
        }

        //END
    }
}
