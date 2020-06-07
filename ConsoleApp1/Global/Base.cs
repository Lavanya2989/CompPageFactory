using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Utils;
using ConsoleApp1.Config;
using ConsoleApp1.Pages;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

using System;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using static ConsoleApp1.Global.GlobalDefinitions;

namespace ConsoleApp1.Global
{
    [SetUpFixture]
    class Base
    {
        #region To access Path from resource file

        public static int Browser = Int32.Parse(MarsResource.Browser);
        public static string ExcelPath = MarsResource.ExcelPath;
        public static string ScreenshotPath = MarsResource.ScreenShotPath;
        public static string ReportPath = MarsResource.ReportPath;
        public static string ReportXMLPath = MarsResource.ReportXMLPath;
        public static string ReportScreenShot = MarsResource.ReportScreenShot;
        #endregion

        
            public static ExtentTest test;
            public static ExtentReports extent;

           [OneTimeSetUp]

             public void Setup()
            {

            #region Initialise Reports
           
                    extent = new ExtentReports();
                    ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(ReportPath);
                    //htmlReporter.setAppendExisting(true);  

                    extent.AttachReporter(htmlReporter);
                    // report design
                    htmlReporter.LoadConfig(ReportXMLPath);
                   
                    //Adding system details
                    extent.AddSystemInfo("Host Name", "Local host");
                    extent.AddSystemInfo("Environment", "QA");
                    extent.AddSystemInfo("User Name", "Lavanya");
                
                #endregion
            }
        
        #region setup and tear down
        [SetUp]
        public void Inititalize()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            GlobalDefinitions.driver = new ChromeDriver();

            if (MarsResource.IsLogin == "true")
            {
                SignIn loginobj = new SignIn();
                loginobj.LoginSteps();
            }
            else
            {
                SignUp obj = new SignUp();
                obj.register();
            }

        }
      
       [OneTimeTearDown]
        public void Teardown()
        {
            extent.Flush();
            driver.Quit();
        }

        [TearDown]
        public void AfterTest()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
                    ? ""
                    : string.Format("{0}", TestContext.CurrentContext.Result.StackTrace);
            Status logstatus;
            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = Status.Fail;
                    DateTime time = DateTime.Now;
                    //Getting failed test screenshot for report
                    String screenShotPath = Capture(driver, ReportPath);
                    test.Log(Status.Fail, "Fail");
                    test.Log(Status.Fail, "Snapshot below: " + test.AddScreenCaptureFromPath(ReportScreenShot));
                    MediaEntityBuilder.CreateScreenCaptureFromPath(ReportPath);
                    break;
                case TestStatus.Inconclusive:
                    logstatus = Status.Warning;
                    break;
                case TestStatus.Skipped:
                    logstatus = Status.Skip;
                    break;
                default:
                    logstatus = Status.Pass;
                    DateTime time1 = DateTime.Now;
                    //Getting pass test screenshot
                    String screenShotPath1 = Capture(driver, ReportPath);
                    test.Log(Status.Pass, "Pass");
                    test.Log(Status.Pass, "Snapshot below: " + test.AddScreenCaptureFromPath(ReportScreenShot));
                    //MediaEntityBuilder.CreateScreenCaptureFromPath(ReportPath) ;
                    break;
            }
            
            test.Log(logstatus, "Test ended with " + logstatus + stacktrace);
            string img = SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "Report");
            driver.Quit();
        }

        public IWebDriver GetDriver()
        {
            return driver;
        }
        public static string Capture(IWebDriver driver, String fileName)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            Screenshot screenshot = ts.GetScreenshot();
            //save screeshot
            screenshot.SaveAsFile(ReportScreenShot, ScreenshotImageFormat.Png);
            return ReportPath;
        }

              #endregion
    }
}



