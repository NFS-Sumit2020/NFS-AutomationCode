using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using OpenQA.Selenium;

namespace WebApp.Modules.Bookings.BookingSearch
{
 public class BookingSearchMain
    {
        private IWebDriver driver;
        private BookingSearchMain bookingSearchMain;


        public BookingSearchMain(IWebDriver driver)
        {
            this.driver = driver;
        }


        protected BookingSearchReferences Map
        {
            get
            {
                return new BookingSearchReferences(this.driver);
            }
        }

        public void BookingSearchRefNumber()
        {

        }






    }

}
