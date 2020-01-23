using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace WebApp.Modules.Administration
{
    public class AdministrationReferences
    {
        private readonly IWebDriver driver;

        public AdministrationReferences(IWebDriver driver)
        {
            this.driver = driver;
        }

        //START
        public IWebElement AdminIcon
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
                return this.driver.FindElement(By.Id("ctl00_propertysetupLink"));
            }
        }

        public IWebElement PropertiesLink
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_subLblProperties"));
            }
        }

        public IWebElement AreaLink
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_subLblArea"));
            }
        }

        public IWebElement DepartmentsLink
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_subLblDepartments"));
            }
        }

        public IWebElement AddPropertyButton
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_btnAdd"));
            }
        }

        public IWebElement AddAreaButton
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_btnAdd"));
            }
        }

        public IWebElement AddDepartmentButton
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_btnAdd"));
            }
        }

        public IWebElement ResourceManagementTab
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_resourcemanagementLink"));
            }
        }

        public IWebElement ResourceTypeLink
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_subLblResourceType"));
            }
        }

        public IWebElement ResourceLink
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_subLblResource"));
            }
        }

        public IWebElement ResourceGroupLink
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_subLblResourceGroup"));
            }
        }

        public IWebElement AddonsLink
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_subLblAddons"));
            }
        }

        public IWebElement AddonsByResourceLink
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_subLblResourceGroupAddons"));
            }
        }

        public IWebElement ResourceFeatureIconsLink
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_subLblResourceFeatureIcon"));
            }
        }

        public IWebElement SettingsTab
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_lblSettings"));
            }
        }

        public IWebElement LanguageLink
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_subLblLanguages"));
            }
        }

        public IWebElement StatusLink
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_subLblStatus"));
            }
        }

        public IWebElement PropertySettingsLink
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_subLblPropertySettings"));
            }
        }

        public IWebElement GlobalSettingsLink
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_subLblGlobalSettings"));
            }
        }

        public IWebElement BRESettingsLink
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_subLblBusinessRuleSettings"));
            }
        }

        public IWebElement GlobalBRESettingsLink
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_subLblGlobalBusinessRuleSettings"));
            }
        }

        public IWebElement MobileSettingsLink
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_subLblMobileSettings"));
            }
        }

        public IWebElement AllUserDiarySettingsLink
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_subLblAllUserDiarySetting"));
            }
        }

        public IWebElement RollingDisplayLink
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_subLblRollingDisplay"));
            }
        }

        public IWebElement WizardManagementTab
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_lblWizardManagement"));
            }
        }

        public IWebElement WizardLink
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_subLblWizard"));
            }
        }

        public IWebElement PropertyWizardAssignmentLink
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_subLblPropertyWizardAssignment"));
            }
        }

        public IWebElement AlertsTab
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_lblAlerts"));
            }
        }

        public IWebElement AlertsLink
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_subLblAlerts"));
            }
        }

        public IWebElement LookupTab
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_lblLookUp"));
            }
        }
        public IWebElement LookupLink
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_subLblLookUp"));
            }
        }

        public IWebElement UserDefinedFieldsLink
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_subLblUDF"));
            }
        }

        public IWebElement QuestionnaireLink
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_subLblQuestionnaire"));
            }
        }

        public IWebElement ChargebackLookupsLink
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_subLblChargebackLookups"));
            }
        }

        public IWebElement UserSecurityTab
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_lblUserSecurity"));
            }
        }

        public IWebElement UserGroupsLink
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_sublblUserGroups"));
            }
        }

        public IWebElement RoleLink
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_subLblRole"));
            }
        }

        public IWebElement RoleADMappingLink
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_subLblRoleADMapping"));
            }
        }

        public IWebElement LoggedInUsersLink
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_subLblLoggedInUsers"));
            }
        }

        public IWebElement LockedBookingsLink
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_subLblLoggedInUsers"));
            }
        }

        public IWebElement ADFieldMappingLink
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_subLblAdFieldMapping"));
            }
        }

        public IWebElement UserLink
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_subLblContactUser"));
            }
        }

        public IWebElement ActiveDirectoryConfigurationLink
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_subLblActiveDirectoryConfiguration"));
            }
        }
        //END
    }
}
