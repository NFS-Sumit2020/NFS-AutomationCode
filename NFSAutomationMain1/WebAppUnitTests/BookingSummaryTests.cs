using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using OpenQA.Selenium.Interactions;
using System.Linq;
using WebApp.Login;
using WebApp.Modules.Bookings;
using WebApp.Modules.Bookings.NewBooking;
using System.Threading;
using WebApp.Utilities;
using System;
using WebApp.BookingSummary;
using RelevantCodes.ExtentReports;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;





namespace UnitTests
{
    [TestFixture]
    public class BookingSummaryTests
    {

        public IWebDriver driver;
        public UtilitiesMain utilities;
        public WebAppLoginMain loginMain;
        public BookingSummaryMain bookingsummaryMain;
        public NewBookingMain newbookingMain;
        public BookingsMain bookingsMain;

        private readonly string Bookingtitle = ConfigurationManager.AppSettings["bookingtitle"];
        private readonly string HostName = ConfigurationManager.AppSettings["hostname"];


        protected BookingSummaryReferences Map
        {
            get
            {
                return new BookingSummaryReferences(this.driver);
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
            this.bookingsummaryMain = new BookingSummaryMain(this.driver);
            utilities.ReportSetup();
        }

        public void callingloginmethods()
        {
            loginMain.NavigateTo();
            loginMain.LogInSuccess();
            Thread.Sleep(4000);
        }

        public string refNumber = null;
        public void GetReferenceNumber()
        {
            string refnum = this.Map.ReferenceNumber.Text;
            string referenceNumber = refnum.Replace("Reference Number:", "");
            refNumber = referenceNumber.Replace(" ", string.Empty);
            Console.WriteLine(refNumber);
        }



        [Test, Category("Booking Summary Tests")]
        public void BookingTitle()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Booking Title Validation");
            utilities.extenttest.AssignCategory("Booking Summary Tests");
            callingloginmethods();
            newbookingMain.AccessingNewBookingLink();
            newbookingMain.DurationHourDropdown();
            newbookingMain.DurationHourDropdown();
            newbookingMain.ResourceTypeDropdown();
            Thread.Sleep(2000);
            newbookingMain.SearchButton();
            Thread.Sleep(2000);
            newbookingMain.SelectingFirstResource();
            Thread.Sleep(2000);
            newbookingMain.GoToSummary();
            Thread.Sleep(2000);
            bookingsummaryMain.AddTitleDetails();
            bookingsummaryMain.AddHostDetails();
            Thread.Sleep(2000);
            bookingsummaryMain.SingleBookingSave();
            Thread.Sleep(3000);         
            bookingsummaryMain.AcceptSaveBookingPopUP();          
            Thread.Sleep(3000);

            var bookingtitletext = this.Map.BookingTitleInput.GetAttribute("Value");
            Console.WriteLine(bookingtitletext);

            Thread.Sleep(3000);

            GetReferenceNumber();
            Thread.Sleep(3000);

            utilities.DBConnect("SELECT ReferenceNumber, Title From [Booking] where ReferenceNumber = '" + refNumber + "'");

            Thread.Sleep(3000);

            if (Bookingtitle == bookingtitletext    && utilities.data.Contains(refNumber) && utilities.data.Contains(Bookingtitle))
                {
                Console.WriteLine("Test Pass");
                utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
                Assert.Pass();
            }
            else
            {
                Console.WriteLine("Booking title entered and booking title saved doesn't match.");
                Assert.Fail();
            }

        }


        [Test, Category("Booking Summary Tests")]
        public void BookingHost()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Booking Host Validation");
            utilities.extenttest.AssignCategory("Booking Summary Tests");
            callingloginmethods();
            newbookingMain.AccessingNewBookingLink();
            newbookingMain.DurationHourDropdown();
            newbookingMain.DurationHourDropdown();
            newbookingMain.ResourceTypeDropdown();
            Thread.Sleep(2000);
            newbookingMain.SearchButton();
            Thread.Sleep(2000);
            newbookingMain.SelectingFirstResource();
            Thread.Sleep(2000);
            newbookingMain.GoToSummary();
            Thread.Sleep(2000);
            bookingsummaryMain.AddTitleDetails();
            bookingsummaryMain.AddHostDetails();
            Thread.Sleep(2000);
            bookingsummaryMain.SingleBookingSave();
            Thread.Sleep(3000);
            bookingsummaryMain.AcceptSaveBookingPopUP();
            Thread.Sleep(3000);
            string hostname = this.Map.HostInput.GetAttribute("Value");

            Console.WriteLine(hostname);

            GetReferenceNumber();


           // utilities.DBConnect("SELECT Booking.ReferenceNumber, AppUserDetail.DisplayName From Booking JOIN AppUserDetail ON Booking.CreatedBy=AppUserDetail.AppUserId where ReferenceNumber = '" + refNumber + "'");
            utilities.DBConnect("SELECT b.ReferenceNumber, aud.DisplayName from Booking b, AppUserDetail aud where aud.AppUserId IN (select foreignsystemcontactid from BookingAttendee where bookingid IN (select bookingid from booking where ReferenceNumber = '" + refNumber + "')) and b.ReferenceNumber = '" + refNumber + "'");

            if (hostname == HostName)
            {
                Console.WriteLine("Test Pass");
                utilities.extenttest.Log(LogStatus.Pass, "Assert pass");
                Assert.Pass();
            }
            else
            {
                Console.WriteLine("Host name entered and Host saved doesn't match.");
                Assert.Fail();
            }


        }


        [Test, Category("Booking Summary Tests")]
        public void BookingRequester()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Booking requester Validation");
            utilities.extenttest.AssignCategory("Booking Summary Tests");
            callingloginmethods();
            newbookingMain.AccessingNewBookingLink();
            newbookingMain.DurationHourDropdown();
            newbookingMain.DurationHourDropdown();
            newbookingMain.ResourceTypeDropdown();
            Thread.Sleep(2000);
            newbookingMain.SearchButton();
            Thread.Sleep(2000);
            newbookingMain.SelectingFirstResource();
            Thread.Sleep(2000);
            newbookingMain.GoToSummary();
            Thread.Sleep(2000);
            bookingsummaryMain.AddTitleDetails();
            bookingsummaryMain.AddHostDetails();
            Thread.Sleep(2000);
            bookingsummaryMain.SingleBookingSave();
            Thread.Sleep(3000);
            bookingsummaryMain.AcceptSaveBookingPopUP();
            Thread.Sleep(3000);
            string hostname = this.Map.HostInput.GetAttribute("Value");

            Console.WriteLine(hostname);

            GetReferenceNumber();

            string HostName = " Test User4";
            utilities.DBConnect("SELECT Booking.ReferenceNumber, AppUserDetail.DisplayName From Booking JOIN AppUserDetail ON Booking.CreatedBy=AppUserDetail.AppUserId where ReferenceNumber = '" + refNumber + "'");

            if (hostname == HostName)  //hostname == HostName || )
            {
                Console.WriteLine("Test Pass");
                utilities.extenttest.Log(LogStatus.Pass, "Assert pass");
                Assert.Pass();
            }
            else
            {
                Console.WriteLine("Host name entered and Host saved doesn't match.");
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
