using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using System.Configuration;

namespace WebApp.Modules.Visitors
{
    public class VisitorsReferences
    {
        private readonly IWebDriver driver;
        private readonly string hostName = ConfigurationManager.AppSettings[""];

        public VisitorsReferences(IWebDriver driver)
        {
            this.driver = driver;
        }


        public IWebElement VisitorsIcon
        {
            get
            {
                return driver.FindElement(By.Id("ctl00_td_ulVisitorManagement"));
            }
        }
        public IWebElement AddVisitorButton
        {
            get
            {
                return driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_btnAddvisitor"));
            }
        }
        public IWebElement InternalVisitor
        {
            get
            {
                return driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_rdInternal"));
            }
        }
        public IWebElement LastNameInput
        {
            get
            {
                return driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_ddlSearchContacts_Input"));
            }
        }
        public IWebElement LastNameDropDownFirst
        {
            get
            {
                return driver.FindElement(By.XPath("//*[@id='ctl00_MainContentPlaceHolder_ddlSearchContacts_DropDown']/div/ul/li[0]"));
            }
        }
        public IWebElement ExternalVisitor
        {
            get
            {
                return driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_rdExternal"));
            }
        }
        public IWebElement DisplayName
        {
            get
            {
                return driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_txtDisplayName"));
            }
        }
        public IWebElement SelectLastNameOne
        {
            get
            {
                var xpath = string.Format(".//div/ul/li[0][contains(text(), '{0}')]", hostName);
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_ddlSearchContacts_DropDown")).FindElement(By.XPath(xpath));
            }
        }
        public IWebElement HostNameInput
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_rdHostName_Input"));
            }
        }
        public IWebElement CountryInput
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_cmbCountry"));
            }
        }
        public IWebElement SaveButton
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_btnSave"));
            }
        }
        public IWebElement SaveAndExitButton
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_btnSaveAndExit"));
            }
        }
        public IWebElement HostNotFoundButton
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_btnhostnotfound"));
            }
        }
        //HOST NOT FOUND WINDOW START
        public IWebElement HostNotFoundWindow
        {
            get
            {
                //return this.driver.FindElement(By.Id("RadWindowWrapper_ctl00_MainContentPlaceHolder_radWndAddBookingPeople"));
                return this.driver.FindElement(By.XPath("//iframe[@name='radWndAddBookingPeople']"));
            }
        }
        public IWebElement SearchAdCheckbox
        {
            get
            {
                return this.driver.FindElement(By.Id("chkInternal"));
            }
        }
        public IWebElement HostCompanyDropDown
        {
            get
            {
                return this.driver.FindElement(By.Id("ddlHost"));
            }
        }
        public IWebElement HostLastNameInput
        {
            get
            {
                return this.driver.FindElement(By.Name("ddlSearchContacts1"));
            }
        }
        public IWebElement HostFirstNameInput
        {
            get
            {
                return this.driver.FindElement(By.Id("txtFirstName"));
            }
        }
        public IWebElement HostSave
        {
            get
            {
                return this.driver.FindElement(By.Id("btnSave"));
            }
        }
        //HOST NOT FOUND WINDOW END
        //TESTING CONTACT PAGES TELERIK GRID SELECTION
        public IWebElement Contacts
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_hostTextSpan"));
            }
        }
        public IWebElement Filter
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_usergrdList_ctl00_ctl02_ctl02_Filter_IsInternal"));
            }
        }
        public IWebElement EqualTo
        {
            get
            {
                return this.driver.FindElement(By.CssSelector(".RadMenu.RadMenu_Default.RadMenu_Context.RadMenu_Default_Context"));
            }
        }
        public IWebElement EqualTo2
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='ctl00_MainContentPlaceHolder_usergrdList_rfltMenu_detached']/ul"));
            }
        }
        public IWebElement FirstValueTest
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='ctl00_MainContentPlaceHolder_usergrdList_ctl00__0']/td[7]/div"));
            }
        }
        public IWebElement FirstNameInput
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_txtFirstName"));
            }
        }
        public IWebElement SelectHostNameOne
        {
            get
            {
                //var xpath = string.Format(".//div/ul/li[1][contains(text(), '{0}')]", hostName);
                //return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_rdHostName_DropDown")).FindElement(By.XPath(xpath));
                return this.driver.FindElement(By.XPath("//*[@id='ctl00_MainContentPlaceHolder_rdHostName_DropDown']/div/ul/li"));
            }
        }
        public IWebElement VisitorListRowOne
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_grdVisitors_ctl00__0"));
            }
        }
        public IWebElement NewVisitorFaxInput
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_txtFaxNumber"));
            }
        }
        public IWebElement NewVisitorTitleInput
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_ddlTitle"));
            }
        }
        //Visitor List Fields Top Row
        public IWebElement VisitorName
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_grdVisitors_ctl00_ctl04_lnkvisitorName"));
            }
        }
        public IWebElement ExpectedTime
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_grdVisitors_ctl00_ctl04_lblExpectedTime"));
            }
        }
        public IWebElement BookingTitle
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_grdVisitors_ctl00_ctl04_lblBookingTitle"));
            }
        }
        public IWebElement MeetingRoom
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='ctl00_MainContentPlaceHolder_grdVisitors_ctl00__0']/td[12]"));
            }
        }
        public IWebElement HostName
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='ctl00_MainContentPlaceHolder_grdVisitors_ctl00__0']/td[13]"));
            }
        }
        //Visitor List Fields Top Row End
        //TESTING END
    }
}
