using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Configuration;
using WebApp.Modules.Bookings.NewBooking;

namespace WebApp.BookingSummary
{
    public class BookingSummaryMain
    {
        private IWebDriver driver;
        private readonly string HostName = ConfigurationManager.AppSettings["hostname"];
        private readonly string BookingTitle = ConfigurationManager.AppSettings["bookingtitle"];

        public BookingSummaryMain bookingSummaryMain;
        public NewBookingMain newBookingMain;

        //Init driver
        public BookingSummaryMain(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void Setup()
        {
            BookingSummaryMain bookingSummaryMain = new BookingSummaryMain(this.driver);
            NewBookingMain newBookingMain = new NewBookingMain(this.driver);
        }

        //Map references
        protected BookingSummaryReferences Map
        {
            get
            {
                return new BookingSummaryReferences(this.driver);
            }
        }

        //======GLOBAL START=====
        //Save Booking
        public void SingleBookingSave()
        {
            this.Map.SaveButton.Click();
            Thread.Sleep(3000);
           // this.Map.BookingSaveSuccessPopup.Click();
        }

        //USE AFTER SAVE TO GET THE REFERENCE NUMBER ****IMPORTANT****
       /*
        *Moved this to Test Class
        public string GetReferenceNumber()
        {
            string refnum = this.Map.ReferenceNumber.Text;
            string referenceNumber = refnum.Replace("Reference Number:", "");
            string refNumber = referenceNumber.Replace(" ", string.Empty);
            Console.WriteLine(refNumber);
        }*/
        public void BookAnotherResource()
        {
            this.Map.BookAnotherResourceButton.Click();
            Thread.Sleep(3000);
        }
        //=====GLOBAL END=====

        //Add Title - MUST BE ON BOOKING SUMMARY TO USE
        public void AddTitleDetails()
        {
          
            Thread.Sleep(1000);
            this.Map.BookingTitleInput.SendKeys(BookingTitle);
            Thread.Sleep(2000);
        }
        


        public void AcceptSaveBookingPopUP()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(40));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("ctl00_MainContentPlaceHolder_lblReferenceNumber")));
            Thread.Sleep(2000);
            driver.SwitchTo().ActiveElement().FindElement(By.XPath("/html/body/div[3]"));
            Thread.Sleep(2000);
            this.Map.PopupMessage.Click();
            Thread.Sleep(4000);       
        }

        //Validation popup handling
        public void ValidationPopup()
        {
            Thread.Sleep(2000);
            driver.SwitchTo().ActiveElement().FindElement(By.XPath("/html/body/div[3]"));
            Thread.Sleep(2000);
        }
        //Validation for Host Popup
        public void HostPopupValidation()
        {
            Thread.Sleep(2000);
            IWebElement HostFrame = this.Map.GetFrameForHost;
            driver.SwitchTo().Frame(HostFrame);
            Thread.Sleep(2000);
        }
        //Validation for Addon notification message accepted
        public void AcceptAddonNotificationPopup()
        {
            Thread.Sleep(2000);
            driver.SwitchTo().ActiveElement().FindElement(By.XPath("//*[@id='RadWindowWrapper_ctl00_MainContentPlaceHolder_ctl00_rdAddonNotification']"));
            Thread.Sleep(2000);
            this.Map.AddonValidationContinue.Click();
            Thread.Sleep(2000);
        }


        
        public void internalattendee()
        {
            this.Map.InternalButton.Click();
        }

        public void internalsearchbox()

        {
            this.Map.InternalSearchbox.Click();
            Thread.Sleep(1000);
            this.Map.InternalSearchbox.SendKeys("Sumit");
            Thread.Sleep(2000);
            this.Map.InternalSearchbuttn.Click();
            Thread.Sleep(1000);
            this.Map.InternalAddattendeeaddbtn.Click();
            Thread.Sleep(1000);

        }

        public void internalsearchboxfornextAttendee()

        {
            this.Map.InternalSearchbox.Click();
            Thread.Sleep(1000);
            this.Map.InternalSearchbox.SendKeys("TestSumit");
            Thread.Sleep(2000);
            this.Map.InternalSearchbuttn.Click();
            Thread.Sleep(1000);
            this.Map.InternalAddattendeeaddbtn.Click();
            Thread.Sleep(1000);

        }
        public void internalserchbuttn()

        {
            this.Map.InternalSearchbuttn.Click();

        }

        public void popupforateendeeok()

        {
            this.Map.popupforateendee.Click();
        }
        //AddPeopleTab

        public void AddPeopleTabbtn()
        {
            this.Map.AddPeopleTab.Click();
        }

        public void Addattendeebtn()// + buton

        {
            this.Map.InternalAddattendeeaddbtn.Click();
        }








        //SINGLE USE START
        //Add Host info - MUST BE ON BOOKING SUMMARY TO USE
        public void AddHostDetails()
        {
            this.Map.HostSearchIcon.Click();
            Thread.Sleep(2000);
            IWebElement HostFrame = this.Map.GetFrameForHost;
            driver.SwitchTo().Frame(HostFrame);
            Thread.Sleep(2000);
            this.Map.HostFrameInput.Click();
           // this.Map.HostFrameInput.SendKeys(HostName);
            this.Map.HostFrameInput.SendKeys("Test User4");
            Thread.Sleep(2000);
            this.Map.HostFrameSearch.Click();
            Thread.Sleep(2000);
            this.Map.HostFrameSelect.Click();
            Thread.Sleep(3000);
            driver.SwitchTo().DefaultContent();
        }

        //TESTING ADD HOST ONLY
        public void AddHostDetailsTest()
        {
            this.Map.HostInput.SendKeys(HostName);
            Thread.Sleep(4000);
            var addName = this.Map.HostSelect;
            addName.Click();
            Thread.Sleep(2000);
        }

        //Add Requester info - MUST BE ON BOOKING SUMMARY TO USE
        public void AddRequesterDetails()
        {
            this.Map.RequesterSearchIcon.Click();
            Thread.Sleep(2000);
            IWebElement RequesterFrame = this.Map.GetFrameForRequester;
            driver.SwitchTo().Frame(RequesterFrame);
            Thread.Sleep(2000);
            this.Map.RequesterFrameInput.Click();
            this.Map.RequesterFrameInput.SendKeys(HostName);
            Thread.Sleep(2000);
            this.Map.RequesterFrameSearch.Click();
            Thread.Sleep(2000);
            this.Map.RequesterFrameSelect.Click();
            Thread.Sleep(3000);
            driver.SwitchTo().DefaultContent();
        }
        //Add external host
        public void AddExternalHostDetails()
        {
            this.Map.ResourceParticipants.SendKeys("2");
            this.Map.NextButton.Click();
            Thread.Sleep(3000);
            this.Map.ExternalButton.Click();
            Thread.Sleep(2000);
            this.Map.ExternalLastName.SendKeys("LastName");
            this.Map.ExternalFirstName.SendKeys("FirstName");
            Thread.Sleep(2000);
            this.Map.ExternalSave.Click();
            Thread.Sleep(8000);
            this.Map.RoleDropDown.Click();
            Thread.Sleep(1000);
            this.Map.SelectRoleHost.Click();
            Thread.Sleep(2000);
        }
        //Click go to summary from attendees
        public void GoToSummaryFromAttendees()
        {
            this.Map.AttendeesGoToSummaryButton.Click();
            Thread.Sleep(2000);
        }
        //SINGLE USE END

        //Add All Details
        public void AddAllDetails()
        {
            //newBookingMain.SingleBookingSummary();
            Thread.Sleep(2000);
            AddTitleDetails();
            Thread.Sleep(2000);
            AddHostDetails();
            Thread.Sleep(2000);
            AddRequesterDetails();
            Thread.Sleep(5000);
        }

        //Add All Details and Add Attendee
        public void AddExternalAttendee()
        {
            AddAllDetails();
            this.Map.ResourceParticipants.SendKeys("2");
            this.Map.NextButton.Click();
            Thread.Sleep(3000);
            this.Map.ExternalButton.Click();
            Thread.Sleep(2000);
            this.Map.ExternalLastName.SendKeys("LastName");
            this.Map.ExternalFirstName.SendKeys("FirstName");
            Thread.Sleep(2000);
            this.Map.ExternalSave.Click();
            Thread.Sleep(3000);
        }

        //Add All Details, Add Attendee and Change Role to Host
        public void AddExternalHost()
        {
            AddExternalAttendee();
            this.Map.RoleDropDown.Click();
            Thread.Sleep(1000);
            this.Map.SelectRoleHost.Click();
            Thread.Sleep(2000);
        }

        //Add All Details, Add Attendee, Change Role to Host and Go To Summary
        public void AddExternalHostSummary()
        {
            AddExternalHost();
            this.Map.AttendeesGoToSummaryButton.Click();
            Thread.Sleep(2000);
        }
        //Go to summary from attendees
        public void AttendeesSummary()
        {
            this.Map.AttendeesGoToSummaryButton.Click();
            Thread.Sleep(2000);
        }

        //=====ADDONS SPECIFIC START=====
        //MUST BE ON SUMMARY TO USE
        public void NavigateToAddons()
        {
            bookingSummaryMain.AddAllDetails();
            this.Map.AddonButton.Click();
            Thread.Sleep(5000);
        }

        //MUST BE ON SUMMARY TO USE - Add addon and remain on page
        public void SelectAddon()
        {
            this.Map.AddonButton.Click();
            Thread.Sleep(2000);
            this.Map.AddonOnev2.Click();
            try
            {
                AcceptAddonNotificationPopup();
            }
            catch(NoAlertPresentException Ex)
            {

            }
            Thread.Sleep(3000);
        }

        //MUST BE ON SUMMARY TO USE
        public void AddAddons()
        {
            bookingSummaryMain.NavigateToAddons();
            this.Map.AddonOnev2.Click();
            Thread.Sleep(3000);
            this.Map.AddAddonsButton.Click();
            Thread.Sleep(2000);
            this.Map.GoToSummaryButton.Click();
            Thread.Sleep(2000);
        }

        //MUST BE ON SUMMARY TO USE
        public void AddAddonsAndSave()
        {
            bookingSummaryMain.AddAddons();
            this.Map.SaveButton.Click();
            Thread.Sleep(5000);
        }

        //MUST BE ON SUMMARY TO USE
        public void AddAddonsAndSaveAndExit()
        {
            bookingSummaryMain.AddAddons();
            this.Map.SaveAndExitButton.Click();
            Thread.Sleep(5000);
        }
        //=====ADDONS SPECIFIC END=====
    }
}
