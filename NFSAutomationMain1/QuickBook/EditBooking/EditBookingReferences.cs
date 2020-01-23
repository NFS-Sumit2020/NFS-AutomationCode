using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace QuickBook.EditBooking
{
    public class EdiBookingReference
    {
        private readonly IWebDriver driver;
        public EdiBookingReference(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement EditBookingsBurgerBar
        {
            get
            {
                return driver.FindElement(By.Id("editBookingOptionMenu"));
                //return driver.FindElement(By.XPath("//*[@id='editBookingOptionMenu']"));
            }                                    //*[@id="editBookingOptionMenu"]
        }

        /* public IWebElement ChangeResourceDropdown
         {
             get
             {
                 return driver.FindElement(By.XPath("//*[@id='editBookingOptionPanel']/ul/li[2]/a"));
             }
         }*/

        public IWebElement EditIcon
        {
            get
            {
                return driver.FindElement(By.XPath("//*[@id='tab-0']/div/div/div[4]/span/a[1]/img"));
            }
        }

        public IWebElement PrivateCheckBox
        {
            get
            {
                return driver.FindElement(By.Id("bookingIsPrivate"));
            }
        }

        public IWebElement ChangeResourceDropDown
        {
            get
            {
                return driver.FindElement(By.XPath("//*[@id='editBookingOptionPanel']/ul/li[2]/a"));
            }
        }

        public IWebElement EditBurgerButton
        {
            get
            {
                return driver.FindElement(By.Id("editBookingOption"));
            }
        }


        public IWebElement ChangeResourceButton
        {
            get
            {
                return driver.FindElement(By.Id("btnchangeresource"));
                // return driver.FindElement(By.ClassName("btn btn-book update-bookinginfo"));
            }
        }

        public IWebElement CloseButton
        {
            get
            {
                return driver.FindElement(By.Id("btnclose"));
            }
        }
        public IWebElement ChangeResource
        {
            get
            {
                return driver.FindElement(By.Id("btnchangeresource"));
            }
        }
        public IWebElement ExactMatch
        {
            get
            {
                return driver.FindElement(By.ClassName("exact-match"));
            }
        }
        public IWebElement NextButton
        {
            get
            {
                return driver.FindElement(By.Id("btnMSBook"));
            }
        }
        public IWebElement Confirmchange
        {
            get
            {
                return driver.FindElement(By.Id("btnConfirmBooking"));
            }
        }
        public IWebElement AddResource
        {
            get
            {
                return driver.FindElement(By.XPath("//*[@id='editBookingOptionPanel']/ul/li[1]/a"));
            }
        }
        public IWebElement FinishButton
        {
            get
            {
                return driver.FindElement(By.Id("btnConfirmBooking"));
            }
        }
        public IWebElement Finder
        {
            get
            {
                return driver.FindElement(By.Id("btnFind"));
            }
        }
        public IWebElement RemoveResource
        {
            get
            {
                return driver.FindElement(By.XPath("//*[@id='editBookingOptionPanel']/ul/li[3]/a"));
            }
        }
        public IWebElement Removetheroom
        {
            get
            {
                return driver.FindElement(By.Id("btnDeleteResource"));
            }
        }
        public IWebElement Yes
        {
            get
            {
                return driver.FindElement(By.Id("btnConfirmationYes"));
            }
        }
        public IWebElement Save
        {
            get
            {
                return driver.FindElement(By.ClassName("btn btn-book update-bookinginfo"));
            }                                         //btn btn-book fixwidth btn-finish
                                                      //btn btn-book update-bookinginfo
        }
        public IWebElement Checkedbox
        {
            get
            {
                return driver.FindElement(By.XPath("//*[@id='divchangeresource']/div[1]/div/p[1]/label/span"));
            }
        }


        public IWebElement DateRandom
        {
            get
            {
                return driver.FindElement(By.XPath("//*[@id='datepicker']/div/table/tbody/a"));
            }
        }

        public IWebElement ModifyDate
        {
            get
            {
                return driver.FindElement(By.XPath("//*[@id='editBookingOptionPanel']/ul/li[4]/a"));
            }
        }

        public IWebElement CurrentDay
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@class=' ui-datepicker-days-cell-over  ui-datepicker-current-day ui-datepicker-today']/a | //*[@class=' ui-datepicker-week-end ui-datepicker-days-cell-over  ui-datepicker-current-day ui-datepicker-today']/a"));
            }
        }

        public IWebElement check
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='ui-datepicker-div']/table/tbody"));

            }
        }

        public IWebElement MyBookingsNextDay(string a)
        {
            return this.driver.FindElement(By.XPath("//a[contains(text(),'" + a + "')]"));
            // return this.driver.FindElement(By.XPath("//*[@id='ui-datepicker-div']/table/tbody"));
        }

        public IWebElement CalendarChangeMonthForward
        {
            get
            {
                //return driver.FindElement(By.ClassName("ui-icon ui-icon-circle-triangle-e"));
                return driver.FindElement(By.XPath("//*[@id='ui-datepicker-div']/div/a[2]"));
            }
        }
        public IWebElement ChangeCalendarDate
        {
            get
            {
                return driver.FindElement(By.XPath("//*[@class=' ']/a"));
            }
        }

        public IWebElement CancelBookingSelect
        {
            get
            {
                return driver.FindElement(By.XPath("//*[@id='editBookingOptionPanel']/ul/li[7]/a"));
            }                                      //*[@id="editBookingOptionPanel"]/ul/li[7]/a
        }

        public IWebElement Yesbutton
        {
            get
            {
                return driver.FindElement(By.XPath("//*[@id='btnConfirmationYes']"));
            }                                      //*[@id="btnokforupdate"]
        }

        public IWebElement Donotcancel
        {
            get
            {
                return driver.FindElement(By.Id("btnConfirmationNo"));
            }
        }

        public IWebElement OKBtn
        {
            get
            {
                return driver.FindElement(By.Id("btnDialogOK"));
            }
        }

        public IWebElement SaveBTN2
        {
            get
            {
                return driver.FindElement(By.XPath("//*[@id='page-wrap']/section[2]/div[3]/a[3]"));
            }                                       //*[@id="buttons_M78056"]/a[3]
        }

        public IWebElement ModifyresourceSelect
        {
            get
            {
                return driver.FindElement(By.XPath("//*[@id='editBookingOptionPanel']/ul/li[8]/a")); //
            }                                       //*[@id="inputResourceCover"]
        }

        public IWebElement SavingIt
        {
            get
            {
                return driver.FindElement(By.XPath("//*[@id='page-wrap']/section[2]/div[1]/div[8]/a[2]"));
                //XPath("//*[@id='page - wrap']/section[2]/div[1]/div[8]/a[2]"//*[@id="page-wrap"]/section[2]/div[1]/div[8]/a[2]//*[@id="page-wrap"]/section[2]/div[1]/div[8]/a[2]//*[@id="page-wrap"]/section[2]/div[1]/div[8]/a[2]//*[@id="page-wrap"]/section[2]/div[1]/div[8]/a[2]btn btn-book update-bookinginfo
            }
        }

        public IWebElement ModifyNum
        {
            get
            {
                return driver.FindElement(By.XPath("//*[@id='page-wrap']/section[2]/div[1]/div[5]/div/div/div/p[2]/span/span/input"));  //
                                                 //*[@id='page-wrap']/section[2]/div[1]/div[5]/div[1]/div[1]/div/p[2]
            }
        }

        public IWebElement Recparticipantsave
        {
            get
            {
                return driver.FindElement(By.XPath("//*[@id='page - wrap']/section[2]/div[1]/div[6]/a[2]"));
            }
        }
    }
}
