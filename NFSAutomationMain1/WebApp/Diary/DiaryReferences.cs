using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace WebApp.Diary
{
   public class DiaryReferences
    {
        private readonly IWebDriver driver;

        public DiaryReferences(IWebDriver driver)
        {
            this.driver = driver;
        }


        //First Cell on diary 
        public IWebElement FirstCell
        {
            get
            {
                //return this.driver.FindElement(By.Id("Cell0000"));
                return this.driver.FindElement(By.XPath("//td[@id='dailySchedulerMainCell']//tr[3]/td[2]"));
                
            }
        }

        //If First Cell is booked then Increment to next cell by 1 each time. 
        public IWebElement IfFirstCellnotFound(int j)
        {
           
               // return this.driver.FindElement(By.XPath("//*[@id='ShTBLNo0']/tbody/tr[3]/td["+j+"]"));
            return this.driver.FindElement(By.XPath("//td[@id='dailySchedulerMainCell']//tr[3]/td["+j+"]"));
        }

        //New Booking Popup
        public IWebElement NewBookingPopUp
        {
            get
            {
                return this.driver.FindElement(By.Id("tblResources"));
            }
        }


        public IWebElement EditBookingPage
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_spanbookingeditLink"));
            }
        }

        //Booking Summary Exit Button 
        public IWebElement BookingEditExitButton
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_btnExit1"));
            }
        }

        //New Booking Popup Continue With Booking Button 
        public IWebElement ContinueWithBookingButton
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_btnCreate"));
            }
        }

        //New Booking Popup cancel button 
        public IWebElement NewBookingPopoupCancelButton
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_btnCancel1"));
            }
        }

        //New Booking Popup Recuring Booking Check Box
        public IWebElement NewBookingPopupRecurcheckbox
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_chkRecurrence"));
            }
        }

        //New Booking Popup duration days Text Box  
        public IWebElement NewBookingPopupDurationDaysTextBox
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_txtDurationDays"));
            }
        }

        
        //New Booking Popup duration Hours Text Box 
        public IWebElement NewBookingPopupDurationHoursTextBox
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_txtDurationHrs"));
            }
        }


        //New Booking Pop up Minutes Duration Text Box 
        public IWebElement NewBookingPopupDurationMinutesTextBox
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_txtDuration"));
            }
        }


        //New Booking Popup From Time Text Box 
        public IWebElement NewBookingPopupFromTimeTextBox
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_dtDiaryFromTime_dateInput"));
            }
        }

        //New Booking Popup To Time Text Box
        public IWebElement NewBookingPopupToTimeTextBox
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_dtDiaryToTime_dateInput"));
            }
        }

        //New Booking Popup From Time Clock Icon
        public IWebElement NewBookingPopupFromTimeIcon
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_dtDiaryFromTime_timePopupLink"));
            }
        }

        //NewBookingPop Up To Time Clock Icon
        public IWebElement NewBookingPopupToTimeIcon
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_dtDiaryToTime_timePopupLink"));
            }
        }



    }
}
