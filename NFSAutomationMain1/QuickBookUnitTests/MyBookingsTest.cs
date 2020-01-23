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
using QuickBook.MyBookings;
using QuickBook.Utilities;
using NUnit.Framework;
using System.Diagnostics;
using System.Configuration;

namespace UnitTests
{
    [TestFixture]
    public class MyBookingsTest
    {
        public IWebDriver driver;
        private readonly string TextFilePath = ConfigurationManager.AppSettings["textfilepath"];
        public MyProfile myprofile;
        public LoginMain login;
        public HomepageMain homepage;
        public MyBookings mybookings;
        public UtilitiesMain utilities;



        [OneTimeSetUp]
        public void SetupTest()
        {
            this.driver = new ChromeDriver();
            this.myprofile = new MyProfile(this.driver);
            this.login = new LoginMain(this.driver);
            this.homepage = new HomepageMain(this.driver);
            this.mybookings = new MyBookings(this.driver);
            this.utilities = new UtilitiesMain(this.driver);
            utilities.ReportSetup();
        }

        //Need To Validate
        [Test, Category("MyBookingsTest")]
        public void ShowMyTeam()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Show My Team Bookings");
            utilities.extenttest.AssignCategory("MyBookings");
            login.NavigateTo();
            login.LoginSuccess();
            Thread.Sleep(4000);
            mybookings.MyBookingsSelect();
            Thread.Sleep(4000);
            mybookings.TickBox();
            //Assert.IsFalse(driver.FindElement(By.ClassName(""));
        }

        //Need To Validate
        [Test, Category("MyBookingsTest")]
        public void ShowHostBooking()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Show Host Bookings");
            utilities.extenttest.AssignCategory("MyBookings");
            login.NavigateTo();
            login.LoginSuccess();
            Thread.Sleep(4000);
            mybookings.MyBookingsEnter();
            Thread.Sleep(3000);
            mybookings.ShowHostOnly();
            // Assert.IsFail(driver.FindElement(By.("")).Displayed);
        }

        //Need To Validate
        [Test, Category("MyBookingsTest")]
        public void ChangeDateMyBookings()

        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("My Bookings Change Date");
            utilities.extenttest.AssignCategory("MyBookings");
            login.NavigateTo();
            login.LoginSuccess();
            Thread.Sleep(3000);
            mybookings.MyBookingsSelect();
            Thread.Sleep(6000);
            mybookings.Calenderselect();
            Thread.Sleep(5000);
            mybookings.GoToMyBookings();
            //   Assert.IsTrue(driver.FindElement(By.ClassName("btnclose")).Displayed);
        }

        [Test, Category("MyBookingsTest")]

        public void Crosstocancel()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Cancel from cross");
            utilities.extenttest.AssignCategory("MyBookings");
            login.NavigateTo();
            Thread.Sleep(630);
            login.LoginSuccess();
            Thread.Sleep(4000);
            mybookings.MyBookingsEnter();
            Thread.Sleep(3000);
            mybookings.PressCancel();
            Thread.Sleep(2000);
            mybookings.YesBTN();
            mybookings.SelectOK();
            Console.WriteLine("Pass");
            Assert.IsTrue(driver.FindElement(By.XPath("//*[@id='tab-0']/div/div/div[4]/span/a[1]")).Displayed);
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
