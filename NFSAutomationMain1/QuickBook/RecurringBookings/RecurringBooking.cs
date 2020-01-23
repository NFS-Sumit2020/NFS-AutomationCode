using NUnit.Framework;
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

namespace QuickBook.RecurringBooking
{
    public class RecurringBookingMain
    {

        private IWebDriver driver;

        protected RecurringBookingReferences Map
        {
            get
            {
                return new RecurringBookingReferences(this.driver);
            }
        }

        public RecurringBookingMain(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void RecurringButton()
        {
            this.Map.recurringbutton.Click();

        }

        public void RecurringButton2()
        {
            this.Map.recurringbutton2.Click();

        }

        public void ShowDatesButton()
        {
            this.Map.showdatesbutton.Click();
        }

        public void RecurringNextButton()
        {
            this.Map.recurrringnextbutton.Click();
        }

        public void RecurringFromTime()
        {
            var selectfromtime = this.Map.recurringFromTime;
            SelectElement selectingfromtime = new SelectElement(selectfromtime);
            selectingfromtime.SelectByValue("12.0");
        }

        public void RecurringToTime()
        {
            var selecttotime = this.Map.recurringToTime;
            SelectElement selectingtotime = new SelectElement(selecttotime);
            selectingtotime.SelectByValue("14.0");

        }

        public void RecurringBookingDuration()
        {
            var bookingduration = this.Map.recurringBookingDuration;
            SelectElement selectingbookingsuration = new SelectElement(bookingduration);
            selectingbookingsuration.SelectByValue("2.00");
        }

        public void DailyRecurringPattern()
        {
            this.Map.recurringDailyPattern.Click();
        }

        public void WeeklyRecurringPattern()
        {
            this.Map.recurringWeeklyPattern.Click();
        }

        public void MonthlyRecurringPattern()
        {
            this.Map.recurringMonthlyPattern.Click();
        }

        public void YearlyRecurringPattern()
        {
            this.Map.recurringYearlyPattern.Click();
        }

        public void EverydayPatternBox()
        {
            this.Map.EverydayPattern.SendKeys(Keys.Control + "a");
            this.Map.EverydayPattern.SendKeys("5");
        }

        public void EveryWeekDayPatterncheckBox()
        {
            this.Map.DailyEveryWeekDayPattern.Click();
        }

        public void EveryWeekDayPatternEndAfterCheckBox()
        {
            this.Map.EndAfterCheckbox.Click();
        }

        public void RecurringEndByCheckbox()
        {
            this.Map.EndByDateCheckBox.Click();
        }

        public void EndAfterOccurrences()
        {
            this.Map.EndAfterOccurrences.Click();
            this.Map.EndAfterOccurrences.SendKeys(Keys.Control + "a");
            this.Map.EndAfterOccurrences.SendKeys("7");
        }

        public void RecurringEndDateCalendar()
        {
            this.Map.RangeEndByCalendar.Click();
            Thread.Sleep(3000);
            this.Map.Datepicker.Click();
        }

        public void RecurringStartDateCalendar()
        {
            this.Map.RangeStartDateCalendar.Click();
            Thread.Sleep(3000);
            this.Map.Datepicker.Click();
        }

        public void getCalendarRecurringStartDate()
        {
            var a = this.driver.FindElement(By.XPath("//*[@id='frmRecPattern']/div[1]/div[2]/div[3]/div[2]/div/div[1]/div[1]/input")).GetAttribute("value");
            var b = this.driver.FindElement(By.XPath("//*[@id='frmRecPattern']/div[1]/div[2]/div[3]/div[2]/div/div[1]/div[1]/span")).Text;

           // Convert.ToDateTime(a);
            DateTime  D = DateTime.ParseExact(a, "MM/dd/yyyy", null);
            
            string RSD = D.ToString("dd/MM/yyyy");
            var WD = D.DayOfWeek;
            Console.WriteLine("A: " + RSD + "Day: " + WD);
            Console.WriteLine("B: " + b);





           // DateTime startRecurDate = DateTime.ParseExact(startRecurDatestring, "MM/dd/yyyy", null);
         //   string RecurringStartDate = startRecurDate.ToString("dd/MM/yyyy");
        }

        public List<string> stringList = new List<string>();
        public DateTime Dates;
        public List<DateTime> datelist = new List<DateTime>();

        public void GetRecurrencedates()
        {
            var selectedDates = this.driver.FindElement(By.XPath("//*[@id='frmRecPattern']/div[1]/div[1]/div[1]/div[2]/input[1]")).GetAttribute("value");

            string[] list = selectedDates.Split('#');

            stringList.Clear();

            foreach (string days in list.Skip(1))
            {
                Dates = DateTime.ParseExact(days, "yyyy-MM-dd", null);
                var onlydates = Dates.Date;
                datelist.Add(onlydates);
                var recurrencedates = Dates.ToShortDateString();
                stringList.Add(recurrencedates);
            }

        }


        public void PrintRecurrencedates()
        {
            var selectedDates = this.driver.FindElement(By.XPath("//*[@id='frmRecPattern']/div[1]/div[1]/div[1]/div[2]/input[1]")).GetAttribute("value");

            string[] list = selectedDates.Split('#');

            stringList.Clear();

            foreach (string days in list.Skip(1))
            {
                Dates = DateTime.ParseExact(days, "yyyy-MM-dd", null);
                var onlydates = Dates.Date;
                datelist.Add(onlydates);
                var recurrencedates = Dates.ToShortDateString();
                stringList.Add(recurrencedates);
            }

            stringList.ForEach(Console.WriteLine);

        }

        //Gets selected recurring days of the week
        public void GetSelectedRecurringDays()
        {
            var selectedDates = this.driver.FindElement(By.XPath("//*[@id='frmRecPattern']/div[1]/div[1]/div[1]/div[2]/input[1]")).GetAttribute("value");

            string[] list = selectedDates.Split('#');

            stringList.Clear();

            foreach (string days in list.Skip(1))
            {
                Dates = DateTime.ParseExact(days, "yyyy-MM-dd", null);
                var onlydays = Dates.DayOfWeek;
                stringList.Add(onlydays.ToString());

            }
            Console.WriteLine("------------------------------------------------");
            stringList.ForEach(Console.WriteLine);
        }




        public void RecurWeeklyTextBox()
        {
            this.Map.RecurEveryTextBox.Click();
            this.Map.RecurEveryTextBox.SendKeys(Keys.Control + "a");
            this.Map.RecurEveryTextBox.SendKeys("2");
        }

        //Monthly Recurring

        public void MonthlyRecurringDayCheckBox()
        {
            this.Map.MonthlyDayCheckbox.Click();
            this.Map.MonthlyWeekdayCheckBox.Click();
            this.Map.MonthlyDayCheckbox.Click();
        }

        public void MonthlyRecurringWeekDayCheckBox()
        {
           this.Map.MonthlyWeekdayCheckBox.Click();
            
        }

        public void MonthlyRecurringDayTextBox()
        {
            this.Map.MonthlyDayTextBox.SendKeys(Keys.Control + "a");
            this.Map.MonthlyDayTextBox.SendKeys("14");
        }

    }
}
