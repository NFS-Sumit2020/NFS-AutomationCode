using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace QuickBook.MyProfile
{
   public class MyProfileReferences
    {
       private readonly IWebDriver driver;

       public MyProfileReferences(IWebDriver driver)
       {
           this.driver = driver;
       }

       public IWebElement MyProfileIcon
       {
           get
           {
              return this.driver.FindElement(By.XPath("//*[@id='drop-down']/li[1]"));
           }
       }

       public IWebElement MyProfileButton
       {
           get
           {
               return this.driver.FindElement(By.Id("myProfile"));
           }
       }

       public IWebElement unsavedDataconfirmationYes
       {
           get
           {
               return this.driver.FindElement(By.Id("btnConfirmationYes"));
           }
       }

       public IWebElement unsavedDataconfirmationNo
       {
           get
           {
               return this.driver.FindElement(By.Id("btnConfirmationNo"));
           }
       }

       public IWebElement MyPrimaryproperty
       {
           get
           {
               return this.driver.FindElement(By.Id("PrimaryPropertyId"));
           }
       }

       public IWebElement LanguagePreference
       {
           get
           {
               return this.driver.FindElement(By.Id("LanguagePreference"));
           }
       }

       public IWebElement InitialLanguage
       {
           get
           {
               return this.driver.FindElement(By.XPath("//*[@id='page-wrap']/section[2]/div[1]/div/div[2]/p[2]"));
           }
       }

      

       public IWebElement NewBookingButton
       {
           get
           {
               return this.driver.FindElement(By.XPath("//*[@id='page-wrap']/section[1]/div[4]/ul/li[1]/a"));
           }
       }

       public IWebElement MyBookingButton
       {
           get
           {
               return this.driver.FindElement(By.XPath("//*[@id='page-wrap']/section[1]/div[4]/ul/li[2]/a"));
           }
       }

       public IWebElement SuccessMessage
       {
           get
           {
               return this.driver.FindElement(By.XPath("//*[@id='btnDialogOK']"));
           }
       }

       public IWebElement MainPageProperty
       {
           get
           {
               return this.driver.FindElement(By.XPath("//*[@id='SinglePropertySearch']/div[1]/span/input"));
           }
       }

       public IWebElement Languagecode
       {
           get
           {
               return this.driver.FindElement(By.ClassName("prof-details fleft"));
           }
       }

       public IWebElement UserNameLink
       {
           get
           {
               return this.driver.FindElement(By.XPath("//*[@id='drop-down']/li[1]/span"));
           }
       }
       public IWebElement LogOutLink
       {
           get
           {
               return this.driver.FindElement(By.XPath("//*[@id='btnLogout']"));
           }
       }
       public IWebElement MyProfileLink
       {
           get
           {
               return this.driver.FindElement(By.XPath("//*[@id='myProfile']"));
           }
       }
       public IWebElement NavigateYes
       {
           get
           {
               return this.driver.FindElement(By.XPath("//*[@id='btnConfirmationYes']"));
           }
       }
       public IWebElement CancelButton
       {
           get
           {
               return this.driver.FindElement(By.XPath("//*[@id='page-wrap']/section[2]/div[1]/form/div/div[1]/div[3]/button[1]"));
           }
       }
       public IWebElement SaveButton
       {
           get
           {
               return this.driver.FindElement(By.XPath("//*[@id='page-wrap']/section[2]/div[1]/form/div/div[1]/div[3]/button[2]"));
           }
       }
       public IWebElement SaveOkButton
       {
           get
           {
               return this.driver.FindElement(By.XPath("//*[@id='btnDialogOK']"));
           }
       }
       public IWebElement PrimaryPropertyDropDown
       {
           get
           {
               return this.driver.FindElement(By.XPath("//*[@id='PrimaryPropertyId']"));
           }
       }
       public IWebElement LanguagePreferenceDropDown
       {
           get
           {
               return this.driver.FindElement(By.XPath("//*[@id='LanguagePreference']"));
           }
       }
       //Loading Icon
       public IWebElement LoadingIcon
       {
           get
           {
               return this.driver.FindElement(By.XPath("//*[@id='loading']/div"));
           }
       }

    }
}
