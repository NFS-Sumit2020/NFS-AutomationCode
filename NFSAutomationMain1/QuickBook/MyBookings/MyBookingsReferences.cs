using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace QuickBook.MyBookings
{
    public class MyBookingsReferences
    {
        private readonly IWebDriver driver;

        public MyBookingsReferences(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement MyBookings
        {
            get
            {
                return driver.FindElement(By.ClassName("my-booking"));
            }
        }
        public IWebElement TeamCheckBox
        {
            get
            {
                // return driver.FindElement(By.Id("showTeamBookings"));
                return driver.FindElement(By.XPath("//*[@id='dvShowTeamBookings']/div/div/label"));
            }
        }
        public IWebElement ShowHostOnlyCheckBox
        {
            get
            {
                return driver.FindElement(By.XPath("//*[@id='mybooking']/div[1]/div[1]/div/label"));
            }
        }
        public IWebElement CalendarSelect
        {
            get
            {
                return driver.FindElement(By.Id("btnCal"));
            }
        }
        public IWebElement ChangeCalendarDate
        {
            get
            {
                return driver.FindElement(By.XPath("//*[@class=' ']/a"));
            }
        }
        public IWebElement MyBookingSelect
        {
            get
            {
                return driver.FindElement(By.ClassName("my-booking"));
            }
        }
        public IWebElement MyBookingsCurrentDay
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@class=' ui-datepicker-days-cell-over  ui-datepicker-current-day ui-datepicker-today']/a | //*[@class=' ui-datepicker-week-end ui-datepicker-days-cell-over  ui-datepicker-current-day ui-datepicker-today']/a"));
            }
        }
        public IWebElement MyBookingWeekEnd
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@class=' ui-datepicker-week-end ']/a"));
            }
        }
        public IWebElement CalendarChangeMonthForward
        {
            get
            {
                //return driver.FindElement(By.ClassName("ui-icon ui-icon-circle-triangle-e"));
                return driver.FindElement(By.XPath("//*[@id='ui-datepicker-div']/div/a[2]"));
            }
        }

        public IWebElement MyBookingsNextDay(string a)
        {
            return this.driver.FindElement(By.XPath("//a[contains(text(),'" + a + "')]"));
            // return this.driver.FindElement(By.XPath("//*[@id='ui-datepicker-div']/table/tbody"));
        }

        public IWebElement check
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='ui-datepicker-div']/table/tbody"));

            }
        }
        public IWebElement CrosstoCancel
        {
            get
            {
                //return this.driver.FindElement(By.XPath("//*[@id='tab - 0']/div[2]/div/div[4]/span/a[2]"));
                return this.driver.FindElement(By.XPath("//*[@id='tab-0']/div[1]/div/div[4]/span/a[2]"));

            }
        }

        public IWebElement PressYes
        {
            get
            {
                return this.driver.FindElement(By.Id("btnConfirmationYes"));
            }
        }

        public IWebElement SelectOK
        {
            get
            {
                return this.driver.FindElement(By.Id("btnBookingCancelOk"));
            }
        }
    }
}
