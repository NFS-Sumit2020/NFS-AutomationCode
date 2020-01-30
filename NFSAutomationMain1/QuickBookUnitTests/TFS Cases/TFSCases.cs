using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using QuickBook.Attendees;
using QuickBook.Booking;
using QuickBook.Homepage;
using QuickBook.Login;
using QuickBook.MyBookings;
using QuickBook.MyProfile;
using QuickBook.Services;
using QuickBook.Utilities;
using RelevantCodes.ExtentReports;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Configuration;
using System.Threading;
using WebApp.Modules.Administration;
using WebApp.Modules.Administration.Settings.Status;
using WebApp.Login;
using WebApp.Modules.Bookings;
using WebApp.Modules.Bookings.BookingSearch;
using WebApp.BookingSummary;
using QuickBook.EditBooking;
using WebApp.Modules.Bookings.NewBooking;

namespace QuickBookUnitTests.TFS_Cases
{
    [TestFixture]
    public class TFSCases
    {
        public IWebDriver driver;
        private readonly string TextFilePath = ConfigurationManager.AppSettings["textfilepath"];
        public MyProfile myprofile;
        public LoginMain login;
        public HomepageMain homepage;
        public ServicesMain services;
        public UtilitiesMain utilities;
        public BookingMain booking;
        public AttendeesMain attendees;
        public MyBookings mybookings;
        public WebAppLoginMain webappLogin;
        public StatusMain webappStatus;
        public AdministrationMain admin;
        public BookingsMain webAppBookingsMain;
        public BookingSearchMain webAppBookingSearchMain;
        public BookingSummaryMain webAppBookingSummaryMain;
        public EditBookingMain editBookingMain_s;
        public NewBookingMain NewBookingMain;
        protected ServicesReferences Map
        {
            get
            {
                return new ServicesReferences(this.driver);
            }
        }

        protected MyBookingsReferences MyBookingsRefMap
        {
            get
            {
                return new MyBookingsReferences(this.driver);
            }
        }

        protected BookingSearchReferences BookingSearchRefMap
        {
            get
            {
                return new BookingSearchReferences(this.driver);
            }
        }

        protected BookingSummaryReferences BookingSummaryRefMap
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
            this.myprofile = new MyProfile(this.driver);
            this.login = new LoginMain(this.driver);
            this.homepage = new HomepageMain(this.driver);
            this.services = new ServicesMain(this.driver);
            this.utilities = new UtilitiesMain(this.driver);
            this.attendees = new AttendeesMain(this.driver);
            this.booking = new BookingMain(this.driver);
            this.mybookings = new MyBookings(this.driver);
            this.webappLogin = new WebAppLoginMain(this.driver);
            this.webappStatus = new StatusMain(this.driver);
            this.admin = new AdministrationMain(this.driver);
            this.webAppBookingsMain = new BookingsMain(this.driver);
            this.webAppBookingSearchMain = new BookingSearchMain(this.driver);
            this.webAppBookingSummaryMain = new BookingSummaryMain(this.driver);
            utilities.ReportSetup();
            this.editBookingMain_s = new EditBookingMain(this.driver);
            this.NewBookingMain = new NewBookingMain(this.driver);
        }


        //Test Case 3615 from TFs. To check Cancel Popup displaying correctly. 
        [Test, Category("TFS Cases")]
        public void Case3615()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("TFS Case 3615 Cancel Popup not displaying properly");
            utilities.extenttest.AssignCategory("Case 3615. Cancel Popup");
            login.NavigateTo();
            login.LoginSuccess();
            Thread.Sleep(4000);
            homepage.SelectResource();
            login.Wait();
            attendees.AddingInternalAttendee();
            Thread.Sleep(2000);
            homepage.NextButton();
            Thread.Sleep(2000);
            booking.BookingTitle();
            var refnumber = this.driver.FindElement(By.XPath("//*[@id='page-wrap']/section[2]/div[1]/div/div[3]/span")).Text;
            Console.WriteLine(refnumber);
            mybookings.MyBookingsSelect();
            Thread.Sleep(3000);

            //Querying DB to get BookingID which is linked with cancel button on the page.
            utilities.DBConnect("SELECT BookingID, StartTime FROM [Booking] where ReferenceNumber = '" + refnumber + "'");
            Thread.Sleep(2000);
            string S1 = utilities.data[0];
            string S2 = utilities.data[1];

            Console.WriteLine("Test: " + S1);
            Console.WriteLine("Booking Date : " + S2);

            DateTime Date = Convert.ToDateTime(S2);
            string date = Date.ToShortDateString();
            int month = Date.Month;
            Console.WriteLine(date);
            Console.WriteLine(month);

            DateTime TodayDate = DateTime.Now;
            int TodayMonth = TodayDate.Month;

            Console.WriteLine("Current Month : " + TodayMonth);


            //Passing Text inside Text Box with JavascriptExecutor
            IWebElement element = driver.FindElement(By.CssSelector(".mybooking-calendar .text-box"));
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            jse.ExecuteScript("arguments[0].value='" + S2 + "';", element);

            driver.FindElement(By.CssSelector(".mybooking-calendar .text-box")).SendKeys(Keys.Enter);

            Thread.Sleep(2000);

            this.driver.FindElement(By.XPath("//*[@id='page-wrap']/section[3]/span[1]")).Click();


            //Try and catch block. When try element is not found. No such element expection is thrown and then changing the page number and going through the whole processs again.
            try
            {
                IJavaScriptExecutor ex1 = (IJavaScriptExecutor)driver;
                ex1.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//*[@data-id='" + S1 + "']")));
            }
            catch (NoSuchElementException e)
            {
                IList<IWebElement> se = driver.FindElements(By.XPath("//*[@id='customPageList']/div/ul/li"));
                IEnumerator<IWebElement> enumerator = se.GetEnumerator();

                bool hasNext = enumerator.MoveNext();

                while (hasNext)
                {

                    login.Wait();

                    int c = se.Count;

                    this.driver.FindElement(By.XPath("//*[@id='customPageList']/div/ul/li[" + c + "]/a")).Click();

                    Thread.Sleep(2000);

                    try
                    {

                        IJavaScriptExecutor ex1 = (IJavaScriptExecutor)driver;
                        ex1.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//*[@data-id='" + S1 + "']")));

                        var abc = this.driver.FindElement(By.XPath("//*[@id='ConfirmationModal']/div"));

                        if (abc.Displayed)
                        {
                            break;
                        }
                    }
                    catch (NoSuchElementException e2)
                    {
                        hasNext = enumerator.MoveNext();
                    }

                }
                enumerator.Dispose();
            }

            var confirmText = this.driver.FindElement(By.XPath("//*[@id='ConfirmationModal']/div[1]"));

            var CancelText = this.driver.FindElement(By.XPath("//*[@id='myBookingdialog']/div[1]"));

            //If Confirmation box contains the ref number then click on yes. If cancel text contains Ref number then click on OK. 
            if (confirmText.Text.Contains(refnumber))
            {
                mybookings.YesBTN();

                if (CancelText.Text.Contains("Booking with reference number " + refnumber + " cancelled successfully"))
                {
                    mybookings.SelectOK();
                    Console.WriteLine("Booking Cancelled Successfully");
                    utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
                }
            }
            //If 
            else
            {
                Console.WriteLine("Reference numnber doesn't match");
                Assert.Fail();
            }

        }


        //TFS Case 3620To check Resource Notes displayed on My Bookings Page. 
        [Test, Category("TFS Cases")]
        public void Case3620()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("TFS Case 3620 Resource notes not displaying on My bookings page");
            utilities.extenttest.AssignCategory("Case 3620. Resource notes not showing on my bookings page.");
            login.NavigateTo();
            login.LoginSuccess();
            Thread.Sleep(4000);
            homepage.SelectResource();
            login.Wait();
            attendees.AddingInternalAttendee();
            Thread.Sleep(2000);
            homepage.NextButton();
            Thread.Sleep(2000);
            booking.BookingTitle();
            var refnumber = this.driver.FindElement(By.XPath("//*[@id='page-wrap']/section[2]/div[1]/div/div[3]/span")).Text;
            Console.WriteLine(refnumber);
            mybookings.MyBookingsSelect();
            Thread.Sleep(3000);


            utilities.DBConnect("SELECT BookingID, StartTime FROM [Booking] where ReferenceNumber = '" + refnumber + "'");
            Thread.Sleep(2000);
            string D1 = utilities.data[0];
            string D2 = utilities.data[1];


            Console.WriteLine("D1: " + D1);
            Console.WriteLine("D2 : " + D2);


            //Querying DB to get NotesID and getting notes from notes table.      
            utilities.DBConnect("select booking.ReferenceNumber, notes.Notes from Booking join bookingitem on bookingitem.bookingid = booking.BookingId and booking.bookingid IN(select BookingId from booking where ReferenceNumber = '" + refnumber + "') join resource on resource.resourceid = bookingitem.resourceid join notes on notes.noteid = resource.NoteId");

            Thread.Sleep(2000);
            string S1 = utilities.data[2];
            string DBResourceNotes = utilities.data[3];

            Console.WriteLine("Ref: " + S1);
            Console.WriteLine("DB Resource Notes : " + DBResourceNotes);


            //Pasing the date value in Text box
            IWebElement element = driver.FindElement(By.CssSelector(".mybooking-calendar .text-box"));
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            jse.ExecuteScript("arguments[0].value='" + D2 + "';", element);

            driver.FindElement(By.CssSelector(".mybooking-calendar .text-box")).SendKeys(Keys.Enter);

            Thread.Sleep(2000);

            this.driver.FindElement(By.XPath("//*[@id='page-wrap']/section[3]/span[1]")).Click();

            Thread.Sleep(2000);



            try
            {
                //click on + button to expand the booking.
                IJavaScriptExecutor ex1 = (IJavaScriptExecutor)driver;
                ex1.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//*[@data-detail='" + refnumber + "']/i[1]")));
                Thread.Sleep(3000);
            }
            catch (NoSuchElementException e)
            {
                IList<IWebElement> se = driver.FindElements(By.XPath("//*[@id='customPageList']/div/ul/li"));
                IEnumerator<IWebElement> enumerator = se.GetEnumerator();

                bool hasNext = enumerator.MoveNext();

                    while (hasNext)
                    {

                     login.Wait();

                     int c = se.Count;

                     this.driver.FindElement(By.XPath("//*[@id='customPageList']/div/ul/li[" + c + "]/a")).Click();

                        Thread.Sleep(2000);

                        try
                             {
                                 IJavaScriptExecutor ex1 = (IJavaScriptExecutor)driver;
                                 ex1.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//*[@data-detail='" + refnumber + "']/i[1]")));
                                   Thread.Sleep(3000);

                             var check = this.driver.FindElement(By.Id("booking-content-view-" + refnumber + ""));

                                if (check.Displayed)
                                  {
                                    break;
                                    }

                            }

                        catch (NoSuchElementException e2)
                            {
                                 hasNext = enumerator.MoveNext();
                            }

                     enumerator.Dispose();
                    }

                }
            Thread.Sleep(3000);

            //Clicking on i Icon after expanding the booking. 
            IJavaScriptExecutor ex2 = (IJavaScriptExecutor)driver;
            ex2.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//*[@id='booking-content-view-" + refnumber + "']/div[1]/div[1]/div[1]/div[1]/ul/li/div[1]/span[1]/img")));
            Thread.Sleep(3000);

            string ResourceNotes = this.driver.FindElement(By.XPath("//*[@id='booking-content-view-" + refnumber + "']/div[1]/div[1]/div[1]/div[1]/ul/li/div[4]/div[2]/p")).Text;
            Console.WriteLine("Resource Notes : " + ResourceNotes);
            // this.driver.FindElement(By.CssSelector(".workspace-summary .firstrow img")).Click();

            if (DBResourceNotes == ResourceNotes)
            {
                Console.WriteLine("Resource notes matches with Resource notes in DB");
                utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
            }
           
            else
            {
                Console.WriteLine("Resource notes doesn't match");
                Assert.Fail();
            }
        }


        //TFS Case 3621 To check if No Show bookings displayed in mybookings. 
        
        [Test, Category("TFS Cases")]
        public void Case3621()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("TFS Case 3620 Resource notes not displaying on My bookings page");
            utilities.extenttest.AssignCategory("Case 3620. Resource notes not showing on my bookings page.");
            webappLogin.NavigateTo(); 
            webappLogin.LogInSuccess(); //WebApp Login 
            Thread.Sleep(4000);
            admin.AccessAdminModule(); //Access Admin Module 
            admin.AccessSettings();  //Access Settings Tab 
            admin.StatusLink();  //Click on Status Link 
            webappStatus.AddNewStatus();  //Creating New Status 
            string statusName = webappStatus.StatusName;
            Console.WriteLine(statusName);

            Thread.Sleep(2000);
            
             //Open New Tab in the Same window and continue on the new Window.    
             ((IJavaScriptExecutor)driver).ExecuteScript("window.open();");
             driver.SwitchTo().Window(driver.WindowHandles.Last());
              
             Thread.Sleep(2000);
             login.NavigateTo();   //Navigate to QB
             login.LoginSuccess();  //Login to QB
             Thread.Sleep(4000);
             homepage.SelectResource();  //Selecting a Resource 
             login.Wait();
             attendees.AddingInternalAttendee(); //Adding Internal Attendee
             Thread.Sleep(2000);
             homepage.NextButton(); //Go to next Page 
             Thread.Sleep(2000);
             booking.BookingTitle();
            var refnumber = this.driver.FindElement(By.XPath("//*[@id='page-wrap']/section[2]/div[1]/div/div[3]/span")).Text;
            Console.WriteLine(refnumber);
            Thread.Sleep(3000);

            driver.SwitchTo().Window(driver.WindowHandles.First());

            Thread.Sleep(2000);
            webAppBookingsMain.AccessBookingSearchLink();

            Thread.Sleep(2000);
            this.BookingSearchRefMap.BookingRefNumber.SendKeys(refnumber);

            this.BookingSearchRefMap.BookingSearchSearchButton.Click();

        
            this.BookingSearchRefMap.BookingLinkWhenSearchByRefNumber.Click();

            SelectElement select = new SelectElement(this.BookingSummaryRefMap.BookingStatusDropdown);
            select.SelectByText(statusName);
            Thread.Sleep(2000);

            this.BookingSummaryRefMap.SaveButton.Click();
            webAppBookingSummaryMain.AcceptSaveBookingPopUP();
            
            driver.SwitchTo().Window(driver.WindowHandles.Last());

            mybookings.MyBookingsSelect();
            Thread.Sleep(3000);


            utilities.DBConnect("SELECT BookingID, StartTime FROM [Booking] where ReferenceNumber = '" + refnumber + "'");
            Thread.Sleep(2000);
            string D1 = utilities.data[0];
            string D2 = utilities.data[1];


            Console.WriteLine("D1: " + D1);
            Console.WriteLine("D2 : " + D2);

            //Pasing the date value in Text box
            IWebElement element = driver.FindElement(By.CssSelector(".mybooking-calendar .text-box"));
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            jse.ExecuteScript("arguments[0].value='" + D2 + "';", element);

            driver.FindElement(By.CssSelector(".mybooking-calendar .text-box")).SendKeys(Keys.Enter);

            Thread.Sleep(2000);

            this.driver.FindElement(By.XPath("//*[@id='page-wrap']/section[3]/span[1]")).Click();

            Thread.Sleep(2000);


        }



        [Test, Category("TFS Cases")]
        public void Case3723()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("TFS Case 3620 Resource notes not displaying on My bookings page");
            utilities.extenttest.AssignCategory("Case 3620. Resource notes not showing on my bookings page.");
            webappLogin.NavigateTo();
            webappLogin.LogInSuccess();
            Thread.Sleep(4000);
            admin.AccessAdminModule();
            admin.AccessSettings();
            admin.StatusLink();
            //webappStatus.AddNewStatus();


            Thread.Sleep(2000);

            ((IJavaScriptExecutor)driver).ExecuteScript("window.open();");
            driver.SwitchTo().Window(driver.WindowHandles.Last());

            Thread.Sleep(2000);
            login.NavigateTo();
            login.LoginSuccess();
            Thread.Sleep(4000);
            homepage.SelectResource();
            login.Wait();
            attendees.AddingInternalAttendee();
            Thread.Sleep(2000);
            homepage.NextButton();
            Thread.Sleep(1000);

            //To test Some Functionality 


        }


        [Test, Category("TFS Cases")]
        public void Case3473()//Assign to Sumit - done but case is open
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("TFS Case 3473 Resource notes not displaying on My bookings page");
            utilities.extenttest.AssignCategory("Case 3473. Resource notes not showing on my bookings page.");
            login.NavigateTo(); // Loging to QuickBook
            login.LoginSuccess();// Sucess Login
            Thread.Sleep(4000);

            try
            {

                mybookings.MyBookingsSelect();

                Thread.Sleep(1000);
                editBookingMain_s.EditBookingPencil();
                Thread.Sleep(1000);
                editBookingMain_s.ISPrivate_Booking();// Check ISprivate Booking 
                Thread.Sleep(1000);

                Console.WriteLine("TFS Case 3473 run sucessfully!");
            }

            catch
            {
                Console.WriteLine("TFS Case 3473 Faild !!");
            }

        }

        [Test, Category("TFS Cases")]
        public void Case3245()//Assign to Sumit - Done 
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("TFS Case 3245 Resource notes not displaying on My bookings page");
            utilities.extenttest.AssignCategory("Case 3245. Resource notes not showing on my bookings page.");
            login.NavigateTo(); // Loging to QuickBook
            login.LoginSuccess();// Sucess Login
            Thread.Sleep(4000);

            try
            {

                homepage.MyProfileYes(); // Click 'Yes' for the 'unsaved data lost' message
                Thread.Sleep(1000);
                myprofile.IsPrimarypropertySelect();//Observe that the primary property is select
                Thread.Sleep(1000);
                Console.WriteLine("TFS Case 3245 Run sucessfully!");
            }
            catch
            {
                Console.WriteLine("TFS Case 3245 Failed !!");

            }

        }

        [Test, Category("TFS Cases")]
        public void Case3622()//Assign to Sumit - Done 
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("TFS Case 3622 Resource notes not displaying on My bookings page");
            utilities.extenttest.AssignCategory("Case 3622. Resource notes not showing on my bookings page.");
            webappLogin.NavigateTo();
            webappLogin.LogInSuccess(); //WebApp Login 
            Thread.Sleep(4000);
            try
            {
              

                NewBookingMain.AccessingNewBookingLink();//New booking link
                NewBookingMain.FromDate();
                Thread.Sleep(2000);
                NewBookingMain.ToDate();
                Thread.Sleep(1000);
                NewBookingMain.SearchButton();
                Thread.Sleep(1000);
                NewBookingMain.SelectMultiResourceforBooking();// Select multiresource for booking
                Thread.Sleep(1000);
                NewBookingMain.GoToSummary();
                Thread.Sleep(2000);

                booking.BookingTitle();
                Thread.Sleep(2000);
                NewBookingMain.participantcount();// Add no of paricipant 
                Thread.Sleep(2000);
                NewBookingMain.AddPeople();// click on Add People tab
                Thread.Sleep(2000);
                webAppBookingSummaryMain.internalsearchbox();// Search for internal Atendee           
                Thread.Sleep(2000);
                webAppBookingSummaryMain.internalsearchboxfornextAttendee();
                Thread.Sleep(2000);
                NewBookingMain.SelectAttendeeforresource();// select attendee for booking        
                Thread.Sleep(1000);
                booking.SaveandexistBooking();
                Thread.Sleep(2000);

                //Open New Tab in the Same window and continue on the new Window.    
                ((IJavaScriptExecutor)driver).ExecuteScript("window.open();");
                driver.SwitchTo().Window(driver.WindowHandles.Last());

                Thread.Sleep(2000);
                login.NavigateTo();   //Navigate to QB
                login.LoginSuccess();  //Login to QB
                Thread.Sleep(4000);
                mybookings.MyBookingsSelect();
                Thread.Sleep(1000);
                editBookingMain_s.EditBookingPencil();
                Thread.Sleep(2000);
                booking.EditForAddPeople();
                Thread.Sleep(1000);
                booking.QBAteendee();//Verify Assign Attendee added from Webapp with respective Resource
                Thread.Sleep(1000);

                Console.WriteLine("TFS case 3622 run Sucessfully! ");
            }
            catch
            {
                Console.WriteLine("TFS case 3622 Failed !!");
               

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
            // this.driver.Quit();
        }


    }
}
