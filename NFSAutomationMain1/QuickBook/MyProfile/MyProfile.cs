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
using QuickBook.Login;

namespace QuickBook.MyProfile
{
  public class MyProfile
    {
        private IWebDriver driver;
        private readonly string url = ConfigurationManager.AppSettings["URL"];

       protected MyProfileReferences Map
        {
            get
            {
                return new MyProfileReferences(this.driver);
            }
        }

       //Define Implicit Wait
       public void Wait(IWebDriver driver)
       {
           this.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
       }

       public MyProfile(IWebDriver driver)
       {
           this.driver = driver;
       }

     /*  public void NavigateTo()
       {
           this.driver.Navigate().GoToUrl(this.url);
       }*/

       public void MyProfileicon()
       {
           this.Map.MyProfileIcon.Click();
       }

       //Login functionality taken from Login.Login
       public void NavigateToInit()
       {
           LoginMain login = new LoginMain(this.driver);
           login.NavigateTo();
           login.LoginSuccess();
           //Add WAIT
           Thread.Sleep(5000);
       }

       //Login and Navigate to My Profile
       public void NavigateTo()
       {
           MyProfile browser = new MyProfile(this.driver);
           browser.NavigateToInit();
           this.Map.UserNameLink.Click();
           this.Map.MyProfileLink.Click();
           this.Map.NavigateYes.Click();
           Wait(this.driver);
       }
       //Navigate To without Logging In
       public void NavigateToNoLogin()
       {
           MyProfile browser = new MyProfile(this.driver);
           this.Map.UserNameLink.Click();
           this.Map.MyProfileLink.Click();
           this.Map.NavigateYes.Click();
           Wait(this.driver);
       }

       //Change Primary Property
       public string newPrimaryProperty = "NULL";
       public string oldPrimaryProperty = "NULL";
        public string primaryproperty = "Toronto - 'NEW'";
       public void PrimaryPropertyChange()
       {
           MyProfile browser = new MyProfile(this.driver);
           var dropDown = new SelectElement(this.Map.PrimaryPropertyDropDown);
           var dropDownSelected = dropDown.SelectedOption.Text;
           oldPrimaryProperty = dropDownSelected;
           SelectElement allOptions = new SelectElement(this.Map.PrimaryPropertyDropDown);
           IList<IWebElement> options = allOptions.Options;
           foreach (IWebElement option in options)
           {
               if (option.Text.Equals(dropDownSelected))
               {
                   //Do nothing - Next
               }
               else
               {
                   newPrimaryProperty = option.Text.ToString();
                   option.Click();
                   break;
               }
           }
       }
        public void IsPrimarypropertySelect()//check primary property select or not 
        {
            MyProfile browser = new MyProfile(this.driver);
            var dropDown = new SelectElement(this.Map.PrimaryPropertyDropDown);
            var dropDownSelected = dropDown.SelectedOption.Text;
            Thread.Sleep(1000);


            if (primaryproperty == dropDownSelected)
            {
                Console.WriteLine("Primary property selected");
            }
            else
            {
                Console.WriteLine("Primary property not selected");
            }
            Thread.Sleep(1000);
        }


        //Change Language Preference
        public string oldLanguagePreference = "NULL";
       public string newLanguagePreference = "NULL";
       public void LanguagePreferenceChange()
       {
           MyProfile browser = new MyProfile(this.driver);
           var dropDown = new SelectElement(this.Map.LanguagePreferenceDropDown);
           var dropDownSelected = dropDown.SelectedOption.Text;
           oldLanguagePreference = dropDownSelected;
           SelectElement allOptions = new SelectElement(this.Map.LanguagePreferenceDropDown);
           IList<IWebElement> options = allOptions.Options;
           foreach (IWebElement option in options)
           {
               if (option.Text.Equals(dropDownSelected))
               {
                   //Donothing - Next
               }
               else
               {
                   newLanguagePreference = option.Text.ToString();
                   option.Click();
                   break;
               }
           }
       }
       //Logout - needed to check saved data is actually saved
       public void MyProfileLogout()
       {
           MyProfile browser = new MyProfile(this.driver);
           this.Map.UserNameLink.Click();
           Thread.Sleep(1000);
           this.Map.LogOutLink.Click();
       }
       //Click Save
       public void ClickSave()
       {
           MyProfile browser = new MyProfile(this.driver);
           this.Map.SaveButton.Click();
       }
       //Click Save and OK
       public void ClickSaveOk()
       {
           MyProfile browser = new MyProfile(this.driver);
           this.Map.SaveButton.Click();
           Wait(this.driver);
           this.Map.SaveOkButton.Click();
           Wait(this.driver);
       }
       //Click Cancel
       public void ClickCancel()
       {
           MyProfile browser = new MyProfile(this.driver);
           this.Map.CancelButton.Click();
       }
      
  }
}
