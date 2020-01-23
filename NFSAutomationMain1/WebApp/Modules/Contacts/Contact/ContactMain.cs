using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Configuration;
using System.Threading;


namespace WebApp.Modules.Contacts.Contact
{
    public class ContactMain
    {

        private IWebDriver driver;
        private readonly string contactfirstname = ConfigurationManager.AppSettings["ContactFirstname"];
        private readonly string displayname = ConfigurationManager.AppSettings["displayname"];
        private readonly string contactlastname = ConfigurationManager.AppSettings["ContactLastname"];
        private readonly string Propertyaddress = ConfigurationManager.AppSettings["Propertyaddress"];
        private readonly string Propertytown = ConfigurationManager.AppSettings["Propertytown"];
        private readonly string Propertytelephone = ConfigurationManager.AppSettings["Propertytelephone"];
        private readonly string Propertyemail = ConfigurationManager.AppSettings["Propertyemail"];
        private readonly string PropertytimeZone = ConfigurationManager.AppSettings["Timezone"];
        private readonly string Propertytype = ConfigurationManager.AppSettings["Propertytype"];
        private readonly string Propertycountry = ConfigurationManager.AppSettings["Propertycountry"];
        private readonly string Propertyregion = ConfigurationManager.AppSettings["Propertyregion"];
        private readonly string Propertystatecounty = ConfigurationManager.AppSettings["Propertystatecounty"];

        public ContactMain(IWebDriver driver)
        {
            this.driver = driver;
        }


        protected ContactReferences Map
        {
            get
            {
                return new ContactReferences(this.driver);
            }
        }


        public void AccessContactsTab()
        {
            this.Map.ContactIcon.Click();
        }

        public void AddNewContactButton()
        {
            this.Map.AddNewContactButton.Click();
        }

        public void AddNewCompanyButton()
        {
            this.Map.AddNewCompanyBtn.Click();
        }


        public void CompanyDropDownList()
        {
            //this.Map.CompanyDropDownList.Click();
            var option = this.Map.CompanyDropDownList;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5000);
            Thread.Sleep(4000);
            var selectElement = new SelectElement(option);
            selectElement.SelectByIndex(6);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5000);
        }

        public void SelectTitle()
        {
            var titleoptions = this.Map.SelectTitle;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2000);
            var selectElement = new SelectElement(titleoptions);
            selectElement.SelectByIndex(4);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2000);
        }

        public void EnterFirstName()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2000);
            this.Map.EnterFirstName.SendKeys(contactfirstname);

        }

        public void EnterLastName()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2000);
            this.Map.EnterLastName.SendKeys(contactlastname);
        }

        public void EnterDisplayName()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2000);
            //  Thread.Sleep(3000);
            //  this.Map.EnterDisplayName.Clear();
            this.Map.EnterDisplayName.Click();

            Thread.Sleep(3000);
            //  this.Map.EnterDisplayName.Clear();
            // this.Map.EnterDisplayName.SendKeys(displayname);
            // this.Map.EnterDisplayName.Click();
        }

        public void EnterAddress1()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2000);
            this.Map.EnterAddress1.Clear();
            this.Map.EnterAddress1.SendKeys(Propertyaddress);
        }

        public void EnterTown()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2000);
            this.Map.EnterTown.Clear();
            this.Map.EnterTown.SendKeys(Propertytown);
        }

        public void SelectCountry()
        {

            var Countryoptions = this.Map.SelectCountry;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2000);
            var selectElement = new SelectElement(Countryoptions);
            selectElement.SelectByValue(Propertycountry);

        }

        public void SelectRegion()
        {
            var Regionoptions = this.Map.SelectRegion;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2000);
            var selectElement = new SelectElement(Regionoptions);
            selectElement.SelectByValue(Propertyregion);
        }

        public void Selectstate()
        {
            // var Stateoptions = driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_Address1_ddlStateCounty"));
            var Stateoptions = this.Map.SelectState;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2000);
            var selectElement = new SelectElement(Stateoptions);
            selectElement.SelectByValue(Propertystatecounty);

        }

        public void EnterTelephone1()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2000);
            // this.Map.EnterTelephone1.Clear();
            this.Map.EnterTelephone1.SendKeys(Propertytelephone);
        }

        public void EnterEmail()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2000);
            this.Map.EnterEmail.Clear();
            this.Map.EnterEmail.SendKeys(Propertyemail);
        }

        public void SaveButtonClicked()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2000);
            this.Map.SaveButton.Click();
        }

        public void CancelButtonClicked()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2000);
            this.Map.CancelButton.Click();
        }

        public void SaveandAddMoreButtonClicked()
        {

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2000);
            this.Map.SaveandAddMoreButton.Click();

        }

        public void SearchingContactFromDisplayName()  //Searching By Display Name     //string displayname
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2000);
            this.Map.SearchingByDisplayName.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2000);
            this.Map.SearchingByDisplayName.SendKeys(displayname);
            Thread.Sleep(3000);
            this.Map.SearchingByDisplayName.SendKeys(Keys.Enter);
        }

        public void SearchingContactFromCompanyName()  //Searching By Company Name 
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2000);
            this.Map.SearchingByCompanyName.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2000);
            this.Map.SearchingByCompanyName.SendKeys("NFS");
            Thread.Sleep(3000);
            this.Map.SearchingByCompanyName.SendKeys(Keys.Enter);
        }

        public void SearchingContactFromPropertyName()   //Searching By Property Name
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2000);
            this.Map.SearchingByPropertyName.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2000);
            this.Map.SearchingByPropertyName.SendKeys("Vancouver");
            Thread.Sleep(3000);
            this.Map.SearchingByPropertyName.SendKeys(Keys.Enter);
        }

        public void SearchingContactByTelephoneNumber()    //Searching by Telephone Number
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2000);
            this.Map.SearchingByTelephone.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2000);
            this.Map.SearchingByTelephone.SendKeys("1234");
            Thread.Sleep(3000);
            this.Map.SearchingByTelephone.SendKeys(Keys.Enter);
        }


        public void click()
        {
            var flreql = this.Map.FilterEqualTo;
            var selectElement = new SelectElement(flreql);
            selectElement.SelectByText("EqualTo");
        }
        public void FilterByInternal()    //Filter by is Internal?
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2000);
            this.Map.InternalFilter.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2000);
            Thread.Sleep(3000);
            this.Map.InternalFilterButton.Click();
            Thread.Sleep(2000);
            var xpath = string.Format(".//li[6]/a/span[contains(text(),'{0}')]", "EqualTo");
            driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_usergrdList_rfltMenu_detached")).FindElement(By.XPath(xpath)).Click();
        }

    }
}
