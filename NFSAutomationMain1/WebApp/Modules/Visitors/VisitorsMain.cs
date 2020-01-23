using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using System.Configuration;
using WebApp.Login;

namespace WebApp.Modules.Visitors
{
    public class VisitorsMain
    {
        private IWebDriver driver;
        private readonly string hostName = ConfigurationManager.AppSettings[""];
        private readonly string externalName = ConfigurationManager.AppSettings[""];
        private readonly string NewHostLastName = ConfigurationManager.AppSettings[""];
        private readonly string NewHostFirstName = ConfigurationManager.AppSettings[""];
        private readonly string NewExternalFirstName = ConfigurationManager.AppSettings[""];
        private readonly string NewExternalLastName = ConfigurationManager.AppSettings[""];

        private VisitorsMain visitorsMain;
        private WebAppLoginMain loginMain;

        //Init driver
        public VisitorsMain(IWebDriver driver)
        {
            this.driver = driver;
        }

        //Map references
        protected VisitorsReferences Map
        {
            get
            {
                return new VisitorsReferences(this.driver);
            }
        }



        public void AccessVisitorModule()
        {
            loginMain.NavigateTo();
            loginMain.LogInSuccess();
            this.Map.VisitorsIcon.Click();
        }
        //ADDING A VISITOR START
        //Get to Add Visitor Page
        public void AccessAddVisitor()
        {
            visitorsMain.AccessVisitorModule();
            Thread.Sleep(2000);
            this.Map.AddVisitorButton.Click();
        }
        //Search for existing Internal
        public void ExistingInternalSearch()
        {
            visitorsMain.AccessAddVisitor();
            this.Map.InternalVisitor.Click();
            this.Map.LastNameInput.SendKeys(hostName);
        }
        //Search for existing External
        public void ExistingExternalSearch()
        {
            visitorsMain.AccessAddVisitor();
            this.Map.ExternalVisitor.Click();
            this.Map.LastNameInput.SendKeys(externalName);
        }
        //Check Info Populates for existing
        public void CheckExistingInfo()
        {
            visitorsMain.ExistingInternalSearch();
            this.Map.LastNameDropDownFirst.Click();
            Thread.Sleep(2000);
        }
        //Check Existing Host DropDown
        public void ExistingHostSearch()
        {
            visitorsMain.AccessAddVisitor();
            this.Map.HostNameInput.SendKeys(hostName);
            Thread.Sleep(2000);
        }
        //Check Mandatory Fields on save
        public void CheckMandatoryFields()
        {
            visitorsMain.AccessAddVisitor();
            this.Map.SaveButton.Click();
            Thread.Sleep(2000);
        }
        //Click Host Not Found Button
        public void AccessHostNotFound()
        {
            visitorsMain.AccessAddVisitor();
            this.Map.HostNotFoundButton.Click();
            Thread.Sleep(2000);
        }
        //REMEMBER TO SWITCH TO HOST FRAME
        public void HostNotFoundAdSearchFalse()
        {
            visitorsMain.AccessHostNotFound();
            IWebElement HostNotFoundFrame = this.Map.HostNotFoundWindow;
            driver.SwitchTo().Frame(HostNotFoundFrame);
            IWebElement SearchAdCheckbox = this.Map.SearchAdCheckbox;
            if (SearchAdCheckbox.Selected)
            {
                SearchAdCheckbox.Click();
            }
            else
            {
                //Do Nothing
            }
        }
        public void HostNotFoundAdSearchTrue()
        {
            visitorsMain.AccessHostNotFound();
            IWebElement HostNotFoundFrame = this.Map.HostNotFoundWindow;
            driver.SwitchTo().Frame(HostNotFoundFrame);
            IWebElement SearchAdCheckbox = this.Map.SearchAdCheckbox;
            if (!SearchAdCheckbox.Selected)
            {
                SearchAdCheckbox.Click();
            }
            else
            {
                //Do Nothing
            }
        }
        //Enter new host details except from Last Name (Mandatory)
        public void CheckHostLastNameValidation()
        {
            visitorsMain.AccessHostNotFound();
            IWebElement HostNotFoundFrame = this.Map.HostNotFoundWindow;
            driver.SwitchTo().Frame(HostNotFoundFrame);
            this.Map.HostCompanyDropDown.Click();
            this.Map.HostCompanyDropDown.SendKeys(Keys.Down);
            this.Map.HostCompanyDropDown.SendKeys(Keys.Return);
            this.Map.HostSave.Click();
        }
        //CHECK IF CHROME ALERT DISPLAYS - USE WITH VALIDATION CHECKS FOR NAME/COMPANY
        public bool IsAlertDisplayed()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException Ex)//Currently Not using exception
            {
                return false;
            }
        }
        //Enter new host details except from Company (Mandatory)
        public void CheckHostCompanyValidation()
        {
            visitorsMain.AccessHostNotFound();
            IWebElement HostNotFoundFrame = this.Map.HostNotFoundWindow;
            driver.SwitchTo().Frame(HostNotFoundFrame);
            this.Map.HostLastNameInput.SendKeys(NewHostLastName);
            Thread.Sleep(1000);
            this.Map.HostLastNameInput.SendKeys(Keys.Tab);//Tab required due to dropdown box blocking all other fields
            Thread.Sleep(1000);
            this.Map.HostSave.Click();
        }
        //Enter Host details and Save
        public void AddNewHost()
        {
            visitorsMain.AccessHostNotFound();
            IWebElement HostNotFoundFrame = this.Map.HostNotFoundWindow;
            driver.SwitchTo().Frame(HostNotFoundFrame);
            this.Map.HostLastNameInput.SendKeys(NewHostLastName);
            Thread.Sleep(1000);
            this.Map.HostLastNameInput.SendKeys(Keys.Tab);//Tab required due to dropdown box blocking all other fields
            Thread.Sleep(1000);
            this.Map.HostFirstNameInput.SendKeys(NewHostFirstName);
            Thread.Sleep(1000);
            this.Map.HostCompanyDropDown.Click();
            this.Map.HostCompanyDropDown.SendKeys(Keys.Down);
            this.Map.HostCompanyDropDown.SendKeys(Keys.Return);
            this.Map.HostSave.Click();
            driver.SwitchTo().DefaultContent();
        }
        //TESTING CONTACT PAGES TELERIK GRID SELECTION
        public bool Test1()
        {
            //VisitorModule browser = new VisitorModule(this.driver);
            //browser.LogIn();

            loginMain.NavigateTo();
            loginMain.LogInSuccess();

            this.Map.Contacts.Click();

            string value = this.Map.FirstValueTest.Text.ToString();
            value.Trim();
            if (value == "Yes") //If first value is yes filter by No
            {
                var xpath = string.Format(".//li[6]/a/span[contains(text(),'{0}')]", "EqualTo");
                driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_usergrdList_rfltMenu_detached")).FindElement(By.XPath(xpath)).Click();
                string newValue = this.Map.FirstValueTest.Text.ToString();
                newValue.Trim();
                if (newValue == "No")
                {
                    Thread.Sleep(2000);
                    return true;
                }
                else
                {
                    Thread.Sleep(2000);
                    return false;
                }
            }
            else//If first value is no filter by yes
            {
                this.Map.Filter.Click();
                Thread.Sleep(2000);
                var xpath = string.Format(".//li[6]/a/span[contains(text(),'{0}')]", "EqualTo");
                driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_usergrdList_rfltMenu_detached")).FindElement(By.XPath(xpath)).Click();
                string newValue = this.Map.FirstValueTest.Text.ToString();
                newValue.Trim();
                if (newValue == "Yes")
                {
                    Thread.Sleep(2000);
                    return true;
                }
                else
                {
                    Thread.Sleep(2000);
                    return false;
                }
            }
        }
        //TESTING END
        public void TimeCheck()//CURRENTLY DOES NTO WORK DUE TO TIMEZONE AND TIMEFORMAT
        {
            visitorsMain.AccessAddVisitor();
            var currentTime = DateTime.Now;
            string formattedCurrentTime = currentTime.ToString("dd/mm/yyyy HH:mm");//Need to add control for date format
            this.Map.DisplayName.SendKeys(formattedCurrentTime);
        }

        public void AddExternalVisitorSave()//currently not working
        {
            visitorsMain.AccessAddVisitor();
            this.Map.ExternalVisitor.Click();
            this.Map.LastNameInput.SendKeys(NewExternalLastName);
            Thread.Sleep(1000);
            this.Map.NewVisitorFaxInput.Click();
            Thread.Sleep(1000);
            this.Map.FirstNameInput.SendKeys(NewExternalFirstName);
            Thread.Sleep(1000);
            this.Map.DisplayName.Click();
            Thread.Sleep(1000);
            this.Map.HostNameInput.SendKeys(hostName);
            Thread.Sleep(1000);
            this.Map.SelectHostNameOne.Click();
            Thread.Sleep(1000);
            this.Map.SaveButton.Click();
        }
        public void AddExternalVisitorSaveExit()//currently not working
        {
            visitorsMain.AccessAddVisitor();
            this.Map.ExternalVisitor.Click();
            this.Map.LastNameInput.SendKeys(NewExternalLastName);
            Thread.Sleep(1000);
            this.Map.NewVisitorFaxInput.Click();
            Thread.Sleep(1000);
            this.Map.FirstNameInput.SendKeys(NewExternalFirstName);
            Thread.Sleep(1000);
            this.Map.DisplayName.Click();
            Thread.Sleep(1000);
            this.Map.HostNameInput.SendKeys(hostName);
            Thread.Sleep(1000);
            this.Map.SelectHostNameOne.Click();
            Thread.Sleep(1000);
            this.Map.SaveAndExitButton.Click();
        }
        //ADDING A VISITOR END
        //Existing Visitors
        public void CheckExistingAttendee() //Must be on visitor list to use
        {
            if (this.Map.VisitorListRowOne.Displayed)
            {
                //Visitor Exists
            }
            else
            {
                //Add Visitor
                this.Map.AddVisitorButton.Click();
                Thread.Sleep(3000);
                this.Map.ExternalVisitor.Click();
                this.Map.LastNameInput.SendKeys(NewExternalLastName);
                Thread.Sleep(1000);
                this.Map.NewVisitorFaxInput.Click();
                Thread.Sleep(1000);
                this.Map.FirstNameInput.SendKeys(NewExternalFirstName);
                Thread.Sleep(1000);
                this.Map.DisplayName.Click();
                Thread.Sleep(1000);
                this.Map.HostNameInput.SendKeys(hostName);
                Thread.Sleep(1000);
                this.Map.SelectHostNameOne.Click();
                Thread.Sleep(1000);
                this.Map.SaveAndExitButton.Click();
            }
        }
        public void GetExistingVisitorDetails()
        {
            string visitorName = this.Map.VisitorName.Text.ToString();
            string bookingTitle = this.Map.BookingTitle.Text.ToString();
            string meetingRoom = this.Map.MeetingRoom.Text.ToString();
            string hostName = this.Map.HostName.Text.ToString();
        }
        public void SelectFirtsExistingVisitor()
        {
            visitorsMain.AccessVisitorModule();
            visitorsMain.GetExistingVisitorDetails();
            this.Map.VisitorName.Click();
            //Needs to be finished
        }
        //Existing Visitor End
    }
}
