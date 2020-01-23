using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using QuickBook.Login;
using QuickBook.Booking;

namespace QuickBook.EditBooking
{
    public class EditBookingMain
    {
        private IWebDriver driver;

        protected EdiBookingReference Map
        {
            get
            {
                return new EdiBookingReference(this.driver);
            }
        }
        public EditBookingMain(IWebDriver driver)
        {
            this.driver = driver;
        }
        /*  public void EditBookingResource()
          {
            // EditBooking broswer = new EditBooking(this.driver);
              this.Map.EditIcon.Click();
              Thread.Sleep(2000);
              this.Map.EditBookingsBurgerBar.Click();
              Thread.Sleep(3000);
              this.Map.ChangeResourceDropdown.Click();
              Thread.Sleep(2500);
              this.Map.ChangeResourceButton.Click();
          }*/



        public void EditBookingPencil()
        {
            this.Map.EditIcon.Click();
        }

        public void Private_CheckBox()
        {
            this.Map.PrivateCheckBox.Click();
        }

        public void ISPrivate_Booking()//Check if its checked or not
        {
            Boolean aa = this.Map.PrivateCheckBox.Selected.Equals(true);

            if (aa.Equals(true))
            {
                Console.WriteLine(" Private Booking ");
            }
            else
            {
                this.Map.PrivateCheckBox.Click();
            }
            
        }

        public void CloseButton()
        {
            this.Map.CloseButton.Click();
        }
        public void EditBookingBurgerButton()
        {
            this.Map.EditBookingsBurgerBar.Click();
        }
        public void EditResourceDropdownSelectChangeResource()
        {
            this.Map.ChangeResourceDropDown.Click();
        }
        public void ChangeResourceBTN()
        {

            if (this.Map.Checkedbox.Selected)
            {
                this.Map.ChangeResourceButton.Click();
            }
            else
            {
                this.Map.Checkedbox.Click();
                this.Map.ChangeResourceButton.Click();
            }
        }
        public void ExactMatchSelect()
        {
            this.Map.ExactMatch.Click();
        }
        public void Next()
        {
            this.Map.NextButton.Click();
        }
        // public void Finish()
        // {
        //   this.Map.Confirmchange.Click();
        //}
        public void SelectAddResource()
        {
            this.Map.AddResource.Click();
        }
        public void FinishBTN()
        {
            this.Map.FinishButton.Click();
        }
        public void Finding()
        {
            this.Map.Finder.Click();
        }
        public void RemoveResource()
        {
            this.Map.RemoveResource.Click();
        }
        public void DeleteIT()
        {
            this.Map.Removetheroom.Click();
        }
        public void YesButton()
        {
            this.Map.Yes.Click();
        }
        public void SaveBooking()
        {
            this.Map.Save.Click();
        }
        public void CalendarDates()
        {
            var v1 = this.Map.DateRandom;
            var v2 = new SelectElement(v1);
            v2.SelectByText("29");
            //SelectElement v2 = v1.SelectByText("29");

        }

        public void DateChager()
        {
            this.Map.ModifyDate.Click();
        }

        public void ModifyCal()
        {
            string today = this.Map.CurrentDay.Text;
            int todayInt = Convert.ToInt32(today);
            Console.WriteLine("Today: " + today);
            Console.WriteLine("Toda int: " + todayInt);

            if (todayInt < 31)
            {
                int nextActual = todayInt + 1;
                string nextString = Convert.ToString(nextActual);
                string days = this.Map.check.Text;
                if (days.Contains(nextString))
                {
                    this.Map.MyBookingsNextDay(nextString).Click();
                }
                else
                {
                    this.Map.CalendarChangeMonthForward.Click();
                    this.Map.ChangeCalendarDate.Click();
                }
            }
        }

        public void CancelABookingButton()
        {
            this.Map.CancelBookingSelect.Click();
        }

        public void DoNotcancel()
        {
            this.Map.Donotcancel.Click();
        }
        public void PressOk()
        {
            this.Map.OKBtn.Click();
        }
        public void SelectSave()
        {
            this.Map.SaveBTN2.Click();
        }
        public void ModifyResParticipants()
        {
            this.Map.ModifyresourceSelect.Click();
        }

        public void SaveButton()
        {
            this.Map.SavingIt.Click();
        }

        public void ParticipantValue()
        {
            this.Map.ModifyNum.Click();
            this.Map.ModifyNum.SendKeys(Keys.Control + "a");
            this.Map.ModifyNum.SendKeys("7");
        }
    }
}
