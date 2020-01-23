using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace QuickBook.MyProfile
{
    public class MyProfile_Validators
    {
        private readonly IWebDriver driver;

        //Init driver
        public MyProfile_Validators(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement MyProfileHeaderValidator
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='page-wrap']/section[2]/div[1]/h1"));
            }
        }
        public IWebElement UserNameLinkValidator
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='drop-down']/li[1]/span"));
            }
        }
        public IWebElement UserNameValidator
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='page-wrap']/section[2]/div[1]/div/div[2]/p[1]"));
            }
        }
        public string PrimaryPropertyDropDownValidator
        {
            get
            {
                IWebElement dropDown = this.driver.FindElement(By.XPath("//*[@id='PrimaryPropertyId']"));
                var dropDownVar = new SelectElement(dropDown);
                var dropDownSelected = dropDownVar.SelectedOption.Text;
                return dropDownSelected;
            }
        }
        public string LangaugePreferenceDropDownValidator
        {
            get
            {
                IWebElement dropDown = this.driver.FindElement(By.XPath("//*[@id='LanguagePreference']"));
                var dropDownVar = new SelectElement(dropDown);
                var dropDownSelected = dropDownVar.SelectedOption.Text;
                return dropDownSelected;
            }
        }
        public IWebElement CancelValidator
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='btnNextStep0']"));
            }
        }
        public IWebElement SaveValidator
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='btnDialogOK']"));
            }
        }
    }
}
