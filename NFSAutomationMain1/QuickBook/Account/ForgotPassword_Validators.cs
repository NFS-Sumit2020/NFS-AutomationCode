using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace QuickBook.Account
{
    public class ForgotPassword_Validators
    {
        private readonly IWebDriver driver;

        //Init driver
        public ForgotPassword_Validators(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement NoUserNameValidator
        {
            get
            {
                return this.driver.FindElement(By.XPath("/html/body/div/section/form/div/div[2]/div/div/span[2]/span/span"));
            }
        }
        public IWebElement NoEmailValidator
        {
            get
            {
                return this.driver.FindElement(By.XPath("/html/body/div/section/form/div/div[3]/div/div/span[2]/span/span"));
            }
        }
        public IWebElement EmailFormatValidator
        {
            get
            {
                return this.driver.FindElement(By.XPath("/html/body/div/section/form/div/div[3]/div/div/span[2]/span/span"));
            }
        }
        public IWebElement InformationMismatchValidator
        {
            get
            {
                return this.driver.FindElement(By.XPath("/html/body/div/section/form/div/div[2]/div/span"));
            }
        }
        public IWebElement InformationMatchValidator
        {
            get
            {
                return this.driver.FindElement(By.XPath(""));
            }
        }

        //LOGIN BUTTON FROM LOGIN PAGE
        public IWebElement LoginButtonValidator
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='btnLogin']"));
            }
        }
    }
}
