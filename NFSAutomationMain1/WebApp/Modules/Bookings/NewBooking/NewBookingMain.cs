using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading;
using WebApp.BookingSummary;
using WebApp.Login;

namespace WebApp.Modules.Bookings.NewBooking
{
    public class NewBookingMain
    {
        public IWebDriver driver;
        private readonly string bookingTitle = ConfigurationManager.AppSettings["BookingTitle"];
        private readonly string hostName = ConfigurationManager.AppSettings["HostName_CreateBooking"];
        private readonly string requesterName = ConfigurationManager.AppSettings["RequesterName_CreateBooking"];
        private readonly string dateFormat = ConfigurationManager.AppSettings["DateFormat"];
        private readonly string property = ConfigurationManager.AppSettings["propertyname"];

        DateTime today = DateTime.Now;
        //static var tomorrow = today.AddDays(1).Date;

        
           
        
         public NewBookingMain newBookingMain;
         public BookingsMain bookingsMain;
         public BookingSummaryMain bookingSummaryMain;


        public void setup()
        {
            
            NewBookingMain newBookingMain = new NewBookingMain(this.driver);
            BookingsMain bookingsMain = new BookingsMain(this.driver);
        }

        // 

        //Init driver
        public NewBookingMain(IWebDriver driver)
        {
            this.driver = driver;

        }
        
        //Map references
        protected NewBookingReferences Map
        {
            get
            {
                return new NewBookingReferences(this.driver);
            }
        }


        

        //Get Tomorrows Date
        public void GetDate()
        {
            var today = DateTime.Now;
            var tomorrow = today.AddDays(1).Date;
        }

        //Accessing New Bookings Tab
        public void AccessingNewBookingLink()
        {     
            BookingsMain bookingsMain = new BookingsMain(this.driver);
            Thread.Sleep(4000);
            bookingsMain.AccessBookingsModule();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20000);
            bookingsMain.AccessNewBooking();
            bookingsMain.AccessNewBookingLink();
        }


        //Click on Search Button 
        public void SearchButton()
        {
            this.Map.SearchButton.Click();
        }

        //Click on Booking Summary Button
        public void GoToSummary()
        {
            this.Map.GoToSummaryButton.Click();
        }

        public void participantcount()// No of participant 
        {
            this.Map.participant.Clear();
            this.Map.participant.SendKeys("4");
        }


        //Apply tomorrows date and Search for 9am - 10am
        public void SearchTomorrowsDate()
        {
            var today = DateTime.Today;
            var tomorrow = today.AddDays(1).Date;
            Console.WriteLine(tomorrow);
            string tomorrowFrom = tomorrow.ToShortDateString();          //ToString(dateFormat);
            string tomorrowTo = tomorrow.ToShortDateString();           //ToString(dateFormat);
            Console.WriteLine("From : " + tomorrowFrom);
            Console.WriteLine("To : " + tomorrowTo);
            this.Map.FromDateInput.SendKeys(Keys.Control + "a");
            Thread.Sleep(2000);
            this.Map.FromDateInput.SendKeys(tomorrowFrom + " 09:00 AM");
            Thread.Sleep(3000);
            this.Map.ToDateInput.Click();
            this.Map.ToDateInput.SendKeys(Keys.Control + "a");
            Thread.Sleep(2000);
            this.Map.ToDateInput.Click();
            this.Map.ToDateInput.SendKeys(Keys.Control + "a");
            this.Map.ToDateInput.SendKeys(tomorrowFrom + " 10:00 AM");
            
        }

        //FromDate and
        public void FromDate()
        {
            var tomorrow = today.AddDays(1).Date;
            string tomorrowFrom = tomorrow.ToShortDateString();
            this.Map.FromDateInput.SendKeys(Keys.Control + "a");
            Thread.Sleep(2000);
            this.Map.FromDateInput.SendKeys(tomorrowFrom + " 10:00 AM");
        }


        //ToDate and
        public void ToDate()
        {
            var tomorrow = today.AddDays(1).Date;
            string tomorrowFrom = tomorrow.ToShortDateString();
            this.Map.ToDateInput.Click();
            this.Map.ToDateInput.SendKeys(Keys.Control + "a");
            Thread.Sleep(2000);
            this.Map.ToDateInput.Click();
            this.Map.ToDateInput.SendKeys(Keys.Control + "a");
            this.Map.ToDateInput.SendKeys(tomorrowFrom + " 11:00 AM");
        }

        
        //Duration Hour Dropdown change
        public void DurationHourDropdown()
        {
            var hourdropdown = this.Map.HourDropdown;
            SelectElement selecthour = new SelectElement(hourdropdown);
            selecthour.SelectByText("2");
        }

        //Duration Minutes Dropdown Change
        public void DurationMinutesDropdown()
        {
            var minutesdropdown = this.Map.MinutesDropdown;
            SelectElement selectminutes = new SelectElement(minutesdropdown);
            selectminutes.SelectByText("30");
        }

        //Resource Type Dropdown
        public void ResourceTypeDropdown()
        {
            var resourcetype = this.Map.SelectResourceTypeDropDown;
            var selectresourcetype = new SelectElement(resourcetype);
            selectresourcetype.SelectByIndex(1);
        }


        //Selecting Waitlistbooking Checkbox
        public void WaitlistCheckBox()
        {
            this.Map.waitlistbookingcheckbox.Click();
        }

        //Selecting First resoruce from the search results
        public void SelectingFirstResource()
        {
            this.Map.firstitemofthelist.Click();
        }


        public void AddPeople()// Add People tab
        {
            this.Map.Addpeoplelink.Click();
        }

        
       




        //=================================================================================================================




        //Apply tomorrows date, search 9am - 10am, select first resource and Go To Summary
        public void SingleBookingSummary()
        {
            newBookingMain.SearchTomorrowsDate();
            Thread.Sleep(5000);
            this.Map.FirstSearchResultCheckBox.Click();
            Thread.Sleep(2000);
            this.Map.GoToSummaryButton.Click();
            Thread.Sleep(5000);
        }

        //Search by Title - MUST BE ON BOOKING SEARCH PAGE TO USE
        public void SearchByTitle()
        {
            this.Map.TitleSearchInput.SendKeys(bookingTitle);
            Thread.Sleep(1000);
            this.Map.BookingSearchButton.Click();
            Thread.Sleep(2000);
        }

        //CHECK IF BOOKING EXISTS -- NEDS TO BE REVIEWED
        public void CheckForBooking()
        {
            newBookingMain.SearchByTitle();
            Thread.Sleep(2000);
            IWebElement firstRow = this.Map.BookingSearchFirstResult;
            for (int i = 0; i < 2; i++)
                if (firstRow.Text.Contains(bookingTitle))
                {
                    //Carry on running
                    Thread.Sleep(3000);
                }
                else
                {
                    //If not then Create Booking

                    newBookingMain.SingleBookingSummary();
                    Thread.Sleep(3000);
                    bookingSummaryMain.AddTitleDetails();
                    Thread.Sleep(3000);
                    bookingSummaryMain.AddHostDetails();
                    Thread.Sleep(3000);
                    bookingSummaryMain.AddRequesterDetails();
                    Thread.Sleep(3000);
                    //browser.SingleBookingSave();
                    Thread.Sleep(3000);
                }
        }
        /*
        //CHECK IF BOOKING EXISTS BY REF NUMBER
        //---DOES NOT WORK---
        public string GetBookingReference()
        {
            return bookingSummaryMain.GetReferenceNumber();
        }
        //MUST BE USED AFTER SAVE
        public void CheckForBookingByReference()
        {
            newBookingMain.GetBookingReference();
            //Next line may cause error - UNTESTED
            bookingsMain.AccessBookingSearchLink();
            Thread.Sleep(2000);
            string referenceNumber = Convert.ToString(GetBookingReference());
            this.Map.SearchRefNoField.SendKeys(referenceNumber);
            Thread.Sleep(1000);
            this.Map.BookingSearchButton.Click();
            Thread.Sleep(3000);
        }
        //MUST BE USED AFTER SAVE
        public void SelectExistingBookingByReference()
        {
            newBookingMain.CheckForBookingByReference();
            this.Map.TitleLink2.Click();
            Thread.Sleep(5000);
        }*/

        //Access Booking if it exists
        public void AccessExistingBookingSummary()
        {
            newBookingMain.CheckForBooking();
            this.Map.BookingSearchSelectExistingBooking.Click();
            Thread.Sleep(5000);
        }

        public void SelectMultiResourceforBooking()// Select multi-resources 

        {
            string R1 = "28-01";
            string R2 = "28-02";
            string R3 = "29-02UpdatedTect";


            List<IWebElement> ResourceList = this.driver.FindElements(By.ClassName("rgRow")).ToList();
            Thread.Sleep(2000);
            for (int j = 0; j < ResourceList.Count; j++)
            {
                IList<IWebElement> td = ResourceList[j].FindElements(By.TagName("td"));
                Thread.Sleep(1000);
                string ss = td[4].Text.ToString();
                if (ss == R1 || ss == R2 || ss == R3)
                {
                    Thread.Sleep(1000);
                    td[3].Click();
                    Thread.Sleep(1000);
                }

                else
                {
                    Thread.Sleep(1000);
                }
            }
            

        }

        
        public void SelectAttendeeforresource()// select attendee for resource

        {
            string K1 = "Dr sumit morey";
          
            string K3 = "TestSumit";
          
          List<IWebElement> AttendeeList = this.driver.FindElements(By.ClassName("rgRow")).ToList();
              
            Thread.Sleep(2000);
            for (int j = 3; j < AttendeeList.Count; j++)
            {
                IList<IWebElement> td = AttendeeList[j].FindElements(By.TagName("td"));
                Thread.Sleep(1000);
                string ss = td[3].Text.ToString();
                if (ss == K1 ||  ss == K3)
                {
                    Thread.Sleep(1000);
                    IList<IWebElement> ddlist = this.driver.FindElements(By.ClassName("droplist_inputbox")).ToList();

                    Thread.Sleep(2000);
                    for (int ja = 24; ja < ddlist.Count; ja += 2)
                    {
                        IList<IWebElement> tda = ddlist[ja].FindElements(By.TagName("option"));
                        Thread.Sleep(1000);
                        string ssa = tda[1].Text.ToString();

                        tda[1].Click();
                        Thread.Sleep(1000);
                        break;
                    }
                    break;
                }

            }
        }


        //Increment through properties (excluding defualt) to find one with resources
        //Returns the value required to find the Property without needing to increment again
        public int FindPropertyWithResources()
        {
            int a = 1;
            int b = 101;
            string currentProp = property;
            string newProp = "NULL";
            this.Map.PropertiesDropdownArrow.Click();
            this.Map.SelectAllPropertiesCheckbox.Click();   //select all props
            this.Map.SelectAllPropertiesCheckbox.Click();   //deselect all props
            while (a < 20)
            {
                if (newProp == currentProp) //check selected prop is not default prop
                {
                    a++;
                }
                else
                {
                    this.Map.PropertiesDropdownArrow.Click();
                    this.Map.SelectAllPropertiesCheckbox.Click();   //select all props
                    this.Map.SelectAllPropertiesCheckbox.Click();   //deselect all props
                    newProp = this.Map.IncrementPropertyName(a).Text.ToString();
                    this.Map.IncrementPropertyCheckbox(a).Click();
                    this.Map.ResourceSearchButton.Click();
                    Thread.Sleep(3000);
                    if (this.Map.NoSearchResults.Text.ToString().Contains("No Records found. Please check late booking/past booking policies, future booking restriction, office hours, week-ends and holidays ."))
                    {
                        a++;    //No result founds, incremt a to check next property
                    }
                    else
                    {
                        //Result for a property found
                        return a;
                    }
                }
            }
            return b;
        }
        //Go straight to Property
        public void FindProperty(int a)
        {
            if(a == 101)
            {
                Console.WriteLine("Something has gone wrong");
            }
            else
            {
                this.Map.PropertiesDropdownArrow.Click();
                this.Map.SelectAllPropertiesCheckbox.Click();   //select all props
                this.Map.SelectAllPropertiesCheckbox.Click();   //deselect all props
                this.Map.IncrementPropertyCheckbox(a).Click();
                this.Map.BookingSearchButton.Click();
            }
        }
    }
}
