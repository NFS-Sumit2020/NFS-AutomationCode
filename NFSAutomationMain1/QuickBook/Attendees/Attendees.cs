using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Threading;

namespace QuickBook.Attendees
{
   public class AttendeesMain
    {

       private IWebDriver driver;
       private readonly string ExternalVisitorEditedName = ConfigurationManager.AppSettings["externalvisitoreditedname"];
       private readonly string ExternalVisitorEditedLastName = ConfigurationManager.AppSettings["externalvisitoreditedlastname"];
       private readonly string ExtenalVisitorEditedEmail = ConfigurationManager.AppSettings["externalvisitoreditedemail"];
       private readonly string ExternalVisitorEditedCompany = ConfigurationManager.AppSettings["externalvisitoreditedcompany"];

        protected AttendeesReferences Map
        {
            get
            {
                return  new AttendeesReferences(this.driver);
            }
        }

        public AttendeesMain(IWebDriver driver)
        {
            this.driver = driver;
        }


       public void InternalAttendeeSearchbox(){

           this.Map.attendeetestbox.SendKeys("Test User6");
           Thread.Sleep(3000);
       }

       public void InternalAttendeeSelector()
       {
           this.Map.SearchedAttendee.Click();
       }

       public void AddingInternalAttendee()
       {
           InternalAttendeeSearchbox();
           InternalAttendeeSelector();
       }

       public void ExternalAttendeeSearchbox()
       {
           this.Map.ExternalAttendeeSearchBox.Click();
       }

       public void ExternalAttendeeLastName()
       {
           this.Map.ExternalAttendeeLastName.SendKeys("LastName");
       }

       public void ExternalAttendeeFirstName()
       {
           this.Map.ExternalAttendeeFirstName.SendKeys("FirstName");
       }

       public void ExternalAttendeeEmail(){
           this.Map.ExternalAttendeeEmail.SendKeys("ExternalEmail@ex.com");
       }

       public void ExternalAttendeeCompany(){
           this.Map.ExternalAttendeeCompany.SendKeys("Test Company");
       }

       public void ExternalAttendeeAddButton()
       {
           this.Map.ExternalAttendeeAddButton.Click();
       }

       public void AddingExternalAttendee()
       {
           ExternalAttendeeSearchbox();
           ExternalAttendeeLastName();
           ExternalAttendeeFirstName();
           ExternalAttendeeEmail();
           ExternalAttendeeCompany();
       }


       public string ChangedRole = "";
       public string previousRole = "";
       public void externalAttendeerole()
       {
           var role = new SelectElement (this.Map.ExternalAttendeeRole);
           previousRole = role.SelectedOption.Text;
           SelectElement selectrole = new SelectElement(this.Map.ExternalAttendeeRole);
           IList<IWebElement> options = selectrole.Options;
           foreach (IWebElement option in options)
           {
               if (option.Text.Equals(previousRole))
               {
                   // Go to next one 
               }
              else
               {
                  ChangedRole = option.Text;
                   option.Click();
                   break;
               }
           }
       }

       public string InternalAttendeeChangedRole = "";
       public string InternalAttendeePreviousRole = "";
       public void InternalAttendeeRole()
       {
           var InternalRole = new SelectElement(this.Map.InternalAttendeeRole);
           InternalAttendeePreviousRole = InternalRole.SelectedOption.Text;
           SelectElement internalRole = new SelectElement(this.Map.InternalAttendeeRole);
           IList<IWebElement> Internaloptions = internalRole.Options;
           foreach (IWebElement option in Internaloptions)
           {
               if (option.Text.Equals(InternalAttendeePreviousRole))
               {
                   //
               }
               else if (option.Text.Equals("Chief Participant")) 
               {

               }
               else
               {
                   InternalAttendeeChangedRole = option.Text;
                   option.Click();
                   break;
               }
           }

       }

       public void appointmentorganiser()
       {
           this.Map.AppointmentOrganiser.Click();
       }

       public void RemovingInternalAttendee()
       {
           this.Map.InternalAttendeeRemove.Click();
       }


       public void RemovingExternalAttendee()
       {
           this.Map.ExternalAttendeeRemove.Click();
       }

       public void ExternalAttendeeEditButton()
       {
           this.Map.ExternalAttendeeEdit.Click();
       }

       public void ExternalAttendeeEditFirstName()
       {
           this.Map.ExternalAttendeeEditFirstName.Clear();
           this.Map.ExternalAttendeeEditFirstName.SendKeys(ExternalVisitorEditedName);
       }

       public void ExternalAttendeeEditLastName()
       {
           this.Map.ExternalAttendeeEditLastName.Clear();
           this.Map.ExternalAttendeeEditLastName.SendKeys(ExternalVisitorEditedLastName);
       }

       public void ExternalAttendeeEditEmail()
       {
           this.Map.ExternalAttendeeEditEmail.Clear();
           this.Map.ExternalAttendeeEditEmail.SendKeys(ExtenalVisitorEditedEmail);
       }

       public void ExternalAttendeeEditCompany()
       {
           this.Map.ExternalAttendeeEditCompany.Clear();
           this.Map.ExternalAttendeeEditCompany.SendKeys(ExternalVisitorEditedCompany);
       }

       public void ExternalAttendeeEditUpdateButton()
       {
           this.Map.ExternalAttendeeEditUpdate.Click();
       }

       public void ExternalAttendeeEditCancelButton()
       {
           this.Map.ExternalAttendeeEditCancel.Click();
       }






       
    }
}
