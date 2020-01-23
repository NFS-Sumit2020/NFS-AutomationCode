using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using QuickBook;
using QuickBook.Account;
using QuickBook.Login;
using QuickBook.Utilities;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using RelevantCodes.ExtentReports;
using System.IO;
using System.Diagnostics;



namespace UnitTests
{
    [TestFixture]
    public class AccountTests
    {
        public IWebDriver driver;
        private readonly string TextFilePath = ConfigurationManager.AppSettings["textfilepath"];
        public LoginMain login;
        public Register register;
        public ForgotPassword forgotpass;
        public UtilitiesMain utilities;
       
       

        //Get Validators
        protected Register_Validators RegisterValidatorsMap        // protected Register_Validators RegisterValidatorsMap
        {
            get
            {
                return new Register_Validators(this.driver);
            }
        }
        protected ForgotPassword_Validators ForgotPasswordValidatorsMap
        {
            get
            {
                return new ForgotPassword_Validators(this.driver);
            }
        }

        protected ForgotPassword_References ForgotPasswordReferences
        {
            get
            {
                return new ForgotPassword_References(this.driver);
            }
        }

        [OneTimeSetUp]
        public void TestSetUp()
        {
            this.driver = new ChromeDriver();
            this.login = new LoginMain(this.driver);
            this.register = new Register(this.driver);
            this.forgotpass = new ForgotPassword(this.driver);
            this.utilities = new UtilitiesMain(this.driver);
            utilities.ReportSetup();

        }

        [Test, Category("GG_Register")]
        public void Register_NoInformation()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Register No Information");
            utilities.extenttest.AssignCategory("AccountTests");
            login.NavigateTo();
            register.RegisterLink();
            register.RegisterClick();
            Assert.IsTrue(this.RegisterValidatorsMap.NoEmailValidator.Displayed && this.RegisterValidatorsMap.NoPasswordValidator.Displayed && this.RegisterValidatorsMap.NoConfirmPasswordValidator.Displayed);
            utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
        }
        [Test, Category("GG_Register")]
        public void Register_IncorrectEmailFormat()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Register_IncorrectEmailFormat");
            utilities.extenttest.AssignCategory("AccountTests");
            login.NavigateTo();
            register.RegisterLink();
            register.EmailFormat();
            register.RegisterClick();
            Assert.IsTrue(this.RegisterValidatorsMap.NoEmailValidator.Displayed);
            utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
        }
        [Test, Category("GG_Register")]
        public void Register_PasswordMismatch()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Register_PasswordMismatch");
            utilities.extenttest.AssignCategory("AccountTests");
            login.NavigateTo();
            register.RegisterLink();
            register.PasswordMismatch();
            register.RegisterClick();
            Assert.IsTrue(this.RegisterValidatorsMap.PasswordMatchValidator.Text.Equals("'Confirm Password' and 'Password' do not match."));
            utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
        }
        [Test, Category("GG_Register")]
        public void Register_PasswordComplexityFail()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Register_PasswordComplexityFail");
            utilities.extenttest.AssignCategory("AccountTests");
            login.NavigateTo();
            register.RegisterLink();
            register.PasswordComplexity();
            register.RegisterClick();
            Assert.IsTrue(this.RegisterValidatorsMap.PasswordComplexityValidator.Displayed);
            utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
        }
        [Test, Category("GG_Register")]
        public void Register_CorporateEmailMismatch()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Register_CorporateEmailMismatch");
            utilities.extenttest.AssignCategory("AccountTests");
            login.NavigateTo();
            register.RegisterLink();
            register.CorporateEmailMismatch();
            register.RegisterClick();
            Assert.IsTrue(this.RegisterValidatorsMap.CorporateEmailFailValidator.Displayed);
            utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
        }
        [Test, Category("GG_Register")]
        public void Register_UnregisteredEmail()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Register_UnregisteredEmail");
            utilities.extenttest.AssignCategory("AccountTests");
            login.NavigateTo();
            register.RegisterLink();
            register.UnregisteredCorporateEmail();
            register.RegisterClick();
            //NEEDS VALIDATION
            utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
        }
        [Test, Category("GG_Register")]
        public void Register_RegisteredEmail()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Register_RegisteredEmail");
            utilities.extenttest.AssignCategory("AccountTests");
            login.NavigateTo();
            register.RegisterLink();
            register.RegisteredCorporateEmail();
            register.RegisterClick();
            //NEEDS VALIDATION
            utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
        }
        [Test, Category("GG_Register")]
        public void Register_RegisterLoginLink()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Register_RegisterLoginLink");
            utilities.extenttest.AssignCategory("AccountTests");
            login.NavigateTo();
            register.RegisterLink();
            register.LoginLink();
            Assert.IsTrue(this.RegisterValidatorsMap.LoginButton.Displayed);
            utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
        }
        //=============SPLIT==============//
        [Test, Category("GG_ForgotPassword")]
        public void ForgotPassword_LoginLink()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("ForgotPassword_LoginLink");
            utilities.extenttest.AssignCategory("AccountTests");
            login.NavigateTo();
            login.ForgotPasswordLink();
            forgotpass.LoginLinkClick();
            Assert.IsTrue(this.ForgotPasswordValidatorsMap.LoginButtonValidator.Displayed);
            utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
        }
        [Test, Category("GG_ForgotPassword")]
        public void ForgotPassword_NoInformation()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("ForgotPassword_NoInformation");
            utilities.extenttest.AssignCategory("AccountTests");
            login.NavigateTo();
            login.ForgotPasswordLink();
            forgotpass.ForgotPasswordClick();
            Assert.IsTrue(this.ForgotPasswordValidatorsMap.NoEmailValidator.Text.Contains("Please enter corporate email") && this.ForgotPasswordValidatorsMap.NoUserNameValidator.Displayed);
            utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
        }
        [Test, Category("GG_ForgotPassword")]
        public void ForgotPassword_EmailFormat()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("ForgotPassword_EmailFormat");
            utilities.extenttest.AssignCategory("AccountTests");
            login.NavigateTo();
            forgotpass.EmailFormat();
            this.ForgotPasswordReferences.EmailTestBox.SendKeys(Keys.Tab);
            Assert.IsTrue(this.ForgotPasswordValidatorsMap.EmailFormatValidator.Text.Contains("Invalid Email Address"));
            utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
        }
        [Test, Category("GG_ForgotPassword")]
        public void ForgotPassword_InformationMismatch()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("ForgotPassword_InformationMismatch");
            utilities.extenttest.AssignCategory("AccountTests");
            login.NavigateTo();
            forgotpass.InformationMismatch();
            forgotpass.ForgotPasswordClick();
            Assert.IsTrue(this.ForgotPasswordValidatorsMap.InformationMismatchValidator.Displayed);
            utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
        }
        [Test, Category("GG_ForgotPassword")]
        public void ForgotPassword_InformationMatch()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("ForgotPassword_InformationMatch");
            utilities.extenttest.AssignCategory("AccountTests");
            login.NavigateTo();
            forgotpass.InformationMatch();
            forgotpass.ForgotPasswordClick();
            // Assert.IsTrue(this.ForgotPasswordValidatorsMap.InformationMatchValidator.Displayed);
            //NEEDS VALIDATING
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
