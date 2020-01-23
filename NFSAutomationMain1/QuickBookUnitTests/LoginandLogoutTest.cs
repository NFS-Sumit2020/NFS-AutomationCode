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
using QuickBook.Account;
using QuickBook.Login;
using QuickBook.MyProfile;
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
    public class LoginandLogoutTest
    {
        public IWebDriver driver;
        private readonly string TextFilePath = ConfigurationManager.AppSettings["textfilepath"];
        public LoginMain login;
        public UtilitiesMain utilities;
        public MyProfile myprof;
        

        [OneTimeSetUp]
        public void SetupTest()
        {
            this.driver = new ChromeDriver();
            this.login = new LoginMain(this.driver);
            this.utilities = new UtilitiesMain(this.driver);
            this.myprof = new MyProfile(this.driver);
            utilities.ReportSetup();
            
        }

       
        [Test, Category("LoginandLogoutTest")]
        public void LoginSuccess()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Login Success");
            utilities.extenttest.AssignCategory("Login and Logout Tests");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2000);
            login.NavigateTo();
            login.LoginSuccess();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2000);
            Assert.IsTrue(driver.FindElement(By.XPath("//*[@id='page-wrap']/section[1]")).Displayed);
            utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
        }

        [Test, Category("LoginandLogoutTest")]
        public void LoginwithIncorrectUsername()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Login With Incorrect Username");
            utilities.extenttest.AssignCategory("Login and Logout Tests");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2000);
            login.NavigateTo();
            login.LoginUsernameFail();
            IWebElement error = driver.FindElement(By.ClassName("error-box"));
            Assert.IsTrue(error.Text.Equals("Invalid username or password."));
            utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
        }

        [Test, Category("LoginandLogoutTest")]
        public void LoginwithIncorrectPassword()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Login with Incorrect password");
            utilities.extenttest.AssignCategory("Login and Logout Tests");
            login.NavigateTo();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2000);
            login.LoginPasswordFail();
            IWebElement error = driver.FindElement(By.ClassName("error-box"));
            Assert.IsTrue(error.Text.Equals("Invalid username or password."));
            utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
        }

        [Test, Category("LoginandLogoutTest")]
        public void LoginwithoutUsername()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Login without username");
            utilities.extenttest.AssignCategory("Login and Logout Tests");
            login.NavigateTo();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2000);
            login.Loginwithoutusername();
            IWebElement fielderror = driver.FindElement(By.ClassName("field-validation-error"));
            Assert.IsTrue(fielderror.Text.Equals("Please enter username"));
            utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
        }

        [Test, Category("LoginandLogoutTest")]
        public void LoginwithoutPassword()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Login without password");
            utilities.extenttest.AssignCategory("Login and Logout Tests");
            login.NavigateTo();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2000);
            login.Loginwithoutpassword();
            IWebElement fielderrorpassword = driver.FindElement(By.ClassName("field-validation-error"));
            Assert.IsTrue(fielderrorpassword.Text.Equals("Please enter password"));
            utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
        }

        [Test, Category("LoginandLogoutTest")]
        public void Loginwithoutdetails()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Login Without Details");
            utilities.extenttest.AssignCategory("Login and Logout Tests");
            login.NavigateTo();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2000);
            login.Loginwithoutdetails();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2000);
            IWebElement fielderror1 = driver.FindElement(By.XPath("/html/body/div/section/form/div/div[2]/div/div/span[2]/span"));
            IWebElement fielderror2 = driver.FindElement(By.XPath("/html/body/div/section/form/div/div[3]/div/div/span[2]/span"));
            Assert.IsTrue(fielderror1.Text.Equals("Please enter username") && fielderror2.Text.Equals("Please enter password"));
            utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
        }

        //Need to validate this. 
        [Test, Category("LoginandLogoutTest")]
        public void Logout()
        {

            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Logout");
            utilities.extenttest.AssignCategory("Login and Logout Tests");
            login.NavigateTo();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2000);
            login.LoginSuccess();
            Thread.Sleep(8000);
            myprof.MyProfileicon();
            Thread.Sleep(3000);
            login.Logout();
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
