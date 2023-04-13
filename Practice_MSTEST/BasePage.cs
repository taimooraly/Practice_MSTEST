using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter.Configuration;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace POM
{
    public class BasePage 
    {
        public static IWebDriver driver;
        static public IWebDriver driverr;
        public static ExtentReports extentReports;
        public static ExtentTest exParentTest;
        public static ExtentTest exChildTest;
        public static string dirpath;
        public static void Initialization(String browser)
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }
        public static void LogReport(string testcase)
        {
            extentReports = new ExtentReports();
            dirpath = @"..\..\TestExecutionReports\" + '_' + testcase;
            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(dirpath);
            htmlReporter.Config.Theme = Theme.Standard;
            extentReports.AttachReporter(htmlReporter);
        }
        public static void TakeScreenshot(Status status, string stepDetail)
        {
            string path = @"C:\Users\S Link Solotion\source\repos\SeleniumProject\TestExecutionReports" + "TestExecLog_" + DateTime.Now.ToString("yyyyMMddHHmmss");
            Screenshot image_username = ((ITakesScreenshot)driver).GetScreenshot();
            image_username.SaveAsFile(path + ".png", ScreenshotImageFormat.Png);
            exChildTest.Log(status, stepDetail, MediaEntityBuilder.CreateScreenCaptureFromPath(path + ".png").Build());
        }
        public static void SeliniumClose()
        {
            driver.Close();
        }
        public void OpenUrl(string url)
        {
            driver.Url = url;
        }
        public void Write(By by, string text)
        {
            try
            {
                driver.FindElement(by).SendKeys(text);
                TakeScreenshot(Status.Pass, "Enter ");
            }
            catch (Exception ex)
            {
                TakeScreenshot(Status.Fail, "Enter Failed" + ex);
            }
        }
        public void Click(By by)
        {
            try
            {
                driver.FindElement(by).Click();
                TakeScreenshot(Status.Pass, "Click ");
            }
            catch (Exception ex)
            {
                TakeScreenshot(Status.Fail, "Click Failed " + ex);
            }
        }
        public static void Clear(By by)
        {
            driver.FindElement(by).Clear();
        }
        
    }
}