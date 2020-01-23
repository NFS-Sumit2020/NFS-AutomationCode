using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using WebApp.Utilities;
using RelevantCodes.ExtentReports;
using System.Configuration;
using WebApp.Login;
using WebApp.Modules.Administration;
using WebApp.Modules.Bookings;
using WebApp.Modules.Bookings.WaitlistBookings;


namespace WebAppUnitTests.ModuleTests.Bookings.WaitlistBookings
{

    [TestFixture]
    class WaitlistBookingTests
    {

        public IWebDriver driver;
        public UtilitiesMain utilities;
        public WebAppLoginMain loginMain;
        public AdministrationMain admin;
        public BookingsMain bookingsMain;


        protected WaitlistBookingsReferences Map
        {
            get
            {
                return new WaitlistBookingsReferences(this.driver);
            }
        }

        [OneTimeSetUp]
        public void SetupTest()
        {
            this.driver = new ChromeDriver();
            this.loginMain = new WebAppLoginMain(this.driver);
            this.utilities = new UtilitiesMain(this.driver);
            this.admin = new AdministrationMain(this.driver);
            this.bookingsMain = new BookingsMain(this.driver);
            utilities.ReportSetup();
        }

        public void callingloginmethods()
        {
            loginMain.NavigateTo();
            loginMain.LogInSuccess();
            Thread.Sleep(4000);
        }

        [Test, Category("Booking Summary Tests")]
        public void NavigateToWaitlistBookingsPage()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Booking Title Validation");
            utilities.extenttest.AssignCategory("Booking Summary Tests");
            callingloginmethods();
            Thread.Sleep(3000);
            bookingsMain.AccessWaitlistBookingTab();




        }







        }
}
