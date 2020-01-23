using OpenQA.Selenium;

using OpenQA.Selenium.Interactions;
using System.Threading;

namespace WebApp.Diary
{
    public class DiaryMain
    {
        private IWebDriver driver;



        public DiaryMain(IWebDriver driver)
        {
            this.driver = driver;
        }

        protected DiaryReferences Map
        {
            get
            {
                return new DiaryReferences(this.driver);
            }
        }

        //Double Click on the first cell of the Diary 
        public void ClickFirstCell()
        {
            var firstcellclick = this.Map.FirstCell;
            Actions action = new Actions(driver);
            action.MoveToElement(firstcellclick).DoubleClick().Perform();
            Thread.Sleep(3000);


            /*
                        int j = 2;

                        for (j = 2; j < 1000; j++)
                        {
                            // var b = this.Map.IfFirstCellnotFound(j);
                            Console.WriteLine(j);
                            string Xpath = "//*[@id='ShTBLNo0']/tbody/tr[3]/td[" + j + "]";
                            Thread.Sleep(5000);
                            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));


                          wait.Until(ExpectedConditions.ElementExists((By.XPath("//*[@id='ShTBLNo0']/tbody/tr[3]/td[" + j + "]"))));   
                         action.MoveToElement(this.driver.FindElement(By.XPath(Xpath))).DoubleClick().Perform();
                            //action.  //*[@id="ShTBLNo0"]/tbody
                            Thread.Sleep(3000);
                            if (this.driver.FindElement(By.Id("tblResources")).Displayed)
                            {
                                Thread.Sleep(2000);
                                this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_btnCreate")).Click();
                                break;
                            }
                            else
                            {

                                this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_btnExit1")).Click();
                                Thread.Sleep(2000);
                                this.driver.FindElement(By.Id("diarySpan")).Click();
                                Thread.Sleep(2000);
                                this.driver.FindElement(By.XPath("//*[@id='lbtnRefresh']")).Click();



                            }
                            // Thread.Sleep(3000);
                            //action.MoveToElement(this.driver.FindElement(By.XPath(Xpath))).DoubleClick().Perform();

                            Console.WriteLine(j);





                            /*  public void ClickFirstCell()
                              {

                              Actions action = new Actions(driver);

                              int j = 2;
                              string Xpath = "//*[@id='ShTBLNo0']/tbody/tr[3]/td[" + j + "]"; 
                              try
                              {


                                  for (j = 2; j < 1000; j++)
                                  {
                                      // var b = this.Map.IfFirstCellnotFound(j);
                                      Console.WriteLine(j);


                                      action.MoveToElement(this.driver.FindElement(By.XPath(Xpath))).DoubleClick().Perform();
                                      Thread.Sleep(3000);
                                      if (this.driver.FindElement(By.Id("tblResources")).Displayed)
                                      {

                                          this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_btnCreate")).Click();
                                          break;
                                      }
                                      else
                                      {

                                          this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_btnExit1")).Click();
                                      }
                                      Thread.Sleep(3000);

                                      Console.WriteLine(j);

                                  }
                              }
                              catch (StaleElementReferenceException e)
                              {

                                  // action.MoveToElement(this.driver.FindElement(By.XPath(Xpath))).DoubleClick().Perform();3


                                  IList<IWebElement> selectElements = driver.FindElements(By.XPath(Xpath));
                                  IEnumerator<IWebElement> enumerator = selectElements.GetEnumerator();
                                  action.MoveToElement(this.driver.FindElement(By.XPath(Xpath))).DoubleClick().Perform();
                                  bool hasNext = enumerator.MoveNext();
                                  while (hasNext)
                                  {
                                      IWebElement i = enumerator.Current;
                                      if (this.driver.FindElement(By.Id("tblResources")).Displayed)
                                      {

                                          this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_btnCreate")).Click();
                                          break;
                                      }
                                      else
                                      {

                                          this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_btnExit1")).Click();
                                          hasNext = enumerator.MoveNext();
                                      }

                                  }
                                  enumerator.Dispose();
                              }



                              }*/









        }


        public void NewBookingPopupDisplayed()
        {
            
                this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_btnCreate"));
            
        }

        public void editBookingExitButtonClicked()
        {
            this.Map.BookingEditExitButton.Click();
        }

        //Contining with booking. continue with booking button clicked. 
        public void continueWithBookingButton()
        {
            this.Map.ContinueWithBookingButton.Click();
        }



































    }

}
    /*
        public void Click()
        {

            var firstcellclick = this.Map.FirstCell;
            Actions action = new Actions(driver);
            //action.MoveToElement(this.Map.IfFirstCellnotFound(j)).DoubleClick().Perform();

            //  IWebElement tableproducts = this.driver.FindElement(By.XPath("//*[@id='RowID000']"));

            //  List<IWebElement> tabled = new WebDriverWait(driver, 10).Until(ExpectedConditions.ElementExists(By.TagName("td")));



            // int j = 2;
            bool staleElement = true;
            while (staleElement)
            {
                try
                {

                    if (this.driver.FindElement(By.XPath("//*[@id='Lbl1_0']")).Displayed)
                    {
                        Thread.Sleep(3000);
                        for (int j = 2; j < 1000;)
                        {
                            Thread.Sleep(5000);
                            j++;
                            action.MoveToElement(this.Map.IfFirstCellnotFound(j)).DoubleClick().Perform();
                            //  IWebElement elementLocator = this.Map.IfFirstCellnotFound(j);
                            //  action.DoubleClick(elementLocator).Perform();

                            if (this.driver.FindElement(By.XPath("//*[@id='tblResources']")).Displayed)
                            {
                                this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_btnCreate")).Click();

                                break;
                            }
                            else
                            {
                                Thread.Sleep(4000);
                                // action.MoveToElement(this.Map.IfFirstCellnotFound(j)).DoubleClick().Perform();

                                this.driver.FindElement(By.XPath("//*[@id='ctl00_MainContentPlaceHolder_btnExit1']")).Click();
                                this.driver.FindElement(By.XPath("//*[@id='diarySpan']")).Click();
                            }

                            //j++;
                            //Thread.Sleep(30000);
                            //  if (this.driver.FindElement(By.XPath("//*[@id='ctl00_sub_bookingEditLink']/a")).Displayed)
                            //  {
                            //      this.driver.FindElement(By.XPath("//*[@id='ctl00_MainContentPlaceHolder_btnExit1']")).Click();
                            //  }
                        }
                        Thread.Sleep(2000);
                        // this.driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_btnCreate")).Click();

                    }

                }

                catch (StaleElementReferenceException e)

                {
                    staleElement = true;

                }

            }
        }



        public void DiaryClickTest()
        {
            var firstcellclick = this.Map.FirstCell;
            Actions action = new Actions(driver);

            var a = this.driver.FindElement(By.ClassName("WholeHourSeparatorStyleDaily")).Text;
           
           Console.WriteLine(a);

           /* IJavaScriptExecutor ex1 = (IJavaScriptExecutor)driver;
            ex1.ExecuteScript("arguments[0].dblclick();", driver.FindElement(By.XPath("//*[@id='RowID000']/td[1]")));
            Thread.Sleep(3000);*/


    //((IJavascriptExecutor)driver).ExecuteScript("arguments[0].dblclick();", driver.FindElement(By.XPath("")));

    //*[@id='RowID000']/td[1]/td

    









