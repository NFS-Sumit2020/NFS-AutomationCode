using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using WebApp.Login;

namespace WebApp.Modules.Help
{
    public class HelpMain
    {
        private IWebDriver driver;
        private WebAppLoginMain loginMain;

        //Init driver
        public HelpMain(IWebDriver driver)
        {
            this.driver = driver;
        }

        //Map references
        protected HelpReferences Map
        {
            get
            {
                return new HelpReferences(this.driver);
            }
        }

        //Navigate to Help Module
        public void AccessHelpModule()
        {
            loginMain.NavigateTo();
            loginMain.LogInSuccess();
            this.Map.HelpIcon.Click();
            Thread.Sleep(4000);
        }


    }
}
