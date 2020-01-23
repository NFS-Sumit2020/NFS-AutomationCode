using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Threading;
using System.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using WebApp.Utilities;
using WebApp.Modules.Administration.PropertySetup.Properties;
using WebApp.Login;
using RelevantCodes.ExtentReports;


namespace UnitTests.ModuleTests.Administration.PropertySetup.Properties
{

    public class PropertiesTest
    {
        public IWebDriver driver;
        private readonly string TextFilePath = ConfigurationManager.AppSettings["textfilepath"];
        public UtilitiesMain utilities;
        public WebAppLoginMain loginMain;
        public PropertiesMain propertiesMain;

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
        

        protected PropertiesReferences Map
        {
            get
            {
                return new PropertiesReferences(this.driver);
            }
        }

        [OneTimeSetUp]
        public void SetupTest()
        {
            this.driver = new ChromeDriver();
            this.loginMain = new WebAppLoginMain(this.driver);
            this.utilities = new UtilitiesMain(this.driver);
            this.propertiesMain = new PropertiesMain(this.driver);
            utilities.ReportSetup();
        }

        

        [Test, Category("Properties Tests"), Order(1)] //Accessing Admin Page
        public void AdminstrationButtonClicked()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Admin Button Clicked");
            utilities.extenttest.AssignCategory("Properties Tests");
            loginMain.NavigateTo();
            loginMain.LogInSuccess();
            propertiesMain.AccessAdminIcon();
            if (driver.FindElement(By.Id("ctl00_lblPropertySetUp")).Displayed)
            {
                Console.WriteLine("Admin Button Clicked");
                utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
                Assert.Pass();

            }
            else
            {
                Console.WriteLine("Admin button was not clicked");
                Assert.Fail();

            }
        }
        //------------------------------------------------------------------------------------------------

        [Test, Category("Properties Tests"), Order(2)] //Accessing Adminstration Page
        public void PropertySetupButtonClicked()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Property Setup Button Clicked");
            utilities.extenttest.AssignCategory("Properties Tests");
            loginMain.NavigateTo();
            loginMain.LogInSuccess();
            propertiesMain.AccessAdminIcon();
            propertiesMain.AccessPropertySetupab();
            if (driver.FindElement(By.Id("ctl00_subLblProperties")).Displayed)
            {
                Console.WriteLine("Property Setup Button Clicked");
                utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
                Assert.Pass();

            }
            else
            {
                Console.WriteLine("Property Setup button was not clicked");
                Assert.Fail();

            }
        }

        [Test, Category("Properties Tests"), Order(3)] //Accessing Adminstration Page
        public void propertiesButtonClicked()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Properties Button Clicked");
            utilities.extenttest.AssignCategory("Properties Tests");
            loginMain.NavigateTo();
            loginMain.LogInSuccess();
            propertiesMain.AccessAdminIcon();
            propertiesMain.AccessPropertySetupab();
            propertiesMain.AccessPropertiesTab();            
            if (driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_btnAdd")).Displayed)
            {
                Console.WriteLine("Properties Button Clicked");
                utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
                Assert.Pass();

            }
            else
            {
                Console.WriteLine("Properties Setup button was not clicked");
                Assert.Fail();

            }
        }

        [Test, Category("Properties Tests"), Order(4)] //Adding new property      
        public void AddNewPropertiesButtonClicked()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Add New Property Button Clicked");
            utilities.extenttest.AssignCategory("Properties Tests");
            loginMain.NavigateTo();
            loginMain.LogInSuccess();
            propertiesMain.AccessAdminIcon();
            propertiesMain.AccessPropertySetupab();
            propertiesMain.AccessPropertiesTab();
            propertiesMain.AddnewpropertyButton();
            Thread.Sleep(3000);
            var title = this.driver.FindElement(By.XPath("//*[@id='ctl00_Td5']/table/tbody/tr/td/table/tbody/tr[1]/td[1]/span")).Text;
                                                         
            Console.WriteLine("Title : " + title);
            if (title.Contains("Add a New Property"))
            {
                Console.WriteLine("Add new Property Button Clicked");
                utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
                Assert.Pass();

            }
            else
            {
                Console.WriteLine("Add new property button was not clicked");
                Assert.Fail();

            }
        }



        [Test, Category("Properties Tests"), Order(20)] //Edit Property Type
        public void ValidatePropertyType()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Property type Validation ");
            utilities.extenttest.AssignCategory("Properties Tests");
            loginMain.NavigateTo();
            loginMain.LogInSuccess();
            propertiesMain.AccessAdminIcon();
            propertiesMain.AccessPropertySetupab();
            propertiesMain.AccessPropertiesTab();
            propertiesMain.SearchDropdown();
            this.Map.Searchbox.SendKeys(propertiesMain.Propertyname);
            propertiesMain.SearchButton();
            Thread.Sleep(2000);
            IWebElement time = driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_grdList"));      
            if (time.Text.Contains(Propertytype))
            {
                Console.WriteLine("Property type Validation Pass");
                utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
                Assert.Pass();

            }
            else
            {
                Console.WriteLine("Property type validation failed");
                Assert.Fail();

            }
        }


        [Test, Category("Properties Tests"), Order(5)] //Saving New Property
        public void SavingNewProperty()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Saving new Property");
            utilities.extenttest.AssignCategory("Properties Tests");
            loginMain.NavigateTo();
            loginMain.LogInSuccess();
            propertiesMain.AccessAdminIcon();
            propertiesMain.AccessPropertySetupab();
            propertiesMain.AccessPropertiesTab();
            propertiesMain.AddnewpropertyButton();
            Thread.Sleep(1000);
            propertiesMain.SelectType();
            propertiesMain.PropertyName();
            // this.Map.PropertyName.SendKeys(Propertyname);
            propertiesMain.PropertyActiveYes();
            propertiesMain.PropertyDescription();
            propertiesMain.PropertyAddress1();
            propertiesMain.PropertyTownOrCity();
            Thread.Sleep(1000);
            propertiesMain.PropertyCountry();
            Thread.Sleep(1000);
            propertiesMain.PropertyRegion();
            Thread.Sleep(1000);
            propertiesMain.PropertyStateOrCounty();
            Thread.Sleep(1000);
            propertiesMain.PropertyTelephone1();
            propertiesMain.PropertyEmail();
            Thread.Sleep(1000);
            propertiesMain.PropertyTimeZone();
            Thread.Sleep(1000);
            propertiesMain.PropertyTime12Hour();
            Thread.Sleep(1000);
            propertiesMain.PropertySaveButton();
            Thread.Sleep(1000);
            propertiesMain.PropertyUserGroupPage();
            Thread.Sleep(1000);
            propertiesMain.PropertyUserGroupFilterOption();
            Thread.Sleep(1000);
            propertiesMain.PropertyUserGroupRole();
            Thread.Sleep(1000);
            propertiesMain.PropertyUserGroupPageSaveButton();
            Thread.Sleep(3000);
            IWebElement body = driver.FindElement(By.TagName("body"));
           
            if (body.Text.Contains(propertiesMain.Propertyname))
            {
                Console.WriteLine("New Property added");
                utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
                Assert.Pass();

            }
            else
            {
                Console.WriteLine("Saving new property Failed");
                Assert.Fail();

            }
        }

        [Test, Category("Properties Tests"), Order(6)] //Property name
        public void ValidatePropertyName()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Property Name Validation");
            utilities.extenttest.AssignCategory("Properties Tests");
            loginMain.NavigateTo();
            loginMain.LogInSuccess();
            propertiesMain.AccessAdminIcon();
            propertiesMain.AccessPropertySetupab();
            propertiesMain.AccessPropertiesTab();
            Thread.Sleep(1000);
            propertiesMain.SearchDropdown();
            Thread.Sleep(1000);
            propertiesMain.SearchBox();
            Thread.Sleep(1000);
            propertiesMain.SearchButton();
            Thread.Sleep(1000);
            IWebElement body = driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_grdList"));
            
            if (body.Text.Contains(propertiesMain.Propertyname)) 
            {
                Console.WriteLine("Property name validation pass");
                utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
                Assert.Pass();

            }
            else
            {
                Console.WriteLine("Property name validation failed");
                Assert.Fail();

            }
        }

        [Test, Category("Properties Tests"), Order(18)] //Property Active Yes
        public void PropertyActiveYes()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Property Active Yes Validation");
            utilities.extenttest.AssignCategory("Properties Tests");
            loginMain.NavigateTo();
            loginMain.LogInSuccess();
            propertiesMain.AccessAdminIcon();
            propertiesMain.AccessPropertySetupab();
            propertiesMain.AccessPropertiesTab();
            propertiesMain.SearchDropdown();
            this.Map.Searchbox.SendKeys(propertiesMain.Propertyname);
            propertiesMain.SearchButton();
            Thread.Sleep(2000);
           
            if (driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_grdList_ctl00_ctl04_chkActive")).Selected)
            {
                Console.WriteLine("Property is active");
                utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
                Assert.Pass();

            }
            else
            {
                Console.WriteLine("Property active but not displaying correctly here");
                Assert.Fail();

            }
        }

        [Test, Category("Properties Tests"), Order(19)] //Property Active No
        public void PropertyActiveNo()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Property Active No validation ");
            utilities.extenttest.AssignCategory("Properties Tests");
            loginMain.NavigateTo();
            loginMain.LogInSuccess();
            propertiesMain.AccessAdminIcon();
            propertiesMain.AccessPropertySetupab();
            propertiesMain.AccessPropertiesTab();
            propertiesMain.SearchDropdown();
            this.Map.Searchbox.SendKeys(propertiesMain.Propertyname);
            propertiesMain.SearchButton();
            Thread.Sleep(2000);
           
            // test.Log(LogStatus.Pass, "Booking has been copied successfully"); 
            if (driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_grdList_ctl00_ctl04_chkActive")).Selected)
            {
               
                Console.WriteLine("Property not active but not displaying active here");
                Assert.Fail();
                

            }
            else
            {
                Console.WriteLine("Property is not active");
                utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
                Assert.Pass();

            }
        }


        [Test, Category("Properties Tests"), Order(7)] //Property Description
        public void ValidatePropertyDescription()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Property description validation");
            utilities.extenttest.AssignCategory("Properties Tests");
            loginMain.NavigateTo();
            loginMain.LogInSuccess();
            propertiesMain.AccessAdminIcon();
            propertiesMain.AccessPropertySetupab();
            propertiesMain.AccessPropertiesTab();
            propertiesMain.SearchDropdown();
            this.Map.Searchbox.SendKeys(propertiesMain.Propertyname);
            propertiesMain.SearchButton();
            Thread.Sleep(2000);
            propertiesMain.SelectingProperty();
            string description = this.Map.PropertyDescription.GetAttribute("value");
            if (description == Propertydescription)
            {
                Console.WriteLine("Property description Validation Passed");
                utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
                Assert.Pass();

            }
            else
            {
                Console.WriteLine("Property description validation failed");
                Assert.Fail();

            }

        }

        [Test, Category("Properties Tests"), Order(8)] //Property Address1
        public void ValidatePropertyAddress1()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Property address Validation");
            utilities.extenttest.AssignCategory("Properties Tests");
            loginMain.NavigateTo();
            loginMain.LogInSuccess();
            propertiesMain.AccessAdminIcon();
            propertiesMain.AccessPropertySetupab();
            propertiesMain.AccessPropertiesTab();
            propertiesMain.SearchDropdown();
            this.Map.Searchbox.SendKeys(propertiesMain.Propertyname);
            propertiesMain.SearchButton();
            Thread.Sleep(2000);
            propertiesMain.SelectingProperty();
            string address = this.Map.PropertyAddress1.GetAttribute("value");
            if (address == Propertyaddress)
            {
                Console.WriteLine("Property address Validation Passed");
                utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
                Assert.Pass();

            }
            else
            {
                Console.WriteLine("Property address Validation Failed");
                Assert.Fail();

            }
        }

        [Test, Category("Properties Tests"), Order(9)] //Property Town OR City
        public void ValidatePropertyTownOrCity()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Property Town/City Validation");
            utilities.extenttest.AssignCategory("Properties Tests");
            loginMain.NavigateTo();
            loginMain.LogInSuccess();
            propertiesMain.AccessAdminIcon();
            propertiesMain.AccessPropertySetupab();
            propertiesMain.AccessPropertiesTab();
            propertiesMain.SearchDropdown();
            this.Map.Searchbox.SendKeys(propertiesMain.Propertyname);
            propertiesMain.SearchButton();
            Thread.Sleep(2000);
            propertiesMain.SelectingProperty();
            string town = this.Map.PropertyTownOrCity.GetAttribute("value");           
            if (town == Propertytown)
            {
                Console.WriteLine("Property Town/City Validation Passed");
                utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
                Assert.Pass();

            }
            else
            {
                Console.WriteLine("Property Town/City Validation Failed");
                Assert.Fail();

            }
        }

        [Test, Category("Properties Tests"), Order(10)] //Property Country
        public void ValidatePropertyCountry()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Property Country Validation");
            utilities.extenttest.AssignCategory("Properties Tests");
            loginMain.NavigateTo();
            loginMain.LogInSuccess();
            propertiesMain.AccessAdminIcon();
            propertiesMain.AccessPropertySetupab();
            propertiesMain.AccessPropertiesTab();
            propertiesMain.SearchDropdown();
            this.Map.Searchbox.SendKeys(propertiesMain.Propertyname);
            propertiesMain.SearchButton();
            Thread.Sleep(2000);
            propertiesMain.SelectingProperty();
            Thread.Sleep(2000);
            //string town = this.Map.PropertyCountry.GetAttribute("value");
            IWebElement country = this.Map.PropertyCountry;
            SelectElement value = new SelectElement(country);
            string value1 = value.SelectedOption.Text;           
            if (value1 == Propertycountry)
            {
                Console.WriteLine("Property Country Validation Passed");
                utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
                Assert.Pass();

            }
            else
            {
                Console.WriteLine("Property Country Validation Failed");
                Assert.Fail();

            }
        }

        [Test, Category("Properties Tests"), Order(11)] //Property Region
        public void ValidatePropertyRegion()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Property Region Validation");
            utilities.extenttest.AssignCategory("Properties Tests");
            loginMain.NavigateTo();
            loginMain.LogInSuccess();
            propertiesMain.AccessAdminIcon();
            propertiesMain.AccessPropertySetupab();
            propertiesMain.AccessPropertiesTab();
            propertiesMain.SearchDropdown();
            this.Map.Searchbox.SendKeys(propertiesMain.Propertyname);
            propertiesMain.SearchButton();
            Thread.Sleep(2000);
            propertiesMain.SelectingProperty();
            IWebElement region = this.Map.PropertyRegion;
            SelectElement value = new SelectElement(region);
            string value1 = value.SelectedOption.Text;            
            if (value1 == Propertyregion)
            {
                Console.WriteLine("Property Region Validation Passed");
                utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
                Assert.Pass();

            }
            else
            {
                Console.WriteLine("Property Region Validation Failed");
                Assert.Fail();

            }

        }

        [Test, Category("Properties Tests"), Order(12)] //Property State/County
        public void ValidatePropertyStateOrCounty()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Property State/County Validation");
            utilities.extenttest.AssignCategory("Properties Tests");
            loginMain.NavigateTo();
            loginMain.LogInSuccess();
            propertiesMain.AccessAdminIcon();
            propertiesMain.AccessPropertySetupab();
            propertiesMain.AccessPropertiesTab();
            propertiesMain.SearchDropdown();
            this.Map.Searchbox.SendKeys(propertiesMain.Propertyname);
            propertiesMain.SearchButton();
            Thread.Sleep(2000);
            propertiesMain.SelectingProperty();
            IWebElement state = this.Map.PropertyStateOrCounty;
            SelectElement value = new SelectElement(state);
            string value1 = value.SelectedOption.Text;
            if (value1 == Propertystatecounty)
            {
                Console.WriteLine("Property State/County Validation Passed");
                utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
                Assert.Pass();

            }
            else
            {
                Console.WriteLine("Property State/Region Validation Failed");
                Assert.Fail();

            }

        }

        [Test, Category("Properties Tests"), Order(13)] //Property Telephone1
        public void ValidatePropertyTelephone1()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Property Telephone Validation");
            utilities.extenttest.AssignCategory("Properties Tests");
            loginMain.NavigateTo();
            loginMain.LogInSuccess();
            propertiesMain.AccessAdminIcon();
            propertiesMain.AccessPropertySetupab();
            propertiesMain.AccessPropertiesTab();
            propertiesMain.SearchDropdown();
            this.Map.Searchbox.SendKeys(propertiesMain.Propertyname);
            propertiesMain.SearchButton();
            Thread.Sleep(2000);
            propertiesMain.SelectingProperty();
            string telephone = this.Map.PropertyTelephone1.GetAttribute("value");
            if (telephone == Propertytelephone)
            {
                Console.WriteLine("Property Telephone Validation Passed");
                utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
                Assert.Pass();

            }
            else
            {
                Console.WriteLine("Property Telephone Validation Failed");
                Assert.Fail();

            }
        }

        [Test, Category("Properties Tests"), Order(14)] //Property Email
        public void ValidatePropertyEmail()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Property Email Validation");
            utilities.extenttest.AssignCategory("Properties Tests");
            loginMain.NavigateTo();
            loginMain.LogInSuccess();
            propertiesMain.AccessAdminIcon();
            propertiesMain.AccessPropertySetupab();
            propertiesMain.AccessPropertiesTab();
            propertiesMain.SearchDropdown();
            this.Map.Searchbox.SendKeys(propertiesMain.Propertyname);
            propertiesMain.SearchButton();
            Thread.Sleep(2000);
            propertiesMain.SelectingProperty();
            string email = this.Map.PropertyEmail.GetAttribute("value");
            if (email == Propertyemail)
            {
                Console.WriteLine("Property Email Validation Passed");
                utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
                Assert.Pass();

            }
            else
            {
                Console.WriteLine("Property Email Validation Failed");
                Assert.Fail();

            }
        }

        [Test, Category("Properties Tests"), Order(15)] //Property TimeZone
        public void ValidatePropertyTimeZone()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Property Timezone Validation");
            utilities.extenttest.AssignCategory("Properties Tests");
            loginMain.NavigateTo();
            loginMain.LogInSuccess();
            propertiesMain.AccessAdminIcon();
            propertiesMain.AccessPropertySetupab();
            propertiesMain.AccessPropertiesTab();
            propertiesMain.SearchDropdown();
            this.Map.Searchbox.SendKeys(propertiesMain.Propertyname);
            propertiesMain.SearchButton();
            Thread.Sleep(2000);
            propertiesMain.SelectingProperty();
            string timezone = this.Map.PropertyTimeZone.GetAttribute("value");
            if (timezone == PropertytimeZone)
            {
                Console.WriteLine("Property TimeZone Validation Passed");
                utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
                Assert.Pass();

            }
            else
            {
                Console.WriteLine("Property Timezone Validation Failed");
                Assert.Fail();

            }
        }

        [Test, Category("Properties Tests"), Order(16)] //Property 12 Hour Time Display
        public void ValidatePropertyTime12Hour()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Property Time 12 Hour Validation");
            utilities.extenttest.AssignCategory("Properties Tests");
            loginMain.NavigateTo();
            loginMain.LogInSuccess();
            propertiesMain.AccessAdminIcon();
            propertiesMain.AccessPropertySetupab();
            propertiesMain.AccessPropertiesTab();
            propertiesMain.SearchDropdown();
            this.Map.Searchbox.SendKeys(propertiesMain.Propertyname);
            propertiesMain.SearchButton();
            Thread.Sleep(2000);
            propertiesMain.SelectingProperty();
            propertiesMain.PropertyTime12Hour();
            propertiesMain.PropertySaveButton();
            propertiesMain.SearchDropdown();
            this.Map.Searchbox.SendKeys(propertiesMain.Propertyname);
            propertiesMain.SearchButton();
            Thread.Sleep(2000);
            // Assert.IsTrue(this.Map.Property12HourDisplay.Selected);  This is just to check if it's selected. 
            IWebElement time = driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_grdList"));          
            if (time.Text.Contains("12 Hours Display"))
            {
                Console.WriteLine("Property Time 12 Hour Validation Passed");
                utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
                Assert.Pass();

            }
            else
            {
                Console.WriteLine("Property Time 12 Hour Validation Fail");
                Assert.Fail();

            }

        }


        [Test, Category("Properties Tests"), Order(17)] //Property 24 Hour Time Display
        public void ValidatePropertyTime24Hour()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Property Time 24 Hour Validation");
            utilities.extenttest.AssignCategory("Properties Tests");
            loginMain.NavigateTo();
            loginMain.LogInSuccess();
            propertiesMain.AccessAdminIcon();
            propertiesMain.AccessPropertySetupab();
            propertiesMain.AccessPropertiesTab();
            propertiesMain.SearchDropdown();
            this.Map.Searchbox.SendKeys(propertiesMain.Propertyname);
            propertiesMain.SearchButton();
            Thread.Sleep(2000);
            propertiesMain.SelectingProperty();
            propertiesMain.PropertyTime24Hour();
            propertiesMain.PropertySaveButton();
            propertiesMain.SearchDropdown();
            this.Map.Searchbox.SendKeys(propertiesMain.Propertyname);
            propertiesMain.SearchButton();
            Thread.Sleep(2000);
            // Assert.IsTrue(this.Map.Property24HourDisplay.Selected);  This is just to check if it's selected. 
            IWebElement time = driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_grdList"));
            if (time.Text.Contains("24 Hours Display"))
            {
                Console.WriteLine("Property Time 24 Hour Validation Passed");
                utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
                Assert.Pass();

            }
            else
            {
                Console.WriteLine("Property Time 24 Hour Validation Fail");
                Assert.Fail();

            }
        }

        //------------------------------------------------------------------------------------------------
        //Tear Down Start
        [TearDown]
        public void Result()
        {
            utilities.GetResult();
        }


        [OneTimeTearDown]
        public void TearDownTest()
        {
            utilities.extent.Flush();
            utilities.extent.Close();
            this.driver.Quit();
        }
    }
}





