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
using QuickBook.Homepage;
using QuickBook.Attendees;

namespace QuickBook.Booking
{
    public class BookingMain
    {

        private IWebDriver driver;
        private readonly string Bookingnotes = ConfigurationManager.AppSettings["bookingnotes"];
        private readonly string Bookingspecialrequests = ConfigurationManager.AppSettings["bookingspecialrequests"];

        protected BookingReferences Map
        {
            get
            {
                return new BookingReferences(this.driver);
            }
        }

        public BookingMain(IWebDriver driver)
        {
            this.driver = driver;
        }



        public void BookingTitle()
        {

            Random ran = new Random();
            int i = ran.Next(0, 10000);
            this.Map.bookingtitle.SendKeys("TestBooking " + i);
            Thread.Sleep(2000);
            //this.Map.Bookbutton.Click();

        }

        public void BookingType()
        {

            var bookingstype = this.Map.bookingtype;
            var selectbookingtype = new SelectElement(bookingstype);
            //selectbookingtyoe.SelectByText("Client"); Can also select by text.
            selectbookingtype.SelectByIndex(1);
        }

        public void PrivateBooking()
        {
            this.Map.PrivateBooking.Click();
        }

        public void EditForAddPeople()//edit button for edit people
        {
            this.Map.Addpeoplebutton.Click();
        }

        public void SaveandexistBooking()
        {
            this.Map.Saveandexist.Click();
        }

        public void BookingNotes()
        {

            Random ran = new Random();
            int i = ran.Next(0, 10000);
            this.Map.BookingNotes.SendKeys(Bookingnotes + i);
        }

        public void BookingSpecialRequests()
        {
            Random ran = new Random();
            int i = ran.Next(0, 10000);
            this.Map.BookingSpecialRequests.SendKeys(Bookingspecialrequests + i);
        }

        public void QBAteendee()//Verify Assign Attendee added from Webapp with respective Resource
        {
            List<IWebElement> Attendee_List = this.driver.FindElements(By.Id("tblAttendees")).ToList();

            for (int j = 0; j < Attendee_List.Count; j++)
            {
                IList<IWebElement> attendee_row = Attendee_List[j].FindElements(By.ClassName("attendee-name"));
                Thread.Sleep(1000);
                for (int i = 0; i < attendee_row.Count; i++)
                {
                    string attename = attendee_row[i].Text.ToString();
                    Thread.Sleep(1000);
                    if (attename == "morey, sumit")
                    {
                        Thread.Sleep(1000);
                        IList<IWebElement> attendee_col = Attendee_List[j].FindElements(By.ClassName("select-box"));
                        Thread.Sleep(1000);

                        for (int k = 0; k < attendee_col.Count; k++)
                        {
                            IList<IWebElement> optionlist = attendee_col[k].FindElements(By.TagName("option"));
                            Thread.Sleep(1000);
                            for (int n = 0; n < optionlist.Count; n++)
                            {
                                string ss = optionlist[n].Text.ToString();

                                if (ss == "28-01")
                                {
                                    if (optionlist[n].Selected)
                                    
                                    {
                                        Thread.Sleep(2000);
                                        Console.WriteLine("Attendee Verify Sucessfully");
                                    }
                                    Thread.Sleep(2000);
                                    
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
