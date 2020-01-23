using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace QuickBook.Account
{
    public class Register_References
    {
        private readonly IWebDriver driver;

        //Init driver
        public Register_References(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement EmailTextBox
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='Email']"));
            }
        }
        public IWebElement PasswordTextBox
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='Password']"));
            }
        }
        public IWebElement ConfirmPasswordTextBox
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='ConfirmPassword']"));
            }
        }
        public IWebElement RegisterButton
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='btnRegister']"));
            }
        }
        public IWebElement LoginLink
        {
            get
            {
                return this.driver.FindElement(By.XPath("/html/body/div/section/form/div/div[6]/div/div/a"));
            }
        }

        public IWebElement RegisterLink
        {
            get
            {
                return this.driver.FindElement(By.XPath("/html/body/div/section/form/div/div[5]/div/div[1]/a"));
            }
        }

    }
}
