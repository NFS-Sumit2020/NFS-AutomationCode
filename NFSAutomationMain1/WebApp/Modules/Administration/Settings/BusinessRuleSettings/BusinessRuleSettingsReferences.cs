using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using System.Configuration;

namespace WebApp.Modules.Administration.Settings.BusinessRuleSettings
{
    public class BusinessRuleSettingsReferences
    {
        private readonly IWebDriver driver;
        private readonly string propertyName = ConfigurationManager.AppSettings["PropertyName"];

        public BusinessRuleSettingsReferences(IWebDriver driver)
        {
            this.driver = driver;
        }

        //START
        public IWebElement PropertySelectDropDown
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_ddlProperty_Arrow"));
            }
        }

        public IWebElement SelectProperty
        {
            get
            {
                var xpath = string.Format(".//ul/li[contains(text(), '{0}')]", propertyName);
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_ddlProperty_DropDown")).FindElement(By.XPath(xpath));
            }
        }

        //Select BRE Category - CAN BE REUSED
        public IWebElement AddonsCategory
        {
            get
            {
                var xpath = string.Format(".//ul/li/a/span/span[contains(text(), '{0}')]", "Addons");
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_pnlBRESettings")).FindElement(By.XPath(xpath));
            }
        }
        //Select BRE Category Option 1 - CAN BE REUSED
        public IWebElement AddonsCategoryOption1
        {
            get
            {
                var xpath = string.Format(".//ul/li/div/ul/li/a/span/span[contains(text(), '{0}')]", "Addons");
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_pnlBRESettings")).FindElement(By.XPath(xpath));
            }
        }
        //Select BRE Category Option 2
        public IWebElement AddonsCategoryOption2
        {
            get
            {
                var xpath = string.Format(".//ul/li/div/ul/li/a/span/span[contains(text(), '{1}')]", "Addons");
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_pnlBRESettings")).FindElement(By.XPath(xpath));
            }
        }

        public IWebElement AllowZeroQuantityYes
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_rbtnZeroQunatAddonYes"));
            }
        }
        public IWebElement AllowZeroQuantityNo
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_rbtnZeroQuantAddonNo"));
            }
        }
        //IS A DROPDOWN
        public IWebElement CutOff48HoursFriday
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_ddl48HoursCutoffRuleDays"));
            }
        }
        //DOES NOT WORK - INCOMPLETE XPath
        public IWebElement SelectFridayDropDown
        {
            get
            {
                var xpath = string.Format(".//ul/li[contains(text(), '{0}')]", "Friday");
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_ddl48HoursCutoffRuleDays")).FindElement(By.XPath(xpath));
            }
        }

        public IWebElement SaveBRESettings
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_btnUpdateCurrentSettings"));
            }
        }

        public IWebElement AddonOneQuantityInput
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@class='pageviewer_addons']/div/div/div/table/tbody/tr/td/fieldset/div/table/tbody/tr/td/span/input"));
            }
        }

        public IWebElement AddAddonsButton
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_ctl00_btnAdd"));
            }
        }




        //Select BRE Category - CAN BE REUSED
        public IWebElement BookingCategory
        {
            get
            {
                var xpath = string.Format(".//ul/li/a/span/span[contains(text(), '{0}')]", "Booking");
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_pnlBRESettings")).FindElement(By.XPath(xpath));
            }
        }
        //Select BRE Category Option 1 - CAN BE REUSED
        public IWebElement BookingCategoryOption1
        {
            get
            {
                var xpath = string.Format(".//ul/li/div/ul/li/a/span/span[contains(text(), '{0}')]", "Booking");
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_pnlBRESettings")).FindElement(By.XPath(xpath));
            }
        }



        //Select BRE Category - CAN BE REUSED
        public IWebElement HostAllocationCategory
        {
            get
            {
                var xpath = string.Format(".//ul/li/a/span/span[contains(text(), '{0}')]", "Host");
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_pnlBRESettings")).FindElement(By.XPath(xpath));
            }
        }

        //Select BRE Category Option - CAN BE REUSED
        public IWebElement HostAllocationCategoryOption1
        {
            get
            {
                var xpath = string.Format(".//ul/li/div/ul/li/a/span/span[contains(text(), '{0}')]", "Host");
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_pnlBRESettings")).FindElement(By.XPath(xpath));
            }
        }

        public IWebElement MultipleHostsYes
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_rbtnAllowMultipleHostYes"));
            }
        }
        public IWebElement MultipleHostsNo
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_rbtnAllowMultipleHostNo"));
            }
        }

        public IWebElement BookingWithoutHostYes
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_rbtnAllowBookingWOHostYes"));
            }
        }
        public IWebElement BookingWithoutHostNo
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_rbtnAllowBookingWOHostNo"));
            }
        }

        public IWebElement AddHostExistingYes
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_rbtnAllowHostInMultipleBookingY"));
            }
        }
        public IWebElement AddHostExistingNo
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_rbtnAllowHostInMultipleBookingN"));
            }
        }

        public IWebElement SaveBookingButton
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_btnSave"));
            }
        }

        public IWebElement OkButtonOnSave
        {
            get
            {
                return this.driver.FindElement(By.XPath("//button[.='OK']"));
            }
        }

        public IWebElement SummaryCancelButton
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_btnCancel"));
            }
        }
        //TEST VALIDATION USE ONLY START
        //Validate text on popup
        public IWebElement PopupText
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='dvBreRole']"));
            }
        }
        //Validate save booking popup
        public IWebElement SaveBookingPopup
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='dvSumm']"));
            }
        }
        //Validate host adding to existing booking
        public IWebElement HostExistingPopup
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='dvInvalidCharMsg']"));
            }
        }
        //Validate all validation popup text
        public IWebElement AnyValidationPopup
        {
            get
            {
                return this.driver.FindElement(By.XPath("/html/body/div[3]/div[2]"));
            }
        }
        //Validate addon has been added
        public IWebElement AddedAddonCategoryOne
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='divGruoup0']"));
            }
        }
        //TEST VALIDATION USE ONLY END
    }
}
