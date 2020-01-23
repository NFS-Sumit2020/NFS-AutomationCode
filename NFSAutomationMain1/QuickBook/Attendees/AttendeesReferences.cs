using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace QuickBook.Attendees
{
    public class AttendeesReferences
        {

        private readonly IWebDriver driver;

        public AttendeesReferences(IWebDriver driver)
        {
            this.driver = driver;

        }

        public IWebElement attendeetestbox
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='InternalUser']"));
            }
        }

        public IWebElement SearchedAttendee
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[contains(@class, 'ui-autocomplete ui-front ui-menu ui-widget ui-widget-content')]//li[1]"));
            }
        }

        public IWebElement SelectedInternalAttendee
        {
            get
            {
                return this.driver.FindElement(By.Id("personGridPanel"));
            }
        }

        public IWebElement ExternalAttendeeSearchBox
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='ExternalUser']"));
            }
        }

        public IWebElement ExternalAttendeeLastName
        {
            get
            {
              return this.driver.FindElement(By.Id("ExternalUserModel_LastName"));
            }
        }

        public IWebElement ExternalAttendeeFirstName
        {
            get
            {
                return this.driver.FindElement(By.Id("ExternalUserModel_FirstName"));
            }
        }

        public IWebElement ExternalAttendeeEmail
        {
            get
            {
                return this.driver.FindElement(By.Id("ExternalUserModel_Email"));
            }
        }

        public IWebElement ExternalAttendeeCompany
        {
            get
            {
                return this.driver.FindElement(By.Id("ExternalUserModel_CompanyName"));
            }
        }

        public IWebElement ExternalAttendeeAddButton
        {
            get
            {
                return this.driver.FindElement(By.Id("btnAddExternalUser"));
            }
        }


        public IWebElement IAttendee
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='tblAttendees']"));
            }
        }

        public IWebElement ExternalAttendeeRole
        {
            get
            {

                return this.driver.FindElement(By.Name("extenalAttendeeList[1].BookingRoleId"));
                
            }
        }


         public IWebElement InternalAttendeeRole
        {
            get
            {

                return this.driver.FindElement(By.Name("[2].BookingRoleId"));
             
            }
        }

         public IWebElement InternalAttendeeResourceChange
         {
             get
             {
                 return this.driver.FindElement(By.Name("[2].ResourceId"));
             }
         }

         public IWebElement ExternalAttendeeResourceChange
         {
             get
             {
                 return this.driver.FindElement(By.Name("extenalAttendeeList[1].ResourceId"));
             }
         }

         public IWebElement AppointmentOrganiser
         {
             get
             {
                 return this.driver.FindElement(By.XPath("//*[@id='rowIA_2']/td[6]/label/span"));
             }
         }

         public IWebElement InternalAttendeeRemove
         {
             get
             {
                 return this.driver.FindElement(By.XPath("//*[@id='rowIA_2']/td[7]/a"));
             }
         }

         public IWebElement ExternalAttendeeRemove
         {
             get
             {
                 return this.driver.FindElement(By.XPath("//*[@id='rowEA_1']/td[6]/a[2]"));
             }
         }

         public IWebElement ExternalAttendeeEdit
         {
             get
             {
                 return this.driver.FindElement(By.XPath("//*[@id='rowEA_1']/td[6]/a[1]/img"));
             }
         }

         public IWebElement ExternalAttendeeEditUpdate
         {
             get
             {
                 return this.driver.FindElement(By.XPath("//*[@id='rowEA_1']/td[6]/a[1]"));
             }
         }

         public IWebElement ExternalAttendeeEditCancel
         {
             get
             {
                 return this.driver.FindElement(By.XPath("//*[@id='rowEA_1']/td[6]/a[2]"));
             }
         }

         public IWebElement ExternalAttendeeEditFirstName
         {
             get
             {
                 return this.driver.FindElement(By.XPath("//*[@id='txtVisitorFname']"));
             }
         }

         public IWebElement ExternalAttendeeEditLastName
         {
             get
             {
                 return this.driver.FindElement(By.XPath("//*[@id='txtVisitorLname']"));
             }
         }

         public IWebElement ExternalAttendeeEditEmail
         {
             get
             {
                 return this.driver.FindElement(By.XPath("//*[@id='txtVisitorEmail']"));
             }
         }

         public IWebElement ExternalAttendeeEditCompany
         {
             get
             {
                 return this.driver.FindElement(By.XPath("//*[@id='txtVisitorCompanyName']"));
             }
         }

         public IWebElement Externalattendee
         {
             get
             {
                 return this.driver.FindElement(By.Id("tblExternalAttendees1"));
             }
         }

    }
}
