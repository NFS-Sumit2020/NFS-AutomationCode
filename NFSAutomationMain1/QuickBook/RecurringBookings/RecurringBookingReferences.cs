using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace QuickBook.RecurringBooking
{
    public class RecurringBookingReferences
    {

        private readonly IWebDriver driver;

        public RecurringBookingReferences(IWebDriver driver)
        {
            this.driver = driver;

        }


        public IWebElement recurringbutton
        {
            get
            {
                //return this.driver.FindElement(By.Id("btnRecurrenceBooking"));
                return this.driver.FindElement(By.XPath("//*[@id='btnRecurrenceBooking']"));
            }
        }

        public IWebElement recurringbutton2
        {
            get
            {
                //return this.driver.FindElement(By.Id("btnRecurrenceBooking"));
                return this.driver.FindElement(By.XPath("//*[@id='btnRecurrenceBooking']/h3/span"));
            }
        }


        public IWebElement recurringFromTime
        {
            get
            {
                return this.driver.FindElement(By.Id("RecurFromTime"));
            }
        }

        public IWebElement recurringToTime
        {
            get
            {
                return this.driver.FindElement(By.Id("RecurToTime"));
            }
        }

        public IWebElement recurringBookingDuration
        {
            get
            {
                return this.driver.FindElement(By.Id("RecurDuration"));
            }
        }

        public IWebElement recurringDailyPattern
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='frmRecPattern']/div[1]/div[2]/div[2]/div[2]/div[1]/div/div[1]/label/input"));
            }
        }

        public IWebElement recurringWeeklyPattern
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='frmRecPattern']/div[1]/div[2]/div[2]/div[2]/div[1]/div/div[2]/label/input"));
            }
        }

        public IWebElement recurringMonthlyPattern
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='frmRecPattern']/div[1]/div[2]/div[2]/div[2]/div[1]/div/div[3]/label/input"));
            }
        }

        public IWebElement recurringYearlyPattern
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='frmRecPattern']/div[1]/div[2]/div[2]/div[2]/div[1]/div/div[4]/label/input"));
            }
        }

        public IWebElement showdatesbutton
        {
            get
            {
                return this.driver.FindElement(By.Id("btnShowRecDates"));
            }
        }

        public IWebElement recurrringnextbutton
        {
            get
            {
                return this.driver.FindElement(By.Id("btnPostRecPattern"));
            }
        }

        public IWebElement EverydayPattern
        {
            get
            {
                return this.driver.FindElement(By.Id("DailyDetails_EveryXDay"));
            }
        }

        public IWebElement DailyEveryWeekDayPattern
        {
            get
            {
                // return this.driver.FindElement(By.Id("DailyDetails_IsEveryDay"));
                return this.driver.FindElement(By.XPath(" //*[@id='DailyRecPanel']/div[2]/label[1]"));
            }
        }

        public IWebElement RangeStartDateCalendar
        {
            get
            {
                //return this.driver.FindElement(By.Id("FromDate"));
                return this.driver.FindElement(By.XPath("//*[@id='frmRecPattern']/div[1]/div[2]/div[3]/div[2]/div/div[1]/div[1]/img"));
            }
        }

        public IWebElement RangeEndByCalendar
        {
            get
            {
                //                return this.driver.FindElement(By.Id("ToDate"));
                return this.driver.FindElement(By.XPath("//*[@id='frmRecPattern']/div[1]/div[2]/div[3]/div[2]/div/div[2]/div[2]/img"));
            }
        }

        public IWebElement EndByDateCheckBox
        {
            get
            {
                //return this.driver.FindElement(By.Id("EndAfter"));
                return this.driver.FindElement(By.XPath("//*[@id='frmRecPattern']/div[1]/div[2]/div[3]/div[2]/div/div[2]/div[2]/label/input"));


            }
        }

        public IWebElement EndAfterCheckbox
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='frmRecPattern']/div[1]/div[2]/div[3]/div[2]/div[1]/div[1]/div[2]/label[1]/input[1]"));
            }
        }

        public IWebElement EndAfterOccurrences
        {
            get
            {
                return this.driver.FindElement(By.Id("EndAfterOccurences"));
            }
        }

        public IWebElement Datepicker
        {
            get
            {
                // return this.driver.FindElement(By.XPath("//*[@class=' ']/a "));  
                return this.driver.FindElement(By.XPath("//*[@id='ui-datepicker-div']/table/tbody//tr//td[@class=' ']/a"));
            }
        }

        public IWebElement RecurEveryTextBox
        {
            get
            {
                return this.driver.FindElement(By.Id("WeeklyDetails_EveryXWeek"));
            }
        }

        public IWebElement WeeklyFrequency
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='WeeklyRecPanel']/div[2]/label"));
                //*[@id="WeeklyRecPanel"]/div[2]
            }
        }

        public IWebElement MonthlyDayCheckbox
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='MonthlyRecPanel']/div[1]/label[1]/input"));
            }
        }

        public IWebElement MonthlyWeekdayCheckBox
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='MonthlyRecPanel']/div[2]/label[1]/input"));
            }
        }

        public IWebElement MonthlyDayTextBox
        {
            get
            {
                return this.driver.FindElement(By.Id("MonthlyDetails_DayX"));
            }
        }

        public IWebElement MonthlyDayEveryMonthTextBox
        {
            get
            {
                return this.driver.FindElement(By.Id("MonthlyDetails_MonthX"));
            }
        }

        public IWebElement MonthlyFrequencyOccurrenceDropdown
        {
            get
            {
                return this.driver.FindElement(By.Id("MonthlyDetails_Occurrence"));
            }
        }

        public IWebElement MonthlyWeekDayFrequenceDropbox
        {
            get
            {
                return this.driver.FindElement(By.Id("MonthlyDetails_WeekDay"));
            }
        }

        public IWebElement MonthlyWeekDayEveryMonthTextBox
        {
            get
            {
                return this.driver.FindElement(By.Id("MonthlyDetails_EveryXMonth"));
            }
        }






    }

}