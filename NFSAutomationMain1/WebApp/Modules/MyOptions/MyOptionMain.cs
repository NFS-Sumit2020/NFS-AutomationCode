using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;



namespace WebApp.Modules.MyOptions
{
    public class MyOptionMain
    {
        private IWebDriver driver;

        public MyOptionMain(IWebDriver driver)
        {
            this.driver = driver;
        }

        protected MyOptionReferences Map
        {
            get
            {
                return new MyOptionReferences(this.driver);
            }
        }


        public void AccessMyoptionIcon()
        {

            this.Map.MyOptionIcon.Click();

        }

        public void MyoptionTitle()
        {

            // this.Map.MyOptionTitle.Click();
            var titlemyoptions = this.Map.MyOptionTitle;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2000);
            var selectElement = new SelectElement(titlemyoptions);
            selectElement.SelectByIndex(4);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2000);
        }

        public void MyoptionFirstName()
        {

            this.Map.MyOptionFirstName.Clear();
            this.Map.MyOptionFirstName.SendKeys("Test4");
            this.Map.MyOptionFirstName.SendKeys(Keys.Tab);
        }

        public void MyoptionLastName()
        {

            this.Map.MyOptionLastName.Clear();
            this.Map.MyOptionLastName.SendKeys("User4");
        }

        public void MyoptionDisplayName()
        {

            this.Map.MyOptionDisplayName.Clear();
            this.Map.MyOptionDisplayName.SendKeys("Test4 User4");
        }

        public void MyoptionDiaryTreeCollapsedYes()
        {

            this.Map.MyOptionDiaryTreeviewYes.Click();
        }

        public void MyoptionDiaryTreeCollapsedNo()
        {

            this.Map.MyOptionDiaryTreeviewNo.Click();
        }

        public void MyoptionEmail()
        {

            this.Map.MyOptionEmail.Clear();
            this.Map.MyOptionEmail.SendKeys("Test.User4@dev.nfs03.com");
        }

        public void MyoptionEmailOptOutYes()
        {

            this.Map.MyOptionEmailOptOutYes.Click();
        }

        public void MyoptionEmailOptOutNo()
        {

            this.Map.MyOptionEmailOptOutNo.Click();
        }

        public void MyoptionLangPref()
        {

            var myoptionslangpref = this.Map.MyOptionLanguagePref;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2000);
            var selectElement = new SelectElement(myoptionslangpref);
            selectElement.SelectByIndex(1);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2000);
        }

        public void MyoptionPrimaryProperty()
        {

            var myoptionsprmyprop = this.Map.MyOptionPrimaryProperty;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2000);
            var selectElement = new SelectElement(myoptionsprmyprop);
            selectElement.SelectByIndex(6);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2000);
        }

        public void MyoptionGroupingOnDiaryTimezone()
        {

            this.Map.MyOptionGroupingOnDiaryTimezone.Click();
        }

        public void MyoptionGroupingOnDiaryProperty()
        {

            this.Map.MyOptionGroupingOnDiaryProperty.Click();
        }

        public void MyoptionShowBusinessHoursYes()
        {

            this.Map.MyOptionShowBusinessHoursYes.Click();
        }

        public void MyoptionShowBusinessHoursNo()
        {

            this.Map.MyOptionShowBusinessHoursNo.Click();
        }

        public void MyoptionSaveButton()
        {

            this.Map.MyOptionSaveButton.Click();
        }

        public void MyoptionCancelButton()
        {

            this.Map.MyOptionCancelButton.Click();
        }

        public void MyoptionEmailWrongFormat()
        {

            this.Map.MyOptionEmail.SendKeys("email.com");
        }

        public bool test1()
        {

            //*[@id="ctl00_MainContentPlaceHolder_ddlTitle"]
            SelectElement element = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_MainContentPlaceHolder_ddlTitle']/option[4]")));
            string title = element.ToString();
            SelectElement element2 = new SelectElement(driver.FindElement(By.XPath(" //*[@id='ctl00_MainContentPlaceHolder_ddlTitle']")));
            string title2 = element2.SelectedOption.ToString();
            if (title2 == title)
                return true;
            else
                return false;
        }

        public void GoToDiary()
        {

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2000);
            this.Map.DiaryButton.Click();
        }

        public bool langtest()
        {

            SelectElement lang1 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_MainContentPlaceHolder_ddlLanguagePreferences']/option[2]")));
            string language1 = lang1.ToString();
            SelectElement lang2 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_MainContentPlaceHolder_ddlLanguagePreferences']")));
            string language2 = lang2.SelectedOption.ToString();
            if (language2 == language1)
                return true;
            else
                return false;
        }

        public void MyoptionsSavingWithoutEmail()
        {

            this.Map.MyOptionEmail.Clear();
        }

        public void MyoptionsSavingWithoutFirstName()
        {

            this.Map.MyOptionFirstName.Clear();
        }

        public void MyoptionsSavingWithoutLastName()
        {

            this.Map.MyOptionLastName.Clear();
        }

        public void MyoptionsSavingWithoutDisplayName()
        {

            this.Map.MyOptionDisplayName.Clear();
        }

    }
}











/*
 * 
 * Ignore this is just for testing.
 * 
 * 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;



namespace WebApp.Modules.MyOptions
{
   public class MyOptionMain
    {
        private IWebDriver driver;

        public MyOptionMain(IWebDriver driver)
        {
            this.driver = driver;
        }

        protected MyOptionReferences Map
        {
            get
            {
                return new MyOptionReferences(this.driver);
            }
        }


        public void AccessMyoptionIcon()
        {
            Myoptions myoption = new Myoptions(this.driver);
            this.Map.MyOptionIcon.Click();

        }

        public void MyoptionTitle()
        {
            Myoptions myoption = new Myoptions(this.driver);
            // this.Map.MyOptionTitle.Click();
            var titlemyoptions = this.Map.MyOptionTitle;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2000);
            var selectElement = new SelectElement(titlemyoptions);
            selectElement.SelectByIndex(4);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2000);
        }

        public void MyoptionFirstName()
        {
            Myoptions myoption = new Myoptions(this.driver);
            this.Map.MyOptionFirstName.Clear();
            this.Map.MyOptionFirstName.SendKeys("Test4");
            this.Map.MyOptionFirstName.SendKeys(Keys.Tab);
        }

        public void MyoptionLastName()
        {
            Myoptions myoption = new Myoptions(this.driver);
            this.Map.MyOptionLastName.Clear();
            this.Map.MyOptionLastName.SendKeys("User4");
        }

        public void MyoptionDisplayName()
        {
            Myoptions myoption = new Myoptions(this.driver);
            this.Map.MyOptionDisplayName.Clear();
            this.Map.MyOptionDisplayName.SendKeys("Test4 User4");
        }

        public void MyoptionDiaryTreeCollapsedYes()
        {
            Myoptions myoption = new Myoptions(this.driver);
            this.Map.MyOptionDiaryTreeviewYes.Click();
        }

        public void MyoptionDiaryTreeCollapsedNo()
        {
            Myoptions myoption = new Myoptions(this.driver);
            this.Map.MyOptionDiaryTreeviewNo.Click();
        }

        public void MyoptionEmail()
        {
            Myoptions myoption = new Myoptions(this.driver);
            this.Map.MyOptionEmail.Clear();
            this.Map.MyOptionEmail.SendKeys("Test.User4@dev.nfs03.com");
        }

        public void MyoptionEmailOptOutYes()
        {
            Myoptions myoption = new Myoptions(this.driver);
            this.Map.MyOptionEmailOptOutYes.Click();
        }

        public void MyoptionEmailOptOutNo()
        {
            Myoptions myoption = new Myoptions(this.driver);
            this.Map.MyOptionEmailOptOutNo.Click();
        }

        public void MyoptionLangPref()
        {
            Myoptions myoption = new Myoptions(this.driver);
            var myoptionslangpref = this.Map.MyOptionLanguagePref;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2000);
            var selectElement = new SelectElement(myoptionslangpref);
            selectElement.SelectByIndex(1);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2000);
        }

        public void MyoptionPrimaryProperty()
        {
            Myoptions myoption = new Myoptions(this.driver);
            var myoptionsprmyprop = this.Map.MyOptionPrimaryProperty;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2000);
            var selectElement = new SelectElement(myoptionsprmyprop);
            selectElement.SelectByIndex(6);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2000);
        }

        public void MyoptionGroupingOnDiaryTimezone()
        {
            Myoptions myoption = new Myoptions(this.driver);
            this.Map.MyOptionGroupingOnDiaryTimezone.Click();
        }

        public void MyoptionGroupingOnDiaryProperty()
        {
            Myoptions myoption = new Myoptions(this.driver);
            this.Map.MyOptionGroupingOnDiaryProperty.Click();
        }

        public void MyoptionShowBusinessHoursYes()
        {
            Myoptions myoption = new Myoptions(this.driver);
            this.Map.MyOptionShowBusinessHoursYes.Click();
        }

        public void MyoptionShowBusinessHoursNo()
        {
            Myoptions myoption = new Myoptions(this.driver);
            this.Map.MyOptionShowBusinessHoursNo.Click();
        }

        public void MyoptionSaveButton()
        {
            Myoptions myoption = new Myoptions(this.driver);
            this.Map.MyOptionSaveButton.Click();
        }

        public void MyoptionCancelButton()
        {
            Myoptions myoption = new Myoptions(this.driver);
            this.Map.MyOptionCancelButton.Click();
        }

        public void MyoptionEmailWrongFormat()
        {
            Myoptions myoption = new Myoptions(this.driver);
            this.Map.MyOptionEmail.SendKeys("email.com");
        }

        public bool test1()
        {
            Myoptions myoption = new Myoptions(this.driver);
            //*[@id="ctl00_MainContentPlaceHolder_ddlTitle"]
            SelectElement element = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_MainContentPlaceHolder_ddlTitle']/option[4]")));
            string title = element.ToString();
            SelectElement element2 = new SelectElement(driver.FindElement(By.XPath(" //*[@id='ctl00_MainContentPlaceHolder_ddlTitle']")));
            string title2 = element2.SelectedOption.ToString();
            if (title2 == title)
                return true;
            else
                return false;
        }

        public void GoToDiary()
        {
            Myoptions myoption = new Myoptions(this.driver);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2000);
            this.Map.DiaryButton.Click();
        }

        public bool langtest()
        {
            Myoptions myoption = new Myoptions(this.driver);
            SelectElement lang1 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_MainContentPlaceHolder_ddlLanguagePreferences']/option[2]")));
            string language1 = lang1.ToString();
            SelectElement lang2 = new SelectElement(driver.FindElement(By.XPath("//*[@id='ctl00_MainContentPlaceHolder_ddlLanguagePreferences']")));
            string language2 = lang2.SelectedOption.ToString();
            if (language2 == language1)
                return true;
            else
                return false;
        }

        public void MyoptionsSavingWithoutEmail()
        {
            Myoptions myoption = new Myoptions(this.driver);
            this.Map.MyOptionEmail.Clear();
        }

        public void MyoptionsSavingWithoutFirstName()
        {
            Myoptions myoption = new Myoptions(this.driver);
            this.Map.MyOptionFirstName.Clear();
        }

        public void MyoptionsSavingWithoutLastName()
        {
            Myoptions myoption = new Myoptions(this.driver);
            this.Map.MyOptionLastName.Clear();
        }

        public void MyoptionsSavingWithoutDisplayName()
        {
            Myoptions myoption = new Myoptions(this.driver);
            this.Map.MyOptionDisplayName.Clear();
        }

    }
}
*/