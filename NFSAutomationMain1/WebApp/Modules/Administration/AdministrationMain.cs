using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using WebApp.Login;

namespace WebApp.Modules.Administration
{
    public class AdministrationMain
    {
        private IWebDriver driver;
        private WebAppLoginMain loginMain;
        private AdministrationMain administrationMain;

        public AdministrationMain(IWebDriver driver)
        {
            this.driver = driver;
        }

        //Map references
        public AdministrationReferences Map
        {
            get
            {
                return new AdministrationReferences(this.driver);
            }
        }

        //Login and navigate to admin module
        public void AccessAdminModule()
        {
           //Removed login from here as it's being used directly from Login class
            this.Map.AdminIcon.Click();
            Thread.Sleep(4000);
        }

        //=====PROPERTY SETUP GROUP=====
        //Navigate from Admin Module to Property Setup
        public void AccessPropertySetup()
        {
            administrationMain.AccessAdminModule();
            this.Map.PropertySetupTab.Click();
            Thread.Sleep(2000);
        }
        //Navigate from Property Setup to Properties
        public void PropertiesLink()
        {
            administrationMain.AccessPropertySetup();
            this.Map.PropertiesLink.Click();
            Thread.Sleep(2000);
        }
        //Navigate from Property Setup to Area
        public void AreaLink()
        {
            administrationMain.AccessPropertySetup();
            this.Map.AreaLink.Click();
            Thread.Sleep(2000);
        }
        //Navigate from Property Setup to Departments
        public void DepartmentsLink()
        {
            administrationMain.AccessPropertySetup();
            this.Map.DepartmentsLink.Click();
            Thread.Sleep(2000);
        }
        //=====PROPERTY SETUP GROUP END=====
        //=====RESOURCE MANAGEMENT GROUP=====
        public void AccessResourceManagement()
        {
            administrationMain.AccessAdminModule();
            this.Map.ResourceManagementTab.Click();
            Thread.Sleep(2000);
        }
        public void ResourceTypeLink()
        {
            administrationMain.AccessResourceManagement();
            this.Map.ResourceTypeLink.Click();
            Thread.Sleep(2000);
        }
        public void ResourceLink()
        {
            administrationMain.AccessResourceManagement();
            this.Map.ResourceLink.Click();
            Thread.Sleep(2000);
        }
        public void ResourceGroupLink()
        {
            administrationMain.AccessResourceManagement();
            this.Map.ResourceGroupLink.Click();
            Thread.Sleep(2000);
        }
        public void AddonsLink()
        {
            administrationMain.AccessResourceManagement();
            this.Map.AddonsLink.Click();
            Thread.Sleep(2000);
        }
        public void AddonsByResourceLink()
        {
            administrationMain.AccessResourceManagement();
            this.Map.AddonsByResourceLink.Click();
            Thread.Sleep(2000);
        }
        public void ResourceFeatureIconsLink()
        {
            administrationMain.AccessResourceManagement();
            this.Map.ResourceFeatureIconsLink.Click();
            Thread.Sleep(2000);
        }
        //=====RESOURCE MANAGEMENT GROUP END=====
        //=====SETTINGS GROUP=====
        public void AccessSettings()
        {
            //administrationMain.AccessAdminModule();
            this.Map.SettingsTab.Click();
            Thread.Sleep(2000);
        }
        public void LanguageLink()
        {
            administrationMain.AccessSettings();
            this.Map.LanguageLink.Click();
            Thread.Sleep(2000);
        }
        public void StatusLink()
        {
           
            this.Map.StatusLink.Click();
            Thread.Sleep(2000);
        }
        public void PropertySettingsLink()
        {
            administrationMain.AccessSettings();
            this.Map.PropertySettingsLink.Click();
            Thread.Sleep(2000);
        }
        public void GlobalSettingsLink()
        {
            administrationMain.AccessSettings();
            this.Map.GlobalSettingsLink.Click();
            Thread.Sleep(2000);
        }
        public void BRESettingsLink()
        {
            AccessSettings();
            Thread.Sleep(1000);
            this.Map.BRESettingsLink.Click();
            Thread.Sleep(2000);
        }
        public void GlobalBRESettingsLink()
        {
            administrationMain.AccessSettings();
            this.Map.GlobalBRESettingsLink.Click();
            Thread.Sleep(2000);
        }
        public void MobileSettingsLink()
        {
            administrationMain.AccessSettings();
            this.Map.MobileSettingsLink.Click();
            Thread.Sleep(2000);
        }
        public void AllUserDiarySettingsLink()
        {
            administrationMain.AccessSettings();
            this.Map.AllUserDiarySettingsLink.Click();
            Thread.Sleep(2000);
        }
        public void RollingDisplayLink()
        {
            administrationMain.AccessSettings();
            this.Map.RollingDisplayLink.Click();
            Thread.Sleep(2000);
        }
        //=====SETTINGS GROUP END=====
        //=====WIZARD MANAGEMENT GROUP=====
        public void AccessWizardManagement()
        {
            administrationMain.AccessAdminModule();
            this.Map.WizardManagementTab.Click();
            Thread.Sleep(2000);
        }
        public void WizardLink()
        {
            administrationMain.AccessWizardManagement();
            this.Map.WizardLink.Click();
            Thread.Sleep(2000);
        }
        public void PropertyWizardAssignmentLink()
        {
            administrationMain.AccessSettings();
            this.Map.PropertyWizardAssignmentLink.Click();
            Thread.Sleep(2000);
        }
        //=====WIZARD MANAGEMENT GROUP END=====
        //=====ALERTS GROUP=====
        public void AccessAlerts()
        {
            administrationMain.AccessAdminModule();
            this.Map.AlertsTab.Click();
            Thread.Sleep(2000);
        }
        public void AlertsLink()
        {
            administrationMain.AccessAlerts();
            this.Map.AlertsLink.Click();
            Thread.Sleep(2000);
        }
        //=====ALERTS GROUP END=====
        //=====LOOKUP GROUP=====
        public void AccessLookup()
        {
            administrationMain.AccessAdminModule();
            this.Map.LookupTab.Click();
            Thread.Sleep(2000);
        }
        public void LookupLink()
        {
            administrationMain.AccessLookup();
            this.Map.LookupLink.Click();
            Thread.Sleep(2000);
        }
        public void UserDefinedFieldsLink()
        {
            administrationMain.AccessLookup();
            this.Map.UserDefinedFieldsLink.Click();
            Thread.Sleep(2000);
        }
        public void QuestionnaireLink()
        {
            administrationMain.AccessLookup();
            this.Map.QuestionnaireLink.Click();
            Thread.Sleep(2000);
        }
        public void ChargebackLookupsLink()
        {
            administrationMain.AccessLookup();
            this.Map.ChargebackLookupsLink.Click();
            Thread.Sleep(2000);
        }
        //=====LOOKUP GROUP END=====
        //=====USER SECURITY GROUP=====
        public void AccessUserSecurity()
        {
            administrationMain.AccessAdminModule();
            this.Map.UserSecurityTab.Click();
            Thread.Sleep(2000);
        }
        public void UserGroupsLink()
        {
            administrationMain.AccessUserSecurity();
            this.Map.UserGroupsLink.Click();
            Thread.Sleep(2000);
        }
        public void RoleLink()
        {
            administrationMain.AccessUserSecurity();
            this.Map.RoleLink.Click();
            Thread.Sleep(2000);
        }
        public void RoleADMappingLink()
        {
            administrationMain.AccessUserSecurity();
            this.Map.RoleADMappingLink.Click();
            Thread.Sleep(2000);
        }
        public void LoggedInUsersLink()
        {
            administrationMain.AccessUserSecurity();
            this.Map.LoggedInUsersLink.Click();
            Thread.Sleep(2000);
        }
        public void LockedBookingsLink()
        {
            administrationMain.AccessUserSecurity();
            this.Map.LockedBookingsLink.Click();
            Thread.Sleep(2000);
        }
        public void ADFieldMappingLink()
        {
            administrationMain.AccessUserSecurity();
            this.Map.ADFieldMappingLink.Click();
            Thread.Sleep(2000);
        }
        public void UserLink()
        {
            administrationMain.AccessUserSecurity();
            this.Map.UserLink.Click();
            Thread.Sleep(2000);
        }
        public void ActiveDirectoryConfigurationLink()
        {
            administrationMain.AccessUserSecurity();
            this.Map.ActiveDirectoryConfigurationLink.Click();
            Thread.Sleep(2000);
        }
        //=====USER SECURITY GROUP END=====
    }
}
