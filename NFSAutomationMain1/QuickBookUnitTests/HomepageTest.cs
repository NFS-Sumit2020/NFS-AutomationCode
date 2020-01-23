using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using QuickBook;
using QuickBook.MyProfile;
using QuickBook.Login;
using QuickBook.Homepage;
using QuickBook.Utilities;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using RelevantCodes.ExtentReports;
using System.IO;
using System.Diagnostics;
using System.Configuration;





namespace UnitTests
{

    [TestFixture]
    public class HomepageTest
    {
        public IWebDriver driver;
        private readonly string TextFilePath = ConfigurationManager.AppSettings["textfilepath"];
        public MyProfile myprofile;
        public LoginMain login;
        public HomepageMain homepage;
        public UtilitiesMain utilities;


        protected HomepageReferences Map
        {
            get
            {
                return new HomepageReferences(this.driver);
            }
        }

        protected HomepageValidators validatormap
        {
            get
            {
                return new HomepageValidators(this.driver);
            }
        }


        [OneTimeSetUp]
        public void SetupTest()
        {
            this.driver = new ChromeDriver();
            this.myprofile = new MyProfile(this.driver);
            this.login = new LoginMain(this.driver);
            this.homepage = new HomepageMain(this.driver);
            this.utilities = new UtilitiesMain(this.driver);
            utilities.ReportSetup();
            //utilities.ConsoleOutput();
            //Report Setup But this is moved to Utilities. Using it from there. 
            /* string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
             string actualPath = path.Substring(0, path.LastIndexOf("bin"));
             string projectPath = new Uri(actualPath).LocalPath;
             string reportPath = projectPath + "Reports\\Build v6.4.1(Fuji) " + DateTime.Now.ToString("yyyy-MM-dd HH-mm") + ".html";
             extent = new ExtentReports(reportPath, true);
             extent.AddSystemInfo("Host Name", "PC 47");
             extent.AddSystemInfo("Environment", "QA");
             extent.AddSystemInfo("User Name", "Mohit Sharma");
             string file = @"F:\Automation Testing\QuickBook Automation Team Code\QuickBookAutomation\UnitTests\Reports\extent-config.xml";
             extent.LoadConfig(file);*/
        }


        [Test, Category("HomepageTest")]
        public void FindResource()
        {

            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Find Resource");
            utilities.extenttest.AssignCategory("HomePage Tests");
            login.NavigateTo();
            login.LoginSuccess();
            Thread.Sleep(3000);
            homepage.SearchResource();
            Assert.IsTrue(driver.FindElement(By.XPath("//*[@id='tblResourcesGrid']/tbody/tr[2]/td")).Displayed);
            utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
        }

        [Test, Category("HomepageTest")]
        public void SelectResource()
        {

            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Select Resource");
            utilities.extenttest.AssignCategory("HomePage Tests");
            login.NavigateTo();
            login.LoginSuccess();
            Thread.Sleep(4000);
            homepage.SelectResource();
            Thread.Sleep(3000);
            homepage.resourceselectedvalidator();
            utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
        }

        [Test, Category("HomepageTest")]
        public void SelectedDateValidation()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Selected Date Validation");
            utilities.extenttest.AssignCategory("HomePage Tests");
            login.NavigateTo();
            login.LoginSuccess();
            Thread.Sleep(4000);
            homepage.SelectResource();
            Thread.Sleep(3000);
            var availdate = this.Map.availibilityDate.Text;
            var selecteddate = this.Map.selectedDate.Text;
            Console.WriteLine(availdate);
            Console.WriteLine(selecteddate);
            Assert.IsTrue(availdate == selecteddate);
            utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
        }


        [Test, Category("HomepageTest")]
        public void SelectResourceExactTime()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Select Resource Exact match");
            utilities.extenttest.AssignCategory("HomePage Tests");
            login.NavigateTo();
            login.LoginSuccess();
            Thread.Sleep(4000);
            homepage.SelectResource();
            Thread.Sleep(3000);
            var exactmatchTime = this.Map.exactmatchtime.Text;
            var selectedTime = this.Map.selectedexactmatchtimevalidator.Text;
            Console.WriteLine(exactmatchTime);
            Console.WriteLine(selectedTime);
            Assert.IsTrue(exactmatchTime == selectedTime);
            utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
        }


        [Test, Category("HomepageTest")]
        public void MultiLocationBookingButton()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Multi Location Booking Button");
            utilities.extenttest.AssignCategory("HomePage Tests");
            login.NavigateTo();
            login.LoginSuccess();
            Thread.Sleep(4000);
            homepage.MultiLocationBookingButton();
            Assert.IsTrue(this.driver.FindElement(By.XPath("//*[@id='stepSelection']/div/div/div/div[1]/div[1]")).Displayed);
            utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
        }

        [Test, Category("HomepageTest")]
        public void BookingDurationValidation()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Booking Duration Validation");
            utilities.extenttest.AssignCategory("HomePage Tests");
            login.NavigateTo();
            login.LoginSuccess();
            //Thread.Sleep(4000);
            login.Wait();
            homepage.SearchResource();
            // Thread.Sleep(2000);
            login.Wait();
            var Time = this.Map.exactmatchtime.Text;
            Console.WriteLine("Time: " + Time);
            string StartTime = Time.Substring(0, Time.IndexOf("-"));
            Console.WriteLine("Start Time: " + StartTime);
            string FinishTime = Time.Substring(Time.IndexOf("-") + 2);
            Console.WriteLine("Finish Time: " + FinishTime);
            string finishtimehoursplit = FinishTime.Substring(0, FinishTime.IndexOf(":"));
            Console.WriteLine("Finish Time Split: " + finishtimehoursplit);
            int finishtimehourint = Convert.ToInt32(finishtimehoursplit);
            Console.WriteLine("FT: " + finishtimehourint);
            string starttimehoursplit = StartTime.Substring(0, StartTime.IndexOf(":"));
            Console.WriteLine("Start Time split: " + starttimehoursplit);
            int starttimehourint = Convert.ToInt32(starttimehoursplit);
            Console.WriteLine("Start Time Hour in Int: " + starttimehourint);
            int Hoursum = 0;

            if ((FinishTime.Contains("pm") && !FinishTime.Contains("12")) && ((StartTime.Contains("am")) && !StartTime.Contains("12")))
            {
                Hoursum = (12 + finishtimehourint) - starttimehourint;
            }
            else if ((FinishTime.Contains("am") || FinishTime.Contains("12")) && (StartTime.Contains("am")))
            {
                Hoursum = finishtimehourint - starttimehourint;
            }
            else if (StartTime.Contains("pm"))
            {
                Hoursum = (12 + finishtimehourint) - (12 + starttimehourint);
            }
            else if ((FinishTime.Contains("pm") && !FinishTime.Contains("12")) && ((StartTime.Contains("am")) && StartTime.Contains("12")))
            {
                Hoursum = (12 + finishtimehourint);
            }

            Console.WriteLine("SUM: " + Hoursum);

            Console.WriteLine("---------------------------------------------");
            //Minutes Starts here

            string finishtimeminutesplit = FinishTime.Substring(FinishTime.IndexOf(":") + 1);
            Console.WriteLine("Finish Time Minute Split: " + finishtimeminutesplit);
            string finishtimeminutesplitpm = finishtimeminutesplit.Substring(0, 2);
            Console.WriteLine("Finish Time Minute Split PM : " + finishtimeminutesplitpm);
            int finishtimeminuteint = Convert.ToInt32(finishtimeminutesplitpm);
            Console.WriteLine("Finish Time Minute in Int: " + finishtimeminuteint);
            string starttimeminutesplit = StartTime.Substring(StartTime.IndexOf(":") + 1);
            Console.WriteLine("Start Time Minutesplit: " + starttimeminutesplit);
            string starttimeminutesplitpm = starttimeminutesplit.Substring(0, 2);
            Console.WriteLine("Start Time Minute Split PM : " + starttimeminutesplitpm);
            int starttimeminuteint = Convert.ToInt32(starttimeminutesplitpm);
            Console.WriteLine("Start Time Minute in Int: " + starttimeminuteint);
            Console.WriteLine("---------------------------------------------");

            int minutesum = 0;

            if ((finishtimeminutesplitpm.Contains("00")) && ((starttimeminutesplitpm.Contains("15")) || (starttimeminutesplitpm.Contains("30") || (starttimeminutesplitpm.Contains("45")))))
            {
                minutesum = (60 - starttimeminuteint);
                Console.WriteLine(minutesum);
            }
            else if (starttimeminuteint < finishtimeminuteint)
            {
                minutesum = finishtimeminuteint - starttimeminuteint;
                Console.WriteLine("Running second if : " + minutesum);
            }
            //else if ((starttimeminutesplitpm.Equals("00") && (finishtimeminutesplitpm.Contains("00"))))
            else if (starttimeminutesplitpm == finishtimeminutesplitpm)
            {
                minutesum = finishtimeminuteint - starttimeminuteint;
                Console.WriteLine("Running Third if : " + minutesum);
            }
            else if (starttimeminuteint > finishtimeminuteint)
            {
                minutesum = 60 + (finishtimeminuteint - starttimeminuteint);
                Console.WriteLine("Running Fourth if : " + minutesum);
            }

            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Final Minute : " + minutesum);

            Console.WriteLine("---------------------------------------------");

            string Finalminutes = "";
            if (minutesum < 15)
            {
                Finalminutes = "0" + minutesum;
                Console.WriteLine("Final minutes with Zero added in  Front :" + Finalminutes);
            }
            else
            {
                Finalminutes = minutesum.ToString();
                Console.WriteLine("Final Minute :" + Finalminutes);

            }

            if (starttimeminuteint > finishtimeminuteint)
            {
                Hoursum = Hoursum - 1;
            }

            Console.WriteLine("Hour Sum = " + Hoursum);

            Console.WriteLine("---------------------------------------------");

            string Finalduration = Hoursum + "." + Finalminutes;

            Console.WriteLine("Final Duration = " + Finalduration);

            var selecteddur = this.Map.Duration.GetAttribute("value");
            Console.WriteLine("Selected Duration = " + selecteddur);

            Assert.IsTrue(Finalduration.Equals(selecteddur));
            utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
        }

        [Test, Category("HomepageTest") , Author("Mohit Sharma")]
        
        public void SelectResourceDifferentTime()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Select Resource Different Time");
            utilities.extenttest.AssignCategory("HomePage Tests");
            login.NavigateTo();
            login.LoginSuccess();
            Thread.Sleep(4000);
            homepage.SearchResource();
            Thread.Sleep(3000);
            homepage.time();
            Thread.Sleep(5000);
            var diffTime = this.Map.differentTime.GetAttribute("data-time");
            var selectedTime = this.Map.selectedexactmatchtimevalidator.Text;
            Console.WriteLine(diffTime);
            // Console.WriteLine(selectedTime);
            // Assert.IsTrue(diffTime  selectedTime);
            Assert.AreEqual(selectedTime, diffTime);
            utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
            //This is not working need to fix this.
        }


        //GG's BOC
        //=====MY PROFILE=====

        public void Create_UserNameLink()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Username Link");
            utilities.extenttest.AssignCategory("HomePage Tests");
            login.NavigateTo();
            login.LoginSuccess();
            login.Wait();
            homepage.UserNameLink();
            login.Wait();
            Assert.IsTrue(this.validatormap.MyProfileOptionValidator.Displayed && this.validatormap.LogOutOptionValidator.Displayed);
            utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
        }



        public void Create_MyProfileLink()
        {

            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("My Profile Link");
            utilities.extenttest.AssignCategory("HomePage Tests");
            login.NavigateTo();
            login.LoginSuccess();
            login.Wait();
            homepage.MyProfleLink();
            Assert.IsTrue(this.validatormap.MyProfileConfirmNavigateValidator.Displayed || this.validatormap.MyProfileLandingScreenValidator.Displayed);
            utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
        }


        public void Create_MyProfileNavigateYes()
        {

            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("My Profile Navigate Yes");
            utilities.extenttest.AssignCategory("HomePage Tests");
            login.NavigateTo();
            login.LoginSuccess();
            login.Wait();
            homepage.MyProfileYes();
            Assert.IsTrue(this.validatormap.MyProfileConfirmNavigateValidator.Displayed);
            utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
        }

        //=====SEARCH PANEL=====

        public void Create_ChangeProperty()
        {

            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Change Property");
            utilities.extenttest.AssignCategory("HomePage Tests");
            login.NavigateTo();
            login.LoginSuccess();
            login.Wait();
            homepage.ChangePropertySelection();
            Console.WriteLine("new: " + homepage.newProperty);
            Console.WriteLine("old: " + homepage.oldProperty);
            Assert.IsTrue(((homepage.newProperty != homepage.oldProperty) && (homepage.propertyChange = true)) || ((homepage.newProperty == homepage.oldProperty) && (homepage.propertyChange = false)));
            utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
        }


        public void Create_ChangeArea()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Change Area");
            utilities.extenttest.AssignCategory("HomePage Tests");
            login.NavigateTo();
            login.LoginSuccess();
            login.Wait();
            homepage.ChangeAreaSelection();
            Console.WriteLine("new: " + homepage.newArea);
            Console.WriteLine("old: No Selection");
            Assert.IsTrue(((homepage.newArea != "Area") && (homepage.areaChange = true)) || ((homepage.newArea == "Area") && (homepage.areaChange = false)));
            utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
        }

        [Test, Category("HomepageTest")]
        public void Create_ChangeResourceType()
        {

            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Change Resource Type");
            utilities.extenttest.AssignCategory("HomePage Tests");
            login.NavigateTo();
            login.LoginSuccess();
            login.Wait();
            homepage.ChangeResourceTypeSelection();
            Console.WriteLine("old: " + homepage.oldResourceType);
            Console.WriteLine("new: " + homepage.newResourceType);
            Assert.IsTrue(((homepage.newResourceType != homepage.oldResourceType) && (homepage.resourceTypeChange = true)) || ((homepage.newResourceType == homepage.oldResourceType) && (homepage.resourceTypeChange = false)));
            utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
        }

        [Test, Category("HomepageTest")]
        public void Create_ChangeLayout()
        {

            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Change Layout");
            utilities.extenttest.AssignCategory("HomePage Tests");
            login.NavigateTo();
            login.LoginSuccess();
            login.Wait();
            homepage.ChangeLayoutSelection();
            Console.WriteLine("old: " + homepage.oldLayout);
            Console.WriteLine("new: " + homepage.newLayout);
            Assert.IsTrue(((homepage.newLayout != homepage.oldLayout) && (homepage.layoutChange = true)) || ((homepage.newLayout == homepage.oldLayout) && (homepage.layoutChange = false)));
            utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
        }


        public void Create_CheckDefaultMonth()
        {

            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Default Month Check");
            utilities.extenttest.AssignCategory("HomePage Tests");
            login.NavigateTo();
            login.LoginSuccess();
            login.Wait();
            Console.WriteLine("Default: " + this.validatormap.SelectedMonthValidator.Text);
            Console.WriteLine("Current: " + DateTime.Now.ToString("MMMM"));
            Assert.IsTrue(this.validatormap.SelectedMonthValidator.Text == DateTime.Now.ToString("MMMM"));
            utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
        }

        [Test, Category("HomepageTest")]
        public void Create_CalendarPastMonth()
        {

            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Calendar Past Month");
            utilities.extenttest.AssignCategory("HomePage Tests");
            login.NavigateTo();
            login.LoginSuccess();
            login.Wait();
            homepage.CalendarChangeMonthBack();
            Console.WriteLine("Current: " + DateTime.Now.ToString("MMMM"));
            Console.WriteLine("After Back: " + this.validatormap.SelectedMonthValidator.Text);
            Assert.IsTrue(this.validatormap.SelectedMonthValidator.Text == DateTime.Now.ToString("MMMM"));
            utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
        }

        [Test, Category("HomepageTest")]
        public void Create_CalendarMonthForward()
        {

            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Calendar Month Forward");
            utilities.extenttest.AssignCategory("HomePage Tests");
            login.NavigateTo();
            login.LoginSuccess();
            login.Wait();
            homepage.CalendarChangeMonthForward();
            Console.WriteLine("Current: " + DateTime.Now.ToString("MMMM"));
            Console.WriteLine("After Change: " + this.validatormap.SelectedMonthValidator.Text);
            Assert.IsTrue(this.validatormap.SelectedMonthValidator.Text != DateTime.Now.ToString("MMMM"));
            utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
        }

        [Test, Category("HomepageTest")]
        public void Create_CalendarMonthBack()
        {

            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Calendar Month Back");
            utilities.extenttest.AssignCategory("HomePage Tests");
            login.NavigateTo();
            login.LoginSuccess();
            Thread.Sleep(4000);
            login.Wait();
            homepage.CalendarChangeMonthForward();
            Console.WriteLine("Current: " + DateTime.Now.ToString("MMMM"));
            Console.WriteLine("After Forward Change: " + this.validatormap.SelectedMonthValidator.Text);
            Assert.IsFalse(this.validatormap.SelectedMonthValidator.Text == DateTime.Now.ToString("MMMM"));
            homepage.CalendarChangeMonthBack();
            Console.WriteLine("After Back Change: " + this.validatormap.SelectedMonthValidator.Text);
            Assert.IsTrue(this.validatormap.SelectedMonthValidator.Text == DateTime.Now.ToString("MMMM"));
            utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
        }

        [Test, Category("HomepageTest")]
        public void Create_CalendarDefaultDay()
        {

            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Calendar Default Day");
            utilities.extenttest.AssignCategory("HomePage Tests");
            login.NavigateTo();
            login.LoginSuccess();
            login.Wait();
            Console.WriteLine("Current Day: " + DateTime.Now.Day);
            Console.WriteLine("Default Day: " + this.validatormap.CalendarDefaultDayValidator.Text);
            Assert.IsTrue(this.validatormap.CalendarDefaultDayValidator.Text == DateTime.Now.Day.ToString());
            utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
        }

        [Test, Category("HomepageTest")]
        public void Create_CalendarValidDaySelection()
        {

            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Calendar Valid Day Selection");
            utilities.extenttest.AssignCategory("HomePage Tests");
            login.NavigateTo();
            login.LoginSuccess();
            login.Wait();
            homepage.CalendarSelectNextDay();
            Console.WriteLine("Current Day: " + DateTime.Now.Day);
            Console.WriteLine("Selected Day: " + this.validatormap.CalendarSelectedDayValidator.Text);
            int selectedDay = Int32.Parse(this.validatormap.CalendarSelectedDayValidator.Text);
            Assert.IsTrue(selectedDay != DateTime.Now.Day);
            utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
        }

        [Test, Category("HomepageTest")]
        public void Create_CalendarInvalidDaySelection()
        {

            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Calendar Invalid Day Selection");
            utilities.extenttest.AssignCategory("HomePage Tests");
            login.NavigateTo();
            login.LoginSuccess();
            login.Wait();
            homepage.CalendarSelectPastDay();
            int selectedDay = Int32.Parse(this.validatormap.CalendarDefaultDayValidator.Text);
            Assert.IsTrue((selectedDay == DateTime.Now.Day) || (homepage.calendarPastDayValidation == "No possible past days available"));
            utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
        }

        [Test, Category("HomepageTest")]
        public void Create_StartTimePastCheck()
        {

            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Start Time Past Check");
            utilities.extenttest.AssignCategory("HomePage Tests");
            login.NavigateTo();
            login.LoginSuccess();
            login.Wait();
            homepage.StartTimePast();
            Assert.IsTrue(this.validatormap.StartTimeValidationButtonValidator.Displayed);
            utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
        }

        [Test, Category("HomepageTest")]
        public void Create_StartTimePastValidationReturn()
        {

            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Start Time Past Validation Return");
            utilities.extenttest.AssignCategory("HomePage Tests");
            login.NavigateTo();
            login.LoginSuccess();
            login.Wait();
            homepage.StartTimePastReturn();
            Console.WriteLine("Selected Time: " + this.validatormap.StartTimeSelectedValidator.GetAttribute("value"));
            Console.WriteLine("Default Time: " + homepage.oldStartTime);
            Assert.IsTrue(this.validatormap.StartTimeSelectedValidator.GetAttribute("value") == homepage.oldStartTime);
            utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
        }

        //Need to Validate
        [Test, Category("HomepageTest")]
        public void Create_DurationFilterCheck()
        {

            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Duration Filter Check");
            utilities.extenttest.AssignCategory("HomePage Tests");
            login.NavigateTo();
            login.LoginSuccess();
            login.Wait();
            homepage.StartTimeChange();
            //  homepage.DurationDropDown();
            // Boolean present1 = homepage.isAttributePresent(this.validatormap.DurationTimeShownValidator, "style");
            //  Boolean present2 = homepage.isAttributePresent(this.validatormap.DurationTimeNotShownValidator, "style");
            //  Assert.IsTrue(!present1 && present2); //NOT WORKING - ALWAYS THINKS ATTRIBUTE EXISTS WHEN IT DOESN't
        }

        [Test, Category("HomepageTest")]
        public void Create_ResetButton()
        {

            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Reset Button Check");
            utilities.extenttest.AssignCategory("HomePage Tests");
            login.NavigateTo();
            login.LoginSuccess();
            login.Wait();
            homepage.ChangePropertySelection(); //Change Property
            Thread.Sleep(5000);
            Console.WriteLine("new Prop: " + homepage.newProperty);
            Console.WriteLine("old Prop: " + homepage.oldProperty);
            homepage.ChangeAreaSelection(); //Change Area
            Thread.Sleep(1000);
            Console.WriteLine("new Area: " + homepage.newArea);
            Console.WriteLine("old Area: No Selection");
            homepage.ChangeResourceTypeSelection(); //Change Resource Type
            Thread.Sleep(1000);
            Console.WriteLine("old ResType: " + homepage.oldResourceType);
            Console.WriteLine("new ResType: " + homepage.newResourceType);
            homepage.ChangeLayoutSelection(); //Change Layout
            Thread.Sleep(1000);
            Console.WriteLine("old Layout: " + homepage.oldLayout);
            Console.WriteLine("new Layout: " + homepage.newLayout);
            homepage.CalendarSelectNextDay(); //Change Date
            Thread.Sleep(1000);
            Console.WriteLine("Current Day: " + DateTime.Now.Day);
            Console.WriteLine("Selected Day: " + this.validatormap.CalendarSelectedDayValidator.Text);
            homepage.StartTimeChange(); //Change Start Time
            Thread.Sleep(1000);
            Console.WriteLine("old Time: " + homepage.oldStartTime);
            Console.WriteLine("new Time: " + homepage.newStartTime);
            homepage.ChangeDurationSelection(); //Change Duration
            Thread.Sleep(1000);
            Console.WriteLine("old Duration: " + homepage.oldDuration);
            Console.WriteLine("new Duration: " + homepage.newDuration);
            homepage.ChangeParticipantsValue(); //Change Participants
            Thread.Sleep(1000);
            Console.WriteLine("old Participants: " + homepage.oldParticipantsValue);
            Console.WriteLine("new Participants: " + homepage.newParticipantsValue);
            homepage.ResetSearch();
            Thread.Sleep(3000);
            //ADDED VALIDATION FOR ALL FIELDS
            Boolean propertyValidation = false;
            if (homepage.oldProperty == this.validatormap.PropertyDropDownSelectedValidator.GetAttribute("value"))
            {
                propertyValidation = true;
            }
            Boolean resourceTypeValdiation = false;
            if (homepage.oldResourceType == this.validatormap.ResourceTypeDropDownSelectedValidator.GetAttribute("value"))
            {
                resourceTypeValdiation = true;
            }
            Boolean layoutValidation = false;
            var dropDownLayout = new SelectElement(this.validatormap.LayoutDropDownValidator);
            var dropDownSelectedLayout = dropDownLayout.SelectedOption.Text;
            if (homepage.oldLayout == dropDownSelectedLayout || homepage.layoutChange == false)
            {
                layoutValidation = true;
            }
            Boolean dateValidation = false;
            int selectedDay = Int32.Parse(this.validatormap.CalendarSlectedCurrentDateValidator.Text);
            if (selectedDay == DateTime.Now.Day)
            {
                dateValidation = true;
            }
            Boolean startTimeValidation = false;
            if (homepage.oldStartTime == this.validatormap.StartTimeSelectedValidator.GetAttribute("value"))
            {
                startTimeValidation = true;
            }
            Boolean durationValidation = false;
            var dropDownDuration = new SelectElement(this.validatormap.DurationDropDownValidator);
            var dropDownSelectedDuration = dropDownDuration.SelectedOption.Text;
            if (homepage.oldDuration == dropDownSelectedDuration)
            {
                durationValidation = true;
            }
            Boolean participantsValidation = false;
            int currentParticpantsValue = Int32.Parse(this.validatormap.ParticipantsSearchValueValidator.GetAttribute("value"));
            if (homepage.newParticipantsValue != currentParticpantsValue)
            {
                participantsValidation = true;
            }
            Assert.IsTrue(propertyValidation && (this.validatormap.AreaDropDownValidator.GetAttribute("value") == "Area") && resourceTypeValdiation && layoutValidation && dateValidation && startTimeValidation && durationValidation && participantsValidation);
        }
        //=====SEARCH PANEL END=====
        //=====SEARCH START=====
        [Test, Category("HomepageTest")]
        public void Create_SearchSingleDate()
        {

            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Search Single Date");
            utilities.extenttest.AssignCategory("HomePage Tests");
            login.NavigateTo();
            login.LoginSuccess();
            login.Wait();
            homepage.SinglePropertySearch();
            Thread.Sleep(5000);
            string searchedForDate = this.validatormap.SearchedForDateValidator.Text;
            Console.WriteLine("Date Displayed: " + searchedForDate);
            Console.WriteLine("Date Searched: " + this.validatormap.CalendarSelectedDayValidator.Text);
            Assert.IsTrue(searchedForDate.Contains(this.validatormap.CalendarSelectedDayValidator.Text));
            utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
        }

        [Test, Category("HomepageTest")]
        public void Create_SearchSingleProperty()
        {

            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Search Single Property");
            utilities.extenttest.AssignCategory("HomePage Tests");
            login.NavigateTo();
            login.LoginSuccess();
            login.Wait();
            homepage.SinglePropertySearch();
            Thread.Sleep(5000);
            string searchedForProperty = this.validatormap.SearchedForPropertyValidator.Text;
            Console.WriteLine("Property Displayed: " + searchedForProperty);
            Console.WriteLine("Property Searched: " + this.validatormap.PropertyDropDownSelectedValidator.GetAttribute("value"));
            Assert.IsTrue(searchedForProperty.Contains(this.validatormap.PropertyDropDownSelectedValidator.GetAttribute("value")));
            utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
        }

        [Test, Category("HomepageTest")]
        public void Create_SearchSingleTime()
        {

            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Search Single Time");
            utilities.extenttest.AssignCategory("HomePage Tests");
            login.NavigateTo();
            login.LoginSuccess();
            login.Wait();
            homepage.SinglePropertySearch();
            Thread.Sleep(5000);
            string searchedForTime = this.validatormap.StartTimeSelectedValidator.GetAttribute("value");
            Boolean present1 = homepage.isAttributePresent(this.validatormap.SearchedForTimeValidator, "style");
            if (present1 == true)
            {
                Console.WriteLine("Exact match starts at 9am");
                Assert.Pass();
                utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
            }
            else
            {
                Console.WriteLine("Exact match does not start at 9am or not available resources exist");
                Assert.Fail();

            }
        }

        [Test, Category("HomepageTest")]
        public void Create_SearchParticipantsValue()
        {

            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Search Participants Value");
            utilities.extenttest.AssignCategory("HomePage Tests");
            login.NavigateTo();
            login.LoginSuccess();
            login.Wait();
            homepage.SinglePropertySearch();
            Thread.Sleep(5000);
            homepage.SinglePropertySelect();
            Thread.Sleep(3000);
            Console.WriteLine("participants in Search " + this.validatormap.ParticipantsSearchValueValidator.GetAttribute("value"));
            Console.WriteLine("participants on select " + this.validatormap.SearchedForParticipantsValidator.Text);
            Assert.IsTrue(this.validatormap.SearchedForParticipantsValidator.Text.Contains(this.validatormap.ParticipantsSearchValueValidator.GetAttribute("value")));
            utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
        }

        [Test, Category("HomepageTest")]
        public void Create_SearchSingleResourceSelected()
        {

            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Search Single Resource Selected");
            utilities.extenttest.AssignCategory("HomePage Tests");
            login.NavigateTo();
            login.LoginSuccess();
            login.Wait();
            homepage.SinglePropertySearch();
            Thread.Sleep(5000);
            homepage.SinglePropertySelect();
            Thread.Sleep(3000);
            Assert.IsTrue(this.validatormap.FirstResourceNameValidator.Text == this.validatormap.SelectedResourceNameValidator.Text);
            utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
        }

        [Test, Category("HomepageTest")]
        public void Create_ResourceListInformation()
        {

            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Resource List Information");
            utilities.extenttest.AssignCategory("HomePage Tests");
            login.NavigateTo();
            login.LoginSuccess();
            login.Wait();
            homepage.SinglePropertySearch();
            Thread.Sleep(5000);
            homepage.ResourceListInformationIcon();
            Boolean present1 = homepage.isAttributePresent(this.validatormap.ResourceListInformationValidator, "class");
            Assert.IsTrue(present1 == true);
            utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
        }

        [Test, Category("HomepageTest")]
        public void Create_SelectedResourceInformation()
        {

            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Selected Resource Information");
            utilities.extenttest.AssignCategory("HomePage Tests");
            login.NavigateTo();
            login.LoginSuccess();
            login.Wait();
            homepage.SinglePropertySearch();
            Thread.Sleep(5000);
            homepage.SinglePropertySelect();
            Thread.Sleep(3000);
            homepage.SelectedResourceInformationIcon();
            Boolean present1 = homepage.isAttributePresent(this.validatormap.SelectedResourceInformationValidator, "class");
            Assert.IsTrue(present1 == true);
            utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
        }

        [Test, Category("HomepageTest")]
        public void Create_RemoveSelectedResource()
        {

            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Remove Selected Resource");
            utilities.extenttest.AssignCategory("HomePage Tests");
            login.NavigateTo();
            login.LoginSuccess();
            login.Wait();
            homepage.SinglePropertySearch();
            Thread.Sleep(5000);
            homepage.SinglePropertySelect();
            Thread.Sleep(3000);
            homepage.RemoveSelectedResource();
            Assert.IsTrue(this.validatormap.RemoveResourcePopupValidator.Displayed);
            utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
        }

        [Test, Category("HomepageTest")]
        public void Create_RemoveSelectedResourceNO()
        {

            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Remove Selected Resource No");
            utilities.extenttest.AssignCategory("HomePage Tests");
            login.NavigateTo();
            login.LoginSuccess();
            login.Wait();
            homepage.SinglePropertySearch();
            Thread.Sleep(5000);
            homepage.SinglePropertySelect();
            Thread.Sleep(3000);
            homepage.RemoveSelectedResourceNo();
            Assert.IsTrue(this.validatormap.SelectedResourceNameValidator.Displayed);
            utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
        }

        [Test, Category("HomepageTest")]
        public void Create_RemoveSelectedResourceYES()
        {

            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Remove Selected Resource Yes");
            utilities.extenttest.AssignCategory("HomePage Tests");
            login.NavigateTo();
            login.LoginSuccess();
            login.Wait();
            homepage.SinglePropertySearch();
            Thread.Sleep(5000);
            homepage.SinglePropertySelect();
            Thread.Sleep(3000);
            homepage.RemoveSelectedResourceYes();
            Assert.IsTrue(this.validatormap.NoResourcesSelectedValidator.Text == "No Selection");
            utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
        }

        [Test, Category("HomepageTest")]
        public void Create_ChangeParticipants()
        {

            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Change Participants");
            utilities.extenttest.AssignCategory("HomePage Tests");
            login.NavigateTo();
            login.LoginSuccess();
            login.Wait();
            homepage.SinglePropertySearch();
            Thread.Sleep(5000);
            homepage.SinglePropertySelect();
            Thread.Sleep(3000);
            homepage.ChangeParticipants();
            Assert.IsTrue(this.validatormap.ChangeParticpantsInputValidator.Displayed);
            utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
        }

        //Need to validate
        [Test, Category("HomepageTest")]
        public void Create_ChangeParticipantsNO()
        {

            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Change Participants No");
            utilities.extenttest.AssignCategory("HomePage Tests");
            login.NavigateTo();
            login.LoginSuccess();
            login.Wait();
            homepage.SinglePropertySearch();
            Thread.Sleep(5000);
            homepage.SinglePropertySelect();
            Thread.Sleep(3000);
        }

        //Need to validate
        [Test, Category("HomepageTest")]
        public void Create_ChangeParticipantsYES()
        {

            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Change Participants Yes");
            utilities.extenttest.AssignCategory("HomePage Tests");
            login.NavigateTo();
            login.LoginSuccess();
            login.Wait();
            homepage.SinglePropertySearch();
            Thread.Sleep(5000);
            homepage.SinglePropertySelect();
            Thread.Sleep(3000);
        }

        //Test for time conversion 12 hour to 24 hour
        [Test, Category("HomepageTest")]
        public void ConversionTest()
        {

            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Conversion Test");
            utilities.extenttest.AssignCategory("HomePage Tests");
            login.NavigateTo();
            login.LoginSuccess();
            login.Wait();
            homepage.CalendarSelectNextDay();
            homepage.StartTimeChange();
            Console.WriteLine(homepage.newStartTime);
            string newTime = utilities.ConvertTimeTo24(homepage.newStartTime);
            Console.WriteLine(newTime); //This is to stop writing to file and then start reading from file to console. 
            Assert.IsTrue(newTime.Contains("Hi"));
            utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
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
            this.driver.Quit();
        }


    }
}
