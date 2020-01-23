using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using System.Configuration;

namespace WebApp.Modules.Bookings.NewBooking
{
    public class NewBookingReferences
    {
        private readonly IWebDriver driver;
        private readonly string hostName = ConfigurationManager.AppSettings["HostName"];

        public NewBookingReferences(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement FromDateInput
        {
            get
            {

                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_dtFrom_dateInput"));
            }
        }

        public IWebElement ToDateInput
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_dtTo_dateInput"));
            }
        }

        public IWebElement SearchButton
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_btnSearchn"));
            }
        }


        public IWebElement SelectResourceTypeDropDown
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_ddlResourceType"));
            }
        }


        public IWebElement HourDropdown
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_ddlHours"));
            }
        }

        
        public IWebElement MinutesDropdown
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_ddlMinutes"));
            }
        }


        public IWebElement GoToSummaryButton
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_btnSaveNGoToSummary"));
            }
        }
        public IWebElement participant
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_txtBookingCovers"));
            }
        }


        //RECURRING
        public IWebElement RecurButton
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_btnRecurrence1"));
            }
        }
 
        //Start time on Booking Summary Page
        public IWebElement BookingsummarystartTime
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_grdSummary_ctl00_ctl04_lbtnStartTime"));
            }
        }


        //End Time on Booking Summary Page
        public IWebElement BookingsummaryendTime
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_grdSummary_ctl00_ctl04_lbtnEndTime"));
            }
        }

        //Booking Duration on Booking Summary Page 
        public IWebElement bookingDuration
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_grdSummary_ctl00_ctl04_lbtnDuration"));
            }
        }
        
        //New Booking WaitList booking checkbox
        public IWebElement waitlistbookingcheckbox
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_chkWaitlist"));
            }
        }

        //WaitListBooking booking Status
        public IWebElement bookingstatusdropdown
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_ddlStatus"));
            }
        }


        //Selecting First Result from the search table 
        public IWebElement firstitemofthelist
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='ctl00_MainContentPlaceHolder_grdSearchResults_ctl00__0']/td[4]/input"));

            }
        }

        public IWebElement Addpeoplelink
        {
            get
            {
                return this.driver.FindElement(By.CssSelector(".rtsAfter"));

            }
        }

        //Select Properties Dropdown arrow
        public IWebElement PropertiesDropdownArrow
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='ctl00_MainContentPlaceHolder_cmbProperties_cmbList_Arrow']"));
            }
        }

        //Select All Properties dropdown checkbox
        public IWebElement SelectAllPropertiesCheckbox
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='ctl00_MainContentPlaceHolder_cmbProperties_cmbList_Header_chkHeader']"));
            }
        }

        //Increment each Property check box
        public IWebElement IncrementPropertyCheckbox(int a)
        {
            return this.driver.FindElement(By.XPath("//*[@id='ctl00_MainContentPlaceHolder_cmbProperties_cmbList_DropDown']/div[2]/ul/li["+a+"]/div/input"));
        }
        //Increment each Property name
        public IWebElement IncrementPropertyName(int a)
        {
            return this.driver.FindElement(By.XPath("//*[@id='ctl00_MainContentPlaceHolder_cmbProperties_cmbList_DropDown']/div[2]/ul/li[" + a + "]/div/label"));
        }
        //No results shown
        public IWebElement NoSearchResults
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='ctl00_MainContentPlaceHolder_grdSearchResults_ctl00']/tbody/tr/td[3]/div"));
            }
        }

        






        //======================================================================================================================

        public IWebElement FirstSearchResultGrid
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_grdSearchResults_ctl00__0"));
            }
        }
        //TESTING ONLY
        public IWebElement AllCheckBoxes
        {
            get
            {
                return this.driver.FindElement(By.CssSelector("[id^=ctl00_MainContentPlaceHolder_grdSearchResults_ctl00_ctl06_chkSelect_]"));
            }
        }

        public IWebElement HostSelect
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='ctl00_MainContentPlaceHolder_ddlSearchContacts_DropDown']/div/ul/li[1]"));
            }
        }
        //TESTING ONLY END
        public IWebElement FirstSearchResultCheckBox
        {
            get
            {
                return this.driver.FindElement(By.CssSelector("[id^=ctl00_MainContentPlaceHolder_grdSearchResults_ctl00_ctl06_chkSelect_]"));
            }
        }


        



        public IWebElement BookingTypeDropdown
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_ddlBookingType"));
            }
        }

       

        public IWebElement GetRecurFrame
        {
            get
            {
                return this.driver.FindElement(By.XPath("//iframe[@name='ctl00_MainContentPlaceHolder_btnRecurrence1']"));
            }
        }

        public IWebElement RecurFrameDailyPattern
        {
            get
            {
                return this.driver.FindElement(By.Id("rcRepeat_rbtDaily"));
            }
        }

        public IWebElement RecurFrameFromDateInput
        {
            get
            {
                return this.driver.FindElement(By.Id("rcRepeat_dtFrom_dateInput"));
            }
        }

        public IWebElement RecurFrameToDateInput
        {
            get
            {
                return this.driver.FindElement(By.Id("rcRepeat_dtTo_dateInput"));
            }
        }

        public IWebElement RecurFrameShowDates
        {
            get
            {
                return this.driver.FindElement(By.Id("rcRepeat_rbtDaily"));
            }
        }

        public IWebElement RecurFrameContinue
        {
            get
            {
                return this.driver.FindElement(By.Id("rcRepeat_btRepeats"));
            }
        }
        //RECURRING END



        public IWebElement TitleSearchInput
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_txtBookingTitle"));
            }
        }

        public IWebElement BookingSearchButton
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_btnSearch"));
            }
        }

        //Booking Search NEW
        public IWebElement ResourceSearchButton
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='ctl00_MainContentPlaceHolder_btnSearchn']"));
            }
        }
        public IWebElement BookingSearchFirstResult
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_grdSearchedBookingItems_ctl00__0"));
            }
        }

        public IWebElement BookingSearchFirstResultTitle
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_grdSearchedBookingItems_ctl00_ctl05_lnkGoToSummary"));
            }
        }

        public IWebElement BookingSearchSelectExistingBooking
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_grdSearchedBookingItems_ctl00_ctl05_lnkGoToSummary"));
            }
        }

        //UTILITY - CANCEL BOOKING REFERENCES
        public IWebElement SearchTitleField
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_txtBookingTitle"));
            }
        }
        public IWebElement TitleLink
        {
            get
            {
                //return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_grdSearchedBookingItems_ctl00__0"));
                var xpath = string.Format(".//td/span[contains(text(), '{0}')]", "B6");
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_grdSearchedBookingItems_ctl00__0")).FindElement(By.XPath(xpath));
            }
        }
        public IWebElement TitleLink2
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_grdSearchedBookingItems_ctl00_ctl05_lnkGoToSummary"));
            }
        }
        //UTILITY - END

        public IWebElement SearchRefNoField
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_txtRefNumber"));
            }
        }


    }
}
