using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using OpenQA.Selenium;

namespace WebApp.Modules.Help
{
    public class HelpReferences
    {
        private readonly IWebDriver driver;

        public HelpReferences(IWebDriver driver)
        {
            this.driver = driver;
        }

        //START
        public IWebElement HelpIcon
        {
            get
            {
                return this.driver.FindElement(By.Id("HelpSpan"));
            }
        }

        public IWebElement UserGuidesTab
        {
            get
            {

                return this.driver.FindElement(By.Id("ctl00_liUserGuides"));
            }
        }

        public IWebElement UserGuidesLink
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_sub_UserGuides"));
            }
        }

        public IWebElement AboutTab
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='ctl00_lblAbout']"));
            }
        }

        public IWebElement AboutLink
        {
            get
            {
                return this.driver.FindElement(By.Id("ctl00_sub_About"));
            }
        }
        //END
    }
}
