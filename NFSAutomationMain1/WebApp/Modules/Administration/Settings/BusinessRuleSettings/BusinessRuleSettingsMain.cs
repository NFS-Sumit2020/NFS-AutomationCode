using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using WebApp.Login;
using WebApp.Modules.Bookings.NewBooking;
using WebApp.BookingSummary;
using WebApp.Modules.Bookings;
using WebApp.Modules.Administration;

namespace WebApp.Modules.Administration.Settings.BusinessRuleSettings
{
    public class BusinessRuleSettingsMain
    {
        private IWebDriver driver;
        public WebAppLoginMain loginMain;
        public BusinessRuleSettingsMain breMain;
        public AdministrationMain adminMain;
        public NewBookingMain newBookingMain;
        public BookingSummaryMain bookingSummaryMain;
        public BookingsMain bookingsMain;

        //Map references from AddonReferences
        protected BusinessRuleSettingsReferences Map
        {
            get
            {
                return new BusinessRuleSettingsReferences(this.driver);
            }
        }

        //Initialise Driver
        public BusinessRuleSettingsMain(IWebDriver driver)
        {
            this.driver = driver;
        }

        //Object creation
        public void Setup()
        {
            WebAppLoginMain loginMain = new WebAppLoginMain(this.driver);
            BusinessRuleSettingsMain breMain = new BusinessRuleSettingsMain(this.driver);
            AdministrationMain adminMain = new AdministrationMain(this.driver);
            NewBookingMain newBookingMain = new NewBookingMain(this.driver);
            BookingSummaryMain bookingSummaryMain = new BookingSummaryMain(this.driver);
            BookingsMain bookingsMain = new BookingsMain(this.driver);
        }

        //=====GLOBAL START=====
        //Login
        public void Login()
        {
            loginMain.NavigateTo();
            loginMain.LogInSuccess();
            Thread.Sleep(4000);
        }
        //Re-Login
        public void ReLogin()
        {
            loginMain.LogoutSuccess();
            loginMain.ReLogInNavigation();
            loginMain.LogInSuccess();
        }
        //Navigate to BRE Settings
        public void NavigateToBRESettings()
        {
            adminMain.AccessAdminModule();
            adminMain.BRESettingsLink();
            Thread.Sleep(2000);
        }
        //Select Correct Property
        public void SelectProperty()
        {
            //NavigateToBRESettings();
            this.Map.PropertySelectDropDown.Click();
            Thread.Sleep(1000);
            this.Map.SelectProperty.Click();
            Thread.Sleep(2000);
        }
        
        public void CreateBooking()
        {
            bookingSummaryMain.AddAllDetails();
        }
        
        //=====GLOBAL END=====
        //=====HOST ALLOCATION START=====
        //Select Host Allocation Category
        public void SelectHostAllocationCategory()
        {
            SelectProperty();
            Thread.Sleep(2000);
            this.Map.HostAllocationCategory.Click();
            Thread.Sleep(2000);
        }
        //Click OK on save - Must be used on popup window
        public void OkClick()
        {
            this.Map.OkButtonOnSave.Click();
            Thread.Sleep(2000);
        }
        //Cancel from Booking Summary
        public void CancelFromSummary()
        {
            this.Map.SummaryCancelButton.Click();
            Thread.Sleep(2000);
        }

        //Select Host Allocation Category Option1
        public void HostAllocationCategoryOption1()
        {
            SelectHostAllocationCategory();
            Thread.Sleep(2000);
            this.Map.HostAllocationCategoryOption1.Click();
            Thread.Sleep(2000);
        }

        //START Allow Multiple Hosts
        //START YES
        public void SelectAllowMultipleHostsYes()
        {
            HostAllocationCategoryOption1();
            this.Map.MultipleHostsYes.Click();
            Thread.Sleep(2000);
            this.Map.SaveBRESettings.Click();
            Thread.Sleep(2000);
        }
        /*
        //Create booking and add multi hosts
        public void BookingWithMultipleHostsYes()
        {
            CreateFromBookingsModule browser = new CreateFromBookingsModule(this.driver);
            browser.AddExternalHostSummary();
        }
        */
        //END YES
        //START NO
        public void SelectAllowMultipleHostsNo()
        {
            HostAllocationCategoryOption1();
            this.Map.MultipleHostsNo.Click();
            Thread.Sleep(2000);
            this.Map.SaveBRESettings.Click();
            Thread.Sleep(2000);
        }
        //Create booking and add multi hosts
        public void BookingWithMultipleHostsNo()
        {
            bookingSummaryMain.AddExternalHost();
            Thread.Sleep(2000);
            driver.SwitchTo().Window(driver.WindowHandles.ToList().Last());
        }
        //END NO
        //END Allow Multiple Hosts
        //START Allow Booking Without Host
        public void BookingWithoutHost()
        {
            newBookingMain.SingleBookingSummary();
            bookingSummaryMain.AddTitleDetails();
            bookingSummaryMain.AddRequesterDetails();
            Thread.Sleep(1000);
            bookingSummaryMain.SingleBookingSave();
            //driver.SwitchTo().Window(driver.WindowHandles.ToList().Last());
        }
        //START YES
        public void SelectAllowBookingWithoutHostYes()
        {
            HostAllocationCategoryOption1();
            this.Map.BookingWithoutHostYes.Click();
            Thread.Sleep(1000);
            this.Map.SaveBRESettings.Click();
        }
        //END YES
        //START NO
        public void SelectAllowBookingWithoutHostNo()
        {
            HostAllocationCategoryOption1();
            this.Map.BookingWithoutHostNo.Click();
            Thread.Sleep(1000);
            this.Map.SaveBRESettings.Click();
        }
        //END NO
        //END Allow Booking Without Host
        //START Add Host to Existing
        public void CreateDummyBooking()
        {
            newBookingMain.SingleBookingSummary();
            bookingSummaryMain.AddTitleDetails();
            bookingSummaryMain.AddRequesterDetails();
            Thread.Sleep(1000);
            bookingSummaryMain.SingleBookingSave();
        }
        public void OpenDummyBooking()
        {
            bookingsMain.AccessBookingSearchLink();
            newBookingMain.AccessExistingBookingSummary();
            Thread.Sleep(2000);
        }
        public void AddAdditionalHost()
        {
            bookingSummaryMain.AddExternalHostSummary();
            Thread.Sleep(2000);
        }
        public void AddHostToExistingBooking()
        {
            CreateDummyBooking();
            OpenDummyBooking();
            Thread.Sleep(1000);
            AddAdditionalHost();
            Thread.Sleep(1000);
        }
        //START YES
        public void SelectAddHostToExistingYes()
        {
            HostAllocationCategoryOption1();
            this.Map.AddHostExistingYes.Click();
            //this.Map.MultipleHostsYes.Click();
            Thread.Sleep(1000);
            this.Map.SaveBRESettings.Click();
        }
        //END YES
        //START NO
        public void SelectAddHostToExistingNo()
        {
            HostAllocationCategoryOption1();
            this.Map.AddHostExistingNo.Click();
            //this.Map.MultipleHostsYes.Click();
            Thread.Sleep(1000);
            this.Map.SaveBRESettings.Click();
        }
        //END NO
        //END Add Host to Existing
        //=====HOST ALLOCATION END=====
        //=====ADDONS START=====
        //Select Addons Category
        public void SelectAddonsCategory()
        {
            SelectProperty();
            Thread.Sleep(2000);
            this.Map.AddonsCategory.Click();
            Thread.Sleep(2000);
        }
        //Select Addons Category Option1
        public void AddonsCategoryOption1()
        {
            //SelectAddonsCategory();
            Thread.Sleep(2000);
            this.Map.AddonsCategoryOption1.Click();
            Thread.Sleep(2000);
        }
        //Select Addons Category Option2
        public void AddonsCategoryOption2()
        {
            //SelectAddonsCategory();
            Thread.Sleep(2000);
            this.Map.AddonsCategoryOption2.Click();
            Thread.Sleep(2000);
        }

        public void ZeroQuantityAddon()
        {
            //bookingSummaryMain.SelectAddon();
            this.Map.AddonOneQuantityInput.Clear();
            this.Map.AddonOneQuantityInput.SendKeys("0");
            Thread.Sleep(2000);
            this.Map.AddAddonsButton.Click();
        }
        //START YES
        public void SelectZeroQuantityYes()
        {
            AddonsCategoryOption1();
            this.Map.AllowZeroQuantityYes.Click();
            Thread.Sleep(1000);
            this.Map.SaveBRESettings.Click();
            Thread.Sleep(2000);
        }
        //END YES
        //START NO
        public void SelectZeroQuantityNo()
        {
            AddonsCategoryOption1();
            this.Map.AllowZeroQuantityNo.Click();
            Thread.Sleep(1000);
            this.Map.SaveBRESettings.Click();
            Thread.Sleep(2000);
        }
        //END NO
        //END Allow Zero Quantity Addons
        //START 48 Hour Cut Off - ASSUME RULE IS SET TO FRIDAY

        //END 48 Hour Cut Off
        //====ADDONS END=====

        //=====BOOKINGS START=====
        //Select Booking Category
        public void SelectBookingCategory()
        {
            SelectProperty();
            Thread.Sleep(2000);
            this.Map.BookingCategory.Click();
            Thread.Sleep(2000);
        }
        //Select Booking Category Option1
        public void BookingCategoryOption1()
        {
            //SelectBookingCategory();
            Thread.Sleep(2000);
            this.Map.BookingCategoryOption1.Click();
            Thread.Sleep(2000);
        }

        //=====BOOKINGS END=====

    }
}
