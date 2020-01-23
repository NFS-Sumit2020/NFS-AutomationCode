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
using QuickBook.Homepage;
using QuickBook.Services;
using QuickBook.Utilities;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using RelevantCodes.ExtentReports;
using System.Diagnostics;
using System.Configuration;


namespace UnitTests
{
    [TestFixture]
    public class ServicesTest
    {
        public IWebDriver driver;
        private readonly string TextFilePath = ConfigurationManager.AppSettings["textfilepath"];
        public MyProfile myprofile;
        public LoginMain login;
        public HomepageMain homepage;
        public ServicesMain services;
        public UtilitiesMain utilities;
       
        protected ServicesReferences Map
        {
            get
            {
                return new ServicesReferences(this.driver);
            }
        }

        [OneTimeSetUp]
        public void SetupTest()
        {
            this.driver = new ChromeDriver();
            this.myprofile = new MyProfile(this.driver);
            this.login = new LoginMain(this.driver);
            this.homepage = new HomepageMain(this.driver);
            this.services = new ServicesMain(this.driver);
            this.utilities = new UtilitiesMain(this.driver);
            utilities.ReportSetup();
        }

         [Test, Category("Services")]
        public void AddServicesButtonCheck()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Add Services Button Check");
            utilities.extenttest.AssignCategory("Services Tests");
            login.NavigateTo();
            login.LoginSuccess();
            Thread.Sleep(3000);
            homepage.SelectResource();
            login.Wait();
            services.AddServicesButton();
            login.Wait();
            Assert.IsTrue(this.driver.FindElement(By.XPath("//*[@id='step3AddServices']")).Displayed);
            utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
        }

         [Test, Category("Services")]
        public void AddAddon()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Add an Addon");
            utilities.extenttest.AssignCategory("Services Tests");
            login.NavigateTo();
            login.LoginSuccess();
            Thread.Sleep(3000);
            homepage.SelectResource();
            Thread.Sleep(2000);
            login.Wait();
            services.AddServicesButton();
            login.Wait();
            services.AddAddon();
           // Console.WriteLine("Loop Break");
            Thread.Sleep(6000); 
            Assert.IsTrue(this.driver.FindElement(By.XPath("//*[@id='tab-1']/div/div[2]")).Displayed);
            utilities.extenttest.Log(LogStatus.Pass, "Assert pass ");
            //Assert.IsTrue(this.driver.FindElement(By.XPath("//*[@id='step3AddServices']")).Displayed);
        }

        //GG START
        [Test, Category("Services")]
        public void Test()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Test");
            utilities.extenttest.AssignCategory("Services Tests");
            login.NavigateTo();
            login.LoginSuccess();
            Thread.Sleep(5000);
            homepage.SelectResource();
            Thread.Sleep(2000);
            login.Wait();
            services.AddServicesButton();
            Thread.Sleep(3000);
            services.AddAddonTest();

        }

        [Test, Category("Services")]
        public void ChangeCategory()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Test");
            utilities.extenttest.AssignCategory("Services Tests");
            login.NavigateTo();
            login.LoginSuccess();
            Thread.Sleep(5000);
            homepage.SelectResource();
            Thread.Sleep(2000);
            login.Wait();
            services.AddServicesButton();
            Thread.Sleep(3000);
            services.ChangeCategory();
            Console.WriteLine("Current Category: " + services.currentCategory);
            Console.WriteLine("New Category: " + services.newCategory);
            Assert.IsTrue(services.currentCategory != services.newCategory);
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
