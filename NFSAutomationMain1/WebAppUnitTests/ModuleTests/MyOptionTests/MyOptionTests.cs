using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using RelevantCodes.ExtentReports;
using System;
using System.Configuration;
using System.Threading;
using WebApp.Login;
using WebApp.Modules.MyOptions;
using WebApp.Utilities;
using WebApp.Modules.Contacts.Contact;


namespace UnitTests.ModuleTests.MyOptionTests
{
  public  class MyOptionTests
    {
        public IWebDriver driver;
        private readonly string TextFilePath = ConfigurationManager.AppSettings["textfilepath"];
        public UtilitiesMain utilities;
        public WebAppLoginMain loginMain;
        public ContactMain contactMain;
        public MyOptionMain myoptionMain;


        protected MyOptionReferences Map
        {
            get
            {
                return new MyOptionReferences(this.driver);
            }
        }

        [OneTimeSetUp]
        public void SetupTest()
        {
            this.driver = new ChromeDriver();
            this.loginMain = new WebAppLoginMain(this.driver);
            this.utilities = new UtilitiesMain(this.driver);
            this.contactMain = new ContactMain(this.driver);
            this.myoptionMain = new MyOptionMain(this.driver);
            utilities.ReportSetup();
        }


        [Test, Category("MyOption Tests")] //Accessing My Options Page
        public void MyOptionButtonClicked()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("MyOptions Button Clicked");
            utilities.extenttest.AssignCategory("MyOption Tests");
            loginMain.NavigateTo();
            loginMain.LogInSuccess();
            myoptionMain.AccessMyoptionIcon();
            Thread.Sleep(3000);
            if (driver.FindElement(By.Id("ctl00_lblMyOption")).Displayed)
            {
                Console.WriteLine("MyOption Button Clicked");
                utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
                Assert.Pass();

            }
            else
            {
                Console.WriteLine("MyOption button was not clicked");
                Assert.Fail();

            }

        }


        /* //This is not done. Need to validate this
         [Test, Category("MyOption Tests")] //Selecting Title
         public void MyOptionsTitle()
         {
             utilities.ConsoleMessageStart();
             utilities.extenttest = utilities.extent.StartTest("MyOptions Button Clicked");
             utilities.extenttest.AssignCategory("MyOption Tests");
             loginMain.NavigateTo();
             loginMain.LogInSuccess();
             myoptionMain.AccessMyoptionIcon();
             myoptionMain.MyoptionTitle();
             myoptionMain.MyoptionSaveButton();
             Thread.Sleep(5000);
             Assert.IsTrue(myoptionMain.test1().Equals(true));  //This can also be used. 

           //  IWebElement title1 = driver.FindElement(By.XPath("//*[@id='ctl00_MainContentPlaceHolder_ddlTitle']"));
           //  string title2 = title1.GetAttribute("value");
          //   Assert.IsTrue(title2 == "ca2a56c7-1841-4f27-83a2-b005a094f42b");


            if (driver.FindElement(By.Id("ctl00_lblMyOption")).Displayed)
            {
                Console.WriteLine("MyOption Button Clicked");
                utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
                Assert.Pass();

            }
            else
            {
                Console.WriteLine("MyOption button was not clicked");
                Assert.Fail();

            }
          }*/

        [Test, Category("MyOption Tests")] //Enter First Name
        public void MyOptionsFirstName()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("MyOptions First Name");
            utilities.extenttest.AssignCategory("MyOption Tests");
            loginMain.NavigateTo();
            loginMain.LogInSuccess();
            myoptionMain.AccessMyoptionIcon();
            myoptionMain.MyoptionFirstName();
            myoptionMain.MyoptionSaveButton();
            Thread.Sleep(5000);
            IWebElement firstnametest = driver.FindElement(By.XPath("//*[@id='ctl00_MainContentPlaceHolder_txtFirstName']"));
            string firstName = firstnametest.GetAttribute("value");
          
            if (firstName == "Test4")
            {
                Console.WriteLine("First Name Updated");
                utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
                Assert.Pass();

            }
            else
            {
                Console.WriteLine("First Name not updated");
                Assert.Fail();

            }
        }

        [Test, Category("MyOption Tests")] //Enter Last Name
        public void MyOptionsLastName()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("MyOptions Last Name");
            utilities.extenttest.AssignCategory("MyOption Tests");
            loginMain.NavigateTo();
            loginMain.LogInSuccess();
            myoptionMain.AccessMyoptionIcon();
            myoptionMain.MyoptionLastName();
            myoptionMain.MyoptionSaveButton();
            Thread.Sleep(5000);
            IWebElement lastnametest = driver.FindElement(By.XPath("//*[@id='ctl00_MainContentPlaceHolder_txtLastName']"));
            string lastName = lastnametest.GetAttribute("value");          
            if (lastName == "User4")
            {
                Console.WriteLine("Last Name Updated");
                utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
                Assert.Pass();
            }
            else
            {
                Console.WriteLine("Last Name not updated");
                Assert.Fail();
            }

        }

        [Test, Category("MyOption Tests")] //Enter Display Name
        public void MyOptionsDisplayName()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("MyOptions Display Name");
            utilities.extenttest.AssignCategory("MyOption Tests");
            loginMain.NavigateTo();
            loginMain.LogInSuccess();
            myoptionMain.AccessMyoptionIcon();
            myoptionMain.MyoptionDisplayName();
            myoptionMain.MyoptionSaveButton();
            Thread.Sleep(5000);
            IWebElement displaynametest = driver.FindElement(By.XPath("//*[@id='ctl00_MainContentPlaceHolder_txtDisplayName']"));
            string displayName = displaynametest.GetAttribute("value");          
            if (displayName == "Test4 User4")
            {
                Console.WriteLine("Display Name Updated");
                utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
                Assert.Pass();

            }
            else
            {
                Console.WriteLine("Display Name not updated");
                Assert.Fail();

            }
        }

        [Test, Category("MyOption Tests")] //Diary Tree Collasped Yes
        public void MyOptionsDiaryTreeCollaspedYes()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("MyOptions Diary Tree Collasped Yes");
            utilities.extenttest.AssignCategory("MyOption Tests");
            loginMain.NavigateTo();
            loginMain.LogInSuccess();
            myoptionMain.AccessMyoptionIcon();
            myoptionMain.MyoptionDiaryTreeCollapsedYes();
            myoptionMain.MyoptionSaveButton();
            Thread.Sleep(5000);
            myoptionMain.GoToDiary();
            Thread.Sleep(3000);
            if (driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_hdnHideTree")).Displayed)
            {
                Console.WriteLine("Fail, diary Tree not collasped");
                Assert.Fail();
            }
            else
            {
                Console.WriteLine("Diary tree is collasped");
                utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
                Assert.Pass();
            }
        }


        [Test, Category("MyOption Tests")] //Diary Tree Collasped No
        public void MyOptionsDiaryTreeCollaspedNo()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("MyOptions Diary Tree Collasped No");
            utilities.extenttest.AssignCategory("MyOption Tests");
            loginMain.NavigateTo();
            loginMain.LogInSuccess();
            myoptionMain.AccessMyoptionIcon();
            myoptionMain.MyoptionDiaryTreeCollapsedNo();
            myoptionMain.MyoptionSaveButton();
            Thread.Sleep(5000);
            myoptionMain.GoToDiary();
            if (driver.FindElement(By.Id("tdLeft")).Displayed)
            {
                Console.WriteLine("Diary tree is not collasped");
                utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
                Assert.Pass();

            }
            else
            {
                Console.WriteLine("Fail, diary Tree is collasped");
                Assert.Fail();

            }
        }

        [Test, Category("MyOption Tests")] //Enter/Changing Email Address
        public void MyOptionEmail()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("MyOptions Email");
            utilities.extenttest.AssignCategory("MyOption Tests");
            loginMain.NavigateTo();
            loginMain.LogInSuccess();
            myoptionMain.AccessMyoptionIcon();
            myoptionMain.MyoptionEmail();
            myoptionMain.MyoptionSaveButton();
            IWebElement displaynametest = driver.FindElement(By.XPath("//*[@id='ctl00_MainContentPlaceHolder_txtEmail']"));
            string displayName = displaynametest.GetAttribute("value");            
            if (displayName == "Test.User4@dev.nfs03.com4")
            {
                Console.WriteLine("Email Updated");
                utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
                Assert.Pass();

            }
            else
            {
                Console.WriteLine("Email not updated");
                Assert.Fail();

            }


        }

        [Test, Category("MyOption Tests")] //Email Opt Out Yes
        public void MyOptionEmailOptOutYes()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("MyOptions Email Optput Yes");
            utilities.extenttest.AssignCategory("MyOption Tests");
            loginMain.NavigateTo();
            loginMain.LogInSuccess();
            myoptionMain.AccessMyoptionIcon();
            myoptionMain.MyoptionEmailOptOutYes();
            myoptionMain.MyoptionSaveButton();
            IWebElement displaynametest = driver.FindElement(By.XPath("//*[@id='ctl00_MainContentPlaceHolder_txtDisplayName']"));
            string displayName = displaynametest.GetAttribute("value");
           
            Thread.Sleep(3000);
            contactMain.AccessContactsTab();
            //  contact.SearchingContactFromDisplayName(displayName);
            Thread.Sleep(2000);
           // Assert.IsTrue(driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_usergrdList_ctl00_ctl04_chkEmailOptOut")).Selected);
            if (driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_usergrdList_ctl00_ctl04_chkEmailOptOut")).Selected)
            {
                Console.WriteLine("Email Opt Out selected");
                utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
                Assert.Pass();

            }
            else
            {
                Console.WriteLine("Email Opt out not selected");
                Assert.Fail();

            }
        }

        [Test, Category("MyOption Tests")] //Email Opt Out No
        public void MyOptionEmailOptOutNo()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("MyOptions Email Opt Out NO ");
            utilities.extenttest.AssignCategory("MyOption Tests");
            loginMain.NavigateTo();
            loginMain.LogInSuccess();
            myoptionMain.AccessMyoptionIcon();
            myoptionMain.MyoptionEmailOptOutNo();
            myoptionMain.MyoptionSaveButton();
            IWebElement displaynametest = driver.FindElement(By.XPath("//*[@id='ctl00_MainContentPlaceHolder_txtDisplayName']"));
            string displayName = displaynametest.GetAttribute("value");
            
            Thread.Sleep(3000);
            contactMain.AccessContactsTab();
            //contact.SearchingContactFromDisplayName(displayName);
            Thread.Sleep(2000);
            if (driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_usergrdList_ctl00_ctl04_chkEmailOptOut")).Selected)
            {
              
                Console.WriteLine("Email Opt out selected");
                Assert.Fail();

            }
            else
            {
                Console.WriteLine("Email Opt Out not selected");
                utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
                Assert.Pass();

            }
        }

        /*
        //This is not done. Need to validate this
        [Test, Category("MyOption Tests")] //Select/Change Language
        public void MyOptionLanguagePref()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("MyOptions Button Clicked");
            utilities.extenttest.AssignCategory("MyOption Tests");
            loginMain.NavigateTo();
            loginMain.LogInSuccess();
            myoptionMain.AccessMyoptionIcon();
            myoptionMain.MyoptionLangPref();
            myoptionMain.MyoptionSaveButton();
            //Thread.Sleep(2000);
            //IWebElement lang1 = driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_ddlLanguagePreferences"));
           // string lang2 = lang1.GetAttribute("value");
           // Assert.IsTrue(lang2 == "zh-SG");
            Assert.IsTrue(myoptionMain.langtest().Equals(true));
        }

        //This is not done. Need to validate this
        [Test, Category("MyOption Tests")] //Group Diary By TimeZone
        public void MyOptionGroupDiaryByTimeZone()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("MyOptions Button Clicked");
            utilities.extenttest.AssignCategory("MyOption Tests");
            loginMain.NavigateTo();
            loginMain.LogInSuccess();
            myoptionMain.AccessMyoptionIcon();
            myoptionMain.MyoptionGroupingOnDiaryTimezone();
            myoptionMain.MyoptionSaveButton();
            myoptionMain.GoToDiary();

        }

        //This is not done. Need to validate this
        [Test, Category("MyOption Tests")] //Group Diary By Property
        public void MyOptionGroupDiaryByProperty()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("MyOptions Button Clicked");
            utilities.extenttest.AssignCategory("MyOption Tests");
            loginMain.NavigateTo();
            loginMain.LogInSuccess();
            myoptionMain.AccessMyoptionIcon();
            myoptionMain.MyoptionGroupingOnDiaryProperty();
            myoptionMain.MyoptionSaveButton();
            myoptionMain.GoToDiary();

        }
        */

        [Test, Category("MyOption Tests")] //Business Hours Yes
        public void MyOptionShowBusinessHoursYes()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("MyOptions Show Business Hours Yes");
            utilities.extenttest.AssignCategory("MyOption Tests");
            loginMain.NavigateTo();
            loginMain.LogInSuccess();
            myoptionMain.AccessMyoptionIcon();
            myoptionMain.MyoptionShowBusinessHoursYes();
            myoptionMain.MyoptionSaveButton();
            Thread.Sleep(5000);
            myoptionMain.GoToDiary();
            if (driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_chbBusinessHr")).Selected)
            {
                Console.WriteLine("showing business hours");
                utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
                Assert.Pass();
            }
            else
            {
                Console.WriteLine("Not showing business hours");
                Assert.Fail();
            }
        }



        [Test, Category("MyOption Tests")] //Business Hours No 
        public void MyOptionShowBusinessHoursNo()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("MyOptions Show business hour NO");
            utilities.extenttest.AssignCategory("MyOption Tests");
            loginMain.NavigateTo();
            loginMain.LogInSuccess();
            myoptionMain.AccessMyoptionIcon();
            myoptionMain.MyoptionShowBusinessHoursNo();
            myoptionMain.MyoptionSaveButton();
            Thread.Sleep(5000);
            myoptionMain.GoToDiary();
            Assert.IsFalse(driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_chbBusinessHr")).Selected);
            if (driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_chbBusinessHr")).Selected)
            {
               
                utilities.extenttest.Log(LogStatus.Fail, "Assert Fail ");
                Assert.Fail();
            }
            else
            {
                Console.WriteLine("Business Hours not selected");
                Assert.Pass();
            }
        }

        [Test, Category("MyOption Tests")] //Saving all details
        public void MyOptionSavingAllDetails()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("MyOptions Save Button");
            utilities.extenttest.AssignCategory("MyOption Tests");
            loginMain.NavigateTo();
            loginMain.LogInSuccess();
            myoptionMain.AccessMyoptionIcon();
            myoptionMain.MyoptionTitle();
            myoptionMain.MyoptionFirstName();
            myoptionMain.MyoptionLastName();
            myoptionMain.MyoptionDisplayName();
            myoptionMain.MyoptionDiaryTreeCollapsedYes();
            myoptionMain.MyoptionEmail();
            myoptionMain.MyoptionEmailOptOutNo();
            myoptionMain.MyoptionLangPref();
            myoptionMain.MyoptionPrimaryProperty();
            myoptionMain.MyoptionGroupingOnDiaryProperty();
            myoptionMain.MyoptionShowBusinessHoursNo();
            myoptionMain.MyoptionSaveButton();          
            if (driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_lblSuccessMessage")).Displayed)
            {
                Console.WriteLine("All details saved");
                utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
                Assert.Pass();

            }
            else
            {
                Console.WriteLine("Details not updated");
                Assert.Fail();

            }
        }

        [Test, Category("MyOption Tests")] //Saving all details
        public void MyOptionCancelButtonClicked()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("MyOptions Cancel Button");
            utilities.extenttest.AssignCategory("MyOption Tests");
            loginMain.NavigateTo();
            loginMain.LogInSuccess();
            myoptionMain.AccessMyoptionIcon();
            myoptionMain.MyoptionCancelButton();
            
            if (driver.FindElement(By.Id("tblMain")).Displayed) 
            {
                Console.WriteLine("Cancelled button clicked");
                utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
                Assert.Pass();

            }
            else
            {
                Console.WriteLine("Cancel button not clicked");
                Assert.Fail();

            }

        }

        [Test, Category("MyOption Tests")] //Saving without mandatory fields
        public void MyOptionSavingWithoutEmail()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("MyOptions Saving without email");
            utilities.extenttest.AssignCategory("MyOption Tests");
            loginMain.NavigateTo();
            loginMain.LogInSuccess();
            myoptionMain.AccessMyoptionIcon();
            myoptionMain.MyoptionsSavingWithoutEmail();
            myoptionMain.MyoptionSaveButton();
            Thread.Sleep(2000);
            IWebElement body = driver.FindElement(By.TagName("body"));           
            if (body.Text.Contains("Enter Email"))
            {
                Console.WriteLine("Email Validation Pass");
                utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
                Assert.Pass();

            }
            else
            {
                Console.WriteLine("Email validation failed");
                Assert.Fail();

            }

        }

        [Test, Category("MyOption Tests")] //Saving without FirstName fields
        public void MyOptionSavingWithoutFirstName()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("MyOptions Saving Without first Name");
            utilities.extenttest.AssignCategory("MyOption Tests");
            loginMain.NavigateTo();
            loginMain.LogInSuccess();
            myoptionMain.AccessMyoptionIcon();
            myoptionMain.MyoptionsSavingWithoutFirstName();
            myoptionMain.MyoptionSaveButton();
            Thread.Sleep(2000);
            IWebElement body = driver.FindElement(By.TagName("body"));           
            if (body.Text.Contains("Please enter first name."))
            {
                Console.WriteLine("First Name Validation Passed");
                utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
                Assert.Pass();
            }
            else
            {
                Console.WriteLine("First Name validation failed");
                Assert.Fail();
            }

        }

        [Test, Category("MyOption Tests")] //Saving without LastName fields
        public void MyOptionSavingWithoutLastName()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("MyOptions Saving Without last Name");
            utilities.extenttest.AssignCategory("MyOption Tests");
            loginMain.NavigateTo();
            loginMain.LogInSuccess();
            myoptionMain.AccessMyoptionIcon();
            myoptionMain.MyoptionsSavingWithoutLastName();
            myoptionMain.MyoptionSaveButton();
            Thread.Sleep(2000);
            IWebElement body = driver.FindElement(By.TagName("body"));
           
            if (body.Text.Contains("Please enter last name."))
            {
                Console.WriteLine("Last Name Validation Passed");
                utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
                Assert.Pass();
            }
            else
            {
                Console.WriteLine("Last Name validation failed");
                Assert.Fail();
            }

        }

        [Test, Category("MyOption Tests")] //Saving without DisplayName fields
        public void MyOptionSavingWithoutDisplayName()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("MyOptions Saving Without Display Name");
            utilities.extenttest.AssignCategory("MyOption Tests");
            loginMain.NavigateTo();
            loginMain.LogInSuccess();
            myoptionMain.AccessMyoptionIcon();
            myoptionMain.MyoptionsSavingWithoutDisplayName();
            myoptionMain.MyoptionSaveButton();
            Thread.Sleep(2000);
            IWebElement body = driver.FindElement(By.TagName("body"));
           
            if (body.Text.Contains("Please enter display name."))
            {
                Console.WriteLine("Display Name Validation Passed");
                utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
                Assert.Pass();
            }
            else
            {
                Console.WriteLine("Display Name validation failed");
                Assert.Fail();
            }
        }




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
