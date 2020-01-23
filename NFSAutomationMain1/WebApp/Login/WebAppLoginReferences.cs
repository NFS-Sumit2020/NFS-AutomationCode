using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace WebApp.Login
{
    public class WebAppLoginReferences
    {
        private readonly IWebDriver driver;

        public WebAppLoginReferences(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement UserNameTextBox
        {
            get
            {
                return this.driver.FindElement(By.Id("loginMain_UserName"));
            }
        }

        public IWebElement PasswordTextBox
        {
            get
            {
                return this.driver.FindElement(By.Id("loginMain_Password"));
            }
        }

        public IWebElement SubmitButton
        {
            get
            {
                return this.driver.FindElement(By.Id("loginMain_LoginButton"));
            }
        }

        public IWebElement LogoutButton
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_lblLogout"));
            }
        }

        public IWebElement ReLogInButton
        {
            get
            {
                return this.driver.FindElement(By.Id("btRelogin"));
            }
        }
    }


}