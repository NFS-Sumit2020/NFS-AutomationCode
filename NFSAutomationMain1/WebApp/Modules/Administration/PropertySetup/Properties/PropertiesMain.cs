using System.Configuration;
using System.Threading;
using WebApp.Login;
using OpenQA.Selenium.Support.UI;
using System;
using OpenQA.Selenium;



namespace WebApp.Modules.Administration.PropertySetup.Properties
{
    public class PropertiesMain
    {

        private IWebDriver driver;
        private readonly string PropertynameMain = ConfigurationManager.AppSettings["propertyname"];
        private readonly string Propertydescription = ConfigurationManager.AppSettings["Propertydescription"];
        private readonly string Propertyaddress = ConfigurationManager.AppSettings["Propertyaddress"];
        private readonly string Propertytown = ConfigurationManager.AppSettings["Propertytown"];
        private readonly string Propertytelephone = ConfigurationManager.AppSettings["Propertytelephone"];
        private readonly string Propertyemail = ConfigurationManager.AppSettings["Propertyemail"];
        private readonly string PropertytimeZone = ConfigurationManager.AppSettings["Timezone"];
        private readonly string Propertytype = ConfigurationManager.AppSettings["Propertytype"];
        private readonly string Propertycountry = ConfigurationManager.AppSettings["Propertycountry"];
        private readonly string Propertyregion = ConfigurationManager.AppSettings["Propertyregion"];
        private readonly string Propertystatecounty = ConfigurationManager.AppSettings["Propertystatecounty"];
        public string Propertyname = null;
      
        public PropertiesMain(IWebDriver driver)
        {
            this.driver = driver;
        }

        protected PropertiesReferences Map
        {
            get
            {
                return new PropertiesReferences(this.driver);
            }
        }


        public void AccessAdminIcon()
        {
            this.Map.AdministrationIcon.Click();
        }

        public void AccessPropertySetupab()
        {
            this.Map.PropertySetupTab.Click();
        }

        public void AccessPropertiesTab()
        {
            this.Map.PropertiesTab.Click();
        }

        public void AddnewpropertyButton()
        {
            this.Map.AddnewProperty.Click();
        }

        public void SelectType()
        {
            var typeoptions = this.Map.PropertyType;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2000);
            var selectElement = new SelectElement(typeoptions);
            selectElement.SelectByText(Propertytype);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2000);
        }

        public void PropertyName()
        {
            Random ran = new Random();
            int i = ran.Next(0, 10000);
            this.Map.PropertyName.SendKeys(PropertynameMain + i);
            Propertyname = this.Map.PropertyName.GetAttribute("value");
        }

        public void PropertyActiveYes()
        {
            this.Map.PropertyActiveYes.Click();
        }

        public void PropertyActiveNo()
        {
            this.Map.PropertyActiveNo.Click();
        }

        public void PropertyDescription()
        {
            this.Map.PropertyDescription.SendKeys(Propertydescription);
        }

        public void PropertyAddress1()
        {
            this.Map.PropertyAddress1.SendKeys(Propertyaddress);
        }

        public void PropertyTownOrCity()
        {
            this.Map.PropertyTownOrCity.SendKeys(Propertytown);
        }

        public void PropertyCountry()
        {
            var countryoptions = this.Map.PropertyCountry;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2000);
            var selectElement = new SelectElement(countryoptions);
            selectElement.SelectByText(Propertycountry);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2000);
        }


        public void PropertyRegion()
        {
            var Regionoptions = this.Map.PropertyRegion;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2000);
            var selectElement = new SelectElement(Regionoptions);
            selectElement.SelectByText(Propertyregion);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2000);
        }

        public void PropertyStateOrCounty()
        {
            var StateCountyoptions = this.Map.PropertyStateOrCounty;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2000);
            var selectElement = new SelectElement(StateCountyoptions);
            selectElement.SelectByText(Propertystatecounty);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2000);
        }

        public void PropertyTelephone1()
        {
            this.Map.PropertyTelephone1.SendKeys(Propertytelephone);
        }

        public void PropertyEmail()
        {
            this.Map.PropertyEmail.SendKeys(Propertyemail);
        }

        public void PropertyTimeZone()
        {
            var Timezoneoptions = this.Map.PropertyTimeZone;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2000);
            var selectElement = new SelectElement(Timezoneoptions);
            selectElement.SelectByValue(PropertytimeZone);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2000);
        }

        public void PropertyTime12Hour()
        {
            this.Map.Property12HourDisplay.Click();
        }

        public void PropertyTime24Hour()
        {
            this.Map.Property24HourDisplay.Click();
        }

        public void PropertySaveButton()
        {
            this.Map.PropertySaveButton.Click();
        }

        public void PropertySaveAddMoreButton()
        {
            this.Map.PropertySaveAddMoreButton.Click();
        }

        public void PropertyCancelButton()
        {
            this.Map.PropertyCancelButton.Click();
        }

        public void PropertyUserGroupPage()
        {
            this.Map.PropertyUserGroupPage.Click();
        }

        public void PropertyUserGroupFilterOption()
        {
            this.Map.PropertyUserGroupPropertyFilterBox.SendKeys(Propertyname);
            Thread.Sleep(2000);
            this.Map.PropertyUserGroupPropertyFilterIcon.Click();
            Thread.Sleep(2000);
            this.Map.PropertyUserGroupPropertyFilterOption.Click();

        }

        public void PropertyUserGroupRole()
        {
            this.Map.PropertyUserGroupRole.Click();
        }

        public void PropertyUserGroupPageSaveButton()
        {
            this.Map.PropertyUserGroupSaveButton.Click();
        }


        public void SearchDropdown()
        {
            var searchoptions = this.Map.Searchdropdown;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2000);
            var selectElement = new SelectElement(searchoptions);
            selectElement.SelectByText("Property Name");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2000);
        }

        public void SearchBox()
        {
            Thread.Sleep(1000);
            this.Map.Searchbox.SendKeys(Propertyname);
        }

        public void SearchButton()
        {
            this.Map.Searchbutton.Click();
        }

        public void SelectingProperty()
        {
            IWebElement link = this.driver.FindElement(By.LinkText(Propertyname));
            link.Click();
        }

    }
}
