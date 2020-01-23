using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using QuickBook;
using QuickBook.MyProfile;
using QuickBook.Login;
using QuickBook.Utilities;
using System.Configuration;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using RelevantCodes.ExtentReports;


namespace UnitTests
{
    [TestFixture]
    public class MyProfileTest
    {
        public IWebDriver driver;
        private readonly string TextFilePath = ConfigurationManager.AppSettings["textfilepath"];
        public MyProfile myprof;
        public LoginMain login;
        public UtilitiesMain utilities;



        protected MyProfile_Validators MyProfileMap
        {
            get
            {
                return new MyProfile_Validators(this.driver);
            }
        }



        [OneTimeSetUp]
        public void SetupTest()
        {
            this.driver = new ChromeDriver();
            this.login = new LoginMain(this.driver);
            this.myprof = new MyProfile(this.driver);
            this.utilities = new UtilitiesMain(this.driver);
            utilities.ReportSetup();
        }


        [Test, Category("MyProfileTests")]
        public void MyProfile_UserNameCheck()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("My Profile Username Check");
            utilities.extenttest.AssignCategory("My Profile Tests");
            login.NavigateTo();
            login.LoginSuccess();
            Assert.IsTrue(this.MyProfileMap.UserNameValidator.Text.Equals(this.MyProfileMap.UserNameLinkValidator.Text));
            utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
        }

        [Test, Category("MyProfileTests")]
        public void MyProfile_CancelButton()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("My Profile Cancel Button");
            utilities.extenttest.AssignCategory("My Profile Tests");
            login.NavigateTo();
            login.LoginSuccess();
            myprof.ClickCancel();
            Assert.IsTrue(this.MyProfileMap.CancelValidator.Displayed);
            utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
        }

        [Test, Category("MyProfileTests")]
        public void MyProfile_SaveButton()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("My Profile Save Button");
            utilities.extenttest.AssignCategory("My Profile Tests");
            login.NavigateTo();
            login.LoginSuccess();
            myprof.ClickSave();
            Assert.IsTrue(this.MyProfileMap.SaveValidator.Displayed);
            utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
        }

        [Test, Category("MyProfileTests")]
        public void MyProfile_PrimaryProperyCancel()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Primary Property Cancel");
            utilities.extenttest.AssignCategory("My Profile Tests");
            login.NavigateTo();
            login.LoginSuccess();
            myprof.PrimaryPropertyChange();
            string originalPrimaryProperty = myprof.oldPrimaryProperty;
            myprof.ClickCancel();
            Thread.Sleep(3000);
            myprof.NavigateToNoLogin();
            Assert.IsTrue(originalPrimaryProperty.Equals(this.MyProfileMap.PrimaryPropertyDropDownValidator));
            utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
        }

        [Test, Category("MyProfileTests")]
        public void MyProfile_PrimaryPropertySave()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Primary Primary Save");
            utilities.extenttest.AssignCategory("My Profile Tests");
            login.NavigateTo();
            login.LoginSuccess();
            myprof.PrimaryPropertyChange();
            myprof.ClickSaveOk();
            Thread.Sleep(3000);
            myprof.MyProfileLogout();
            login.NavigateTo();
            login.LoginSuccess();
            Assert.IsTrue(myprof.newPrimaryProperty.Equals(this.MyProfileMap.PrimaryPropertyDropDownValidator));
            utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
        }

        [Test, Category("MyProfileTests")]
        public void MyProfile_LanguagePreferenceCancel()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Language Preference Cancel");
            utilities.extenttest.AssignCategory("My Profile Tests");
            login.NavigateTo();
            login.LoginSuccess();
            myprof.LanguagePreferenceChange();
            string originalLanguagePreference = myprof.oldLanguagePreference;
            myprof.ClickCancel();
            Thread.Sleep(3000);
            myprof.NavigateToNoLogin();
            Assert.IsTrue(originalLanguagePreference.Equals(this.MyProfileMap.LangaugePreferenceDropDownValidator));
            utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
        }

        [Test, Category("MyProfileTests")]
        public void MyProfile_LanguagePreferenceSave()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Language Preference Save");
            utilities.extenttest.AssignCategory("My Profile Tests");
            login.NavigateTo();
            login.LoginSuccess();
            myprof.LanguagePreferenceChange();
            myprof.ClickSaveOk();
            Thread.Sleep(3000);
            myprof.MyProfileLogout();
            login.NavigateTo();
            login.LoginSuccess();
            Console.WriteLine("NEW" + " " + myprof.newLanguagePreference);
            Console.WriteLine("CURRENT" + " " + this.MyProfileMap.LangaugePreferenceDropDownValidator);
            Assert.IsTrue(myprof.newLanguagePreference.Equals(this.MyProfileMap.LangaugePreferenceDropDownValidator));
            utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
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
