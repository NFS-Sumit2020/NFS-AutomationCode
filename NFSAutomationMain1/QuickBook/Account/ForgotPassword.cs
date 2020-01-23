using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using QuickBook.Login;

namespace QuickBook.Account
{
    public class ForgotPassword
    {
        private IWebDriver driver;
        private readonly string url = ConfigurationManager.AppSettings["URL"];
        private readonly string unregisteredCorporateEmail = ConfigurationManager.AppSettings["UnregisteredCorporateEmail"];
        private readonly string registeredCorporateEmail = ConfigurationManager.AppSettings["RegisteredCorporateEmail"];
        private readonly string registeredCorporateUserName = ConfigurationManager.AppSettings["RegisteredCorporateUserName"];

        //Get references
        protected ForgotPassword_References Map
        {
            get
            {
                return new ForgotPassword_References(this.driver);
            }
        }

       

        //Initialise Driver
        public ForgotPassword(IWebDriver driver)
        {
            this.driver = driver;
        }

       
        //Forgot password with no details entered
        public void ForgotPasswordClick()
        {
            this.Map.ForgotPasswordButton.Click();
            
        }

        //Forgot Password Link Button 
        public void ForgotPasswordLink()
        {
            this.Map.ForgotPasswordLink.Click();
        }
        //Click Login link
        public void LoginLinkClick()
        {
            this.Map.LoginLink.Click();
        }
        //Enter invalid email format
        public void EmailFormat()
        {
            ForgotPasswordLink();
            this.Map.EmailTestBox.SendKeys("InvalidEmailFormat");
        }
        //Information missmatch
        public void InformationMismatch()
        {
            ForgotPasswordLink();
            this.Map.EmailTestBox.SendKeys(registeredCorporateEmail);
            this.Map.UserNameTextBox.SendKeys("NOUSER");
        }
        //Information Match (Success)
        public void InformationMatch()
        {
            ForgotPasswordLink();
            this.Map.EmailTestBox.SendKeys(registeredCorporateEmail);
            this.Map.UserNameTextBox.SendKeys(registeredCorporateUserName);
        }
    }
}
