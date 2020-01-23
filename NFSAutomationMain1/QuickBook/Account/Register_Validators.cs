using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace QuickBook.Account
{
    public class Register_Validators
    {
        private readonly IWebDriver driver;

        //Init driver
        public Register_Validators(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement NoEmailValidator
        {
            get
            {
                return this.driver.FindElement(By.XPath("/html/body/div/section/form/div/div[2]/div/div/span[2]/span/span"));
            }
        }
        public IWebElement NoPasswordValidator
        {
            get
            {
                return this.driver.FindElement(By.XPath("/html/body/div/section/form/div/div[3]/div/div/span[2]/span/span"));
            }
        }
        public IWebElement NoConfirmPasswordValidator
        {
            get
            {
                return this.driver.FindElement(By.XPath("/html/body/div/section/form/div/div[4]/div/div/span[2]/span/span"));
            }
        }
        public IWebElement PasswordMatchValidator
        {
            get
            {
                return this.driver.FindElement(By.XPath("/html/body/div/section/form/div/div[4]/div/div/span[2]/span/span"));
            }
        }
        public IWebElement PasswordComplexityValidator
        {
            get
            {
                return this.driver.FindElement(By.XPath("/html/body/div/section/form/div/span/div"));
            }
        }
        public IWebElement CorporateEmailFailValidator
        {
            get
            {
                return this.driver.FindElement(By.XPath("/html/body/div/section/form/div/div[2]/div/span"));
            }
        }
        public IWebElement EmailAlreadyExistsValidator
        {
            get
            {
                return this.driver.FindElement(By.XPath(""));
            }
        }
        public IWebElement EmailRegisterSuccessValidator
        {
            get
            {
                return this.driver.FindElement(By.XPath(""));
            }
        }
        //LOGIN BUTTON FROM LOGIN PAGE
        public IWebElement LoginButton
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='btnLogin']"));
            }
        }
    }
}
