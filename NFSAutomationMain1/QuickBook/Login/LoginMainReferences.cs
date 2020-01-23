using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace QuickBook.Login
{
    public class LoginMainReferences
    {
        private readonly IWebDriver driver;

        public LoginMainReferences(IWebDriver driver)
        {
            this.driver = driver;

        }

        public IWebElement UserNameTextBox
        {
            get
            {
                return this.driver.FindElement(By.Id("Username"));
            }
        }

        public IWebElement PasswordTextBox
        {
            get
            {
                return this.driver.FindElement(By.Id("Password"));
            }
        }

        public IWebElement LoginButton
        {
            get
            {
                return this.driver.FindElement(By.Id("btnLogin"));
            }
        }

        public IWebElement RegisterLinkButton
        {
            get
            {
                return this.driver.FindElement(By.XPath("/html/body/div/section/form/div/div[5]/div/div[1]"));
            }
        }

        public IWebElement ForgotPasswordButton
        {
            get
            {
                return this.driver.FindElement(By.XPath("/html/body/div/section/form/div/div[5]/div/div[2]"));
            }
        }

        public IWebElement RegisterEmailTextBox
        {
            get
            {
                return this.driver.FindElement(By.Id("Email"));
            }
        }

        public IWebElement RegisterPasswordTextBox
        {
            get
            {
                return this.driver.FindElement(By.Id("Password"));
            }
        }

        public IWebElement RegisterConfirmPasswordTextBox
        {
            get
            {
                return this.driver.FindElement(By.Id("ConfirmPassword"));
            }
        }

        public IWebElement RegisterButton
        {
            get
            {
                return this.driver.FindElement(By.Id("btnRegister"));
            }
        }

        public IWebElement LogoutButton
        {
            get
            {
                return this.driver.FindElement(By.Id("btnLogout"));
            }
        }

        public IWebElement loadingimage
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='loading']/div/img"));
            }
        }

        public IWebElement RegisterLink
        {
            get
            {
                return this.driver.FindElement(By.XPath("/html/body/div/section/form/div/div[5]/div/div[1]/a"));
            }
        }

        public IWebElement ForgotPasswordLink
        {
            get
            {
                return this.driver.FindElement(By.XPath("/html/body/div/section/form/div/div[5]/div/div[2]/a"));
            }
        }


    }
}
