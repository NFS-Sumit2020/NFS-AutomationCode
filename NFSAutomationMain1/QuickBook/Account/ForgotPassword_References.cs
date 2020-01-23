using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace QuickBook.Account
{
    public class ForgotPassword_References
    {
         private readonly IWebDriver driver;

        //Init driver
        public ForgotPassword_References(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement UserNameTextBox
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='Username']"));
            }
        }
        public IWebElement EmailTestBox
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='Email']"));
            }
        }
        public IWebElement ForgotPasswordButton
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='btnForgotPassword']"));
            }
        }
        public IWebElement LoginLink
        {
            get
            {
                return this.driver.FindElement(By.XPath("/html/body/div/section/form/div/div[5]/div/div/a"));
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
