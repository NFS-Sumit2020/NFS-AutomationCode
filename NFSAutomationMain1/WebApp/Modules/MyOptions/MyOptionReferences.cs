using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
namespace WebApp.Modules.MyOptions
{
  public class MyOptionReferences
    {
        private readonly IWebDriver driver;

        public MyOptionReferences(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement MyOptionIcon
        {
            get
            {
                return this.driver.FindElement(By.Id("myoptionsSpan"));
            }
        }

        public IWebElement MyOptionTitle
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_ddlTitle"));
            }
        }

        public IWebElement MyOptionFirstName
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_txtFirstName"));
            }
        }

        public IWebElement MyOptionLastName
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_txtLastName"));
            }
        }

        public IWebElement MyOptionDisplayName
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_txtDisplayName"));
            }
        }

        public IWebElement MyOptionDiaryTreeviewYes
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_rbtnTreeviewYes"));
            }
        }

        public IWebElement MyOptionDiaryTreeviewNo
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_rbtnTreeviewNo"));
            }
        }

        public IWebElement MyOptionEmail
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_txtEmail"));
            }
        }

        public IWebElement MyOptionEmailOptOutYes
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_rdyes"));
            }
        }

        public IWebElement MyOptionEmailOptOutNo
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_rdNo"));
            }
        }

        public IWebElement MyOptionLanguagePref
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_ddlLanguagePreferences"));
            }
        }

        public IWebElement MyOptionPrimaryProperty
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_ddlPrimaryProperty"));
            }
        }

        public IWebElement MyOptionGroupingOnDiaryTimezone
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_rbGroupByTimeZone"));
            }
        }

        public IWebElement MyOptionGroupingOnDiaryProperty
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_rbGroupByProprty"));
            }
        }

        public IWebElement MyOptionShowBusinessHoursYes
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_rbtnBusinessHoursYes"));
            }
        }


        public IWebElement MyOptionShowBusinessHoursNo
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_rbtnBusinessHoursNo"));
            }
        }

        public IWebElement MyOptionSaveButton
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_btnSave"));
            }
        }


        public IWebElement MyOptionCancelButton
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_btnCancel"));
            }
        }

        public IWebElement DiaryButton
        {
            get
            {
                return this.driver.FindElement(By.Id("diarySpan"));
            }
        }

        public IWebElement ShowBusinessHoursDiary
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_chbBusinessHr"));
            }
        }
    }
}
