using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Threading;

namespace QuickBook.MyBookings
{
    public class MyBookings
    {

        private IWebDriver driver;

        protected MyBookingsReferences Map
        {
            get
            {
                return new MyBookingsReferences(this.driver);
            }
        }

        public MyBookings(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void MyBookingsEnter()
        {
            MyBookings broswer = new MyBookings(this.driver);
            this.Map.MyBookings.Click();
        }
        public void TickBox()
        {
            MyBookings broswer = new MyBookings(this.driver);
            // this.Map.ShowHostOnly.Click();
            this.Map.TeamCheckBox.Click();
        }
        public void ShowHostOnly()
        {
            MyBookings browesr = new MyBookings(this.driver);
            this.Map.ShowHostOnlyCheckBox.Click();
        }
        public void MyBookingsSelect()
        {
            MyBookings broswer = new MyBookings(this.driver);
            this.Map.MyBookingSelect.Click();
        }
        public void Calenderselect()
        {
            MyBookings broswer = new MyBookings(this.driver);
            this.Map.CalendarSelect.Click();
        }
        public void DateChange()
        {
            MyBookings broswer = new MyBookings(this.driver);
            this.Map.ChangeCalendarDate.Click();
        }

        public Boolean isElementVisible(IWebElement element)
        {
            Boolean result = false;
            try
            {
                if (element.Displayed)
                {
                    result = true;
                }
            }
            catch (Exception e) { }
            return result;
        }


        public void GoToMyBookings()
        {
            string today = this.Map.MyBookingsCurrentDay.Text;
            int todayInt = Convert.ToInt32(today);
            Console.WriteLine("Today: " + today);
            Console.WriteLine("Today Int: " + todayInt);
            if (todayInt < 31)
            {
                int nextActual = todayInt + 1;
                string nextString = Convert.ToString(nextActual);
                string days = this.Map.check.Text;
                if (days.Contains(nextString))
                {

                    this.Map.MyBookingsNextDay(nextString).Click();
                }
                else
                {
                    this.Map.CalendarChangeMonthForward.Click();
                    this.Map.ChangeCalendarDate.Click();
                }

            }
            else
            {
                this.Map.CalendarChangeMonthForward.Click();
                this.Map.ChangeCalendarDate.Click();
            }
        }

        public void PressCancel()
        {
            MyBookings broswer = new MyBookings(this.driver);
            this.Map.CrosstoCancel.Click();
        }

        public void YesBTN()
        {
            MyBookings broswer = new MyBookings(this.driver);
            this.Map.PressYes.Click();
        }
        public void SelectOK()
        {
            this.Map.SelectOK.Click();
        }
    }
}
