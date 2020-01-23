using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using System.Configuration;

namespace WebApp.BookingSummary
{ 
    public class BookingSummaryReferences
    {
        private readonly IWebDriver driver;

        public BookingSummaryReferences(IWebDriver driver)
        {
            this.driver = driver;
        }


        public IWebElement BookingTitleInput
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_txtTitle"));
            }
        }

        public IWebElement BookingSaveSuccessPopup
        {
            get
            {
                return this.driver.FindElement(By.XPath("/html/body/div[2]/div[11]/div/button/span"));
            }
        }


        public IWebElement PopupMessage

        {
            get
            {
               return this.driver.FindElement(By.CssSelector("span.ui-button-text"));
               // return this.driver.FindElement(By.XPath("/html/body/div[2]/div[11]/div/button/span"));
            }
        }

        //OLD
        public IWebElement HostInput
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_ddlSearchHost_Input"));
            }
        }

        public IWebElement HostDropDown
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_ddlSearchHost_DropDown"));
            }
        }

        public IWebElement HostSearchIcon
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_ibtnMagnify"));
            }
        }

        public IWebElement GetFrameForHost
        {
            get
            {
                return this.driver.FindElement(By.XPath("//iframe[@name='radWndChangeHost']"));

            }
        }

        //-----Add Host from Search Icon-----
        public IWebElement HostFrameInput
        {
            get
            {
                return this.driver.FindElement(By.XPath("//input[@name='txtSearch']"));

            }
        }

        public IWebElement HostFrameSearch
        {
            get
            {
                return this.driver.FindElement(By.Id("btnSeach"));

            }
        }

        public IWebElement HostFrameSelect
        {
            get
            {
                return this.driver.FindElement(By.Name("grdAttendees$ctl00$ctl04$imgbtnAdd"));

            }
        }
        //-----Add Host from Search Icon END-----

        public IWebElement GetFrameForRequester
        {
            get
            {
                return this.driver.FindElement(By.XPath("//iframe[@name='radWndChangeHost']"));

            }
        }

        //-----Add Requester from Search Icon-----
        public IWebElement RequesterFrameInput
        {
            get
            {
                return this.driver.FindElement(By.XPath("//input[@name='txtSearch']"));

            }
        }

        public IWebElement RequesterFrameSearch
        {
            get
            {
                return this.driver.FindElement(By.Id("btnSeach"));

            }
        }

        public IWebElement RequesterFrameSelect
        {
            get
            {
                return this.driver.FindElement(By.Name("grdAttendees$ctl00$ctl04$imgbtnAdd"));

            }
        }
        //-----Add Requester from Search Icon END-----

        public IWebElement RequesterSearchIcon
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_ibtnBookedBy"));
            }
        }

        public IWebElement RequesterSearchField
        {
            get
            {
                return this.driver.FindElement(By.Id("txtSearch"));
            }
        }

        public IWebElement RequesterSearchButton
        {
            get
            {
                return this.driver.FindElement(By.Id("btnSeach"));
            }
        }

        public IWebElement RequesterSearchAdd
        {
            get
            {
                return this.driver.FindElement(By.Id("grdAttendees_ctl00_ctl04_imgbtnAdd"));
            }
        }
        //OLD END
        public IWebElement HostSelect
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='ctl00_MainContentPlaceHolder_ddlSearchContacts_DropDown']/div/ul/li[1]"));
            }
        }






        //START
        //ADDONS
        public IWebElement AddonButton
        {
            get
            {
                return this.driver.FindElement(By.Name("ctl00$MainContentPlaceHolder$grdSummary$ctl00$ctl04$ctl07"));
            }
        }


        //ADDONS END

        public IWebElement ResourceParticipants
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_grdSummary_ctl00_ctl04_txtBICovers"));
            }
        }

        //ATTENDEES START
        public IWebElement AddPeopleTab
        {
            get
            {
                var xpath = string.Format(".//div/ul[contains(text(), '{0}')]", "Add People");
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_tabctlSummary"));
            }
        }
        //Worksaround for AddPeopleTab Not Working
        public IWebElement NextButton
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_btnNext1"));
            }
        }
        //Worksaround END

        public IWebElement InternalSearchbuttn
        {
            get
            {
                return this.driver.FindElement(By.Name("ctl00$MainContentPlaceHolder$ucBookingAttendee$btnSearch"));
            }
        }

        public IWebElement InternalAddattendeeaddbtn
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_ucBookingAttendee_grdAttendees_ctl00_ctl04_imgbtnAdd"));
            }
        }
        public IWebElement popupforateendee
        {
            get
            {
                return this.driver.FindElement(By.ClassName("ui-button-text"));
            }
        }///html/body/div[3]/div[11]/div/button[1]/span
        public IWebElement InternalSearchbox
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_ucBookingAttendee_txtSearch"));
            }
        }//
        public IWebElement InternalButton
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_ucBookingAttendee_rdInternal"));
            }
        }
        public IWebElement ExternalButton
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_ucBookingAttendee_rdExternal"));
            }
        }
        public IWebElement ExternalLastName
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_ucBookingAttendee_ddlSearchContacts_Input"));
            }
        }
        public IWebElement ExternalFirstName
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_ucBookingAttendee_txtFirstVisit"));
            }
        }
        public IWebElement ExternalSave
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_ucBookingAttendee_btnSave"));
            }
        }
        public IWebElement RoleDropDown
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_ucBookingAttendee_grdSelectedAttendees_ctl00_ctl04_ddlGrdBookingRole"));
            }
        }
        public IWebElement SelectRoleHost
        {
            get
            {
                var xpath = string.Format(".//option[contains(text(), '{0}')]", "Host");
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_ucBookingAttendee_grdSelectedAttendees_ctl00_ctl04_ddlGrdBookingRole")).FindElement(By.XPath(xpath));
            }
        }
        public IWebElement AttendeesGoToSummaryButton
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_btnSaveAndGoToSummary"));
            }
        }
        //ATTENDEES END
        //REFERENCE NUMBER START
        public IWebElement ReferenceNumber
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_lblReferenceNumber"));
            }
        }
        //REFERENCE NUMBER END
        //END





        //TRYING TO LOCATE ADDON CHECKBOX FOR FIRST ADDON
        //DOES NOT WORK
        public IWebElement AddonOne
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@class='table_addons']//*[starts-with(@name, 'chk?')]"));
            }
        }
        //WORKS
        public IWebElement AddonOnev2
        {
            get
            {
                return this.driver.FindElement(By.XPath("//input[contains(@onclick,'_0')]"));
            }
        }
        //END

        //ON ADDONS PAGE START
        public IWebElement AddAddonsButton
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_ctl00_btnAdd"));
            }
        }

        public IWebElement ClearAddonsButtons
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_ctl00_btnClear"));
            }
        }
        public IWebElement AddonEditIcon
        {
            get
            {
                return this.driver.FindElement(By.XPath("//input[starts-with(@id, 'imgTime_')]"));
            }
        }
        public IWebElement AddonValidationContinue
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='divButtons']/input[1]"));
            }
        }
        //ADDONS EDIT START
        public IWebElement AddonEditQuantityIncrease
        {
            get
            {
                return this.driver.FindElement(By.XPath(""));
            }
        }
        public IWebElement AddonEditQuantityDecrease
        {
            get
            {
                return this.driver.FindElement(By.XPath(""));
            }
        }
        public IWebElement AddonEditStartTime
        {
            get
            {
                return this.driver.FindElement(By.Id("txtStart"));
            }
        }
        public IWebElement AddonEditEndTime
        {
            get
            {
                return this.driver.FindElement(By.Id("txtEnd"));
            }
        }
        //ADDONS EDIT END
        public IWebElement AddonNotesIcon
        {
            get
            {
                return this.driver.FindElement(By.XPath("//input[starts-with(@id, 'imgNotes_'"));
            }
        }
        public IWebElement AddonDeleteIcon
        {
            get
            {
                return this.driver.FindElement(By.XPath("//input[starts-with(@id, 'imgDelete_')]"));
            }
        }
        //ON ADDONS PAGE END

        public IWebElement GoToSummaryButton
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_btnSaveAndGoToSummary"));
            }
        }

        public IWebElement SaveAndExitButton
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_btnSaveAndExit"));
            }
        }

        public IWebElement SaveButton
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_btnSave"));
            }
        }

        public IWebElement BookAnotherResourceButton
        {
            get
            {
                return this.driver.FindElement(By.Id("//*[@id='ctl00_MainContentPlaceHolder_btnBookAnotherResource1']"));
            }
        }

        public IWebElement BookingStatusDropdown
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_ddlStatus"));
            }
        }
    }
}
