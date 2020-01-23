using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using QuickBook;
using QuickBook.Login;
using QuickBook.Homepage;
using QuickBook.Attendees;
using QuickBook.Utilities;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using RelevantCodes.ExtentReports;
using System.IO;
using System.Diagnostics;
using System.Configuration;


namespace UnitTests
{

    [TestFixture]
    public class AttendeesTest
    {
        public IWebDriver driver;
        public LoginMain login;
        public HomepageMain homepage;
        public AttendeesMain attendees;
        public UtilitiesMain utilities;
    
        private readonly string TextFilePath = ConfigurationManager.AppSettings["textfilepath"];
        private readonly string ExternalVisitorEditedName = ConfigurationManager.AppSettings["externalvisitoreditedname"];
        private readonly string ExternalVisitorEditedLastName = ConfigurationManager.AppSettings["externalvisitoreditedlastname"];
        private readonly string ExtenalVisitorEditedEmail = ConfigurationManager.AppSettings["externalvisitoreditedemail"];
        private readonly string ExternalVisitorEditedCompany = ConfigurationManager.AppSettings["externalvisitoreditedcompany"];


        protected AttendeesReferences Map
        {
            get
            {
                return new AttendeesReferences(this.driver);
            }
        }

        [OneTimeSetUp]
        public void SetupTest()
        {
            this.driver = new ChromeDriver();
            this.login = new LoginMain(this.driver);
            this.homepage = new HomepageMain(this.driver);
            this.attendees = new AttendeesMain(this.driver);
            this.utilities = new UtilitiesMain(this.driver);
            this.utilities = new UtilitiesMain(this.driver);
            utilities.ReportSetup();
        }

        [Test, Category("Attendees Test")]
        public void AddInternalAttendee()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Add Internal Attendee");
            utilities.extenttest.AssignCategory("Attendees Tests");
            login.NavigateTo();
            login.LoginSuccess();
            Thread.Sleep(4000);
            homepage.SelectResource();
            attendees.InternalAttendeeSearchbox();
            Thread.Sleep(3000);
            var searchedattendee = this.Map.SearchedAttendee.Text;
            Console.WriteLine("Searched Attendee: " + searchedattendee);
            string beforetext = searchedattendee.Substring(0, searchedattendee.IndexOf(","));
            Console.WriteLine("Short Text: " + beforetext);
            attendees.InternalAttendeeSelector();
            Thread.Sleep(2000);
            Thread.Sleep(10000);
            var selectedattendee1 = this.Map.SelectedInternalAttendee.Text;
            Console.WriteLine("Selected Attendees: " + selectedattendee1);

            if (selectedattendee1.Contains(beforetext))
            {
                Console.WriteLine("Pass");
                utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
            }
            else
            {
                Console.WriteLine("Test Fail because Attendee selected and attendee searched doesn't match");
                Assert.Fail();
            }
        }


        [Test, Category("Attendees Test")]
        public void AddExternalAttendee()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Add External Attendee");
            utilities.extenttest.AssignCategory("Attendees Tests");
            login.NavigateTo();
            login.LoginSuccess();
            Thread.Sleep(4000);
            homepage.SelectResource();
            Thread.Sleep(4000);
            attendees.AddingExternalAttendee();
            Thread.Sleep(2000);
            var ExternalAttendeelastname = this.Map.ExternalAttendeeLastName.GetAttribute("value");
            var ExternalAttendeefirstname = this.Map.ExternalAttendeeFirstName.GetAttribute("value");
            attendees.ExternalAttendeeAddButton();
            var addfirstnameAndlastname = ExternalAttendeelastname + ", " + ExternalAttendeefirstname;
            Console.WriteLine(addfirstnameAndlastname);
            Thread.Sleep(2000);
            var selectedNamecheck = this.driver.FindElement(By.Id("extAttendeePanel")).Text;
            Console.WriteLine(selectedNamecheck);
            if (selectedNamecheck.Contains(addfirstnameAndlastname))
            {
                Console.WriteLine("PASS");
                utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
            }
            else
            {
                Console.WriteLine("Test Failed because Attendee added does not appear in the list.");
                Assert.Fail();
            }

        }

        /*   Ignore. Just to test some functionality. 
         * 
         * 
         * [TestCategory("AttendeesTest")]
           [TestMethod]
           public void attendeesTest1()
           {
               utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Register_IncorrectEmailFormat");
            utilities.extenttest.AssignCategory("Attendees Tests");
               login.NavigateTo();
               login.LoginSuccess();
               Thread.Sleep(4000);
               homepage.SelectResource();
               Thread.Sleep(4000);
               attendees.InternalAttendeeSearchbox();
               attendees.InternalAttendeeSelector();
                
               Thread.Sleep(5000);
               attendees.AddingExternalAttendee();
               Thread.Sleep(2000);
               attendees.ExternalAttendeeAddButton();
               Thread.Sleep(2000);
            //   var peopletable = this.driver.FindElement(By.XPath("//*[@id='tblAttendees']"));
             //  var peopletable = this.driver.FindElement(By.ClassName("wid25 disp-inl line-break")).Text;
              // var peopletable = this.driver.FindElement(By.Id("tblPersonList")).Text;

                

               IList<IWebElement> Table1 = new IList<IWebElement>(peopletable.FindElement(By.TagName("tr")));

              List<IWebElement> t1 = new List<IWebElement>(peopletable.FindElement(By.TagName("tr")));
               String strRowData = "";

               foreach (var Etr in t1)
               {
                   List<IWebElement> t2 = new List<IWebElement>(Etr.FindElement(By.TagName("td")));
                   if (t2.Count > 0)
                   {
                       foreach (var Etd in t2)
                       {
                           strRowData = strRowData + Etd.Text + "\t\t";
                       }
                   }
                   else
                   {
                       Console.WriteLine("Header Row");
                       Console.WriteLine(t1[0].Text.Replace(" ", "\t\t"));
                   }
                   Console.WriteLine(strRowData);
                   strRowData = String.Empty;
               }
               Console.WriteLine("");  

                
            //   Console.WriteLine(peopletable);
           } */


        [Test, Category("Attendees Test")]
        public void ChangeExternalAttendeeRole()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Change External Attendee Role");
            utilities.extenttest.AssignCategory("Attendees Tests");
            login.NavigateTo();
            login.LoginSuccess();
            Thread.Sleep(4000);
            homepage.SelectResource();
            Thread.Sleep(4000);
            attendees.AddingExternalAttendee();
            Thread.Sleep(2000);
            attendees.ExternalAttendeeAddButton();
            Thread.Sleep(2000);
            // var selectrole = new SelectElement(this.driver.FindElement(By.XPath("//*[@id='extenalAttendeeList_1__BookingRoleId']")));
            // string getrole = selectrole.SelectedOption.Text;
            Thread.Sleep(2000);
            attendees.externalAttendeerole();
            Thread.Sleep(2000);
            Console.WriteLine("Previous Role: " + attendees.previousRole);
            Thread.Sleep(2000);
            //  var selectedRole = new SelectElement(this.driver.FindElement(By.XPath("//*[@id='extenalAttendeeList_1__BookingRoleId']")));
            // string getRole2 = selectedRole.SelectedOption.Text;
            Console.WriteLine("Current Role: " + attendees.ChangedRole);
            // Assert.IsTrue(getrole != getRole2);
            // if (getrole == getRole2)
            Thread.Sleep(2000);
            if (attendees.previousRole == attendees.ChangedRole)
            {
                Console.WriteLine("Test Failed Because Participant role was not changed.");

                Assert.Fail();
            }
            else
            {
                Console.WriteLine("Test Pass, Role Changed");
                utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
            }

        }

        [Test, Category("Attendees Test")]
        public void ChangeInternalAttendeeRole()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Change Internal Attendee Role");
            utilities.extenttest.AssignCategory("Attendees Tests");
            login.NavigateTo();
            login.LoginSuccess();
            Thread.Sleep(4000);
            homepage.SelectResource();
            Thread.Sleep(2000);
            attendees.AddingInternalAttendee();
            Thread.Sleep(2000);
            attendees.InternalAttendeeRole();
            Thread.Sleep(2000);
            Console.WriteLine("Previous Role: " + attendees.InternalAttendeePreviousRole);
            Console.WriteLine("Current Role: " + attendees.InternalAttendeeChangedRole);
            Thread.Sleep(2000);
            if (attendees.InternalAttendeePreviousRole == attendees.InternalAttendeeChangedRole)
            {
                Console.WriteLine("Test Failed Because Participant role was not changed.");
                Assert.Fail();

            }
            else
            {
                Console.WriteLine("Test Pass, Role Changed");
                utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");

            }


            // test.Log(LogStatus.Pass, "Booking has been copied successfully"); 

        }

        public string Internalrole = "Host";
        [Test, Category("Attendees Test")]
        public void ChangeAppointmentOrganiser()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Change Appointment Organiser");
            utilities.extenttest.AssignCategory("Attendees Tests");
            login.NavigateTo();
            login.LoginSuccess();
            Thread.Sleep(8000);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(4000);
            homepage.SelectResource();
            Thread.Sleep(2000);
            attendees.AddingInternalAttendee();
            Thread.Sleep(2000);
            attendees.InternalAttendeeRole();
            Thread.Sleep(2000);
            var rolecheck = new SelectElement(this.Map.InternalAttendeeRole);
            string Internalrolecheck = rolecheck.SelectedOption.Text;
            if (Internalrolecheck.Equals(Internalrole))
            {
                attendees.appointmentorganiser();
            }
            else
            {
                Console.WriteLine("User not host");
                Assert.Fail();

            }
            Thread.Sleep(10000);

            //  Assert.IsTrue((this.Map.AppointmentOrganiser).Selected);

            Assert.IsTrue(this.driver.FindElement(By.XPath("//*[@id='rowIA_2']/td[6]/label/input")).Selected);
            utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");

        }

        [Test, Category("Attendees Test")]
        public void RemovingInternalAttendee()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Removing Internal Attendee");
            utilities.extenttest.AssignCategory("Attendees Tests");
            login.NavigateTo();
            login.LoginSuccess();
            Thread.Sleep(4000);
            homepage.SelectResource();
            attendees.InternalAttendeeSearchbox();
            Thread.Sleep(3000);
            var searchedattendee2 = this.Map.SearchedAttendee.Text;
            Console.WriteLine("Searched Attendee: " + searchedattendee2);
            string beforetext = searchedattendee2.Substring(0, searchedattendee2.IndexOf(","));
            Console.WriteLine("Short Text: " + beforetext);
            attendees.InternalAttendeeSelector();
            Thread.Sleep(2000);
            attendees.RemovingInternalAttendee();
            Thread.Sleep(2000);
            var selectedattendee2 = this.Map.SelectedInternalAttendee.Text;
            // Console.WriteLine("Selected Attendees: " + selectedattendee2);

            if (selectedattendee2.Contains(beforetext))
            {
                Console.WriteLine("Fail");
                Assert.Fail();
            }
            else
            {
                Console.WriteLine("Pass");
                utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
            }
        }

        [Test, Category("Attendees Test")]
        public void RemovingExternalAttendee()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Removing External Attendee");
            utilities.extenttest.AssignCategory("Attendees Tests");
            login.NavigateTo();
            login.LoginSuccess();
            Thread.Sleep(4000);
            homepage.SelectResource();
            Thread.Sleep(4000);
            attendees.AddingExternalAttendee();
            Thread.Sleep(2000);
            var ExternalAttendeelastname2 = this.Map.ExternalAttendeeLastName.GetAttribute("value");
            var ExternalAttendeefirstname2 = this.Map.ExternalAttendeeFirstName.GetAttribute("value");
            attendees.ExternalAttendeeAddButton();
            var addfirstnameAndlastname2 = ExternalAttendeelastname2 + ", " + ExternalAttendeefirstname2;
            Console.WriteLine(addfirstnameAndlastname2);
            Thread.Sleep(2000);
            attendees.RemovingExternalAttendee();
            Thread.Sleep(20000);
            var selectedNamecheck2 = this.driver.FindElement(By.Id("extAttendeePanel")).Text;
            // Console.WriteLine("Selectednamecheck2:" + selectedNamecheck2);
            if (selectedNamecheck2.Contains(addfirstnameAndlastname2))
            {
                Console.WriteLine("Fail");
                Assert.Fail();
            }
            else
            {
                Console.WriteLine("Pass");
                utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
            }
        }


        [Test, Category("Attendees Test")]
        public void EditExternalAttendeeFirstName()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Edit External Attendee First Name");
            utilities.extenttest.AssignCategory("Attendees Tests");
            login.NavigateTo();
            login.LoginSuccess();
            Thread.Sleep(4000);
            homepage.SelectResource();
            Thread.Sleep(4000);
            attendees.AddingExternalAttendee();
            attendees.ExternalAttendeeAddButton();
            Thread.Sleep(2000);
            attendees.ExternalAttendeeEditButton();
            attendees.ExternalAttendeeEditFirstName();
            attendees.ExternalAttendeeEditUpdateButton();
            var updatedFirstName = this.driver.FindElement(By.XPath("//*[@id='rowEA_1']/td[1]/div/span/span[2]")).Text;
            Console.WriteLine("Updated First Name: " + updatedFirstName);
            if (updatedFirstName == ExternalVisitorEditedName)
            {

                Console.WriteLine("Pass, First name updated");
                utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
            }
            else
            {
                Console.WriteLine("Fail, Because updated first name doesn't match the details entered earlier.");
                Assert.Fail();

            }

        }


        [Test, Category("Attendees Test")]
        public void EditExternalAttendeeLastName()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Edit External Attendee Last Name");
            utilities.extenttest.AssignCategory("Attendees Tests");
            login.NavigateTo();
            login.LoginSuccess();
            Thread.Sleep(4000);
            homepage.SelectResource();
            Thread.Sleep(4000);
            attendees.AddingExternalAttendee();
            attendees.ExternalAttendeeAddButton();
            Thread.Sleep(2000);
            attendees.ExternalAttendeeEditButton();
            // attendees.ExternalAttendeeEditFirstName();
            attendees.ExternalAttendeeEditLastName();

            attendees.ExternalAttendeeEditUpdateButton();
            var updatedLastName = this.driver.FindElement(By.XPath("//*[@id='rowEA_1']/td[1]/div/span/span[1]")).Text;
            Console.WriteLine("Updated Last Name: " + updatedLastName);

            string LastName = updatedLastName.Substring(0, updatedLastName.IndexOf(","));
            Console.WriteLine(LastName);
            if (LastName == ExternalVisitorEditedLastName)
            {
                Console.WriteLine("Pass, Last name updated");
                utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
            }
            else
            {
                Console.WriteLine("Fail, Because updated last name doesn't match the details entered earlier.");
                Assert.Fail();
            }

        }


        [Test, Category("Attendees Test")]
        public void EditExternalAttendeeEmail()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Edit External Attendee Email");
            utilities.extenttest.AssignCategory("Attendees Tests");
            login.NavigateTo();
            login.LoginSuccess();
            Thread.Sleep(4000);
            homepage.SelectResource();
            Thread.Sleep(4000);
            attendees.AddingExternalAttendee();
            attendees.ExternalAttendeeAddButton();
            Thread.Sleep(2000);
            attendees.ExternalAttendeeEditButton();
            attendees.ExternalAttendeeEditEmail();
            attendees.ExternalAttendeeEditUpdateButton();
            var updatedEmail = this.driver.FindElement(By.XPath("//*[@id='rowEA_1']/td[2]/div/span")).Text;
            Console.WriteLine("Updated Email: " + updatedEmail);
            if (updatedEmail == ExtenalVisitorEditedEmail)
            {
                Console.WriteLine("Pass, Email updated");
                utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
            }
            else
            {
                Console.WriteLine("Fail, Because updated Email doesn't match the details entered earlier.");
                Assert.Fail();
            }

        }


        [Test, Category("Attendees Test")]
        public void EditExternalAttendeeCompany()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Edit External Attendee Company");
            utilities.extenttest.AssignCategory("Attendees Tests");
            login.NavigateTo();
            login.LoginSuccess();
            Thread.Sleep(4000);
            homepage.SelectResource();
            Thread.Sleep(4000);
            attendees.AddingExternalAttendee();
            attendees.ExternalAttendeeAddButton();
            Thread.Sleep(2000);
            attendees.ExternalAttendeeEditButton();
            attendees.ExternalAttendeeEditCompany();
            attendees.ExternalAttendeeEditUpdateButton();
            var updatedCompany = this.driver.FindElement(By.XPath("//*[@id='rowEA_1']/td[5]/span")).GetAttribute("title");
            Console.WriteLine("Updated Company: " + updatedCompany);
            if (updatedCompany == ExternalVisitorEditedCompany)
            {
                Console.WriteLine("Pass, Company updated");
                utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
            }
            else
            {
                Console.WriteLine("Fail, Because updated Company doesn't match the details entered earlier.");
                Assert.Fail();
            }
        }


        [Test, Category("Attendees Test")]
        public void CancelEditedExternalAttendeeDetails()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Cancel Edited External Attendee Details");
            utilities.extenttest.AssignCategory("Attendees Tests");
            login.NavigateTo();
            login.LoginSuccess();
            Thread.Sleep(4000);
            homepage.SelectResource();
            Thread.Sleep(4000);
            attendees.AddingExternalAttendee();
            attendees.ExternalAttendeeAddButton();
            Thread.Sleep(2000);
            var GettingExternalAttendeeDetialsBefore = this.Map.Externalattendee.Text;
            Console.WriteLine("External Attendee Details : " + GettingExternalAttendeeDetialsBefore);
            attendees.ExternalAttendeeEditButton();
            attendees.ExternalAttendeeEditFirstName();
            attendees.ExternalAttendeeEditLastName();
            attendees.ExternalAttendeeEditEmail();
            attendees.ExternalAttendeeEditCompany();
            attendees.ExternalAttendeeEditCancelButton();
            var GettingExternalAttendeeDetialsAfter = this.Map.Externalattendee.Text;
            Console.WriteLine("External Attendee Details After : " + GettingExternalAttendeeDetialsAfter);
            if (GettingExternalAttendeeDetialsBefore == GettingExternalAttendeeDetialsAfter)
            {
                Console.WriteLine("Pass, Details not updated");
                utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
            }
            else
            {
                Console.WriteLine("Failed to Cancel the edited detials.");
                Assert.Fail();
            }
        }
        [TearDown]
        public void Result()
        {
            utilities.GetResult();
        }


        [OneTimeTearDown]
        public void TestTearDown()
        {
            utilities.extent.Flush();
            // extent.Close();
            this.driver.Quit();
        }

    }

}


