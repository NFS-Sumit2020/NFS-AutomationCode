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
using WebApp.Login;
using WebApp.Diary;
using WebApp.BookingSummary;
using RelevantCodes.ExtentReports;
 using OpenQA.Selenium.Interactions;

namespace UnitTests
{
   public class DiaryTests
    {

        public IWebDriver driver;
        private readonly string TextFilePath = ConfigurationManager.AppSettings["textfilepath"];
        public UtilitiesMain utilities;
        public WebAppLoginMain loginMain;
        public DiaryMain diaryMain;
        public BookingSummaryMain bookingsummary;
        protected DiaryReferences Map
        {
            get
            {
                return new DiaryReferences(this.driver);
            }
        }

        [OneTimeSetUp]
        public void SetupTest()
        {
            this.driver = new ChromeDriver();
            this.loginMain = new WebAppLoginMain(this.driver);
            this.utilities = new UtilitiesMain(this.driver);
            this.diaryMain = new DiaryMain(this.driver);
            this.bookingsummary = new BookingSummaryMain(this.driver);
            utilities.ReportSetup();
        }


        [Test, Category("Diary Tests")]
        public void test()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Admin Button Clicked");
            utilities.extenttest.AssignCategory("Properties Tests");
            loginMain.NavigateTo();
            loginMain.LogInSuccess();

            Thread.Sleep(5000);
            diaryMain.ClickFirstCell();
        }


        [Test, Category("Diary Tests")]
        public void DiaryDoubleClickBooking()
        {
            utilities.ConsoleMessageStart();
            utilities.extenttest = utilities.extent.StartTest("Admin Button Clicked");
            utilities.extenttest.AssignCategory("Properties Tests");
            loginMain.NavigateTo();
            loginMain.LogInSuccess();
            Thread.Sleep(4000);
            // diaryMain.DiaryClickTest();
            diaryMain.ClickFirstCell();

            if (this.Map.NewBookingPopUp.Displayed)
            {
                diaryMain.NewBookingPopupDisplayed();
            }
            else if (this.Map.EditBookingPage.Displayed)
            {
                diaryMain.editBookingExitButtonClicked();

                Thread.Sleep(3000);

                for (int j = 3; j < 25; j++)
                {
                    var iffirstnotfound = this.Map.IfFirstCellnotFound(j);

                    Actions action1 = new Actions(driver);
                    action1.MoveToElement(iffirstnotfound).DoubleClick().Perform();

                    if (this.Map.NewBookingPopUp.Displayed)
                    {
                        diaryMain.NewBookingPopupDisplayed();
                        break;
                    }
                    diaryMain.editBookingExitButtonClicked();
                    Thread.Sleep(2000);
                }


            }
            else
            {
                //do Nothing
            }

            diaryMain.continueWithBookingButton();
            Thread.Sleep(3000);
            bookingsummary.AddHostDetails();
            bookingsummary.AddTitleDetails();
            bookingsummary.SingleBookingSave();
            bookingsummary.AcceptSaveBookingPopUP();


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
            //utilities.extent.Close();
            //this.driver.Quit();
        }
    }
}
