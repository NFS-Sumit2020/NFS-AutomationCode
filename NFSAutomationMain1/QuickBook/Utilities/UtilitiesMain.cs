using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using System.Data.SqlClient;
using System.Configuration;
using QuickBook.Homepage;
using RelevantCodes.ExtentReports;
using System.IO;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace QuickBook.Utilities
{


    public class UtilitiesMain
    {

        public ExtentReports extent;
        public ExtentTest extenttest;
        FileStream fs;
        TextWriter tmp;
        StreamWriter sw;
        private IWebDriver driver;
        string result = null;
       
        private readonly string ConnectionString = ConfigurationManager.AppSettings["connectionstring"];
        private readonly string TestReportUsername = ConfigurationManager.AppSettings["testreportusername"];
        private readonly string TestReportConfigFile = ConfigurationManager.AppSettings["testreportconfigfile"];
        private readonly string TestReportHostName = ConfigurationManager.AppSettings["testreporthostname"];
        private readonly string TextFilePath = ConfigurationManager.AppSettings["textfilepath"];


        public UtilitiesMain(IWebDriver driver)
        {
            this.driver = driver;
        }

        //Take string as an argument and attempts to convert it to 24 hours
        public string ConvertTimeTo24(string time)
        {
            try
            {
                if (time.Contains("am") || time.Contains("pm"))
                {
                    DateTime initTime = DateTime.ParseExact(time, "HH:mm tt", System.Globalization.CultureInfo.CurrentCulture);
                    string newTime = initTime.ToString("HH:mm");
                    return newTime;
                }
                else
                {
                    string newTime = time;
                    return newTime;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("String passed to ConvertTimeTo24 method was not a time");
                return time;
            }
        }
        //Take string as an argument and attempts to convert it to 12 hours
        public string ConvertTimeTo12(string time)
        {
            try
            {
                if (time.Contains("am") || time.Contains("pm"))
                {
                    string newTime = time;
                    return newTime;
                }
                else
                {
                    DateTime initTime = DateTime.ParseExact(time, "hh:mm tt", System.Globalization.CultureInfo.CurrentCulture);
                    string newTime = initTime.ToString("hh:mm tt");
                    return newTime;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("String passed to ConvertTimeTo12 method was not a time");
                return time;
            }
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

        public string SQLDataNew;
        public string SQLData2New;
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

        //Required in Test Init to setup test reporting
        public void ReportSetup()
        {
            string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string actualPath = path.Substring(0, path.LastIndexOf("bin"));
            string projectPath = new Uri(actualPath).LocalPath;
            string reportPath = projectPath + "Reports\\Build v6.4.1(Fuji) " + DateTime.Now.ToString("yyyy-MM-dd HH-mm") + ".html";
            extent = new ExtentReports(reportPath, false);
            extent.AddSystemInfo("Host Name", TestReportHostName);
            extent.AddSystemInfo("Environment", "QA");
            extent.AddSystemInfo("User Name", TestReportUsername);
            extent.LoadConfig(TestReportConfigFile);
        }

        //This is screenshot setup.

        public string Capture(string screenShotName, string name)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            Screenshot screenshot = ts.GetScreenshot();
            string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string actualPath = path.Substring(0, path.LastIndexOf("bin"));
            string projectPath = new Uri(actualPath).LocalPath;
            string finalpth = projectPath + "Reports\\ErrorScreenshots\\" + name  + " " +  DateTime.Now.ToString("yyyy-MM-dd HH-mm") + ".png";
            string localpath = new Uri(finalpth).LocalPath;
            screenshot.SaveAsFile(localpath, ScreenshotImageFormat.Png);
            return localpath;
        }


        public void ConsoleMessageStart()
        {
             fs = new FileStream(TextFilePath, FileMode.Create);
             tmp = Console.Out;
             sw = new StreamWriter(fs);
            Console.SetOut(sw);
        }

        public void ConsoleMessageClose()
        {
            Console.SetOut(tmp);
            sw.Close();
            var fileStream = new FileStream(TextFilePath, FileMode.Open, FileAccess.Read);
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                Console.WriteLine(streamReader.ReadToEnd());
            }
        }


        public void GetResult()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stackTrace = "<pre>" + TestContext.CurrentContext.Result.StackTrace + "</pre>";
            var errorMessage = TestContext.CurrentContext.Result.Message;
            var testname = TestContext.CurrentContext.Test.Name;
            //utilities.ConsoleMessageClose();
            ConsoleMessageClose();
            var fileStream = new FileStream(TextFilePath, FileMode.Open, FileAccess.Read);
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                result = streamReader.ReadToEnd();

            }

            if (status == TestStatus.Failed)
            {
                string screenshotpath = Capture("ScreenshotName", testname);
                extenttest.Log(LogStatus.Fail, stackTrace + errorMessage);
                extenttest.Log(LogStatus.Info, result);
                extenttest.Log(LogStatus.Fail, extenttest.AddScreenCapture(screenshotpath));
                extent.EndTest(extenttest);

            }
            else
            {
                extenttest.Log(LogStatus.Info, result);
                extent.EndTest(extenttest);
                
            }
        }

       /* public void DisplayConsoleResultInOutput()
        {
            var fileStream = new FileStream(@"F:\Automation Testing\QuickBook Automation Team Code\QuickBookAutomation\Redirect.txt", FileMode.Open, FileAccess.Read);
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                Console.WriteLine(streamReader.ReadToEnd());
            }
        }*/
        
        
           
      
            //

        

    }
}
