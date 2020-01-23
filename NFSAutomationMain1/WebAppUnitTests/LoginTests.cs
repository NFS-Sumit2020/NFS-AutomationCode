using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebApp.Login;
using System.Threading;
using WebApp.Utilities;
using RelevantCodes.ExtentReports;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System;


namespace UnitTests
{
    [TestFixture]
    public class LoginTests
    {
        public IWebDriver driver;
        private readonly string TextFilePath = ConfigurationManager.AppSettings["textfilepath"];
        public UtilitiesMain utilities;
        public WebAppLoginMain loginMain;

        [OneTimeSetUp]
        public void SetupTest()
        {
            this.driver = new ChromeDriver();
            this.loginMain = new WebAppLoginMain(this.driver);
            this.utilities = new UtilitiesMain(this.driver);
            utilities.ReportSetup();
        }

        //=====ALL LOGIN TESTS=====
        [Test, Category("LogIn")]
        //Login to Workspace successfully
        public void LogInSuccess()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Login Success");
            utilities.extenttest.AssignCategory("Login Tests");
            loginMain.NavigateTo();
            loginMain.LogInSuccess();
            Thread.Sleep(2000);
            if (driver.FindElement(By.Id("divScheduleMaingPage")).Displayed)
            {
                Console.WriteLine("Login Success");
                utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
                Assert.Pass();
                
            }
            else
            {
                Console.WriteLine("Login Failed");
                Assert.Fail();
                
            }
        }

        [Test, Category("LogIn")]
        //unsuccessful login
        public void LogInUserNameFail()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Login Username Fail");
            utilities.extenttest.AssignCategory("Login Tests");
            loginMain.NavigateTo();
            loginMain.LogInUserNameFail();
            IWebElement body = driver.FindElement(By.TagName("body"));
            if(body.Text.Contains("Your login attempt was not successful. Please try again."))
            {
                Console.WriteLine("Login attempt was unsuccessful.");
                utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
                Assert.Pass();
            }
            else
            {
                utilities.extenttest.Log(LogStatus.Fail, "Fail");
                Assert.Fail();
            } 
        }

        [Test, Category("LogIn")]
        //Unsuccessful login
        public void LogInPasswordFail()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Login Password Fail");
            utilities.extenttest.AssignCategory("Login Tests");
            loginMain.NavigateTo();
            loginMain.LogInPasswordFail();
            IWebElement body = driver.FindElement(By.TagName("body"));
            if (body.Text.Contains("Your login attempt was not successful. Please try again."))
            {
                Console.WriteLine("Login attempt was unsuccessful.");
                utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
                Assert.Pass();
            }
            else
            {
                utilities.extenttest.Log(LogStatus.Fail, "Fail");
                Assert.Fail();
            }
        }

        [Test, Category("LogIn")]
        //Check logout success
        public void LogoutSuccess()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Logout Success");
            utilities.extenttest.AssignCategory("Login Tests");
            loginMain.NavigateTo();
            loginMain.LogInSuccess();
            loginMain.LogoutSuccess();
            Thread.Sleep(4000);
            if (driver.FindElement(By.Id("lblLogout")).Displayed)
            {
                Console.WriteLine("Logout Success");
                utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
                Assert.Pass();
            }
            else
            {
                Console.WriteLine("Logout Failed");
                Assert.Fail();
            }
        }

        [Test, Category("LogIn")]
        //Check re-login redirect
        public void ReLogInRedirect()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("ReLogIn Redirect Success");
            utilities.extenttest.AssignCategory("Login Tests");
            loginMain.NavigateTo();
            loginMain.LogInSuccess();
            loginMain.LogoutSuccess();
            loginMain.ReLogInNavigation();
            Thread.Sleep(6000);
            if (driver.FindElement(By.Id("loginMain_Password")).Displayed)
            {
                Console.WriteLine("ReloginRedirect Success");
                utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
                Assert.Pass();
            }
            else
            {
                Console.WriteLine("LoginRedirect Failed");
                Assert.Fail();
            }
        }
        //=====ALL LOGIN TESTS END=====

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
