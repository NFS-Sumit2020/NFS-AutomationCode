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
    public class Register
    {
        private IWebDriver driver;
        private readonly string url = ConfigurationManager.AppSettings["URL"];
        private readonly string unregisteredCorporateEmail = ConfigurationManager.AppSettings["UnregisteredCorporateEmail"];
        private readonly string registeredCorporateEmail = ConfigurationManager.AppSettings["RegisteredCorporateEmail"];

        //Get references
        protected Register_References Map
        {
            get
            {
                return new Register_References(this.driver);
            }
        }

       

        //Initialise Driver
        public Register(IWebDriver driver)
        {
            this.driver = driver;
        }

        //Login and Navigate to Register Page - functionality taken from Login.Login
        public void NavigateTo()
        {
            LoginMain login = new LoginMain(this.driver);
            login.NavigateTo();
            //login.LoginSuccess();
            login.RegisterLink();
        }

        //Register Link button
        public void RegisterLink()
        {
            this.Map.RegisterLink.Click();
        }


        //Register with no details
        public void RegisterClick()
        {
            this.Map.RegisterButton.Click();
        }

        //Register incorrect email format
        public void EmailFormat()
        {
            this.Map.EmailTextBox.SendKeys("Incorrect@EmailFormat");
        }

        //Register with correct email but none matching passwords
        public void PasswordMismatch()
        {
            this.Map.EmailTextBox.SendKeys("Incorrect@EmailFormat");
            this.Map.PasswordTextBox.SendKeys("Password");
            this.Map.ConfirmPasswordTextBox.SendKeys("WRONG");
        }

        //Register with a password without required characters
        public void PasswordComplexity()
        {
            this.Map.EmailTextBox.SendKeys("TestEmail001@NFS.com");
            this.Map.PasswordTextBox.SendKeys("Pword");
            this.Map.ConfirmPasswordTextBox.SendKeys("Pword");
        }

        //Register correct email format and passwords but missmatch email with Workspace
        public void CorporateEmailMismatch()
        {
            this.Map.EmailTextBox.SendKeys("TestEmail001@NFS.com");
            this.Map.PasswordTextBox.SendKeys("Welcome1@@@");
            this.Map.ConfirmPasswordTextBox.SendKeys("Welcome1@@@");
        }

        //Register correct email format and passwords with an un registered corpoerate Email address
        public void UnregisteredCorporateEmail()
        {
            this.Map.EmailTextBox.SendKeys(unregisteredCorporateEmail);
            this.Map.PasswordTextBox.SendKeys("Welcome1@@@");
            this.Map.ConfirmPasswordTextBox.SendKeys("Welcome1@@@");
        }
        //Register correct email format and passwords with a registered corpoerate Email address
        public void RegisteredCorporateEmail()
        {
            this.Map.EmailTextBox.SendKeys(registeredCorporateEmail);
            this.Map.PasswordTextBox.SendKeys("Welcome1@@@");
            this.Map.ConfirmPasswordTextBox.SendKeys("Welcome1@@@");
        }
        //Check Login Link
        public void LoginLink()
        {
            this.Map.LoginLink.Click();
            
        }
    }
}
