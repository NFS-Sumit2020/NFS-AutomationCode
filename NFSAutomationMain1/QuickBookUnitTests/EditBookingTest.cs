using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using System.Threading;
using QuickBook;
using QuickBook.MyProfile;
using QuickBook.Login;
using QuickBook.Homepage;
using QuickBook.Utilities;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using RelevantCodes.ExtentReports;
using QuickBook.EditBooking;
using QuickBook.MyBookings;
using QuickBook.Booking;


namespace UnitTests
{
    [TestFixture]
    public class EditBookingTest
    {
        public IWebDriver driver;
        public MyProfile myprofile;
        public LoginMain login;
        public HomepageMain homepage;
        public UtilitiesMain utilities;
        public EditBookingMain editbooking;
        public MyBookings mybooking;
        public BookingMain bookings;

        protected MyProfileReferences Map
        {
            get
            {
                return new MyProfileReferences(this.driver);
            }
        }


        [OneTimeSetUp]
        public void SetupTest()
        {
            this.driver = new ChromeDriver();
            this.myprofile = new MyProfile(this.driver);
            this.login = new LoginMain(this.driver);
            this.homepage = new HomepageMain(this.driver);
            this.editbooking = new EditBookingMain(this.driver);
            this.utilities = new UtilitiesMain(this.driver);
            this.mybooking = new MyBookings(this.driver);
            this.bookings = new BookingMain(this.driver);
            //this.EditBooking = new EditBookingMain(this.driver); 

            utilities.ReportSetup();
        }

        [Test, Category("EditBookingTest")]
        public void ChangeResource()
        {
            utilities.ConsoleMessageStart();

            utilities.extenttest = utilities.extent.StartTest("ChangeResource");
            //  utilities.extenttest = utilities.extent.StartTest("Find Resource");

            login.NavigateTo();
            login.LoginSuccess();
            login.Wait();
            Thread.Sleep(4000);
            homepage.SelectResource();
            Thread.Sleep(2000);
            homepage.NextButton();
            login.Wait();
            Thread.Sleep(2500);
            bookings.BookingTitle();
            //homepage.NextButton();
            login.Wait();
            Thread.Sleep(4000);
            editbooking.CloseButton();
            Thread.Sleep(3000);
            mybooking.MyBookingsEnter();
            login.Wait();
            Thread.Sleep(5000);
            editbooking.EditBookingPencil();
            login.Wait();
            Thread.Sleep(4000);
            editbooking.EditBookingBurgerButton();
            Thread.Sleep(4000);
            editbooking.EditResourceDropdownSelectChangeResource();
            login.Wait();
            Thread.Sleep(4500);
            editbooking.ChangeResourceBTN();
            Thread.Sleep(4000);
            editbooking.Finding();
            Thread.Sleep(6000);
            editbooking.ExactMatchSelect();
            Thread.Sleep(3000);
            homepage.NextButton();
            Thread.Sleep(4000);
            //editbooking.Next();
            // homepage.NextButton();
            Thread.Sleep(4000);
            login.Wait();
            //editbooking.Finish();
            editbooking.FinishBTN();
            //EditBooking.CloseButton();
            // homepage.NextButton();

            // editbooking.EditBookingResource();
            /* Assert.IsTrue(driver.FindElement(By.XPath("//*[@id='tblResourcesGrid']/tbody/tr[2]/td")).Displayed);
             utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
             utilities.extenttest.Log(LogStatus.Info, "Test");*/
        }

        [Test, Category("EditBooking")]
        public void AddResource()
        {
            utilities.ConsoleMessageStart();

            utilities.extenttest = utilities.extent.StartTest("Add-Resource");

            login.NavigateTo();
            Thread.Sleep(3000);
            login.LoginSuccess();
            login.Wait();
            Thread.Sleep(3000);
            mybooking.MyBookingsEnter();
            Thread.Sleep(3000);
            // string text = "You have no bookings.";

            login.Wait();


           // var b = this.driver.FindElement(By.XPath("//*[@id='page-wrap']/section[2]/div/div/div[2]/h3"));
           // var a = this.driver.FindElement(By.Id("BookingList"));

            try
            {

                editbooking.EditBookingPencil();

            }
            catch (NoSuchElementException e)
            {
                this.Map.NewBookingButton.Click();
                login.Wait();
                Thread.Sleep(3500);
                homepage.SelectResource();
                login.Wait();
                Thread.Sleep(3000);
                homepage.NextButton();
                Thread.Sleep(3000);
                bookings.BookingTitle();
                mybooking.MyBookingsEnter();
                Thread.Sleep(2000);
                editbooking.EditBookingPencil();
                //Console.WriteLine("A booking was made on your behalf");
            }

           
            Thread.Sleep(3000);
            editbooking.EditBookingBurgerButton();
            Thread.Sleep(4000);
            editbooking.SelectAddResource();
            login.Wait();
            Thread.Sleep(4000);
            homepage.FindBTN();
            Thread.Sleep(4000);
            editbooking.ExactMatchSelect();
            Thread.Sleep(4000);
            editbooking.FinishBTN();


            //  Assert.IsTrue(driver.FindElement(By.Id("btnclose")).Displayed);
            // editbooking.CloseButton();

        }

        [Test, Category("EditBooking")]
        public void RemoveResource()
        {
            utilities.ConsoleMessageStart();

            utilities.extenttest = utilities.extent.StartTest("Resource-Remove");

            login.NavigateTo();

            Thread.Sleep(3000);
            login.LoginSuccess();
            login.Wait();
            Thread.Sleep(3000);
            mybooking.MyBookingsEnter();
            Thread.Sleep(3000);
            login.Wait();
            editbooking.EditBookingPencil();
            Thread.Sleep(3000);
            editbooking.EditBookingBurgerButton();
            Thread.Sleep(4000);
            editbooking.RemoveResource();
            Thread.Sleep(4000);
            editbooking.DeleteIT();
            Thread.Sleep(4000);
            editbooking.YesButton();
            Thread.Sleep(3000);

            if (driver.FindElement(By.Id("btnDialogOK")).Displayed)
            {
                editbooking.PressOk();
                mybooking.MyBookingsEnter();
                Thread.Sleep(3000);
                editbooking.EditBookingPencil();
                Thread.Sleep(3000);
                editbooking.EditBookingBurgerButton();
                Thread.Sleep(4000);
                editbooking.SelectAddResource();
                login.Wait();
                Thread.Sleep(4000);
                homepage.FindBTN();
                Thread.Sleep(4000);
                editbooking.ExactMatchSelect();
                Thread.Sleep(4000);
                editbooking.FinishBTN();
                Thread.Sleep(3000);
                mybooking.MyBookingsEnter();
                Thread.Sleep(3000);
                login.Wait();
                editbooking.EditBookingPencil();
                Thread.Sleep(3000);
                editbooking.EditBookingBurgerButton();
                Thread.Sleep(4000);
                editbooking.RemoveResource();
                Thread.Sleep(4000);
                editbooking.DeleteIT();
                Thread.Sleep(4000);
                editbooking.YesButton();
                Thread.Sleep(3000);
            }

            // editbooking.DeleteIT();
            Console.WriteLine("Pass");
            Thread.Sleep(3000);
            //  editbooking.YesButton();
            Thread.Sleep(2500);
            login.Wait();
            editbooking.SelectSave();
            //  Assert.IsTrue(this.driver.FindElement(By.Id("myBookingdialog")).Displayed);


        }

        [Test, Category("Changedate")]

        public void ModifyDateTime()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("ModifyDateTest");

            login.NavigateTo();
            Thread.Sleep(3000);
            login.LoginSuccess();
            login.Wait();
            Thread.Sleep(3000);
            mybooking.MyBookingsEnter();
            Thread.Sleep(3000);
            login.Wait();
            editbooking.EditBookingPencil();
            Thread.Sleep(3000);
            editbooking.EditBookingBurgerButton();
            Thread.Sleep(4000);
            login.Wait();
            editbooking.DateChager();
            Thread.Sleep(3500);
            homepage.CalendarSelectNextDay();
            Thread.Sleep(4000);
            login.Wait();
            editbooking.SaveButton();


            // Thread.Sleep(4000);
            // editbooking.CalendarDates();
            //  editbooking.ModifyCal();
            Thread.Sleep(4000);
            //editbooking.SaveBooking();
        }

        [Test, Category("CancelBooking")]
        public void CancelBooking()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("CancelTest");

            login.NavigateTo();
            Thread.Sleep(3000);
            login.LoginSuccess();
            login.Wait();
            Thread.Sleep(3000);
            mybooking.MyBookingsEnter();
            Thread.Sleep(3000);
            login.Wait();
            editbooking.EditBookingPencil();
            Thread.Sleep(3000);
            editbooking.EditBookingBurgerButton();
            Thread.Sleep(4000);
            editbooking.CancelABookingButton();
            Thread.Sleep(4000);
            editbooking.YesButton();
            Thread.Sleep(3000);
            Assert.IsTrue(driver.FindElement(By.XPath("//*[@id='btnokforupdate']")).Displayed);
        }

        [Test, Category("EditBookingTest")]

        public void PressNoTest()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("PressNoTest");

            login.NavigateTo();
            Thread.Sleep(1000);
            login.LoginSuccess();
            Thread.Sleep(2000);
            login.Wait();
            mybooking.MyBookingsEnter();
            Thread.Sleep(2000);
            editbooking.EditBookingPencil();
            Thread.Sleep(2500);
            editbooking.EditBookingBurgerButton();
            editbooking.CancelABookingButton();
            editbooking.DoNotcancel();
            Assert.IsTrue(driver.FindElement(By.Id("btnEditPeople")).Displayed);

        }

        [Test, Category("EditBookingTest")]

        public void ModifyResourceParticipants()
        {
            utilities.ConsoleMessageStart();

            utilities.extenttest = utilities.extent.StartTest("Add-Resource");

            login.NavigateTo();
            login.LoginSuccess();
            Thread.Sleep(2000);
            login.Wait();
            mybooking.MyBookingsEnter();
            Thread.Sleep(3000);
            editbooking.EditBookingPencil();
            Thread.Sleep(3000);
            editbooking.EditBookingBurgerButton();
            Thread.Sleep(2500);
            editbooking.ModifyResParticipants();
            Thread.Sleep(3500);
            editbooking.ParticipantValue();

            // editbooking 

            //   mybooking.
            //login.

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
        }
    }
}