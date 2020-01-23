using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using QuickBook;
using QuickBook.MyProfile;
using QuickBook.Login;
using QuickBook.Homepage;
using QuickBook.Booking;
using QuickBook.Attendees;
using QuickBook.Utilities;
using System.Data.SqlClient;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using RelevantCodes.ExtentReports;
using System.IO;
using System.Diagnostics;
using System.Configuration;



namespace UnitTests
{
    [TestFixture]
    public class BookingTest
    {

        public IWebDriver driver;
        public MyProfile myprofile;
        public LoginMain login;
        public HomepageMain homepage;
        public BookingMain booking;
        public AttendeesMain attendee;
        public UtilitiesMain utilities;
       
        private readonly string TextFilePath = ConfigurationManager.AppSettings["textfilepath"];


        // private readonly string Boookingnotes = ConfigurationManager.AppSettings["bookingnotes"];

        protected BookingReferences Map
        {
            get
            {
                return new BookingReferences(this.driver);
            }
        }

        [OneTimeSetUp]
        public void SetupTest()
        {
            this.driver = new ChromeDriver();
            this.myprofile = new MyProfile(this.driver);
            this.login = new LoginMain(this.driver);
            this.homepage = new HomepageMain(this.driver);
            this.booking = new BookingMain(this.driver);
            this.attendee = new AttendeesMain(this.driver);
            this.utilities = new UtilitiesMain(this.driver);
            utilities.ReportSetup();

        }

        [Test, Category("Booking Tests")]
        public void NavigateToBookingSummaryPage()
        {

            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Navigate Ti Booking Summary Page");
            utilities.extenttest.AssignCategory("Booking Tests");
            login.NavigateTo();
            login.LoginSuccess();
            Thread.Sleep(4000);
            homepage.SelectResource();
            attendee.AddingInternalAttendee();
            homepage.NextButton();
            Thread.Sleep(3000);
            Assert.IsTrue(driver.FindElement(By.XPath("//*[@id='step4ConfirmBooking']/div/form")).Displayed);
            utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
        }

        [Test, Category("Booking Tests")]
        public void CreateBooking()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Create Booking");
            utilities.extenttest.AssignCategory("Booking Tests");
            login.NavigateTo();
            login.LoginSuccess();
            Thread.Sleep(4000);
            homepage.SelectResource();
            attendee.AddingInternalAttendee();
            Thread.Sleep(2000);
            homepage.NextButton();
            Thread.Sleep(2000);
            booking.BookingTitle();
            var refnumber = this.driver.FindElement(By.XPath("//*[@id='page-wrap']/section[2]/div[1]/div/div[3]/span")).Text;
            Console.WriteLine(refnumber);
            Thread.Sleep(2000);
            utilities.DBConnect("SELECT TOP 10 ReferenceNumber, Title FROM [Booking] where ReferenceNumber = '" + refnumber + "'");
            if (utilities.data.Contains(refnumber))
            {
                utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
            }
            else
            {
                Console.WriteLine("Booking Not Found in the System.");
                Assert.Fail();
            }



            /* Connectingwithsql.DBMain();
             string connectionString;
             SqlConnection conn;
             connectionString = @"Data Source=localhost\SQLEXPRESS; Initial Catalog=WSTestSystem; Integrated Security=True";
             conn = new SqlConnection(connectionString);
             conn.Open();
             SqlCommand cmd = new SqlCommand("SELECT TOP 10 ReferenceNumber, Title FROM [Booking] where ReferenceNumber = '"+ refnumber +"'", conn);
             SqlDataReader reader = cmd.ExecuteReader();
             while (reader.Read())
             {
                 Console.WriteLine("{1}, {0}", reader.GetString(0), reader.GetString(1));
             }
             reader.Close();
             conn.Close();*/
        }



        [Test, Category("Booking Tests")]
        public void BookingType()
        {

            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Change Booking Type");
            utilities.extenttest.AssignCategory("Booking Tests");
            login.NavigateTo();
            login.LoginSuccess();
            Thread.Sleep(4000);
            homepage.SelectResource();
            attendee.AddingInternalAttendee();
            Thread.Sleep(2000);
            homepage.NextButton();
            Thread.Sleep(2000);
            booking.BookingType();
            Thread.Sleep(2000);
            booking.BookingTitle();
            var selectedType = this.Map.bookingtype.GetAttribute("value");
            Console.WriteLine("Selected Options: " + selectedType);
            var refnumber = this.driver.FindElement(By.XPath("//*[@id='page-wrap']/section[2]/div[1]/div/div[3]/span")).Text;
            Console.WriteLine(refnumber);
            Thread.Sleep(2000);
            utilities.DBConnect("  Select LookUpItem.ListItemId, Booking.ReferenceNumber FROM LookUpItem JOIN Booking ON LookUpItem.ListItemId=Booking.BookingType where ReferenceNumber = '" + refnumber + "'");

            if (utilities.data.Contains(selectedType))
            {
                utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
            }
            else
            {
                Console.WriteLine("Booking Not Found in the System.");
                Assert.Fail();
            }



        }



        [Test, Category("Booking Tests")]
        public void PrivateBooking()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Create Private Booking");
            utilities.extenttest.AssignCategory("Booking Tests");
            login.NavigateTo();
            login.LoginSuccess();
            Thread.Sleep(4000);
            homepage.SelectResource();
            attendee.AddingInternalAttendee();
            Thread.Sleep(2000);
            homepage.NextButton();
            Thread.Sleep(2000);
            booking.BookingType();
            Thread.Sleep(2000);
            booking.PrivateBooking();
            Thread.Sleep(2000);
            booking.BookingTitle();
            var PrivateBookingSelected = this.driver.FindElement(By.XPath("//*[@id='IsPrivate']")).Selected;
            Console.WriteLine("Selected Options: " + PrivateBookingSelected);
            var refnumber = this.driver.FindElement(By.XPath("//*[@id='page-wrap']/section[2]/div[1]/div/div[3]/span")).Text;
            Console.WriteLine(refnumber);
            Thread.Sleep(2000);
            utilities.DBConnect("SELECT TOP 10 ReferenceNumber, IsPrivate FROM [Booking] where ReferenceNumber = '" + refnumber + "'");
            if (PrivateBookingSelected == true)
            {
                if (utilities.data.Contains("True"))
                {
                    Console.WriteLine("Pass as both the values: Selected Option and SQL Data Value for Private booking are both True.");
                    utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
                }
                else
                {
                    Console.WriteLine("Test Failed, Private option was ticked but booking not saved as private in Database");
                    Assert.Fail();

                }

            }
            else
            {
                Console.WriteLine("Booking is not Private. Private option was not ticked.");
                Assert.Fail();
            }


        }



        [Test, Category("Booking Tests")]
        public void AddingBookingNotes()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Adding Booking Notes");
            utilities.extenttest.AssignCategory("Booking Tests");
            login.NavigateTo();
            login.LoginSuccess();
            Thread.Sleep(4000);
            homepage.SelectResource();
            attendee.AddingInternalAttendee();
            Thread.Sleep(2000);
            homepage.NextButton();
            Thread.Sleep(2000);
            booking.BookingType();
            Thread.Sleep(2000);
            booking.BookingNotes();
            Thread.Sleep(2000);
            string enteredbookingnotes = this.Map.BookingNotes.GetAttribute("value");
            Console.WriteLine("Entered Booking notes : " + enteredbookingnotes);
            Thread.Sleep(2000);
            booking.BookingTitle();
            var refnumber = this.driver.FindElement(By.XPath("//*[@id='page-wrap']/section[2]/div[1]/div/div[3]/span")).Text;
            Console.WriteLine("Booking Reference Number : " + refnumber);
            Thread.Sleep(2000);
            utilities.DBConnect("SELECT ReferenceNumber, Notes FROM [Booking] where ReferenceNumber = '" + refnumber + "'");
            if (utilities.data.Contains(enteredbookingnotes))
            {
                Console.WriteLine("Test Pass. Booking Notes match to the booking in the Database.");
                utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
            }
            else
            {
                Console.WriteLine("Test Failed. Booking Notes do not match to the booking in the Database.");
                Assert.Fail();
                utilities.extenttest.Log(LogStatus.Fail, "Assert Fail");
            }
        }


        [Test, Category("Booking Tests")]
        public void AddingBookingSpecialRequests()
        {

            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Adding Booking special Request Notes");
            utilities.extenttest.AssignCategory("Booking Tests");
            login.NavigateTo();
            login.LoginSuccess();
            Thread.Sleep(4000);
            homepage.SelectResource();
            attendee.AddingInternalAttendee();
            Thread.Sleep(2000);
            homepage.NextButton();
            Thread.Sleep(2000);
            booking.BookingType();
            Thread.Sleep(2000);
            booking.BookingSpecialRequests();
            Thread.Sleep(2000);
            string enteredbookingspecialrequests = this.Map.BookingSpecialRequests.GetAttribute("value");
            Console.WriteLine("Entered Booking notes : " + enteredbookingspecialrequests);
            Thread.Sleep(2000);
            booking.BookingTitle();
            var refnumber = this.driver.FindElement(By.XPath("//*[@id='page-wrap']/section[2]/div[1]/div/div[3]/span")).Text;
            Console.WriteLine("Booking Reference Number : " + refnumber);
            Thread.Sleep(2000);
            utilities.DBConnect("SELECT ReferenceNumber, SpecialRequest FROM [Booking] where ReferenceNumber = '" + refnumber + "'");
            if (utilities.data.Contains(enteredbookingspecialrequests))
            {
                Console.WriteLine("Test Pass. Booking SpecialRequest Notes match to the booking in the Database.");
                utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
            }
            else
            {
                Console.WriteLine("Test Failed. Booking Speical Request notes do not mach to the booking in the Database");
                Assert.Fail();
                utilities.extenttest.Log(LogStatus.Fail, "Assert Fail");
            }    

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
