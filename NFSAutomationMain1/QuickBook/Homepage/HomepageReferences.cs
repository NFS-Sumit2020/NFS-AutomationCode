using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace QuickBook.Homepage
{
    public class HomepageReferences
    {

        private readonly IWebDriver driver;

        public HomepageReferences(IWebDriver driver)
        {
            this.driver = driver;


        }


        public IWebElement property
        {
            get
            {

                return this.driver.FindElement(By.XPath("//*[contains(@class, 'ui-autocomplete ui-front ui-menu ui-widget ui-widget-content')]//li[1]"));
            }
        }


        public IWebElement Area
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='SinglePropertySearch']/div[2]/div[2]/ul/li[1]"));
            }
        }

        public IWebElement ResourceType
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='ui-id-28']//li[1]"));
            }
        }

        public IWebElement RoomLayout
        {
            get
            {
                return this.driver.FindElement(By.Id("LayoutId"));
            }
        }

        public IWebElement CalendarPrevious
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='datepicker']/div/div/a[1]/span"));
            }
        }

        public IWebElement CalendarNext
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='datepicker']/div/div/a[2]/span"));
            }
        }

        public IWebElement DatePicker
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='datepicker']/div/table/tbody/tr[3]/td[5]"));
            }
        }

        public IWebElement Datepicker1
        {
            get
            {
                // return this.driver.FindElement(By.XPath("//*[contains(@class, ')]//li[1]"));
                return this.driver.FindElement(By.XPath("//*[@class=' ']/a"));
            }
        }

        public IWebElement Time
        {
            get
            {
                return this.driver.FindElement(By.Id("Time"));
            }
        }

        public IWebElement Duration
        {
            get
            {
                return this.driver.FindElement(By.Id("Duration"));
            }
        }

        public IWebElement Capacity
        {
            get
            {
                return this.driver.FindElement(By.Id("Capacity"));
            }
        }



        public IWebElement FindWorkspaceButton
        {
            get
            {
                return this.driver.FindElement(By.Id("btnNextStep0"));
            }
        }

        public IWebElement MultiLocationBookingButton
        {
            get
            {
                return this.driver.FindElement(By.Id("btnVcBooking"));
            }
        }

        public IWebElement RecurIcon
        {
            get
            {
                return this.driver.FindElement(By.Id("btnRecurrenceBooking"));
            }
        }


        public IWebElement DateTime
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='datepicker']/div"));
                //return this.driver.FindElement(By.ClassName(" ui-state-default ui-state-active"));
            }
        }

        public IWebElement propertydrop
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='SinglePropertySearch']/div[1]/span/a/span[1]"));
            }
        }

        public IWebElement areadrop
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='SinglePropertySearch']/div[2]"));
            }
        }

        public IWebElement Resourcetypedropdown
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='SinglePropertySearch']/div[3]/span/a/span[1]"));
            }
        }

        public IWebElement timedropdown
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='stepSelection']/div/div/div/div[1]/div[2]/div/div[2]/div/div[2]/div/div[1]"));
            }
        }

        public IWebElement exactmatch
        {
            get
            {
                return this.driver.FindElement(By.ClassName("exact-match"));
            }
        }

        public IWebElement exactmatchtime
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='step1FindWorkspace']/div/div[1]/h1/p/span[4]"));
            }
        }

        public IWebElement selectedexactmatchtimevalidator
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='00000000-0000-0000-0000-000000000000']/div[1]/p[3]/span[2]"));
            }
        }

        public IWebElement noresourceselected
        {
            get
            {

                return this.driver.FindElement(By.XPath("//*[@id='MySelection']/div/div[1]/div/div/span"));
            }
        }

        public IWebElement resourceselected
        {
            get
            {

                return this.driver.FindElement(By.XPath("//*[@id='00000000-0000-0000-0000-000000000000']"));
            }
        }

        public IWebElement availibilityDate
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='step1FindWorkspace']/div/div[1]/h1/span"));
            }
        }

        public IWebElement selectedDate
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='00000000-0000-0000-0000-000000000000']/div[1]/p[3]/span[1]"));
            }
        }

        public IWebElement differentTime
        {
            get
            {
                return this.driver.FindElement(By.ClassName("available"));

            }
        }

        public IWebElement roomAvail
        {
            get
            {
                return this.driver.FindElement(By.ClassName("room-availablity"));

            }
        }

        public IWebElement homepagenextbutton
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='step1FindWorkspace']/div/div[2]/a[2]"));
            }
        }


        public IWebElement UserNameLink
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='drop-down']/li[1]/span"));
            }
        }
        public IWebElement MyProfileLink
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='myProfile']"));
            }
        }
        public IWebElement NavigateYes
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='btnConfirmationYes']"));
            }
        }
        public IWebElement NavigateNo
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='btnConfirmationNo']"));
            }
        }
        public IWebElement LogOutLink
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='btnLogout']"));
            }
        }
        //DropDown Lists
        public IWebElement PropertyDropDownIcon
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='SinglePropertySearch']/div[1]/span/a"));
            }
        }
        public IWebElement PropertyDropDownSelected
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='SinglePropertySearch']/div[1]/span/input"));
            }
        }
        public IWebElement PropertyDropDownList
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='ui-id-11']"));
            }
        }

        public IWebElement AreaDropDownIcon
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='AreaId']"));
            }
        }
        public IWebElement AreaDropDownList
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='SinglePropertySearch']/div[2]/div[2]/ul"));
            }
        }

        public IWebElement ResourceTypeDropDownIcon
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='SinglePropertySearch']/div[3]/span/a/span[1]"));
            }
        }
        public IWebElement ResourceTypeDropDownSelected
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='SinglePropertySearch']/div[3]/span/input"));
            }
        }
        public IWebElement ResourceTypeDropDownList
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='ui-id-12']"));
            }
        }

        public IWebElement LayoutDropDown
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='LayoutId']"));
            }
        }

        public IWebElement CalendarBack
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='datepicker']/div/div/a[1]/span"));
            }
        }
        public IWebElement CalendarForward
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='datepicker']/div/div/a[2]/span"));
            }
        }
        public IWebElement CalendarDefaultDay
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@class=' ui-datepicker-days-cell-over  ui-datepicker-current-day ui-datepicker-today']/a"));
            }
        }
        public IWebElement CalendarNextDay
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@class=' ']/a"));
            }
        }
        public IWebElement CalendarPastDay
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@class=' ui-datepicker-unselectable ui-state-disabled ']/span"));
            }
        }
        public IWebElement CalendarSelectedDay
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@class='  ui-datepicker-current-day']/a"));
            }
        }
        public IWebElement StartTimeDropDown
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='Time']"));
            }
        }
        public IWebElement StartTimeSelect9AM
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='Time']/option[38]"));
            }
        }
        public IWebElement StartTimeSelectInvalid
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='Time']/option[2]"));
            }
        }
        public IWebElement StartTimeValidationButton
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='btnDialogOK']"));
            }
        }
        public IWebElement DurationDropDown
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='Duration']"));
            }
        }
        public IWebElement ParticipantsSearchValue
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='Capacity']"));
            }
        }
        public IWebElement ResetButton
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='btnReset']"));
            }
        }
        public IWebElement FindButton
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='btnFind']"));
            }
        }
        public IWebElement FirstResourceCheckBox
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='tblResourcesGrid']/tbody/tr[1]/td/table/tbody/tr[1]/td/div[2]"));
            }
        }
        public IWebElement ResourceListInformationIcon1
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='tblResourcesGrid']/tbody/tr[1]/td/table/tbody/tr[1]/td/span/img"));
            }
        }
        public IWebElement SelectedResourecInformationIcon1
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='00000000-0000-0000-0000-000000000000']/div[1]/p[1]/img"));
            }
        }
        public IWebElement SelectedResourceRemove
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='00000000-0000-0000-0000-000000000000']/div[1]/a/img"));
            }
        }
        public IWebElement RemoveResourcePopupYes
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='btnConfirmationYes']"));
            }
        }
        public IWebElement RemoveResourcePopupNo
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='btnConfirmationNo']"));
            }
        }
        public IWebElement MySelectionParticipantsIcon1
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='SpnPeopleSection']/img"));
            }
        }
        public IWebElement ChangeParticpantsInput
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='inputResourceCover']"));
            }
        }
        public IWebElement ChangeParticipantsInputSave
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='imgSaveResourceCover']"));
            }
        }
        public IWebElement ChangeParticipantsInputCancel
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='imgCancelResourceCover']"));
            }
        }
        public IWebElement getcurrentdate
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@class=' ui-datepicker-days-cell-over  ui-datepicker-current-day ui-datepicker-today']/a"));
            }
        }







    }
}
