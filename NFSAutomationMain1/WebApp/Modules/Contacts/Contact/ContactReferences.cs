using OpenQA.Selenium;

namespace WebApp.Modules.Contacts.Contact
{
   public class ContactReferences
    {

        private readonly IWebDriver driver;

        public ContactReferences(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement ContactIcon
        {
            get
            {
                return this.driver.FindElement(By.Id("hostSpan"));
            }
        }

        public IWebElement AddNewContactButton
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_btnAdd"));
            }
        }

        public IWebElement AddNewCompanyBtn
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_btnAddNewHost"));
            }
        }

        public IWebElement CompanyDropDownList
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_ddlHost"));
               // return this.driver.FindElement(By.XPath("//*[@id='ctl00_MainContentPlaceHolder_pnlHost']/table/tbody/tr/td[2]"));
               // return this.driver.FindElement(By.XPath("//*[@id='ctl00_MainContentPlaceHolder_ddlHost']")); 
            }
        }

        public IWebElement SelectTitle
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_ddlTitle"));
            }
        }

        public IWebElement EnterFirstName
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_txtFirstName"));
            }
        }

        public IWebElement EnterLastName
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_txtLastName"));
            }
        }

        public IWebElement EnterDisplayName
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_txtDisplayName"));
            }
        }

        public IWebElement EnterAddress1
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_Address1_txtAddress1"));

            }
        }

        public IWebElement EnterTown
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_Address1_txtTownCity"));
            }
        }

        public IWebElement SelectCountry
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_Address1_ddlCountry"));
            }
        }

        public IWebElement SelectRegion
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_Address1_ddlRegion"));
            }
        }

        public IWebElement SelectState
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_Address1_ddlStateCounty"));
            }
        }


        public IWebElement EnterTelephone1
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_Address1_txtTelephone1"));
            }
        }

        public IWebElement EnterEmail
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_Address1_txtEmail"));
            }
        }

        public IWebElement SaveButton
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_Button1"));
            }
        }

        public IWebElement CancelButton
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_Button2"));
            }
        }

        public IWebElement SaveandAddMoreButton
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_btnSaveNAddMoreTop"));
            }
        }

        public IWebElement SearchingByDisplayName
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_usergrdList_ctl00_ctl02_ctl02_FilterTextBox_DisplayName"));
            }
        }

        public IWebElement SearchingByCompanyName
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_usergrdList_ctl00_ctl02_ctl02_FilterTextBox_HostDisplayName"));
            }
        }

        public IWebElement SearchingByPropertyName
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_usergrdList_ctl00_ctl02_ctl02_FilterTextBox_PropertyName"));
            }
        }

        public IWebElement SearchingByTelephone
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_usergrdList_ctl00_ctl02_ctl02_FilterTextBox_Telephone"));
            }
        }

        public IWebElement InternalFilter
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_usergrdList_ctl00_ctl02_ctl02_FilterCheckBox_IsInternal"));
            }
        }

        public IWebElement PrimaryFilter
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_usergrdList_ctl00_ctl02_ctl02_FilterCheckBox_IsPrimary"));
            }
        }

        public IWebElement EmailFilter
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_usergrdList_ctl00_ctl02_ctl02_FilterCheckBox_EmailOptOut"));
            }
        }

        public IWebElement ActiveFilter
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_usergrdList_ctl00_ctl02_ctl02_FilterCheckBox_IsActive"));
            }
        }

        public IWebElement InternalFilterButton
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_usergrdList_ctl00_ctl02_ctl02_Filter_IsInternal"));
            }
        }

        public IWebElement FilterOptions
        {
            get
            {
                return this.driver.FindElement(By.ClassName("rmActive rmVertical rmGroup rmLevel1"));
            }
        }

        public IWebElement FilterEqualTo
        {
            get
            {
                // return this.driver.FindElement(By.XPath("//*[@id='ctl00_MainContentPlaceHolder_usergrdList_rfltMenu_detached']/ul"));
                return this.driver.FindElement(By.CssSelector(".ctl00_MainContentPlaceHolder_usergrdList_rfltMenu_detached > ul"));
                //  return this.driver.FindElement(By.ClassName("rmItem rmFirst"));


            }
        }



    }
}
