using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using System.Threading;
using System.Configuration;

namespace WebApp.Login
{
    public class WebAppLoginMain
    {
        private IWebDriver driver;

        private readonly string WebAppURL = ConfigurationManager.AppSettings["WebAppURL"];
        private readonly string userName = ConfigurationManager.AppSettings["UserName"];
        private readonly string password = ConfigurationManager.AppSettings["Password"];

        //Map reference from LoginReferences
        protected WebAppLoginReferences Map
        {
            get
            {
                return new WebAppLoginReferences(this.driver);
            }
        }
        //Driver init
        public WebAppLoginMain(IWebDriver driver)
        {
            this.driver = driver;

        }

        //Navigate to configured Workspace system
        public void NavigateTo()
        {
            this.driver.Navigate().GoToUrl(this.WebAppURL);   //http://localhost/AutomationTestingBLG
            this.driver.Manage().Window.Maximize();
        }

        //Successful login with username and password configured in AppSettings
        public void LogInSuccess()
        {
            this.Map.UserNameTextBox.SendKeys(userName);
            Thread.Sleep(1000);
            this.Map.PasswordTextBox.SendKeys(password);
            Thread.Sleep(1000);
            this.Map.SubmitButton.Click();
        }

        //Unsuccessful login using correct username and incorrect password
        public void LogInUserNameFail()
        {
            this.Map.UserNameTextBox.SendKeys(userName);
            Thread.Sleep(1000);
            this.Map.PasswordTextBox.SendKeys("Incorrect");
            Thread.Sleep(3000);
            this.Map.SubmitButton.Click();
        }

        //Unsuccessful login using incorrect username and correct password
        public void LogInPasswordFail()
        {
            this.Map.UserNameTextBox.SendKeys("Incorrect");
            Thread.Sleep(1000);
            this.Map.PasswordTextBox.SendKeys(password);
            Thread.Sleep(3000);
            this.Map.SubmitButton.Click();
        }

        //Successfull logout
        public void LogoutSuccess()
        {
            Thread.Sleep(2000);
            this.Map.LogoutButton.Click();
        }

        //Check Re-Login button
        public void ReLogInNavigation()
        {
            Thread.Sleep(2000);
            this.Map.ReLogInButton.Click();
            Thread.Sleep(2000);
        }
    }
}
