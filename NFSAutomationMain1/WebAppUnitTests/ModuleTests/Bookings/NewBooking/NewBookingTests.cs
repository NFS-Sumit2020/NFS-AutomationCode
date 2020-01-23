using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using RelevantCodes.ExtentReports;
using System;
using System.Threading;
using WebApp.Login;
using WebApp.Modules.Bookings;
using WebApp.Modules.Bookings.NewBooking;
using WebApp.Utilities;


namespace UnitTests.ModuleTests.Bookings.NewBooking
{
    [TestFixture]
    public class NewBookingTests
    {
        public IWebDriver driver;
        public UtilitiesMain utilities;
        public WebAppLoginMain loginMain;
        public NewBookingMain newbookingMain;
        public BookingsMain bookingsMain;



        protected NewBookingReferences Map
        {
            get
            {
                return new NewBookingReferences(this.driver);
            }
        }


        [OneTimeSetUp]
        public void SetupTest()
        {
            this.driver = new ChromeDriver();
            this.loginMain = new WebAppLoginMain(this.driver);
            this.utilities = new UtilitiesMain(this.driver);
            this.newbookingMain = new NewBookingMain(this.driver);
            this.bookingsMain = new BookingsMain(this.driver);
            utilities.ReportSetup();
        }


        public void callingloginmethods()
        {
            loginMain.NavigateTo();
            loginMain.LogInSuccess();
            Thread.Sleep(4000);
        }

        //Accessing New Booking Page
        [Test, Category("New Booking Tests")]
        public void NewBookingPage()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Access New Booking Page");
            utilities.extenttest.AssignCategory("New Booking Tests");
            callingloginmethods();
            newbookingMain.AccessingNewBookingLink();
            if (this.driver.FindElement(By.XPath("//*[@id='ctl00_Td5']/table/tbody/tr/td/table/tbody/tr[4]/td")).Displayed)
            {
                Console.WriteLine("New Booking Link Clicked");
                utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
                Assert.Pass();

            }
            else
            {
                Console.WriteLine("New Booking Link was not clicked");
                Assert.Fail();

            }
        }

        //From Date and Time Text Field
        [Test, Category("New Booking Tests")]
        public void SearchTomorrowsDate()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Access New Booking Page");
            utilities.extenttest.AssignCategory("New Booking Tests");
            callingloginmethods();
            newbookingMain.AccessingNewBookingLink();
            newbookingMain.SearchTomorrowsDate();
            newbookingMain.DurationHourDropdown();
            Thread.Sleep(3000);
            newbookingMain.DurationMinutesDropdown();
        }


        [Test, Category("New Booking Tests")]
        //From Date Validation
        public void FromDateValidation()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("From Date Validation");
            utilities.extenttest.AssignCategory("New Booking Tests");
            callingloginmethods();
            newbookingMain.AccessingNewBookingLink();
            newbookingMain.FromDate();
            Thread.Sleep(2000);
            newbookingMain.ToDate();
            Thread.Sleep(2000);
            newbookingMain.ResourceTypeDropdown();
            newbookingMain.SearchButton();
            Thread.Sleep(4000);
            newbookingMain.SelectingFirstResource(); 
            Thread.Sleep(2000);
            var getsearchStartTime = this.Map.FromDateInput.GetAttribute("value");
            var getsearchEndTime = this.Map.ToDateInput.GetAttribute("value");
            newbookingMain.GoToSummary();
            Thread.Sleep(4000);
            var getBookingstartTime = this.Map.BookingsummarystartTime.Text;
            var getBookingendTime = this.Map.BookingsummaryendTime.Text;
            Console.WriteLine("Start Time : " + getBookingstartTime + " & " + "End Time : " + getBookingendTime);
            Console.WriteLine("Search Start Time : " + getsearchStartTime + " & " + "Search End Time : " + getsearchEndTime);

            if (getBookingstartTime == getsearchStartTime && getBookingendTime == getsearchEndTime)
            {
                Console.WriteLine("Both Start time and End Time Matches");
                utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
                Assert.Pass();
            }
            else
            {
                Console.WriteLine("Start or End time not correct");
                Assert.Fail();
            }
        }

        [Test, Category("New Booking Tests")]
        //From Date Validation
        public void BookingDurationValidation()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Booking Duration Validation");
            utilities.extenttest.AssignCategory("New Booking Tests");
            callingloginmethods();
            newbookingMain.AccessingNewBookingLink();
            newbookingMain.DurationHourDropdown();
            newbookingMain.DurationMinutesDropdown();
            newbookingMain.ResourceTypeDropdown();
            newbookingMain.SearchButton();
            Thread.Sleep(4000);
            newbookingMain.SelectingFirstResource();
            Thread.Sleep(2000);

            SelectElement selectedhours = new SelectElement(this.Map.HourDropdown);
            string SelectedHours = selectedhours.SelectedOption.Text;

            SelectElement selectedminutes = new SelectElement(this.Map.MinutesDropdown);
            string SelectedMinutes = selectedminutes.SelectedOption.Text;

            Thread.Sleep(2000);
            newbookingMain.GoToSummary();

            string Bookingduration = this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_grdSummary_ctl00_ctl04_lbtnDuration")).Text;


            string SelectedBookingDuration = SelectedHours + ":" + SelectedMinutes;

            if (Bookingduration == SelectedBookingDuration)
            {
                Console.WriteLine("Selected Booking Duration and Actual Booking Duration Match");
                utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
                Assert.Pass();
            }

            else
            {
                Console.WriteLine("Selected booking duration and actual booking duration doesn't match");
                Assert.Fail();

            }
        }

        [Test, Category("New Booking Tests")]
        public void ResourceTypeValidation()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Resource Type Validation");
            utilities.extenttest.AssignCategory("New Booking Tests");
            callingloginmethods();
            newbookingMain.AccessingNewBookingLink();          
            Thread.Sleep(3000);           
            newbookingMain.ResourceTypeDropdown();
            newbookingMain.SearchButton();
            string ResourceType = this.driver.FindElement(By.XPath("//*[@id='ctl00_MainContentPlaceHolder_grdSearchResults_ctl00']/thead/tr[1]/th[5]/a")).Text;

            SelectElement selectedresourcetype = new SelectElement(this.Map.SelectResourceTypeDropDown);
            string SelectedResourceType = selectedresourcetype.SelectedOption.Text;
            Console.WriteLine(SelectedResourceType);

            Console.WriteLine(ResourceType);

            if (SelectedResourceType == ResourceType)
            {
                Console.WriteLine("Selected Booking Resource Type and Displayed Booking Resource Type Match");
                utilities.extenttest.Log(LogStatus.Pass, "Assert pass");
                Assert.Pass();
            }

            else
            {
                Console.WriteLine("Selected Booking Resource Type and Displayed Booking Resource Type don't Match");
                Assert.Fail();

            }
        }


        //WaitList Validation
        [Test, Category("New Booking Tests")]
        public void WaitlistBookingValidation()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Waitlist booking validation");
            utilities.extenttest.AssignCategory("New Booking Tests");
            callingloginmethods();
            newbookingMain.AccessingNewBookingLink();
           // newbookingMain.SearchTomorrowsDate();
          //  newbookingMain.DurationHourDropdown();
            Thread.Sleep(3000);
            // newbookingMain.DurationMinutesDropdown();
            newbookingMain.WaitlistCheckBox();
            newbookingMain.SearchButton();
            Thread.Sleep(2000);
            newbookingMain.SelectingFirstResource();
            Thread.Sleep(2000);


           bool wait = this.Map.waitlistbookingcheckbox.Selected;

            //Console.WriteLine(wait);

            newbookingMain.GoToSummary();

            SelectElement bookingstatus = new SelectElement(this.Map.bookingstatusdropdown);
            string SelectedBookingStatus = bookingstatus.SelectedOption.Text;

            //Console.WriteLine(SelectedBookingStatus);

            var c = this.driver.FindElement(By.XPath("//*[@id='ctl00_MainContentPlaceHolder_lblwaitlist']"));
            
            if (wait == true && (SelectedBookingStatus == "Waitlist") && c.Text.Contains("THIS IS A WAITLIST BOOKING"))
            {
                Console.WriteLine("WaitList CheckBox : " + wait);
                Console.WriteLine("Booking Status : " + SelectedBookingStatus);
                Console.WriteLine("This is a waitlist booking text displayed : " + c.Text.Contains("THIS IS A WAITLIST BOOKING"));
                Console.WriteLine("Test Pass");
                utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
                Assert.Pass();
            }
            else
            {
                Console.WriteLine("Booking is not a waitlist booking.");
                Assert.Fail();
            }
        }

        //Tear Down Start
        [TearDown]
        public void Result()
        {
            utilities.GetResult();
        }


        [OneTimeTearDown]
        public void TearDownTest()
        {
            utilities.extent.Flush();
            //utilities.extent.Close();
            //this.driver.Quit();
        }
    }
}
