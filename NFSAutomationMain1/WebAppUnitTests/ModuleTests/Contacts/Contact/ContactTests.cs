using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using RelevantCodes.ExtentReports;
using System;
using System.Configuration;
using System.Threading;
using WebApp.Login;
using WebApp.Modules.Contacts.Contact;
using WebApp.Utilities;

namespace UnitTests.ModuleTests.Contacts.Contact
{
    [TestFixture]
    public class ContactTests
    {
        public IWebDriver driver;
        private readonly string TextFilePath = ConfigurationManager.AppSettings["textfilepath"];
        private readonly string displayname = ConfigurationManager.AppSettings["displayname"];
        public UtilitiesMain utilities;
        public WebAppLoginMain loginMain;
        public ContactMain contactMain;

        protected ContactReferences Map
        {
            get
            {
                return new ContactReferences(this.driver);
            }
        }

        [OneTimeSetUp]
        public void SetupTest()
        {
            this.driver = new ChromeDriver();
            this.loginMain = new WebAppLoginMain(this.driver);
            this.utilities = new UtilitiesMain(this.driver);
            this.contactMain = new ContactMain(this.driver);
            utilities.ReportSetup();
        }

        //Click on Contacts Button (Nav Bar)
        [Test, Category("Contact Tests")]
        public void ContactButtonClicked()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Contact Button Clicked");
            utilities.extenttest.AssignCategory("Contact Tests");
            loginMain.NavigateTo();
            loginMain.LogInSuccess();
            contactMain.AccessContactsTab();
            if (driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_usergrdList")).Displayed)
            {
                Console.WriteLine("Contacts Button Clicked");
                utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
                Assert.Pass();

            }
            else
            {
                Console.WriteLine("Contacts button was not clicked");
                Assert.Fail();

            }
        }

        [Test, Category("Contact Tests")] //Click on contacts button
        public void AddNewContactButtonClicked()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Add New Contact Button Clicked");
            utilities.extenttest.AssignCategory("Contact Tests");
            loginMain.NavigateTo();
            loginMain.LogInSuccess();
            contactMain.AccessContactsTab();
            contactMain.AddNewContactButton();
            Thread.Sleep(3000);
            var title = this.driver.FindElement(By.XPath("//*[@id='ctl00_Td5']/table/tbody/tr[2]/td/table/tbody/tr[1]/td[1]/span")).Text;
            Console.WriteLine("Title : " + title);
            if (title.Contains("Add a New Contact"))
            {
                Console.WriteLine("Add new Contact Button Clicked");
                utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
                Assert.Pass();
            }
            else
            {
                Console.WriteLine("Add new Contact button was not clicked");
                Assert.Fail();
            }
        }

        /*//This is currently not working not sure how to validate this test.
         [Test, Category("Contact Tests")] //Click on company dropdown list
         public void CompanyDropDownListClicked()
         {
             utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Contact Button Clicked");
            utilities.extenttest.AssignCategory("Contact Tests");
            loginMain.NavigateTo();
            loginMain.LogInSuccess();
            contactMain.AccessContactsTab();
            contactMain.AddNewContactButton();
            Thread.Sleep(4000);
            contactMain.CompanyDropDownList();
         //     Assert.IsTrue(driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_usergrdList")).Displayed);
        //    String bodyText = driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_Address1_txtAddress1")).getAttribute("value");
       //     Assert.assertTrue("Text not found!", bodyText.contains(text));
        
            // var text_input = driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_Address1_txtAddress1"));
          //  if (!String.IsNullOrEmpty(text_input.GetAttribute("value")))
          //  {
          
               // Assert.IsTrue(driver.FindElement(By.Id("alue")).Displayed);
        //    }
           
         }*/

        [Test, Category("Contact Tests")] //Enter All the Details
        public void SavingContact()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Contact Button Clicked");
            utilities.extenttest.AssignCategory("Contact Tests");
            loginMain.NavigateTo();
            loginMain.LogInSuccess();
            contactMain.AccessContactsTab();
            contactMain.AddNewContactButton();
            Thread.Sleep(2000);
          //  contactMain.CompanyDropDownList();
            Thread.Sleep(2000);
            contactMain.SelectTitle();
            Thread.Sleep(2000);
            contactMain.EnterFirstName();
            contactMain.EnterLastName();
            Thread.Sleep(2000);
            contactMain.EnterDisplayName();
            contactMain.EnterAddress1();
            contactMain.EnterTown();
            Thread.Sleep(2000);
            // contactMain.SelectCountry();
            Thread.Sleep(2000);
            // contactMain.SelectRegion();
            Thread.Sleep(2000);
            //  contactMain.Selectstate();
            Thread.Sleep(2000);
            contactMain.EnterTelephone1();
            contactMain.EnterEmail();
            contactMain.SaveButtonClicked();
            contactMain.AccessContactsTab();
            contactMain.SearchingContactFromDisplayName();
            IWebElement check = driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_usergrdList"));
            Assert.IsTrue(check.Text.Contains(displayname));

            //  Assert.IsTrue(driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_usergrdList")).Displayed);
        }

        /*  //This test is not working not not validating
           [Test, Category("Contact Tests")] //Selecting a Title from Dropdown
           public void SelectingTitleFromDropdown()
           {
               utilities.ConsoleMessageStart();
              utilities.extenttest = utilities.extent.StartTest("Contact Button Clicked");
              utilities.extenttest.AssignCategory("Contact Tests");
              loginMain.NavigateTo();
              loginMain.LogInSuccess();
              contactMain.AccessContactsTab();
               contactMain.AddNewContactButton();
               contactMain.SelectTitle();
               Assert.IsTrue(driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_usergrdList")).Displayed);
           } */

        [Test, Category("Contact Tests")] //Saving a contact without selecting company
        public void SavingContactWithoutSelectingCompany()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Contact Button Clicked");
            utilities.extenttest.AssignCategory("Contact Tests");
            loginMain.NavigateTo();
            loginMain.LogInSuccess();
            contactMain.AccessContactsTab();
            contactMain.AddNewContactButton();
            Thread.Sleep(2000);
            contactMain.SelectTitle();
            Thread.Sleep(2000);
            contactMain.EnterFirstName();
            contactMain.EnterLastName();
            contactMain.EnterDisplayName();
            contactMain.EnterAddress1();
            contactMain.EnterTown();
            Thread.Sleep(2000);
            contactMain.SelectCountry();
            Thread.Sleep(2000);
            contactMain.SelectRegion();
            Thread.Sleep(2000);
            contactMain.Selectstate();
            contactMain.EnterTelephone1();
            contactMain.EnterEmail();
            contactMain.SaveButtonClicked();
            Thread.Sleep(2000);
            IWebElement body = driver.FindElement(By.TagName("body"));
            Assert.IsTrue(body.Text.Contains("Select Host"));
        }

        [Test, Category("Contact Tests")] //Saving a contact without Entering First Name
        public void SavingContactWithoutEnteringFirstName()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Contact Button Clicked");
            utilities.extenttest.AssignCategory("Contact Tests");
            loginMain.NavigateTo();
            loginMain.LogInSuccess();
            contactMain.AccessContactsTab();
            contactMain.AddNewContactButton();
            contactMain.CompanyDropDownList();
            Thread.Sleep(2000);
            contactMain.SelectTitle();
            Thread.Sleep(2000);
            //  contactMain.EnterFirstName();
            contactMain.EnterLastName();
            contactMain.EnterDisplayName();
            contactMain.EnterAddress1();
            contactMain.EnterTown();
            Thread.Sleep(2000);
            contactMain.SelectCountry();
            Thread.Sleep(2000);
            contactMain.SelectRegion();
            Thread.Sleep(2000);
            contactMain.Selectstate();
            contactMain.EnterTelephone1();
            contactMain.EnterEmail();
            contactMain.SaveButtonClicked();
            Thread.Sleep(2000);
            IWebElement body = driver.FindElement(By.TagName("body"));
            Assert.IsTrue(body.Text.Contains("Enter First Name"));
        }

        [Test, Category("Contact Tests")] //Saving contact without entering Last Name
        public void SavingContactWithoutEnteringLastName()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Contact Button Clicked");
            utilities.extenttest.AssignCategory("Contact Tests");
            loginMain.NavigateTo();
            loginMain.LogInSuccess();
            contactMain.AccessContactsTab();
            contactMain.AddNewContactButton();
            contactMain.CompanyDropDownList();
            Thread.Sleep(2000);
            contactMain.SelectTitle();
            Thread.Sleep(2000);
            contactMain.EnterFirstName();
            //  contactMain.EnterLastName();
            contactMain.EnterDisplayName();
            contactMain.EnterAddress1();
            contactMain.EnterTown();
            Thread.Sleep(2000);
            contactMain.SelectCountry();
            Thread.Sleep(2000);
            contactMain.SelectRegion();
            Thread.Sleep(2000);
            contactMain.Selectstate();
            contactMain.EnterTelephone1();
            contactMain.EnterEmail();
            contactMain.SaveButtonClicked();
            IWebElement body = driver.FindElement(By.TagName("body"));
            Assert.IsTrue(body.Text.Contains("Enter Last Name"));
        }

        [Test, Category("Contact Tests")] //Saving Contact without entering display name
        public void SavingContactWithoutEnteringDisplayName()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Contact Button Clicked");
            utilities.extenttest.AssignCategory("Contact Tests");
            loginMain.NavigateTo();
            loginMain.LogInSuccess();
            contactMain.AccessContactsTab();
            contactMain.AddNewContactButton();
            contactMain.CompanyDropDownList();
            Thread.Sleep(2000);
            contactMain.SelectTitle();
            Thread.Sleep(2000);
            contactMain.EnterFirstName();
            contactMain.EnterLastName();
            // contactMain.EnterDisplayName();
            contactMain.EnterAddress1();
            contactMain.EnterTown();
            Thread.Sleep(2000);
            contactMain.SelectCountry();
            Thread.Sleep(2000);
            contactMain.SelectRegion();
            Thread.Sleep(2000);
            contactMain.Selectstate();
            contactMain.EnterTelephone1();
            contactMain.EnterEmail();
            contactMain.SaveButtonClicked();
            IWebElement body = driver.FindElement(By.TagName("body"));
            Assert.IsTrue(body.Text.Contains("Enter Display Name"));
        }

        [Test, Category("Contact Tests")] //Saving a contact without entering Address 1
        public void SavingContactWithoutEnteringAddress1()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Contact Button Clicked");
            utilities.extenttest.AssignCategory("Contact Tests");
            loginMain.NavigateTo();
            loginMain.LogInSuccess();
            contactMain.AccessContactsTab();
            contactMain.AddNewContactButton();
            contactMain.CompanyDropDownList();
            Thread.Sleep(2000);
            contactMain.SelectTitle();
            Thread.Sleep(2000);
            contactMain.EnterFirstName();
            contactMain.EnterLastName();
            Thread.Sleep(2000);
            contactMain.EnterDisplayName();
            //contactMain.EnterAddress1();
            this.Map.EnterAddress1.Clear();
            contactMain.EnterTown();
            Thread.Sleep(2000);
            contactMain.SelectCountry();
            Thread.Sleep(2000);
            contactMain.SelectRegion();
            Thread.Sleep(2000);
            contactMain.Selectstate();
            contactMain.EnterTelephone1();
            contactMain.EnterEmail();
            contactMain.SaveButtonClicked();
            IWebElement body = driver.FindElement(By.TagName("body"));
            Assert.IsTrue(body.Text.Contains("Enter Address1"));
        }

        [Test, Category("Contact Tests")] //Saving a contact without entering Town/City
        public void SavingContactWithoutEnteringCity()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Contact Button Clicked");
            utilities.extenttest.AssignCategory("Contact Tests");
            loginMain.NavigateTo();
            loginMain.LogInSuccess();
            contactMain.AccessContactsTab();
            contactMain.AddNewContactButton();
            contactMain.CompanyDropDownList();
            Thread.Sleep(2000);
            contactMain.SelectTitle();
            Thread.Sleep(2000);
            contactMain.EnterFirstName();
            contactMain.EnterLastName();
            contactMain.EnterDisplayName();
            contactMain.EnterAddress1();
            //contactMain.EnterTown();
            this.Map.EnterTown.Clear();
            Thread.Sleep(2000);
            contactMain.SelectCountry();
            Thread.Sleep(2000);
            contactMain.SelectRegion();
            Thread.Sleep(2000);
            contactMain.Selectstate();
            contactMain.EnterTelephone1();
            contactMain.EnterEmail();
            contactMain.SaveButtonClicked();
            IWebElement body = driver.FindElement(By.TagName("body"));
            Assert.IsTrue(body.Text.Contains("Enter Town/City"));
        }

        /*  Country, Region and State/Country are set to First one in list by default. 
        *
        [Test, Category("Contact Tests")] //Saving a contact without entering Country
        public void SavingContactWithoutEnteringCountry()
        {
            utilities.ConsoleMessageStart();
           utilities.extenttest = utilities.extent.StartTest("Contact Button Clicked");
           utilities.extenttest.AssignCategory("Contact Tests");
           loginMain.NavigateTo();
           loginMain.LogInSuccess();
           contactMain.AccessContactsTab();
            contactMain.AddNewContactButton();
            contactMain.CompanyDropDownList();
            Thread.Sleep(2000);
            contactMain.SelectTitle();
            Thread.Sleep(2000);
            contactMain.EnterFirstName();
            contactMain.EnterLastName();
            contactMain.EnterDisplayName();
            contactMain.EnterAddress1();
            contactMain.EnterTown();
            Thread.Sleep(2000);
            //contactMain.SelectCountry();
            //Thread.Sleep(2000);
            contactMain.SelectRegion();
            Thread.Sleep(2000);
            contactMain.Selectstate();
            contactMain.EnterTelephone1();
            contactMain.EnterEmail();
            contactMain.SaveButtonClicked();
            IWebElement body = driver.FindElement(By.TagName("body"));
            Assert.IsTrue(body.Text.Contains("Enter Telephone1"));
        }


        [Test, Category("Contact Tests")] //Saving a contact without selecting Region
        public void SavingContactWithoutSelectingRegion()
        {
            utilities.ConsoleMessageStart();
           utilities.extenttest = utilities.extent.StartTest("Contact Button Clicked");
           utilities.extenttest.AssignCategory("Contact Tests");
           loginMain.NavigateTo();
           loginMain.LogInSuccess();
           contactMain.AccessContactsTab();
            contactMain.AddNewContactButton();
            contactMain.CompanyDropDownList();
            Thread.Sleep(2000);
            contactMain.SelectTitle();
            Thread.Sleep(2000);
            contactMain.EnterFirstName();
            contactMain.EnterLastName();
            contactMain.EnterDisplayName();
            contactMain.EnterAddress1();
            contactMain.EnterTown();
            Thread.Sleep(2000);
            contactMain.SelectCountry();
            Thread.Sleep(2000);
            //contactMain.SelectRegion();
            //Thread.Sleep(2000);
            contactMain.Selectstate();
            contactMain.EnterTelephone1();
            contactMain.EnterEmail();
            contactMain.SaveButtonClicked();
            Assert.IsTrue(driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_usergrdList")).Displayed);
        }

        [Test, Category("Contact Tests")] //Saving a contact without entering State
        public void SavingContactWithoutSelectingState()
        {
            utilities.ConsoleMessageStart();
           utilities.extenttest = utilities.extent.StartTest("Contact Button Clicked");
           utilities.extenttest.AssignCategory("Contact Tests");
           loginMain.NavigateTo();
           loginMain.LogInSuccess();
           contactMain.AccessContactsTab();
            contactMain.AddNewContactButton();
            contactMain.CompanyDropDownList();
            Thread.Sleep(2000);
            contactMain.SelectTitle();
            Thread.Sleep(2000);
            contactMain.EnterFirstName();
            contactMain.EnterLastName();
            contactMain.EnterDisplayName();
            contactMain.EnterAddress1();
            contactMain.EnterTown();
            Thread.Sleep(2000);
            contactMain.SelectCountry();
            Thread.Sleep(2000);
            contactMain.SelectRegion();
            Thread.Sleep(2000);
            //contactMain.Selectstate();
            contactMain.EnterTelephone1();
            contactMain.EnterEmail();
            contactMain.SaveButtonClicked();
            Assert.IsTrue(driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_usergrdList")).Displayed);
        }
       */

        [Test, Category("Contact Tests")] //Saving a contact without entering Telephone
        public void SavingContactWithoutEnteringTelephone1()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Contact Button Clicked");
            utilities.extenttest.AssignCategory("Contact Tests");
            loginMain.NavigateTo();
            loginMain.LogInSuccess();
            contactMain.AccessContactsTab();
            contactMain.AddNewContactButton();
            contactMain.CompanyDropDownList();
            Thread.Sleep(2000);
            contactMain.SelectTitle();
            Thread.Sleep(2000);
            contactMain.EnterFirstName();
            contactMain.EnterLastName();
            contactMain.EnterDisplayName();
            contactMain.EnterAddress1();
            contactMain.EnterTown();
            Thread.Sleep(2000);
            contactMain.SelectCountry();
            Thread.Sleep(2000);
            contactMain.SelectRegion();
            Thread.Sleep(2000);
            contactMain.Selectstate();
            //contactMain.EnterTelephone1();
            contactMain.EnterEmail();
            contactMain.SaveButtonClicked();
            IWebElement body = driver.FindElement(By.TagName("body"));
            Assert.IsTrue(body.Text.Contains("Enter Telephone1"));
        }

        [Test, Category("Contact Tests")] //Saving a contact without entering Email
        public void SavingContactWithoutEnteringEmail()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Contact Button Clicked");
            utilities.extenttest.AssignCategory("Contact Tests");
            loginMain.NavigateTo();
            loginMain.LogInSuccess();
            contactMain.AccessContactsTab();
            contactMain.AddNewContactButton();
            contactMain.CompanyDropDownList();
            Thread.Sleep(2000);
            contactMain.SelectTitle();
            Thread.Sleep(2000);
            contactMain.EnterFirstName();
            contactMain.EnterLastName();
            contactMain.EnterDisplayName();
            contactMain.EnterAddress1();
            contactMain.EnterTown();
            Thread.Sleep(2000);
            contactMain.SelectCountry();
            Thread.Sleep(2000);
            contactMain.SelectRegion();
            Thread.Sleep(2000);
            contactMain.Selectstate();
            contactMain.EnterTelephone1();
            //contactMain.EnterEmail();
            contactMain.SaveButtonClicked();
            IWebElement body = driver.FindElement(By.TagName("body"));
            Assert.IsTrue(body.Text.Contains("Enter Email"));
        }

        [Test, Category("Contact Tests")] //Enter All the Details and save and add more button clicked
        public void SavingContactAndAddingMore()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Contact Button Clicked");
            utilities.extenttest.AssignCategory("Contact Tests");
            loginMain.NavigateTo();
            loginMain.LogInSuccess();
            contactMain.AccessContactsTab();
            contactMain.AddNewContactButton();
            contactMain.CompanyDropDownList();
            Thread.Sleep(2000);
            contactMain.SelectTitle();
            Thread.Sleep(2000);
            contactMain.EnterFirstName();
            contactMain.EnterLastName();
            contactMain.EnterDisplayName();
            contactMain.EnterAddress1();
            contactMain.EnterTown();
            Thread.Sleep(2000);
            contactMain.SelectCountry();
            Thread.Sleep(2000);
            contactMain.SelectRegion();
            Thread.Sleep(2000);
            contactMain.Selectstate();
            contactMain.EnterTelephone1();
            contactMain.EnterEmail();
            contactMain.SaveandAddMoreButtonClicked();
            Assert.IsTrue(driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_lblSuccessMessage")).Displayed);
        }

        [Test, Category("Contact Tests")] //Cancel Button Clicked
        public void CancelButtonClicked()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Contact Button Clicked");
            utilities.extenttest.AssignCategory("Contact Tests");
            loginMain.NavigateTo();
            loginMain.LogInSuccess();
            contactMain.AccessContactsTab();
            contactMain.AddNewContactButton();
            contactMain.CancelButtonClicked();
            Assert.IsTrue(driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_usergrdList")).Displayed);
        }

        [Test, Category("Contact Tests")] //Add new company button clicked
        public void AddNewCompanyButtonClicked()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Contact Button Clicked");
            utilities.extenttest.AssignCategory("Contact Tests");
            loginMain.NavigateTo();
            loginMain.LogInSuccess();
            contactMain.AccessContactsTab();
            contactMain.AddNewContactButton();
            contactMain.AddNewCompanyButton();
            Thread.Sleep(2000);
            Assert.IsTrue(driver.FindElement(By.XPath("//*[@id='RadWindowWrapper_ctl00_MainContentPlaceHolder_radWndHostDetailEdit']/table")).Displayed);
        }


        //Need to Find a way to validate the test 
        [Test, Category("Contact Tests")] //Searching By Display Name
        public void SearchByDisplayName()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Contact Button Clicked");
            utilities.extenttest.AssignCategory("Contact Tests");
            loginMain.NavigateTo();
            loginMain.LogInSuccess();
            contactMain.AccessContactsTab();
            this.Map.SearchingByDisplayName.SendKeys(displayname);
            this.Map.SearchingByDisplayName.SendKeys(Keys.Enter);
            Thread.Sleep(5000);
            IWebElement body = driver.FindElement(By.TagName("title"));
            Assert.IsTrue(body.Text.Contains(displayname));
        }

        [Test, Category("Contact Tests")] //Searching By Company Name
        public void SearchByCompanyName()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Contact Button Clicked");
            utilities.extenttest.AssignCategory("Contact Tests");
            loginMain.NavigateTo();
            loginMain.LogInSuccess();
            contactMain.AccessContactsTab();
            contactMain.SearchingContactFromCompanyName();
            Thread.Sleep(5000);
            IWebElement body = driver.FindElement(By.TagName("title"));
            //Assert.IsTrue(body.Text.Cont("NFS"));
        }


        [Test, Category("Contact Tests")] //Searching By Property Name
        public void SearchByPropertyName()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Contact Button Clicked");
            utilities.extenttest.AssignCategory("Contact Tests");
            loginMain.NavigateTo();
            loginMain.LogInSuccess();
            contactMain.AccessContactsTab();
            contactMain.SearchingContactFromPropertyName();
            Thread.Sleep(5000);
            IWebElement body = driver.FindElement(By.TagName("title"));
            Assert.IsTrue(body.Text.Contains("NFS"));
        }

        [Test, Category("Contact Tests")] //Searching By Telephone Number
        public void SearchByTelephoneNumber()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Contact Button Clicked");
            utilities.extenttest.AssignCategory("Contact Tests");
            loginMain.NavigateTo();
            loginMain.LogInSuccess();
            contactMain.AccessContactsTab();
            contactMain.SearchingContactByTelephoneNumber();
            Thread.Sleep(5000);
            IWebElement body = driver.FindElement(By.TagName("title"));
            Assert.IsTrue(body.Text.Contains("NFS"));
        }

        /* This needs to be done. NOt validating
         [Test, Category("Contact Tests")] //Filter By Equal to 
         public void EqualFilter()
         {
             utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Contact Button Clicked");
            utilities.extenttest.AssignCategory("Contact Tests");
            loginMain.NavigateTo();
            loginMain.LogInSuccess();
            contactMain.AccessContactsTab();
             contactMain.FilterByInternal();
             Thread.Sleep(2000);
             for (int i = 0; i < 9; i++)
             {
                 string id = "ctl00_MainContentPlaceHolder_usergrdList_ctl00__" + i;

                 //*[@id='ctl00_MainContentPlaceHolder_usergrdList_ctl00__0']/td[7]/div/text()
                 var xpath = string.Format(".//td[7]/div[contains(text(),'{0}')]", "No");
                 Assert.IsTrue(driver.FindElement(By.Id(id)).FindElement(By.XPath(xpath)).Displayed);
             }
         }*/
        
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
            //utilities.extent.Close();
            //this.driver.Quit();
        }


    }
}
