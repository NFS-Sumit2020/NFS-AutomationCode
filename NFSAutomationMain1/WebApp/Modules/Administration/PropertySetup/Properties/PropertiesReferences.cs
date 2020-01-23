using OpenQA.Selenium;

namespace WebApp.Modules.Administration.PropertySetup.Properties
{
   public class PropertiesReferences
    {

        private readonly IWebDriver driver;

        public PropertiesReferences(IWebDriver driver)
        {
            this.driver = driver;
        }


        public IWebElement AdministrationIcon
        {
            get
            {
                return this.driver.FindElement(By.Id("adminSpan"));
            }
        }

        public IWebElement PropertySetupTab
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_lblPropertySetUp"));
            }
        }

        public IWebElement PropertiesTab
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_subLblProperties"));
            }
        }

        public IWebElement AddnewProperty
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_btnAdd"));
            }
        }

        public IWebElement PropertyType
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_ddlType"));
            }

        }

        public IWebElement PropertyName
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_txtName"));
            }
        }


        public IWebElement PropertyActiveYes
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_rbtnYes"));
            }
        }

        public IWebElement PropertyActiveNo
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_rbtnNo"));
            }
        }

        public IWebElement PropertyDescription
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_txtDescription"));
            }
        }


        public IWebElement PropertyAddress1
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_Address1_txtAddress1"));
            }
        }

        public IWebElement PropertyTownOrCity
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_Address1_txtTownCity"));
            }
        }

        public IWebElement PropertyCountry
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_Address1_ddlCountry"));
            }
        }

        public IWebElement PropertyRegion
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_Address1_ddlRegion"));
            }
        }

        public IWebElement PropertyStateOrCounty
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_Address1_ddlStateCounty"));
            }
        }

        public IWebElement PropertyZipOrPostCode
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_Address1_txtZipPostCode"));
            }
        }

        public IWebElement PropertyTelephone1
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_Address1_txtTelephone1"));
            }
        }

        public IWebElement PropertyEmail
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_Address1_txtEmail"));
            }
        }

        public IWebElement PropertyTimeZone
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_ddlTimeZone"));
            }
        }

        public IWebElement Property12HourDisplay
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_rbtn12"));
            }
        }

        public IWebElement Property24HourDisplay
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_rbtn24"));
            }
        }

        public IWebElement PropertySaveButton
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_btnSave"));
            }
        }

        public IWebElement PropertyCancelButton
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_btnCancel"));
            }
        }

        public IWebElement PropertySaveAddMoreButton
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_btnSaveAdd"));
            }
        }

        public IWebElement PropertyUserGroupPage
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_hlPropertyUserGroup"));
            }
        }

        public IWebElement PropertyUserGroupPropertyFilterBox
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_grdAssignedProperty_ctl00_ctl02_ctl02_FilterTextBox_PropertyName"));
            }
        }

        public IWebElement PropertyUserGroupPropertyFilterIcon
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_grdAssignedProperty_ctl00_ctl02_ctl02_Filter_PropertyName"));
            }
        }

        public IWebElement PropertyUserGroupPropertyFilterOption
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='ctl00_MainContentPlaceHolder_grdAssignedProperty_rfltMenu_detached']/ul/li[2]/a/span"));
            }
        }

        public IWebElement PropertyUserGroupRole
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='ctl00_MainContentPlaceHolder_grdAssignedProperty_ctl00_ctl04_ddlUserGroupName']/option[1]"));
            }
        }

        public IWebElement PropertyUserGroupSaveButton
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_btnSave"));
            }
        }

        public IWebElement PropertyDisplayNameFilter
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_grdList_ctl00_ctl02_ctl02_FilterTextBox_Name"));
            }
        }

        public IWebElement PropertySelect
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_grdList_ctl00__0"));
            }
        }

        public IWebElement Searchdropdown
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_ddlColumns"));
            }
        }

        public IWebElement Searchbox
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_txtSearch"));
            }
        }

        public IWebElement Searchbutton
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_btnSearchIn"));
            }
        }

    }
}
