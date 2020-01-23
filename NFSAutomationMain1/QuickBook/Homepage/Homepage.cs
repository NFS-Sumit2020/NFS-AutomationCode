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
using QuickBook.MyBookings;
using QuickBook.Utilities;
using QuickBook.Login;

namespace QuickBook.Homepage
{
    public class HomepageMain
    {

        private IWebDriver driver;
    
        protected HomepageReferences Map
        {
            get
            {
                return new HomepageReferences(this.driver);
            }
        }

        

        public HomepageMain(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void Wait()
        {
            this.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        public void SelectProperty()
        {
            this.Map.propertydrop.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2000);
            this.Map.property.Click();
        }

        public void SelectArea()
        {
            this.Map.areadrop.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2000);
            this.Map.Area.Click();
        }

        public void SelectResourceType()
        {
            this.Map.Resourcetypedropdown.Click();
            Thread.Sleep(2000);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2000);
            this.Map.ResourceType.Click();
          }

          public void SelectLayout()
          {
              var layoutType = this.Map.RoomLayout;
              var selectlayout = new SelectElement(layoutType);
              driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2000);
              selectlayout.SelectByIndex(0);
          }

          public void NextMonth()
          {
              this.Map.CalendarNext.Click();
          }

          public void PreviousMonth()
          {
              this.Map.CalendarPrevious.Click();
          }

         /* public void SelectDate()
          {
              
              //this.Map.Datepicker1.Click();
              if (this.Map.Datepicker1.Displayed)
              {
                  this.Map.Datepicker1.Click();
              }
              else
              {
                  NextMonth();
                  this.Map.Datepicker1.Click();
              }
          }*/

          public void SelectDate()
          {
           string today = this.Map.getcurrentdate.Text;
           int todayInt = Convert.ToInt32(today);
           //Console.WriteLine("Today: " + today);
           //Console.WriteLine("Today Int: " + todayInt);
           if (todayInt <= 31)
           {
               this.Map.Datepicker1.Click();
           }
           else
           {
               NextMonth();
               this.Map.Datepicker1.Click();
           }
          }



          public void SelectTime()
          {
              this.Map.timedropdown.Click();
              var time = this.Map.Time;
              var selectTime = new SelectElement(time);
              selectTime.SelectByValue("8.30");
          }

          public void SelectDuration()
          {
             
              var duration = this.Map.Duration;
              var selectduration = new SelectElement(duration);
              selectduration.SelectByIndex(12);
          }

          public void EnterCapacity()
          {
              this.Map.Capacity.Click();
              this.Map.Capacity.SendKeys(Keys.Control+"a");
              driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2000);
              Thread.Sleep(2000);
              this.Map.Capacity.SendKeys("5");
          }

          public void SearchResource()
          {
              driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2000);
              SelectProperty();
              driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2000);
              Thread.Sleep(3000);
              SelectArea();
              driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2000);
             // Thread.Sleep(6000);
            //  SelectResourceType();
              driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(4000);
              SelectLayout();
              driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2000);
             // NextMonth();
             // driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2000);
              SelectDate();
              driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2000);
              SelectTime();
              driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2000);
              SelectDuration();
              driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2000);
              EnterCapacity();
              driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2000);
              this.Map.FindButton.Click();
          }

        /* 
         * MS's can also be used. But using GG's from Line 536.
         * public void ResetSearch()
          {
              SelectProperty();
              SelectArea();
              SelectResourceType();
              SelectLayout();
              NextMonth();
              SelectDate();
              SelectTime();
              SelectDuration();
              EnterCapacity();
              this.Map.ResetButton.Click();
          }*/

          public void time()
          {
              this.Map.differentTime.Click();

          }

          public Boolean IsElementVisible(IWebElement element)
          {
              Boolean result = false;
              try
              {
                  if (element.Displayed)
                  {
                      result = true;
                  }
                 // Console.WriteLine(result);  
              }

              catch (Exception e)
              {
                  return false;
              }
              return result;
          }

        public void SelectResource()
        {
            LoginMain login = new LoginMain(this.driver);
            SearchResource();
            Thread.Sleep(2000);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            try
            {

                this.Map.exactmatch.Click();

            }
            catch (WebDriverException e)
            {

                IList<IWebElement> selectElements = driver.FindElements(By.ClassName("available"));
                IEnumerator<IWebElement> enumerator = selectElements.GetEnumerator();
                bool hasNext = enumerator.MoveNext();
                while (hasNext)
                {
                    IWebElement i = enumerator.Current;
                    login.Wait();
                    i.Click();
                    login.Wait();
                    if (this.Map.resourceselected.Displayed)
                    {
                        break;
                    }
                    else
                    {
                        hasNext = enumerator.MoveNext();
                    }

                }
                enumerator.Dispose();

                Console.WriteLine("Exact match was not Found, but other available time was selected");

            }

        }


        public void resourceselectedvalidator()

        {
            if (this.Map.resourceselected.Displayed)
            {
                Console.WriteLine("Pass");
               
            }
            else if (this.Map.noresourceselected.Displayed)
            {
                Console.WriteLine("Fail, because no resource was selected.");
            }

        }

        public void MultiLocationBookingButton()
        {
            this.Map.MultiLocationBookingButton.Click();
        }
         
          

          public void NextButton()
          {
              this.Map.homepagenextbutton.Click();
          }




        // GG's Code BOC

          //Click on the User Name Link
          public void UserNameLink()
          {
              this.Map.UserNameLink.Click();
              Wait();
          }

          //Click on USerName Link then MyProfile Link
          public void MyProfleLink()
          {
              UserNameLink();
              this.Map.MyProfileLink.Click();

          }

          //Select No on Navigation to My Profile
          public void MyProfileNo()
          {
              this.Map.UserNameLink.Click();
              this.Map.MyProfileLink.Click();
              this.Map.NavigateNo.Click();
              Wait();
          }
          //Select Yes on Navigation to My Profile
          public void MyProfileYes()
          {

              this.Map.UserNameLink.Click();
              this.Map.MyProfileLink.Click();
              this.Map.NavigateYes.Click();
              Wait();
        }//PrimaryPropertyId



        //Log out from UserName Link
        public void LogOut()
          {

              this.Map.UserNameLink.Click();
              this.Map.LogOutLink.Click();
              Wait();
          }

          //Change Property DropDown
          public Boolean propertyChange = true;
          public string newProperty = "NULL";
          public string oldProperty = "NULL";
          public void ChangePropertySelection()
          {

              var dropDownSelected = this.Map.PropertyDropDownSelected.GetAttribute("value");
              oldProperty = dropDownSelected;
              this.Map.PropertyDropDownIcon.Click();
              IWebElement allOptions = this.Map.PropertyDropDownList;
              IList<IWebElement> options = allOptions.FindElements(By.TagName("li"));
              foreach (IWebElement option in options)
              {
                  if (option.Text.Equals(dropDownSelected))
                  {
                      //Do nothing - Next
                      propertyChange = false;
                      newProperty = option.Text.ToString();
                  }
                  else
                  {
                      newProperty = option.Text.ToString();
                      option.Click();
                      break;
                  }
              }
          }


          //Change Area DropDown
          public Boolean areaChange = true;
          public string newArea = "NULL";
          public void ChangeAreaSelection()
          {

              this.Map.AreaDropDownIcon.Click();
              IWebElement allOptions = this.Map.AreaDropDownList;
              IList<IWebElement> options = allOptions.FindElements(By.ClassName("tree-title"));
              foreach (IWebElement option in options)
              {
                  if (option.Text.Equals("Area"))
                  {
                      //Do nothing - Next
                      areaChange = false;
                      newArea = "No Selection";
                  }
                  else
                  {
                      newArea = option.Text.ToString();
                      option.Click();
                      break;
                  }
              }
          }
          //Change Resource Type DropDown
          public Boolean resourceTypeChange = true;
          public string newResourceType = "NULL";
          public string oldResourceType = "NULL";
          public void ChangeResourceTypeSelection()
          {

              var dropDownSelected = this.Map.ResourceTypeDropDownSelected.GetAttribute("value");
              oldResourceType = dropDownSelected;
              this.Map.ResourceTypeDropDownIcon.Click();
              IWebElement allOptions = this.Map.ResourceTypeDropDownList;
              IList<IWebElement> options = allOptions.FindElements(By.TagName("li"));
              foreach (IWebElement option in options)
              {
                  if (option.Text.Equals(dropDownSelected))
                  {
                      //Do nothing - Next
                      resourceTypeChange = false;
                      newResourceType = option.Text.ToString();
                  }
                  else
                  {
                      newResourceType = option.Text.ToString();
                      option.Click();
                      break;
                  }
              }
          }
          //Change Layout DropDown
          public Boolean layoutChange = true;
          public string newLayout = "NULL";
          public string oldLayout = "NULL";
          public void ChangeLayoutSelection()
          {

              var dropDown = new SelectElement(this.Map.LayoutDropDown);
              var dropDownSelected = dropDown.SelectedOption.Text;
              oldLayout = dropDownSelected;
              SelectElement allOptions = new SelectElement(this.Map.LayoutDropDown);
              IList<IWebElement> options = allOptions.Options;
              foreach (IWebElement option in options)
              {
                  if (option.Text.Equals(dropDownSelected))
                  {
                      //Do nothing - Next
                      layoutChange = false;
                      newLayout = option.Text.ToString();
                  }
                  else
                  {
                      newLayout = option.Text.ToString();
                      option.Click();
                      break;
                  }
              }
          }

          //DATE CALENDAR FUNCTIONS
          //Click calendar back
          public string calenderPastMonthException = "NULL";
          public void CalendarChangeMonthBack()
          {

              var currentMonth = DateTime.Now.ToString("MMMM");
              this.Map.CalendarBack.Click();
          }
          //Click calendar forward
          public void CalendarChangeMonthForward()
          {

              var currentMonth = DateTime.Now.ToString("MMMM");
              this.Map.CalendarForward.Click();
          }

          public void CalendarSelectNextDay()
          {

              if (this.Map.CalendarNextDay.Displayed)
              {
                  this.Map.CalendarNextDay.Click();
              }
              else
              {
                  CalendarChangeMonthForward();
                  this.Map.CalendarNextDay.Click();
              }
          }
          //Calendar past day select
          public string calendarPastDayValidation = "NULL";
          public void CalendarSelectPastDay()
          {

              if (this.Map.CalendarPastDay.Displayed)
              {
                  this.Map.CalendarPastDay.Click();
              }
              else
              {
                  //No possible past days displayed
                  calendarPastDayValidation = "No possible past days available";
              }
          }
          //DATE CALENDAR FUNCTIONS END
          //Start Time change to past
          public void StartTimePast()
          {
              this.Map.StartTimeDropDown.Click();
              this.Map.StartTimeSelectInvalid.Click();
          }
          //Start Time change to past and return after validation
          public string oldStartTime = "NULL";
          public void StartTimePastReturn()
          {

              string dropDownSelected = this.Map.StartTimeDropDown.GetAttribute("value");
              oldStartTime = dropDownSelected;
              this.Map.StartTimeDropDown.Click();
              this.Map.StartTimeSelectInvalid.Click();
              this.Map.StartTimeValidationButton.Click();
          }
          //Start Time change to 9am
          public string newStartTime = "NULL";
          public void StartTimeChange()
          {

              string dropDownSelected = this.Map.StartTimeDropDown.GetAttribute("value");
              Console.WriteLine(dropDownSelected);
              oldStartTime = dropDownSelected;
              this.Map.StartTimeDropDown.Click();
              this.Map.StartTimeSelect9AM.Click();
              string dropDownSelected2 = this.Map.StartTimeDropDown.GetAttribute("value");
              Console.WriteLine(dropDownSelected2);
              newStartTime = dropDownSelected2;
          }

          //Duration filter check
          public void DurationDropDown()
          {
             
              this.Map.DurationDropDown.Click();
          }

          //Duration Change to first valid time
          public string oldDuration = "NULL";
          public string newDuration = "NULL";
          public void ChangeDurationSelection()
          {
             
              var dropDown = new SelectElement(this.Map.DurationDropDown);
              var dropDownSelected = dropDown.SelectedOption.Text;
              oldDuration = dropDownSelected;
              SelectElement allOptions = new SelectElement(this.Map.DurationDropDown);
              IList<IWebElement> options = allOptions.Options;
              foreach (IWebElement option in options)
              {
                  if (option.Text.Equals(dropDownSelected))
                  {
                      //Do nothing - Next
                  }
                  else if (option.Text.Equals("Duration"))
                  {
                      //DO nothing - Next
                  }
                  else
                  {
                      newDuration = option.Text.ToString();
                      option.Click();
                      break;
                  }
              }
          }

          public int oldParticipantsValue = 0;
          public int newParticipantsValue = 0;
          public void ChangeParticipantsValue()
          {
             
              var currentValue = this.Map.ParticipantsSearchValue.GetAttribute("value");
              if (currentValue == "2")
              {
                  this.Map.ParticipantsSearchValue.SendKeys(Keys.Backspace);
                  this.Map.ParticipantsSearchValue.SendKeys("3");
              }
              else
              {
                  this.Map.ParticipantsSearchValue.SendKeys(Keys.Backspace);
                  this.Map.ParticipantsSearchValue.SendKeys("2");
              }
              var newValue = this.Map.ParticipantsSearchValue.GetAttribute("value");
              oldParticipantsValue = Int32.Parse(currentValue);
              newParticipantsValue = Int32.Parse(newValue);
          }

          //Click on Reset Button
          public void ResetSearch()
          {
              this.Map.ResetButton.Click();
          }


          //CHECK IF ATTRIBUTE IS PRESENT - CAN BE USED WHEREVER
          public Boolean isAttributePresent(IWebElement element, String attribute)
          {
              Boolean result = false;
              try
              {
                  String value = element.GetAttribute(attribute);
                  if (value != null)
                  {
                      result = true;
                  }
              }
              catch (Exception e) { }
              return result;
          }
          //CHECK IF ELEMENT IS PRESENT _ CAN BE USED WHEREVER
          public Boolean isElementVisible(IWebElement element)
          {
              Boolean result = false;
              try
              {
                  if (element.Displayed)
                  {
                      result = true;
                  }
              }
              catch (Exception e) { }
              return result;
          }

          //CHECK IF ATTRIBUTE IS PRESENT _ CAN BE USED WHEREVER
          public Boolean isElementAttributePresent(IWebElement element, string attribute)
          {
              Boolean result = false;
              try
              {
                  string check = element.GetAttribute(attribute);
                  if (check != null)
                  {
                      result = true;
                  }
              }
              catch (Exception e) { }
              return result;
          }

          //SET SEARCH CRITERIA AND SEARCH FOR NON RECURRING
          public void SinglePropertySearch()
          {
              CalendarSelectNextDay();
              StartTimeChange();
              this.Map.FindButton.Click();
          }
          //SELECT FIRST AVAILABLE RESOURCE
          public void SinglePropertySelect()
          {
             
              this.Map.FirstResourceCheckBox.Click();
          }
          //CLICK FIRST RESOURCE LIST INFO ICON
          public void ResourceListInformationIcon()
          {
             
              this.Map.ResourceListInformationIcon1.Click();
          }
          //CLICK FIRST SELECTED RESOURCE LIST INFO ICON
          public void SelectedResourceInformationIcon()
          {
             
              this.Map.SelectedResourecInformationIcon1.Click();
          }
          //REMOVE FIRST SELECTED RESOURCE - openes popup
          public void RemoveSelectedResource()
          {
             
              this.Map.SelectedResourceRemove.Click();
          }
          //REMOVE FIRST SELECTED RESOURCE - select NO on popup
          public void RemoveSelectedResourceNo()
          {
              
              this.Map.SelectedResourceRemove.Click();
              this.Map.RemoveResourcePopupNo.Click();
          }
          //REMOVE FIRST SELECTED RESOURCE - select YES on popup
          public void RemoveSelectedResourceYes()
          {
              
              this.Map.SelectedResourceRemove.Click();
              this.Map.RemoveResourcePopupYes.Click();
          }

          public void ChangeParticipants()
          {
             
              this.Map.MySelectionParticipantsIcon1.Click();
          }
          public void ChangeParticipantsNO()
          {
             
              this.Map.MySelectionParticipantsIcon1.Click();
              int currentValue = Int32.Parse(this.Map.ChangeParticpantsInput.GetAttribute("value"));
              string newValue = (currentValue + 1).ToString();
              this.Map.ChangeParticpantsInput.SendKeys(newValue);
          }
          public void ChangeParticipantsYES()
          {
              
              this.Map.MySelectionParticipantsIcon1.Click();
          }

        //GG's EOC
        public void FindBTN()
        {
            this.Map.FindButton.Click();
        }


    }
    }

