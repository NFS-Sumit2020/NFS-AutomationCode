using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using WebApp.Login;

namespace WebApp.Modules.Bookings
{
    public class BookingsMain
    {
        private IWebDriver driver;
        private WebAppLoginMain loginMain;
        private BookingsMain bookingsMain;

        //Init driver
        public BookingsMain(IWebDriver driver)
        {
            this.driver = driver;
        }

        //Map references
        protected BookingsReferences Map
        {
            get
            {
                return new BookingsReferences(this.driver);
            }
        }

        //Navigate to Bookings Module
        public void AccessBookingsModule()
        {
            this.Map.BookingsIcon.Click();
            Thread.Sleep(4000);
        }

        //=====NEW BOOKING GROUP=====
        //Navigate from Bookings Module to New Booking
        public void AccessNewBooking()
        {
            this.Map.NewBookingTab.Click();
            Thread.Sleep(2000);
        }
        //Navigate from Bookings Module to New Booking Tab to New Booking Link
        public void AccessNewBookingLink()
        {
            
            this.Map.NewBookingLink.Click();
            Thread.Sleep(2000);
        }
        //=====NEW BOOKING GROUP END=====
        //=====BOOKING SEARCH GROUP=====
        //Navigate from Bookings Module to Booking Search
        public void AccessBookingSearch()
        {
            bookingsMain.AccessBookingsModule();
            this.Map.BookingSearchTab.Click();
            Thread.Sleep(2000);
        }
        //Navigate from Bookings Module to Booking Search to Booking Search Link
        public void AccessBookingSearchLink()
        {
            this.Map.BookingsIcon.Click();
            Thread.Sleep(2000);
            this.Map.BookingSearchTab.Click();
            Thread.Sleep(2000);
            this.Map.BookingSearchLink.Click();
            Thread.Sleep(2000);
        }
        //=====BOOKING SEARCH GROUP END=====
        //=====BACKGROUND BOOKINGS GROUP=====
        //Navigate from Bookings Module to Background Bookings
        public void AccessBackgroundBookings()
        {
            bookingsMain.AccessBookingsModule();
            this.Map.BackgroundBookingsTab.Click();
            Thread.Sleep(2000);
        }
        //Navigate from Bookings Module to Background Bookings to Background Bookings Link
        public void AccessBackgroundBookingsLink()
        {
            bookingsMain.AccessBackgroundBookings();
            this.Map.BackgroundBookingsLink.Click();
            Thread.Sleep(2000);
        }
        //=====BACKGROUND BOOKINGS GROUP END=====
        //=====AUTHORISATION REQUEST GROUP=====
        //Navigate from Bookings Module to Authorisation Request
        public void AccessAuthorisationRequest()
        {
            bookingsMain.AccessBookingsModule();
            this.Map.AuthorisationRequestTab.Click();
            Thread.Sleep(2000);
        }
        //Navigate from Bookings Module to Authorisation Request to Authorisation Request Link
        public void AccessAuthorisationRequestLink()
        {
            bookingsMain.AccessAuthorisationRequest();
            this.Map.AuthorisationRequestLink.Click();
            Thread.Sleep(2000);
        }
        //=====AUTHORISATION REQUEST GROUP END=====

        //=====WAITLIST BOOKINGS GROUP=====
        
        public void AccessWaitlistBookingTab()
        {
            bookingsMain.AccessBookingsModule();
            this.Map.WaitlistBookingsTab.Click();
            Thread.Sleep(2000);

        }

        public void AccessWaitlistBookingLink()
        {
            bookingsMain.AccessWaitlistBookingTab();
            this.Map.WaitlistBookingLink.Click();
            Thread.Sleep(2000);
        }


    }
}
