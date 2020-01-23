using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using QuickBook.Homepage;
using QuickBook.Login;
using QuickBook.MyBookings;
using QuickBook.MyProfile;
using QuickBook.RecurringBooking;
using QuickBook.Utilities;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;







namespace UnitTests
{
    [TestFixture]
    public class RecurringBookingTest
    {
        public IWebDriver driver;
        private readonly string TextFilePath = ConfigurationManager.AppSettings["textfilepath"];
        public MyProfile myprofile;
        public LoginMain login;
        public HomepageMain homepage;
        public RecurringBookingMain recurringbooking;
        public UtilitiesMain utilities;
        public MyBookings mybooking;



        protected RecurringBookingReferences Map
        {
            get
            {
                return new RecurringBookingReferences(this.driver);
            }
        }

        protected HomepageReferences homepageref
        {
            get
            {
                return new HomepageReferences(this.driver);
            }
        }

        [OneTimeSetUp]
        public void SetupTest()
        {
            this.driver = new ChromeDriver();
            this.myprofile = new MyProfile(this.driver);
            this.login = new LoginMain(this.driver);
            this.homepage = new HomepageMain(this.driver);
            this.recurringbooking = new RecurringBookingMain(this.driver);
            this.utilities = new UtilitiesMain(this.driver);
            this.mybooking = new MyBookings(this.driver);
            utilities.ReportSetup();
        }

        //Recurring Button 
        [Test, Category("Recurring Bookings")]
        public void RecurringButton()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Recurring Booking Button");
            utilities.extenttest.AssignCategory("Recurring Bookings");
            login.NavigateTo();
            login.LoginSuccess();
            Thread.Sleep(3000);
            recurringbooking.RecurringButton();
            Thread.Sleep(4000);
            Assert.IsTrue(driver.FindElement(By.Id("RecurrencePopup")).Displayed);
            utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
        }

        //Recurring Booking start time check 
        [Test, Category("Recurring Bookings")]
        public void RecurringBookingFromTimeValidation()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Recurring Booking From Time Validation");
            utilities.extenttest.AssignCategory("Recurring Bookings");
            login.NavigateTo();
            login.LoginSuccess();
            Thread.Sleep(3000);
            recurringbooking.RecurringButton();
            recurringbooking.RecurringFromTime();
            recurringbooking.ShowDatesButton();
            recurringbooking.RecurringNextButton();
            var time = this.homepageref.Time.GetAttribute("value");
            Console.WriteLine(time);
            var selectedtime = this.Map.recurringFromTime.GetAttribute("value");
            Console.WriteLine(selectedtime);
            if (time == selectedtime)
            {
                Console.WriteLine("Time is Equal to Selected Time");
                utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
            }
            else
            {
                Console.WriteLine("Selected time and Booking time doesn't match");
                Assert.Fail();
            }

        }

        //Recurring Booking Finish Time Check 
        [Test, Category("Recurring Bookings")]
        public void RecurringBookingToTimeValidation()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Recurring Booking To Time Validation");
            utilities.extenttest.AssignCategory("Recurring Bookings");
            login.NavigateTo();
            login.LoginSuccess();
            Thread.Sleep(3000);
            recurringbooking.RecurringButton();
            recurringbooking.RecurringToTime();
            recurringbooking.ShowDatesButton();
            recurringbooking.RecurringNextButton();
            var selectedtime = this.Map.recurringToTime.GetAttribute("value");
            float SelectedTime = Convert.ToSingle(selectedtime);
            Console.WriteLine("Selected To Time: " + SelectedTime);
            var fromTime = this.homepageref.Time.GetAttribute("value");
            float FromTime = Convert.ToSingle(fromTime);
            int FromTimeInt = Convert.ToInt32(FromTime);
            Console.WriteLine("Selected From Time: " + FromTime);
            var Duration = this.homepageref.Duration.GetAttribute("value");
            float DurationTime = Convert.ToSingle(Duration);
            int DurationInt = Convert.ToInt32(DurationTime);
            Console.WriteLine("Booking Duration: " + DurationInt);
            int TotalTime = FromTimeInt + DurationInt;
            Console.WriteLine("Total Time : " + TotalTime);
            if (TotalTime == SelectedTime)
            {
                Console.WriteLine("Test Passed, Booking End Time equals to Booking Start time + Booking Duration");
                utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
            }
            else
            {
                Console.WriteLine("Test Failed, Because Finish time and Booking total time is not same.");
                Assert.Fail();
            }
        }

        //Recurring booking duration check 
        [Test, Category("Recurring Bookings")]
        public void RecurringBookingDurationValidation()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Recurring Booking Duration Validation");
            utilities.extenttest.AssignCategory("Recurring Bookings");
            login.NavigateTo();
            login.LoginSuccess();
            Thread.Sleep(3000);
            recurringbooking.RecurringButton();
            recurringbooking.RecurringBookingDuration();
            recurringbooking.ShowDatesButton();
            recurringbooking.RecurringNextButton();
            var selectedduration = this.Map.recurringBookingDuration.GetAttribute("value");
            Console.WriteLine("Duration : " + selectedduration);
            var actualduration = this.homepageref.Duration.GetAttribute("value");
            Console.WriteLine("Homepage Dur : " + actualduration);
            if (selectedduration == actualduration)
            {
                Console.WriteLine("Pass, Selected Duration and Actual duration Matches");
                utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
            }
            else
            {
                Console.WriteLine("Fail, Selected Duration and Actual duration doesn't match.");
                Assert.Fail();
            }
        }

        //Recurring booking daily recuring pattern 
        [Test, Category("Recurring Bookings")]
        public void DailyRecurringButtonCheck()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Daily Recurring Button Check");
            utilities.extenttest.AssignCategory("Recurring Bookings");
            login.NavigateTo();
            login.LoginSuccess();
            Thread.Sleep(3000);
            recurringbooking.RecurringButton();
            recurringbooking.DailyRecurringPattern();
            Assert.IsTrue(this.driver.FindElement(By.Id("DailyRecPanel")).Displayed);
            utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");

        }



        //Recurring booking monthly recuring pattern 
        [Test, Category("Recurring Bookings")]
        public void MonthlyRecurringButtonCheck()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Monthly Recurring Button Check");
            utilities.extenttest.AssignCategory("Recurring Bookings");
            login.NavigateTo();
            login.LoginSuccess();
            Thread.Sleep(3000);
            recurringbooking.RecurringButton();
            recurringbooking.MonthlyRecurringPattern();
            Assert.IsTrue(this.driver.FindElement(By.Id("MonthlyRecPanel")).Displayed);
            utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");

        }

        //Recurring booking yearly recuring pattern 
        [Test, Category("Recurring Bookings")]
        public void YearlyRecurringButtonCheck()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Yearly Recurring Button Check");
            utilities.extenttest.AssignCategory("Recurring Bookings");
            login.NavigateTo();
            login.LoginSuccess();
            Thread.Sleep(3000);
            recurringbooking.RecurringButton();
            recurringbooking.YearlyRecurringPattern();
            Assert.IsTrue(this.driver.FindElement(By.Id("YearlyRecPanel")).Displayed);
            utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");

        }

        ///Recurring booking daily everyday recuring pattern      
        [Test, Category("Recurring Bookings")]
        public void DailyEveryDayPattern()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Daily Everyday Pattern");
            utilities.extenttest.AssignCategory("Recurring Bookings");
            login.NavigateTo();
            login.LoginSuccess();
            Thread.Sleep(3000);
            recurringbooking.RecurringButton();
            recurringbooking.DailyRecurringPattern();
            recurringbooking.EverydayPatternBox();
            var value = this.Map.EverydayPattern.GetAttribute("value");
            Console.WriteLine("Days: " + value);
            recurringbooking.ShowDatesButton();
            var selectedDates = this.driver.FindElement(By.Id("RecDates")).GetAttribute("value");
            Console.WriteLine("Selected Dates : " + selectedDates);
            string[] list = selectedDates.Split('#');
            string firstdate = list[1];
            DateTime StartDate = DateTime.ParseExact(firstdate, "yyyy-MM-dd", null);
            string Difference = null;
            foreach (string day in list.Skip(2))
            {
                DateTime EndDate = DateTime.ParseExact(day, "yyyy-MM-dd", null);
                Console.WriteLine("ED: " + EndDate);
                Console.WriteLine("SD:" + StartDate);
                TimeSpan t = EndDate.Date.Subtract(StartDate.Date);
                StartDate = DateTime.ParseExact(day, "yyyy-MM-dd", null);
                Console.WriteLine("Difference : " + t.TotalDays);
                Difference = t.TotalDays.ToString();
            }
            if (Difference.Equals(value))
            {
                Console.WriteLine("Pass");
                Assert.Pass();
                utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
            }
            else
            {
                Console.WriteLine("Fail");
                Assert.Fail();
                utilities.extenttest.Log(LogStatus.Fail, "Assert Fail ");
            }

        }

        //Daily Every Week Day Pattern  
        [Test, Category("Recurring Bookings")]
        public void DailyEveryWeekDayPattern()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Daily Every WeekDay Pattern");
            utilities.extenttest.AssignCategory("Recurring Bookings");
            login.NavigateTo();
            login.LoginSuccess();
            Thread.Sleep(3000);
            recurringbooking.RecurringButton();
            recurringbooking.DailyRecurringPattern();
            recurringbooking.EveryWeekDayPatterncheckBox();
            recurringbooking.ShowDatesButton();

            var selectedDates = this.driver.FindElement(By.XPath("//*[@id='frmRecPattern']/div[1]/div[1]/div[1]/div[2]/input[1]")).GetAttribute("value");
            Console.WriteLine("Selected Dates : " + selectedDates);
            string[] list = selectedDates.Split('#');
            string selecteddays = null;

            foreach (string days in list.Skip(1))
            {
                DateTime Dates = DateTime.ParseExact(days, "yyyy-MM-dd", null);

                selecteddays = selecteddays + Dates.DayOfWeek.ToString() + '\n';
            }

            Console.WriteLine(selecteddays);

            if (selecteddays.Contains("Saturday") || selecteddays.Contains("Sunday"))
            {

                utilities.extenttest.Log(LogStatus.Fail, "Assert Fail ");
                Assert.Fail();

            }
            else
            {
                utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
                Assert.Pass();

            }

        }

        //Daily Every WeekDay End After Pattern test
        [Test, Category("Recurring Bookings")]
        public void DailyEveryWeekDayEndAfter()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Daily Every WeekDay Pattern End After");
            utilities.extenttest.AssignCategory("Recurring Bookings");
            login.NavigateTo();
            login.LoginSuccess();
            login.Wait();
            Thread.Sleep(3000);
            recurringbooking.RecurringButton();
            recurringbooking.DailyRecurringPattern();
            recurringbooking.EveryWeekDayPatterncheckBox();
            recurringbooking.EveryWeekDayPatternEndAfterCheckBox();
            recurringbooking.EndAfterOccurrences();
            recurringbooking.ShowDatesButton();
            recurringbooking.RecurringNextButton();
            Thread.Sleep(2000);
            recurringbooking.RecurringButton2();
            Thread.Sleep(2000);
            var numberofoccurrence = this.Map.EndAfterOccurrences.GetAttribute("Value");
            Thread.Sleep(5000);
            var selectedDates = this.driver.FindElement(By.XPath("//*[@id='frmRecPattern']/div[1]/div[1]/div[1]/div[2]/input[1]")).GetAttribute("value");
            string[] list = selectedDates.Split('#');
            string selecteddays = null;
            List<string> stringList = new List<string>();
            foreach (string days in list)
            {
                DateTime Dates = DateTime.ParseExact(days, "yyyy-MM-dd", null);
                selecteddays = selecteddays + Dates.DayOfWeek.ToString() + '\n';
                stringList.Add(selecteddays);

            }
            string listitem = stringList.Count.ToString(); //converting List Count to string. 
            Console.WriteLine(numberofoccurrence);
            Console.WriteLine(listitem);

            if (numberofoccurrence == listitem)
            {
                utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
                Console.WriteLine("Pass, Number of occurrences entered is equal to number of occurrences selected.");
                Assert.Pass();
            }
            else
            {
                utilities.extenttest.Log(LogStatus.Fail, "Assert fail ");
                Console.WriteLine("Fail, Number of occurrences entered is not equal to number of occurrences selected");
                Assert.Fail();
            }
        }

        //Recurring Booking Daily EveryWeekDay End By Test
        [Test, Category("Recurring Bookings")]
        public void DailyEveryWeekDayEndbyDateValidatorReccurenceDates()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Daily Every WeekDay Pattern End By Date Validation Test");
            utilities.extenttest.AssignCategory("Recurring Bookings");
            login.NavigateTo();
            login.LoginSuccess();
            login.Wait();
            Thread.Sleep(3000);
            recurringbooking.RecurringButton();
            recurringbooking.DailyRecurringPattern();
            recurringbooking.EveryWeekDayPatterncheckBox();
            recurringbooking.RecurringEndByCheckbox();
            Thread.Sleep(5000);
            var currentenddate = this.driver.FindElement(By.Id("ToDate")).GetAttribute("value");

            DateTime enddate = DateTime.ParseExact(currentenddate, "MM/dd/yyyy", null);
            var CurrentEndDate = enddate.ToShortDateString();
            Console.WriteLine("Current End Date: " + CurrentEndDate);

            recurringbooking.RecurringEndDateCalendar();

            var dateafterchange = this.driver.FindElement(By.Id("ToDate")).GetAttribute("value");

            DateTime enddateafterchange = DateTime.ParseExact(dateafterchange, "MM/dd/yyyy", null);
            var NewEndDateAfterChange = enddateafterchange.ToShortDateString();
            Console.WriteLine("Updated End Date : " + NewEndDateAfterChange);

            recurringbooking.ShowDatesButton();

            recurringbooking.GetRecurrencedates();

            Console.WriteLine("Recurring Bookings Count: " + recurringbooking.stringList.Count);
            Console.WriteLine("Last Occurrence Date: " + recurringbooking.stringList.Last());

            if (NewEndDateAfterChange == recurringbooking.stringList.Last())
            {
                utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
                Console.WriteLine("Pass");
                Assert.Pass("Pass");

            }
            else
            {
                utilities.extenttest.Log(LogStatus.Fail, "Assert Fail");
                Assert.Fail();
            }
        }

        //Daily Every Week Day Booking End by date pattern changing date test.
        [Test, Category("Recurring Bookings")]
        public void DailyEveryWeekDayEndbyDateChange()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Daily Every WeekDay Pattern End By Date Change");
            utilities.extenttest.AssignCategory("Recurring Bookings");
            login.NavigateTo();
            login.LoginSuccess();
            login.Wait();
            Thread.Sleep(3000);
            recurringbooking.RecurringButton();
            recurringbooking.DailyRecurringPattern();
            recurringbooking.EveryWeekDayPatterncheckBox();
            recurringbooking.RecurringEndByCheckbox();
            Thread.Sleep(5000);
            var currentenddate = this.driver.FindElement(By.Id("ToDate")).GetAttribute("value");

            DateTime enddate = DateTime.ParseExact(currentenddate, "MM/dd/yyyy", null);
            var CurrentEndDate = enddate.ToShortDateString();
            Console.WriteLine("Old Date: " + CurrentEndDate);

            recurringbooking.RecurringEndDateCalendar();

            var dateafterchange = this.driver.FindElement(By.Id("ToDate")).GetAttribute("value");

            DateTime enddateafterchange = DateTime.ParseExact(dateafterchange, "MM/dd/yyyy", null);
            var NewEndDateAfterChange = enddateafterchange.ToShortDateString();
            Console.WriteLine("Updated Date: " + NewEndDateAfterChange);

            if (CurrentEndDate == NewEndDateAfterChange)
            {
                utilities.extenttest.Log(LogStatus.Fail, "Assert Fail");
                Console.WriteLine("End Date not changed.");
                Assert.Fail();
            }
            else
            {
                utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
                Console.WriteLine("End Date Changed.");
                Assert.Pass("Pass");
            }
        }

        //Recurring Booking Daily EveryWeekDay End By Validation homepage
        [Test, Category("Recurring Bookings")]
        public void DailyEveryWeekDayEndbyDateValidatorOnHomepage()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Daily Every WeekDay Pattern End By Date validation on homepage");
            utilities.extenttest.AssignCategory("Recurring Bookings");
            login.NavigateTo();
            login.LoginSuccess();
            login.Wait();
            Thread.Sleep(5000);
            recurringbooking.RecurringButton();
            recurringbooking.DailyRecurringPattern();
            recurringbooking.EveryWeekDayPatterncheckBox();
            recurringbooking.RecurringEndByCheckbox();
            Thread.Sleep(5000);
            var currentenddate = this.driver.FindElement(By.Id("ToDate")).GetAttribute("value");

            DateTime enddate = DateTime.ParseExact(currentenddate, "MM/dd/yyyy", null);
            var CurrentEndDate = enddate.ToShortDateString();
            Console.WriteLine(CurrentEndDate);

            recurringbooking.RecurringEndDateCalendar();

            var dateafterchange = this.driver.FindElement(By.Id("ToDate")).GetAttribute("value");

            DateTime enddateafterchange = DateTime.ParseExact(dateafterchange, "MM/dd/yyyy", null);
            var NewEndDateAfterChange = enddateafterchange.ToShortDateString();
            Console.WriteLine(NewEndDateAfterChange);

            recurringbooking.ShowDatesButton();

            recurringbooking.GetRecurrencedates();

            Console.WriteLine(recurringbooking.stringList.Last());

            recurringbooking.RecurringNextButton();

            var recurrence = this.driver.FindElement(By.Id("recurrencePatternMsg")).Text;
            string beforesplit = recurrence.Substring(recurrence.IndexOf("until") + 5);
            string aftersplit = beforesplit.Substring(1, beforesplit.IndexOf("from") - 1);
            Console.WriteLine("After Spliting from the recurring msg : " + aftersplit);

            string endRecurDatestring = Regex.Replace(aftersplit, @"\s+", "");     //Removing White space.
            Console.WriteLine("End Recur Date String : " + endRecurDatestring);
            DateTime endRecurDate = DateTime.ParseExact(endRecurDatestring, "MM/dd/yyyy", null);
            string RecurringEndDate = endRecurDate.ToString("dd/MM/yyyy");

            Console.WriteLine("Recurring End Date: " + RecurringEndDate);

            if (RecurringEndDate == recurringbooking.stringList.Last())
            {
                utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
                Console.WriteLine("Pass");
                Assert.Pass("Pass");

            }
            else
            {
                utilities.extenttest.Log(LogStatus.Fail, "Assert Fail");
                Assert.Fail();
            }
        }

        //Recurring Start Date change. 
        [Test, Category("Recurring Bookings")]
        public void RecurringStartDateChange()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Recurring start date Change");
            utilities.extenttest.AssignCategory("Recurring Bookings");
            login.NavigateTo();
            login.LoginSuccess();
            login.Wait();
            Thread.Sleep(5000);
            recurringbooking.RecurringButton();

            var currentstartdate = this.driver.FindElement(By.Id("FromDate")).GetAttribute("value");

            DateTime startdate = DateTime.ParseExact(currentstartdate, "MM/dd/yyyy", null);
            var CurrentStartDate = startdate.ToShortDateString();
            Console.WriteLine(CurrentStartDate);

            recurringbooking.RecurringStartDateCalendar();

            var dateafterchange = this.driver.FindElement(By.Id("FromDate")).GetAttribute("value");

            DateTime startdateafterchange = DateTime.ParseExact(dateafterchange, "MM/dd/yyyy", null);
            var NewStartDateAfterChange = startdateafterchange.ToShortDateString();
            Console.WriteLine(NewStartDateAfterChange);

            if (CurrentStartDate == NewStartDateAfterChange)
            {
                utilities.extenttest.Log(LogStatus.Fail, "Assert Fail");
                Console.WriteLine("Start Date not changed.");
                Assert.Fail();
            }
            else
            {
                utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
                Console.WriteLine("Start Date Changed.");
                Assert.Pass("Pass");
            }
        }

        //Recurring Start Date change with Validation Done from Selected Recurrence Dates
        [Test, Category("Recurring Bookings")]
        public void RecurringStartDateChangeValidationWithRecurrenceDates()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Recurring start date Change");
            utilities.extenttest.AssignCategory("Recurring Bookings");
            login.NavigateTo();
            login.LoginSuccess();
            login.Wait();
            Thread.Sleep(5000);
            recurringbooking.RecurringButton();

            var currentstartdate = this.driver.FindElement(By.Id("FromDate")).GetAttribute("value");

            DateTime startdate = DateTime.ParseExact(currentstartdate, "MM/dd/yyyy", null);
            var CurrentStartDate = startdate.ToShortDateString();
            Console.WriteLine("Current Start Date: " + CurrentStartDate);

            recurringbooking.RecurringStartDateCalendar();

            var dateafterchange = this.driver.FindElement(By.Id("FromDate")).GetAttribute("value");

            DateTime startdateafterchange = DateTime.ParseExact(dateafterchange, "MM/dd/yyyy", null);
            var NewStartDateAfterChange = startdateafterchange.ToShortDateString();
            Console.WriteLine("Updated Start Date: " + NewStartDateAfterChange);

            Thread.Sleep(2000);
            recurringbooking.ShowDatesButton();

            recurringbooking.GetRecurrencedates();

            Console.WriteLine("First Occurrence Date: " + recurringbooking.stringList.First());

            if (NewStartDateAfterChange == recurringbooking.stringList.First())
            {
                utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
                Console.WriteLine("Start Date Changed.");
                Assert.Pass("Pass");
            }
            else
            {
                utilities.extenttest.Log(LogStatus.Fail, "Assert Fail");
                Console.WriteLine("Start Date not changed.");
                Assert.Fail();
            }
        }

        //Recurring Start Date change with Validation Done from Selected Recurrence Dates On homepage
        [Test, Category("Recurring Bookings")]
        public void RecurringStartDateChangeHomepageValidation()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Recurring start date Change");
            utilities.extenttest.AssignCategory("Recurring Bookings");
            login.NavigateTo();
            login.LoginSuccess();
            login.Wait();
            Thread.Sleep(5000);
            recurringbooking.RecurringButton();

            var currentstartdate = this.driver.FindElement(By.Id("FromDate")).GetAttribute("value");

            DateTime startdate = DateTime.ParseExact(currentstartdate, "MM/dd/yyyy", null);
            var CurrentStartDate = startdate.ToShortDateString();
            Console.WriteLine(CurrentStartDate);

            recurringbooking.RecurringStartDateCalendar();

            var dateafterchange = this.driver.FindElement(By.Id("FromDate")).GetAttribute("value");

            DateTime startdateafterchange = DateTime.ParseExact(dateafterchange, "MM/dd/yyyy", null);
            var NewStartDateAfterChange = startdateafterchange.ToShortDateString();
            Console.WriteLine(NewStartDateAfterChange);

            Thread.Sleep(2000);
            recurringbooking.ShowDatesButton();

            recurringbooking.RecurringNextButton();

            Thread.Sleep(3000);
            var recurrence = this.driver.FindElement(By.Id("recurrencePatternMsg")).Text;

            Console.WriteLine(recurrence);

            string beforesplit = recurrence.Substring(recurrence.IndexOf("effective") + 9);
            string aftersplit = beforesplit.Substring(1, beforesplit.IndexOf("until") - 1);
            Console.WriteLine("After Spliting from the recurring msg : " + aftersplit);

            string startRecurDatestring = Regex.Replace(aftersplit, @"\s+", "");     //Removing White space.
            Console.WriteLine("Start Recur Date String : " + startRecurDatestring);
            DateTime startRecurDate = DateTime.ParseExact(startRecurDatestring, "MM/dd/yyyy", null);
            string RecurringStartDate = startRecurDate.ToString("dd/MM/yyyy");

            Console.WriteLine("Recurring Start Date: " + RecurringStartDate);

            if (NewStartDateAfterChange == RecurringStartDate)
            {
                utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
                Console.WriteLine("Start Date Changed.");
                Assert.Pass("Pass");
            }
            else
            {
                utilities.extenttest.Log(LogStatus.Fail, "Assert Fail");
                Console.WriteLine("Start Date not changed.");
                Assert.Fail();
            }
        }


        //Recurring booking weekly recuring pattern 
        [Test, Category("Recurring Bookings")]
        public void WeeklyRecurringButtonCheck()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Weekly Recurring Button Check");
            utilities.extenttest.AssignCategory("Recurring Bookings");
            login.NavigateTo();
            login.LoginSuccess();
            Thread.Sleep(3000);
            recurringbooking.RecurringButton();
            recurringbooking.WeeklyRecurringPattern();
            Assert.IsTrue(this.driver.FindElement(By.Id("WeeklyRecPanel")).Displayed);
            utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");

        }

        //Recurring booking weekly pattern Recur Every Week Test
        [Test, Category("Recurring Bookings")]
        public void WeeklyRecurringRecurEveryWeekTextBox()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Weekly Recurring Recur options Text Box");
            utilities.extenttest.AssignCategory("Recurring Bookings");
            login.NavigateTo();
            login.LoginSuccess();
            Thread.Sleep(3000);
            recurringbooking.RecurringButton();
            recurringbooking.WeeklyRecurringPattern();
            recurringbooking.RecurWeeklyTextBox();
            recurringbooking.ShowDatesButton();
            recurringbooking.GetRecurrencedates();
            int Difference = 0;
            foreach (DateTime dates in recurringbooking.datelist)
            {
                Console.WriteLine("Dates: " + dates.ToShortDateString());
            }
            DateTime firstdate = recurringbooking.datelist[0];
            foreach (DateTime Occurrences in recurringbooking.datelist.Skip(1))
            {
                DateTime EndDate = Occurrences;
                TimeSpan t = EndDate.Date.Subtract(firstdate.Date);
                firstdate = EndDate;
                Console.WriteLine("Difference In Days: " + t.TotalDays);
                Difference = Convert.ToInt32(t.TotalDays) / 7;
                Console.WriteLine("Difference In Weeks: " + Difference);
            }
            recurringbooking.RecurringNextButton();
            Thread.Sleep(2000);
            recurringbooking.RecurringButton2();
            Thread.Sleep(2000);
            string numberofweeks = this.Map.RecurEveryTextBox.GetAttribute("Value");
            Console.WriteLine(numberofweeks);

            if (numberofweeks == Difference.ToString())
            {
                utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
                Console.WriteLine("Pass, Number of weeks selected is equal to the difference in dates");
                Assert.Pass("Pass");
            }
            else
            {
                utilities.extenttest.Log(LogStatus.Fail, "Assert Fail");
                Console.WriteLine("Number of weeks selected is not equal to the difference in dates");
                Assert.Fail();
            }
        }


        public List<string> stringList = new List<string>();
        public List<string> stringList1 = new List<string>();
        public DateTime Dates;

        //Recurring booking weekly recuring pattern 
        [Test, Category("Recurring Bookings")]
        public void WeeklyRecurringDayCheck()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Weekly Recurring day Check");
            utilities.extenttest.AssignCategory("Recurring Bookings");
            login.NavigateTo();
            login.LoginSuccess();
            login.Wait();
            Thread.Sleep(5000);
            recurringbooking.RecurringButton();
            recurringbooking.WeeklyRecurringPattern();
            IList<IWebElement> weeklyfrequency = this.driver.FindElements(By.XPath("//*[@id='WeeklyRecPanel']/div[2]/label/input[1]"));
            IList<IWebElement> weekDays = this.driver.FindElements(By.XPath("//*[@id='WeeklyRecPanel']/div[2]/label/span"));

            int size = weeklyfrequency.Count;
            string day = null;
            bool value = false;
            List<string> DaysList = new List<string>();
            List<string> ValueList = new List<string>();

            for (int j = 0; j < size; j++)
            {
                day = weekDays.ElementAt(j).Text;
                DaysList.Add(day);
                value = weeklyfrequency.ElementAt(j).Selected;
                ValueList.Add(value.ToString());
                Console.Write(day + " : " + value + "\n");

            }

            //  DaysList.ForEach(Console.WriteLine);
            //  ValueList.ForEach(Console.WriteLine);

            var newList = ValueList.FindAll(x => x.Contains("True")).ToList();

            List<string> MainIndex3 = new List<string>();
            List<string> MainIndex4 = new List<string>();
            string item = null;
            // foreach (string s in ValueList)
            for (int j = 0; j < 7; j++)
            {
                var index = +1;
                index = ValueList[j].IndexOf("True");

                if (index != -1)
                {
                    item = DaysList[j];
                    MainIndex3.Add(item);

                }
                else
                {
                    item = DaysList[j];
                    MainIndex4.Add(item);
                }

            }

            Console.WriteLine("------------------------------------------------");
            newList.ForEach(Console.WriteLine);

            Console.WriteLine("------------------------------------------------");
            MainIndex3.ForEach(Console.WriteLine);

            recurringbooking.ShowDatesButton();

            Thread.Sleep(3000);

            //recurringbooking.GetSelectedRecurringDays();

            Console.WriteLine("**************");
            MainIndex4.ForEach(Console.WriteLine);
            Console.WriteLine("**************");

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
            Console.WriteLine("------------------------------------------------");

            if (stringList.Any(x => MainIndex4.Contains(x)) || MainIndex3.Any(x => MainIndex4.Contains(x)))
            {

                Console.WriteLine("Fail");
                Assert.Fail();
                utilities.extenttest.Log(LogStatus.Fail, "Assert Fail ");

            }
            else
            {

                Console.WriteLine("Pass");
                utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");

            }


        }
        public List<String> daysList = new List<String>();
        //public DateTime Dates;
        [Test, Category("Recurring Bookings")]
        public void StartDateWeeklyRecurringEveryPattern()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Weekly Recurring Pattern Check Every Week");
            utilities.extenttest.AssignCategory("Recurring Bookings");
            login.NavigateTo();
            login.LoginSuccess();
            login.Wait();
            Thread.Sleep(5000);
            recurringbooking.RecurringButton();
            recurringbooking.WeeklyRecurringPattern();

            recurringbooking.ShowDatesButton();

            Thread.Sleep(3000);


            var selectedDates = this.driver.FindElement(By.XPath("//*[@id='frmRecPattern']/div[1]/div[1]/div[1]/div[2]/input[1]")).GetAttribute("value");

            string[] list = selectedDates.Split('#');

            stringList.Clear();

            foreach (string days in list.Skip(1))
            {
                Dates = DateTime.ParseExact(days, "yyyy-MM-dd", null);
                stringList.Add(Dates.ToShortDateString());
                daysList.Add(Dates.DayOfWeek.ToString());

            }

         

            var getstartdate = this.driver.FindElement(By.XPath("//*[@id='frmRecPattern']/div[1]/div[2]/div[3]/div[2]/div/div[1]/div[1]/input")).GetAttribute("value");

            DateTime startdate = DateTime.ParseExact(getstartdate, "MM/dd/yyyy", null);

            string startdatestring = startdate.ToString("dd/MM/yyyy");
            string startday = startdate.DayOfWeek.ToString();
            //Console.WriteLine("Date: " + startdatestring + " " + "Day: " + startday);

            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("List First Date: " + stringList.First());
            Console.WriteLine("Start Date: " + startdatestring);
            Console.WriteLine("List First Day: " + daysList.First());
            Console.WriteLine("Start Day: " + startday);
            Console.WriteLine("------------------------------------------------");

            if (stringList.First() == startdatestring && daysList.First() == startday)
            {
                Console.WriteLine("Pass");
                Assert.Pass();
                utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
            }
            else
            {
                Assert.Fail();
                utilities.extenttest.Log(LogStatus.Fail, "Assert Fail ");
            }
        }

        

        //Recurring booking weekly recuring pattern 
        [Test, Category("Recurring Bookings")]
        public void WeeklyRecurringCompleteCheck()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Weekly Recurring day Check");
            utilities.extenttest.AssignCategory("Recurring Bookings");
            login.NavigateTo();
            login.LoginSuccess();
            login.Wait();
            Thread.Sleep(5000);
            recurringbooking.RecurringButton();
            recurringbooking.WeeklyRecurringPattern();
            recurringbooking.RecurWeeklyTextBox();

            IList<IWebElement> weeklyfrequency = this.driver.FindElements(By.XPath("//*[@id='WeeklyRecPanel']/div[2]/label/input[1]"));
            IList<IWebElement> weekDays = this.driver.FindElements(By.XPath("//*[@id='WeeklyRecPanel']/div[2]/label/span"));

            int size = weeklyfrequency.Count;
            string day = null;
            bool value = false;
            bool value1 = false;
            List<string> DaysList = new List<string>();
            List<string> ValueList = new List<string>();
            
            for (int j = 0; j < size; j++)
            {
                day = weekDays.ElementAt(j).Text;
                DaysList.Add(day);
                value = weeklyfrequency.ElementAt(j).Selected;
                ValueList.Add(value.ToString());
                Console.Write(day + " : " + value + "\n");
            }

            // DaysList.ForEach(Console.WriteLine); 
            // ValueList.ForEach(Console.WriteLine);

            List<string> MainIndex3 = new List<string>();
            List<string> MainIndex4 = new List<string>();
            string item = null;
            var nextindex = 0;
            for (int j = 0; j < 7; j++)
            {
                var index = +1;
                index = ValueList[j].IndexOf("True");

                if (nextindex == 1)
                {
                    weeklyfrequency[j].Click();
                    item = DaysList[j];
                    MainIndex3.Add(item);
                    nextindex = 0;
                    index = ValueList[j].IndexOf("True");
                    index = 100;

                }

                if (index != -1)
                {
                    if (index == 100)
                    {
                        //do nothing
                    }
                    else
                    {
                        item = DaysList[j];
                        MainIndex3.Add(item);
                        nextindex = 1;
                    }
                }
                else
                {
                    item = DaysList[j];
                    MainIndex4.Add(item);
                }

            }

            List<String> NewDayslist = new List<string>();
            List<String> NewValuelist = new List<string>();
            for (int j = 0; j < size; j++)
            {
                day = weekDays.ElementAt(j).Text;
                NewDayslist.Add(day);
                value = weeklyfrequency.ElementAt(j).Selected;
                NewValuelist.Add(value.ToString());
                Console.Write(day + " : " + value + "\n");
            }

            var newList = NewValuelist.FindAll(x => x.Contains("True")).ToList();

            Console.WriteLine("-----------------Test-----------------------");
            MainIndex3.ForEach(Console.WriteLine);
            Console.WriteLine("------------------Test------------------------------");
            Console.WriteLine("Number of selected days:");
            newList.ForEach(Console.WriteLine);

            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Selected Days:");
            MainIndex3.ForEach(Console.WriteLine);

            if (this.driver.FindElement(By.XPath("//*[@id='EndAfter']")).Selected)
            {
                recurringbooking.EndAfterOccurrences();
                recurringbooking.EveryWeekDayPatternEndAfterCheckBox();
                recurringbooking.ShowDatesButton();
                recurringbooking.RecurringNextButton();
                recurringbooking.RecurringButton2();

            }
            else
            {
                recurringbooking.RecurringEndByCheckbox();

            }

            
            Thread.Sleep(3000);

            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Not Selected Days:");
            MainIndex4.ForEach(Console.WriteLine);
            Console.WriteLine("------------------------------------------------");
            
            var selectedDates = this.driver.FindElement(By.XPath("//*[@id='frmRecPattern']/div[1]/div[1]/div[1]/div[2]/input[1]")).GetAttribute("value");

            string[] list = selectedDates.Split('#');

            stringList.Clear();

            foreach (string days in list)
            {
                Dates = DateTime.ParseExact(days, "yyyy-MM-dd", null);
                stringList.Add(Dates.ToShortDateString());
                daysList.Add(Dates.DayOfWeek.ToString());
            }
           
            var getstartdate = this.driver.FindElement(By.XPath("//*[@id='frmRecPattern']/div[1]/div[2]/div[3]/div[2]/div/div[1]/div[1]/input")).GetAttribute("value");

            DateTime startdate = DateTime.ParseExact(getstartdate, "MM/dd/yyyy", null);

            string startdatestring = startdate.ToString("dd/MM/yyyy");
            string startday = startdate.DayOfWeek.ToString();
            //Console.WriteLine("Date: " + startdatestring + " " + "Day: " + startday);

            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("List First Date: " + stringList.First());
            Console.WriteLine("Start Date: " + startdatestring);
            Console.WriteLine("List First Day: " + daysList.First());
            Console.WriteLine("Start Day: " + startday);
            Console.WriteLine("------------------------------------------------");

            


            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Selected Occurrences days:");
            stringList.ForEach(Console.WriteLine);
            Console.WriteLine("------------------------------------------------");

            var numberofoccurrence = this.Map.EndAfterOccurrences.GetAttribute("Value");
            string listitem = stringList.Count.ToString(); //converting List Count to string. 
            Console.WriteLine(numberofoccurrence);
            Console.WriteLine(listitem);




            Console.WriteLine("------------------------------------------------Test");
            string getstartdate1 = null;
            List<string> s1 = new List<string>();
            for (int k = 1; k <= stringList.Count; k++)
            {
                getstartdate1 = this.driver.FindElement(By.XPath("//*[@id='frmRecPattern']/div[1]/div[1]/div[1]/div[2]/div[1]/span["+k+"]")).Text;
                s1.Add(getstartdate1);
            }
            
            Console.WriteLine(s1);
            s1.ForEach(Console.WriteLine);



            //ListeTime> datelist = new List<DateTime>();
           //ist<DateTime> datelist = new List<DateTime>();
           

 //         foreach (string D1 in s1)
 //         {
 //             Dates = DateTime.ParseExact(D1, "yyyy-MM-dd", null);
//              datelist.Add(Dates.ToString());
 //            //aysList.Add(Dates.DayOfWeek.ToString());
//          }

//          datelist.ForEach(Console.WriteLine);

            //Console.WriteLine(datelist);
            //daysList.ForEach(Console.WriteLine);

            Console.WriteLine("------------------------------------------------Test");

            //Need to add end day check and every week check. 

            if (stringList.Any(x => !MainIndex4.Contains(x)) && MainIndex3.Any(x => !MainIndex4.Contains(x)) && numberofoccurrence == listitem && stringList.First() == startdatestring)
            {
                
                Console.WriteLine("Pass");
                utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
            }
            else
            {
                 Console.WriteLine("Fail");
                 Assert.Fail();
                 utilities.extenttest.Log(LogStatus.Fail, "Assert Fail ");
            }

        }


        //Monthly Test Starts 

        //Recurring booking Monthly recurring pattern. Day Checkbox selected test
        [Test, Category("Recurring Bookings")]
        public void MonthlyDayBoxCheck()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Monthly Day Box Check");
            utilities.extenttest.AssignCategory("Recurring Bookings");
            login.NavigateTo();
            login.LoginSuccess();
            Thread.Sleep(3000);
            recurringbooking.RecurringButton();
            recurringbooking.MonthlyRecurringPattern();
            recurringbooking.MonthlyRecurringDayCheckBox();
            Assert.IsTrue(this.Map.MonthlyDayCheckbox.Selected);
            utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
        }


        //Recurring booking Monthly recurring pattern 
        [Test, Category("Recurring Bookings")]
        public void MonthlyWeekDayBoxCheck()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Monthly Day Box Check");
            utilities.extenttest.AssignCategory("Recurring Bookings");
            login.NavigateTo();
            login.LoginSuccess();
            Thread.Sleep(3000);
            recurringbooking.RecurringButton();
            recurringbooking.MonthlyRecurringPattern();
            recurringbooking.MonthlyRecurringWeekDayCheckBox();
            Assert.IsTrue(this.Map.MonthlyWeekdayCheckBox.Selected);
            utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
        }


        //Recurring booking Monthly recurring pattern 
        public List<DateTime> datelist = new List<DateTime>();
        [Test, Category("Recurring Bookings")]
        public void MonthlyDayTextBox()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Monthly Day Box Check");
            utilities.extenttest.AssignCategory("Recurring Bookings");
            login.NavigateTo();
            login.LoginSuccess();
            Thread.Sleep(3000);
            recurringbooking.RecurringButton();
            recurringbooking.MonthlyRecurringPattern();
            recurringbooking.MonthlyRecurringDayCheckBox();
            recurringbooking.MonthlyRecurringDayTextBox();
            recurringbooking.ShowDatesButton();
            recurringbooking.RecurringNextButton();
            recurringbooking.RecurringButton2();

            var getDays = this.Map.MonthlyDayTextBox.GetAttribute("value");

            var selectedDates = this.driver.FindElement(By.XPath("//*[@id='frmRecPattern']/div[1]/div[1]/div[1]/div[2]/input")).GetAttribute("value");
                                                               
            string[] list = selectedDates.Split('#');

            stringList.Clear();

            foreach (string days in list.Skip(2))
            {
                Dates = DateTime.ParseExact(days, "yyyy-MM-dd", null);
                var onlydates = Dates.Date;
                datelist.Add(onlydates);
                var recurrencedates = Dates.ToShortDateString();
                var Days = Dates.Day;
                stringList.Add(recurrencedates);
                stringList.Add(Days.ToString());
            }

            stringList.ForEach(Console.WriteLine);


            


            if(stringList.Equals(getDays))
            {
                Console.WriteLine("Pass");
            }
            else
            {
                Console.WriteLine("Fail");
                Assert.Fail();
            }
            

            // Assert.IsTrue(this.Map.MonthlyWeekdayCheckBox.Selected);
            // utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
        }




        [TearDown]
        public void Result()
        {
            utilities.GetResult();
        }


        [OneTimeTearDown]
        public void TestTearDown()
        {

            utilities.extent.Flush();
            // extent.Close();
            // this.driver.Quit();
        }


    }
}


