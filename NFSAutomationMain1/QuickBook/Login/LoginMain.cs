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
using System.Data.SqlClient;


namespace QuickBook.Login
{
    public class LoginMain
    {

        private IWebDriver driver;
        private readonly string url = ConfigurationManager.AppSettings["QBURL"];
        private readonly string username = ConfigurationManager.AppSettings["Username"];
        private readonly string password = ConfigurationManager.AppSettings["Password"];
        private readonly string ConnectionString = ConfigurationManager.AppSettings["connectionstring"];

        protected LoginMainReferences Map
        {
            get
            {
                return new LoginMainReferences(this.driver);
            }
        }

       
        public LoginMain(IWebDriver driver)
        {
            this.driver = driver;
        }


        public void Wait()
        {
           

            if (this.Map.loadingimage.Displayed)
            {
                //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20000);
                Thread.Sleep(2000);
            }
            else
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            }
        }


        public void NavigateTo()
        {
            this.driver.Navigate().GoToUrl(this.url);
        }

        public void LoginSuccess()
        {
            this.Map.UserNameTextBox.SendKeys(username);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2000);
            this.Map.PasswordTextBox.SendKeys(password);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2000);
            this.Map.LoginButton.Click();  
        }

        public void LoginUsernameFail()
        {
            this.Map.UserNameTextBox.SendKeys("Wrong Username");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2000);
            this.Map.PasswordTextBox.SendKeys(password);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2000);
            this.Map.LoginButton.Click();
        }

        public void LoginPasswordFail()
        {
            this.Map.UserNameTextBox.SendKeys(username);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2000);
            this.Map.PasswordTextBox.SendKeys("Wrong password");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2000);
            this.Map.LoginButton.Click();  
        }

        public void Loginwithoutusername()
        {
            this.Map.PasswordTextBox.SendKeys(password);
             driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2000);
            this.Map.LoginButton.Click();
        }

        public void Loginwithoutpassword()
        {
            this.Map.UserNameTextBox.SendKeys(username);
             driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2000);
            this.Map.LoginButton.Click();
        }

        public void Loginwithoutdetails()
        {
            this.Map.LoginButton.Click();
        }
        public void Logout()
        {
            this.Map.LogoutButton.Click();
        }

    /*    public void DBConnect(String Query)
        {
          
            SqlConnection conn;
            conn = new SqlConnection(ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(Query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("{1}, {0}", reader.GetString(0), reader.GetString(1));
            }
           reader.Close();
            conn.Close();
           
        }   */


        //SQL Data in a list
         public List<String> data = new List<String>();
        public void DBConnect(String Query)
        {
           
            List<String> data2 = new List<String>();
            SqlConnection conn;
            conn = new SqlConnection(ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(Query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                data.Add(reader[0].ToString());
                data.Add(reader[1].ToString());
                
            }
            reader.Close();
            conn.Close();
            foreach (string SQLData in data)
            {
                Console.WriteLine("SQL DATA: {0}", SQLData);
               
            }

            foreach (string SQLData2 in data2)
            {
                Console.WriteLine("SQL Data2: {1}", SQLData2);
            }

        }



       /* public void Wait()
        {
            if (this.Map.loadingimage.Displayed)
            {
               // driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20000);
                Thread.Sleep(2000);
            }
        }*/


        //Check Register Link
        public void RegisterLink()
        {
            this.Map.RegisterLink.Click();
           
        }


        public void ForgotPasswordLink()
        {
            this.Map.ForgotPasswordLink.Click();
           
        }


        public void night()
        {
            Console.WriteLine("Morning");
            Console.WriteLine("Afternoon");
            Console.WriteLine("Evening");
        }


        }
    }

     

       



