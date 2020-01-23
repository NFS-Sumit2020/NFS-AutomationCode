using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace QuickBook.Booking
{
    public class BookingReferences
    {

        private readonly IWebDriver driver;

        public BookingReferences(IWebDriver driver)
        {
            this.driver = driver;

        }

        public IWebElement bookingtitle
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_txtTitle"));
            }
        }

        public IWebElement Bookbutton
        {
            get
            {
                return this.driver.FindElement(By.Id("btnConfirmBooking"));
            }
        }

        public IWebElement bookingtype
        {
            get
            {
                return this.driver.FindElement(By.Id("BookingType"));
            }

        }


        public IWebElement PrivateBooking
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='lblisprivate']"));
            }
        }

        public IWebElement Addpeoplebutton
        {
            get
            {
                return this.driver.FindElement(By.Id("btnEditPeople"));
            }
        }

        public IWebElement Saveandexist
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_btnSaveExit"));
            }
        }

        public IWebElement BookingNotes
        {
            get
            {
                return this.driver.FindElement(By.Id("Notes"));
            }
        }


        public IWebElement BookingSpecialRequests
        {
            get
            {
                return this.driver.FindElement(By.Id("SpecialRequest"));
            }
        }

       



    }
} 
