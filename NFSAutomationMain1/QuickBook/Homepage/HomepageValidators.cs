using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace QuickBook.Homepage
{
    public class HomepageValidators
    {
        private readonly IWebDriver driver;

        //Init driver
        public HomepageValidators(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement MyProfileOptionValidator
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='myProfile']"));
            }
        }
        public IWebElement LogOutOptionValidator
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='btnLogout']"));
            }
        }
        public IWebElement MyProfileConfirmNavigateValidator
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='ConfirmationModal']/div[1]/text()"));
            }
        }
        public IWebElement CreateNewBookingLandingScreenValidator
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='stepSelection']/div/div/div/div[1]/div[1]/div/h3/span/span"));
            }
        }
        public IWebElement MyProfileLandingScreenValidator
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='page-wrap']/section[2]/div[1]/h1"));
            }
        }
        public IWebElement LogInButtonValidator
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='btnLogin']"));
            }
        }
        public IWebElement SelectedMonthValidator
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='datepicker']/div/div/div/span[1]"));
            }
        }
        public IWebElement CalendarDefaultDayValidator
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@class=' ui-datepicker-days-cell-over  ui-datepicker-current-day ui-datepicker-today']/a"));
            }
        }
        public IWebElement CalendarNextDayValidator
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@class=' ']/a"));
            }
        }
        public IWebElement CalendarSelectedDayValidator
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@class='  ui-datepicker-current-day']/a"));
                //return this.driver.FindElement(By.XPath("//*[@id='datepicker']/div/table/tbody/tr[3]/td[4]/a"));
            }
        }
        public IWebElement CalendarSlectedCurrentDateValidator
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@class=' ui-datepicker-days-cell-over  ui-datepicker-current-day ui-datepicker-today']/a"));
            }
        }
        public IWebElement CalendarPastDayValidator
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@class=' ui-datepicker-unselectable ui-state-disabled ']/span"));
            }
        }
        public IWebElement StartTimeValidationButtonValidator
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='btnDialogOK']"));
            }
        }
        public IWebElement StartTimeSelectedValidator
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='Time']"));
            }
        }
        public IWebElement DurationTimeNotShownValidator //15.15hrs Based on 9am time selection
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='Duration']/option[61]"));
            }
        }
        public IWebElement DurationTimeShownValidator //15.00hrs Based on 9am time selection
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='Duration']/option[60]"));
            }
        }
        public IWebElement PropertyDropDownSelectedValidator
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='SinglePropertySearch']/div[1]/span/input"));
            }
        }
        public IWebElement ResourceTypeDropDownSelectedValidator
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='SinglePropertySearch']/div[3]/span/input"));
            }
        }
        public IWebElement LayoutDropDownValidator
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='LayoutId']"));
            }
        }
        public IWebElement DurationDropDownValidator
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='Duration']"));
            }
        }
        public IWebElement AreaDropDownValidator
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='AreaId']"));
            }
        }
        public IWebElement ParticipantsSearchValueValidator
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='Capacity']"));
            }
        }
        public IWebElement SearchedForDateValidator
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='step1FindWorkspace']/div/div[1]/h1/span"));
            }
        }
        public IWebElement SearchedForPropertyValidator
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='workspacePropertyName']"));
            }
        }
        public IWebElement SearchedForTimeValidator //ONLY WORKS WHEN SELECTING 9am
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='tblResourcesGrid']/tbody/tr[1]/td/table/tbody/tr[3]/td[9]/div"));
            }
        }
        public IWebElement SearchedForParticipantsValidator
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='SpnPeopleSection']/span"));
            }
        }
        public IWebElement FirstResourceNameValidator
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='tblResourcesGrid']/tbody/tr[1]/td/table/tbody/tr[1]/td/span/span[1]/i"));
            }
        }
        public IWebElement SelectedResourceNameValidator
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='resourceTitle']"));
            }
        }
        public IWebElement ResourceListInformationValidator
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='tblResourcesGrid']/tbody/tr[1]/td/table/tbody/tr[4]/td/div"));
            }
        }
        public IWebElement SelectedResourceInformationValidator
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='00000000-0000-0000-0000-000000000000']/div[1]/div/div[1]"));
            }
        }
        public IWebElement RemoveResourcePopupValidator
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='btnConfirmationYes']"));
            }
        }
        public IWebElement NoResourcesSelectedValidator
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='MySelection']/div/div[1]/div/div/span"));
            }
        }
        public IWebElement ChangeParticpantsInputValidator
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='inputResourceCover']"));
            }
        }

    }
}
