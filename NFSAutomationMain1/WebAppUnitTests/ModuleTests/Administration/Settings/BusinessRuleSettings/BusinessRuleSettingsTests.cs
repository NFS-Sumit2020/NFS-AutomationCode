using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using RelevantCodes.ExtentReports;
using System.Threading;
using WebApp.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Utilities;
using WebApp.Modules.Administration.Settings.BusinessRuleSettings;
using WebApp.BookingSummary;
using WebApp.Modules.Bookings.NewBooking;
using WebApp.Modules.Administration;

namespace WebAppUnitTests.ModuleTests.Administration.Settings.BusinessRuleSettings
{
    [TestFixture]
    public class BusinessRuleSettingsTests
    {
        public IWebDriver driver;
        public UtilitiesMain utilities;
        public WebAppLoginMain loginMain;
        public BusinessRuleSettingsMain BREMain;
        public BookingSummaryMain _bookingSummaryMain;
        public NewBookingMain newBookingMain;
        public AdministrationMain adminMain;

        [OneTimeSetUp]
        public void SetupTest()
        {
            //Init driver and call classes
            this.driver = new ChromeDriver();
            this.loginMain = new WebAppLoginMain(this.driver);
            this.utilities = new UtilitiesMain(this.driver);
            this.BREMain = new BusinessRuleSettingsMain(this.driver);
            this._bookingSummaryMain = new BookingSummaryMain(this.driver);
            this.newBookingMain = new NewBookingMain(this.driver);
            this.adminMain = new AdministrationMain(this.driver);
            utilities.ReportSetup();
        }

        //Map references from AddonReferences
        protected BusinessRuleSettingsReferences Map
        {
            get
            {
                return new BusinessRuleSettingsReferences(this.driver);
            }
        }

        //Methods to avoid dupe code
        //Login
        public void callLoginMethods()
        {
            loginMain.NavigateTo();
            loginMain.LogInSuccess();
            Thread.Sleep(4000);
        }
        //RE LOGIN
        public void callReLoginMethods()
        {
            loginMain.LogoutSuccess();
            loginMain.ReLogInNavigation();
            loginMain.LogInSuccess();
            Thread.Sleep(4000);
        }

        //Check allow mulitple hosts YES BRE Setting
        [Test, Category("Business Rule Settings Tests")]
        public void AllowMultipleHostsYes()
        {
            //Utilities config for reporting
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Allow Mulitple Hosts Yes");
            utilities.extenttest.AssignCategory("Business Rule Settings Tests");
            //Setup test configurations
            callLoginMethods();
            adminMain.AccessAdminModule();
            adminMain.BRESettingsLink();
            BREMain.SelectAllowMultipleHostsYes();
            //Logout and login to refresh setting changes
            //BREMain.ReLogin();
            callReLoginMethods();
            //Run actual test actions
            newBookingMain.AccessingNewBookingLink();   //Access new booking tab
            //newBookingMain.SingleBookingSummary();  //search for single booking and go to summary
            //START new booking creation
            newBookingMain.DurationHourDropdown();
            newBookingMain.DurationHourDropdown();
            newBookingMain.ResourceTypeDropdown();
            Thread.Sleep(2000);
            newBookingMain.SearchButton();
            Thread.Sleep(2000);
            newBookingMain.SelectingFirstResource();
            Thread.Sleep(2000);
            newBookingMain.GoToSummary();
            Thread.Sleep(4000);
            //END new booking creation
            _bookingSummaryMain.AddTitleDetails();           //Add title
            _bookingSummaryMain.AddHostDetails();            //Add Host
            _bookingSummaryMain.AddExternalHostDetails();    //Add 2nd host as an external host
            //If popup displays case fails - If no popup display case passes
            try
            {
                driver.SwitchTo().Alert();
                Console.WriteLine("Adding multiple hosts failed.");
                Assert.Fail();
            }
            catch (NoAlertPresentException Ex)
            {
                Console.WriteLine("Adding multiple hosts passed.");
                utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
                Assert.Pass();
            }
        }
        //Check allow mulitple hosts NO BRE Setting
        [Test, Category("Business Rule Settings Tests")]
        public void AllowMultipleHostsNo()
        {
            //Utilities config for reporting
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Allow Mulitple Hosts No");
            utilities.extenttest.AssignCategory("Business Rule Settings Tests");
            //Setup test configurations
            callLoginMethods();
            adminMain.AccessAdminModule();
            adminMain.BRESettingsLink();
            BREMain.SelectAllowMultipleHostsNo();
            //Logout and login to refresh setting changes
            //BREMain.ReLogin();
            callReLoginMethods();
            //Run actual test actions
            newBookingMain.AccessingNewBookingLink();   //Access new booking tab
            //newBookingMain.SingleBookingSummary();  //search for single booking and go to summary
            //START new booking creation
            newBookingMain.DurationHourDropdown();
            newBookingMain.DurationHourDropdown();
            newBookingMain.ResourceTypeDropdown();
            Thread.Sleep(2000);
            newBookingMain.SearchButton();
            Thread.Sleep(2000);
            newBookingMain.SelectingFirstResource();
            Thread.Sleep(2000);
            newBookingMain.GoToSummary();
            Thread.Sleep(4000);
            //END new booking creation
            _bookingSummaryMain.AddTitleDetails();           //Add title
            _bookingSummaryMain.AddHostDetails();            //Add Host
            _bookingSummaryMain.AddExternalHostDetails();    //Add 2nd host as an external host
            //If popup displays case fails - If no popup display case passes
            try
            {
                _bookingSummaryMain.ValidationPopup();
                if (this.Map.PopupText.Text.ToString().Contains("Multiple Hosts cannot be added."))
                {
                    Console.WriteLine("Adding multiple hosts failed. Case passed.");
                    utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
                    Assert.Pass();
                }
                else
                {
                    Console.WriteLine("Incorrect popup displayed. But mulitple host not added.");
                    Assert.Fail();
                }
            }
            catch (NoAlertPresentException Ex)
            {
                Console.WriteLine("Adding multiple hosts passed. Case failed.");
                Assert.Fail();
            }
        }
        //Check Allow Booking Without a Host YES BRE Setting
        [Test, Category("Business Rule Settings Tests")]
        public void AllowBookingWithoutHostYes()
        {
            //Utilities config for reporting
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Allow Booking Without Host Yes");
            utilities.extenttest.AssignCategory("Business Rule Settings Tests");
            //Setup test configurations
            callLoginMethods();
            adminMain.AccessAdminModule();
            adminMain.BRESettingsLink();
            BREMain.SelectAllowBookingWithoutHostYes();
            //Logout and login to refresh setting changes
            //BREMain.ReLogin();
            callReLoginMethods();
            //Run actual test actions
            newBookingMain.AccessingNewBookingLink();   //Access new booking tab
            //newBookingMain.SingleBookingSummary();  //search for single booking and go to summary
            //START new booking creation
            newBookingMain.DurationHourDropdown();
            newBookingMain.DurationHourDropdown();
            newBookingMain.ResourceTypeDropdown();
            Thread.Sleep(2000);
            newBookingMain.SearchButton();
            Thread.Sleep(2000);
            newBookingMain.SelectingFirstResource();
            Thread.Sleep(2000);
            newBookingMain.GoToSummary();
            Thread.Sleep(4000);
            //END new booking creation
            _bookingSummaryMain.AddTitleDetails();           //Add title
            _bookingSummaryMain.AddRequesterDetails();       //Add requestor
            _bookingSummaryMain.SingleBookingSave();         //Save booking
            //Check if save popup is displayed
            try
            {
                _bookingSummaryMain.ValidationPopup();
                if (this.Map.SaveBookingPopup.Text.ToString().Contains("Booking saved successfully."))
                {
                    Console.WriteLine("Booking created without a host. Case passed.");
                    utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
                    Assert.Pass();
                }
                else
                {
                    Console.WriteLine("Incorrect popup displayed. But booking not saved.");
                    Assert.Fail();
                }
            }
            catch (NoAlertPresentException Ex)
            {
                Console.WriteLine("Booking without a host not created. Case failed.");
                Assert.Fail();
            }
        }
        //Check All Booking Without a Host NO BRE Setting
        [Test, Category("Business Rule Settings Tests")]
        public void AllowBookingWithoutHostNo()
        {
            //Utilities config for reporting
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Allow Booking Without Host No");
            utilities.extenttest.AssignCategory("Business Rule Settings Tests");
            //Setup test configurations
            callLoginMethods();
            adminMain.AccessAdminModule();
            adminMain.BRESettingsLink();
            BREMain.SelectAllowBookingWithoutHostNo();
            //Logout and login to refresh setting changes
            //BREMain.ReLogin();
            callReLoginMethods();
            //Run actual test actions
            newBookingMain.AccessingNewBookingLink();   //Access new booking tab
            //newBookingMain.SingleBookingSummary();  //search for single booking and go to summary
            //START new booking creation
            newBookingMain.DurationHourDropdown();
            newBookingMain.DurationHourDropdown();
            newBookingMain.ResourceTypeDropdown();
            Thread.Sleep(2000);
            newBookingMain.SearchButton();
            Thread.Sleep(2000);
            newBookingMain.SelectingFirstResource();
            Thread.Sleep(2000);
            newBookingMain.GoToSummary();
            Thread.Sleep(4000);
            //END new booking creation
            _bookingSummaryMain.AddTitleDetails();           //Add title
            _bookingSummaryMain.AddRequesterDetails();       //Add requestor
            _bookingSummaryMain.SingleBookingSave();         //Save booking
            //If popup displays case passes
            try
            {
                _bookingSummaryMain.HostPopupValidation();
                Console.WriteLine("Booking not created without a host. Case passed.");
                utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
                Assert.Pass();
            }
            catch (NoAlertPresentException Ex)
            {
                Console.WriteLine("Booking without a host created. Case failed.");
                Assert.Fail();
            }
        }
        //Check Add Host to Existing Booking YES BRE setting
        [Test, Category("Business Rule Settings Tests")]
        public void AddHostToExistingBookingYes()
        {
            //Utilities config for reporting
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Allow Booking Without Host No");
            utilities.extenttest.AssignCategory("Business Rule Settings Tests");
            //Setup test configurations
            callLoginMethods();
            adminMain.AccessAdminModule();
            adminMain.BRESettingsLink();
            BREMain.SelectProperty();
            if (this.Map.BookingWithoutHostYes.Selected)    //check is option is already selected
            {
                //DO nothing and carry on
            }
            else
            {
                BREMain.SelectAllowBookingWithoutHostYes(); //Ensure booking can be created without a host
                callLoginMethods();
                adminMain.AccessAdminModule();
                adminMain.BRESettingsLink();
                BREMain.SelectProperty();
            }
            if (this.Map.AddHostExistingYes.Selected)   //check is option already selected
            {
                //Do nothing and carry on
            }
            else
            {
                BREMain.SelectAddHostToExistingYes();
                callReLoginMethods();
            }
            //Run actual test actions
            newBookingMain.AccessingNewBookingLink();   //Access new booking tab
            //START new booking search criteria
            newBookingMain.DurationHourDropdown();
            newBookingMain.DurationHourDropdown();
            newBookingMain.ResourceTypeDropdown();
            Thread.Sleep(2000);
            newBookingMain.SearchButton();
            Thread.Sleep(2000);
            newBookingMain.SelectingFirstResource();
            Thread.Sleep(2000);
            newBookingMain.GoToSummary();
            Thread.Sleep(4000);
            //END new booking search criteria
            //START new booking creation
            _bookingSummaryMain.AddTitleDetails();           //Add title
            _bookingSummaryMain.AddRequesterDetails();       //Add requestor
            _bookingSummaryMain.SingleBookingSave();         //Save booking
            _bookingSummaryMain.AcceptSaveBookingPopUP();    //Accept save bookings popup
            //END new booking creation
            //START add host to newly created booking
            _bookingSummaryMain.AddHostDetails();            //Add host
            _bookingSummaryMain.SingleBookingSave();         //Save booking
            //END add host to newly created booking
            //Check if save popup is displayed
            try
            {
                _bookingSummaryMain.ValidationPopup();
                if (this.Map.SaveBookingPopup.Text.ToString().Contains("Booking saved successfully."))
                {
                    Console.WriteLine("Host added to existing booking. Case passed.");
                    utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
                    Assert.Pass();
                }
                else
                {
                    Console.WriteLine("Incorrect popup displayed.");
                    Assert.Fail();
                }
            }
            catch (NoAlertPresentException Ex)
            {
                Console.WriteLine("Some other issue occurred. Case failed.");
                Assert.Fail();
            }
        }
        //Check Add host to Existing Booking NO BRE setting
        [Test, Category("Business Rule Settings Tests")]
        public void AddHostToExistingBookingNo()
        {
            //Utilities config for reporting
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Allow Booking Without Host No");
            utilities.extenttest.AssignCategory("Business Rule Settings Tests");
            //Setup test configurations
            callLoginMethods();
            adminMain.AccessAdminModule();
            adminMain.BRESettingsLink();
            BREMain.SelectProperty();
            if (this.Map.BookingWithoutHostYes.Selected)
            {
                //DO nothing and carry on
            }
            else
            {
                BREMain.SelectAllowBookingWithoutHostYes(); //Ensure booking can be created without a host
                callLoginMethods();
                adminMain.AccessAdminModule();
                adminMain.BRESettingsLink();
                BREMain.SelectProperty();
            }
            if (this.Map.AddHostExistingNo.Selected)
            {
                //Do nothing and carry on
            }
            else
            {
                BREMain.SelectAddHostToExistingNo();
                callReLoginMethods();
            }
            //Run actual test actions
            newBookingMain.AccessingNewBookingLink();   //Access new booking tab
            //START new booking search criteria
            newBookingMain.DurationHourDropdown();
            newBookingMain.DurationHourDropdown();
            newBookingMain.ResourceTypeDropdown();
            Thread.Sleep(2000);
            newBookingMain.SearchButton();
            Thread.Sleep(2000);
            newBookingMain.SelectingFirstResource();
            Thread.Sleep(2000);
            newBookingMain.GoToSummary();
            Thread.Sleep(4000);
            //END new booking search criteria
            //START new booking creation
            _bookingSummaryMain.AddTitleDetails();           //Add title
            _bookingSummaryMain.AddRequesterDetails();       //Add requestor
            _bookingSummaryMain.SingleBookingSave();         //Save booking
            _bookingSummaryMain.AcceptSaveBookingPopUP();    //Accept save bookings popup
            //END new booking creation
            //START add host to newly created booking
            _bookingSummaryMain.AddHostDetails();            //Add host
            _bookingSummaryMain.SingleBookingSave();         //Save booking
            //END add host to newly created booking
            //If popup displays case passed - If no popup display case fails
            try
            {
                _bookingSummaryMain.ValidationPopup();
                if (this.Map.HostExistingPopup.Text.ToString().Contains("Host cannot be added to an existing booking."))
                {
                    Console.WriteLine("Adding host to existing booking failed. Case passed.");
                    utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
                    Assert.Pass();
                }
                else
                {
                    Console.WriteLine("Incorrect popup displayed.");
                    Assert.Fail();
                }
            }
            catch (NoAlertPresentException Ex)
            {
                Console.WriteLine("Adding host to existing booking passed. Case failed.");
                Assert.Fail();
            }
        }
        //
        //Check zero quantity addons YES
        [Test, Category("Business Rule Settings Tests")]
        public void AllowZeroQuantityAddonsYes()
        {
            //Utilities config for reporting
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Allow Zero Quantity Addons Yes");
            utilities.extenttest.AssignCategory("Business Rule Settings Tests");
            //Setup test configurations
            callLoginMethods();
            adminMain.AccessAdminModule();
            adminMain.BRESettingsLink();
            BREMain.SelectProperty();
            BREMain.SelectAddonsCategory();
            if (this.Map.AllowZeroQuantityYes.Selected) //check if option is already selected
            {
                //DO nothing
            }
            else
            {
                BREMain.SelectZeroQuantityYes();
                callReLoginMethods();
            }
            //Run actual test actions
            newBookingMain.AccessingNewBookingLink();   //Access new booking tab
            //START new booking search criteria
            newBookingMain.DurationHourDropdown();
            newBookingMain.DurationHourDropdown();
            newBookingMain.ResourceTypeDropdown();
            Thread.Sleep(2000);
            newBookingMain.SearchButton();
            Thread.Sleep(2000);
            newBookingMain.SelectingFirstResource();
            Thread.Sleep(2000);
            newBookingMain.GoToSummary();
            Thread.Sleep(4000);
            //END new booking search criteria
            //START new booking functions
            _bookingSummaryMain.SelectAddon();
            BREMain.ZeroQuantityAddon();
            //END new booking functions
            //If addon has been added then pass
            if (this.Map.AddedAddonCategoryOne.Displayed)
            {
                Console.WriteLine("Adding zero quantity addons passed. Case passed.");
                utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
                Assert.Pass();
            }
            else
            {
                Console.WriteLine("Adding zero quantity addons failed. Case failed.");
                Assert.Fail();
            }
            
        }
        //Check zero quantity addons NO
        [Test, Category("Business Rule Settings Tests")]
        public void AllowZeroQuantityAddonsNo()
        {
            //Utilities config for reporting
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Allow Zero Quantity Addons Yes");
            utilities.extenttest.AssignCategory("Business Rule Settings Tests");
            //Setup test configurations
            callLoginMethods();
            adminMain.AccessAdminModule();
            adminMain.BRESettingsLink();
            BREMain.SelectProperty();
            BREMain.SelectAddonsCategory();
            if (this.Map.AllowZeroQuantityNo.Selected) //check if option is already selected
            {
                //DO nothing
            }
            else
            {
                BREMain.SelectZeroQuantityNo();
                callReLoginMethods();
            }
            //Run actual test actions
            newBookingMain.AccessingNewBookingLink();   //Access new booking tab
            //START new booking search criteria
            newBookingMain.DurationHourDropdown();
            newBookingMain.DurationHourDropdown();
            newBookingMain.ResourceTypeDropdown();
            Thread.Sleep(2000);
            newBookingMain.SearchButton();
            Thread.Sleep(2000);
            newBookingMain.SelectingFirstResource();
            Thread.Sleep(2000);
            newBookingMain.GoToSummary();
            Thread.Sleep(4000);
            //END new booking search criteria
            //START new booking functions
            _bookingSummaryMain.SelectAddon();
            BREMain.ZeroQuantityAddon();
            //END new booking functions
            //If popup displays case passed - If no popup display case fails
            try
            {
                _bookingSummaryMain.ValidationPopup();
                if (this.Map.AnyValidationPopup.Text.ToString().Contains("Quantity cannot be zero"))
                {
                    Console.WriteLine("Adding zero quantity addons falied. Case passed.");
                    utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
                    Assert.Pass();
                }
                else
                {
                    Console.WriteLine("Incorrect popup displayed.");
                    Assert.Fail();
                }
            }
            catch (NoAlertPresentException Ex)
            {
                Console.WriteLine("Adding zero quanity addon passed. Case failed.");
                Assert.Fail();
            }
        }
        //Check addon 48 hours cut off rule
        [Test, Category("Business Rule Settings Tests")]
        public void Addon48HourCutoffPLACEHOLDER()
        {

        }

        //Check mulitple location bookings YES
        [Test, Category("Business Rule Settings Tests")]
        public void AllowMultipleLocationsYes()
        {
            //Utilities config for reporting
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Allow multi location bookings Yes");
            utilities.extenttest.AssignCategory("Business Rule Settings Tests");
            //Setup test configurations
            callLoginMethods();
            adminMain.AccessAdminModule();
            adminMain.BRESettingsLink();
            BREMain.SelectProperty();
            BREMain.SelectBookingCategory();
            BREMain.BookingCategoryOption1();
            if (this.Map.MultipleHostsYes.Selected) //check if option is already selected
            {
                //DO nothing
            }
            else
            {
                BREMain.SelectAllowMultipleHostsYes();
                callReLoginMethods();
            }
            //Run actual test actions
            newBookingMain.AccessingNewBookingLink();   //Access new booking tab
            //START new booking search criteria
            newBookingMain.DurationHourDropdown();
            newBookingMain.DurationHourDropdown();
            newBookingMain.ResourceTypeDropdown();
            //GET a 2nd property that has resources
            int a = newBookingMain.FindPropertyWithResources();
            //reset search
            newBookingMain.AccessingNewBookingLink();
            newBookingMain.DurationHourDropdown();
            newBookingMain.DurationHourDropdown();
            newBookingMain.ResourceTypeDropdown();
            Thread.Sleep(2000);
            newBookingMain.SearchButton();
            Thread.Sleep(2000);
            newBookingMain.SelectingFirstResource();
            Thread.Sleep(2000);
            newBookingMain.GoToSummary();
            Thread.Sleep(4000);     //Currently in summary with 1 resource selected from default property - int a is value for 2nd property
            _bookingSummaryMain.BookAnotherResource();
            newBookingMain.FindProperty(a);
            //VALDATION IF RESOURCES DISPLAY
            Assert.IsTrue(this.driver.FindElement(By.XPath("//*[@id='ctl00_MainContentPlaceHolder_grdSearchResults_ctl00']/tbody")).Displayed);
        }
        //Check mulitple location bookings NO
        [Test, Category("Business Rule Settings Tests")]
        public void AllowMultipleLocationsNo()
        {

        }
    }


}
