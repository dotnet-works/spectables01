


using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Config;
using LivingDoc.SpecFlowPlugin;
using OpenQA.Selenium;
using System.IO;

namespace SpecTablenRegex.TestUtils
{
    public class EExtentReports
    {
        public static ExtentReports? _extentReports;
        public static ExtentTest? _feature;
        public static ExtentTest? _scenario;

        public static String dir = AppDomain.CurrentDomain.BaseDirectory;
        public static String testResultPath = dir.Replace("bin\\Debug\\net8.0", "TestResults");

        public static void ExtentReportInit()
        {

            ExtentSparkReporter reporter = new ExtentSparkReporter("extent.html");
            reporter.Config.ReportName = "Spec Report";
            reporter.Config.Theme = Theme.Standard;

            //ExtentSparkReporter htmlReporter = new ExtentSparkReporter(testResultPath); //new ExtentHtmlReporter(testResultPath);
            //htmlReporter.Config.ReportName = "Automation Status Report";
            //htmlReporter.Config.DocumentTitle = "Automation Status Report";
            //htmlReporter.Config.Theme = Theme.Standard;
            ////htmlReporter.Start();

            //_extentReports = new ExtentReports();
            _extentReports?.AttachReporter(reporter);
            ////_extentReports.AddSystemInfo("Application", "Youtube");
            ////_extentReports.AddSystemInfo("Browser", "Chrome");
            ////_extentReports.AddSystemInfo("OS", "Windows");
        }

        public static void ExtentReportTearDown()
        {
            _extentReports.Flush();
        }

        public string addScreenshot(IWebDriver driver, ScenarioContext scenarioContext)
        {
            ITakesScreenshot takesScreenshot = (ITakesScreenshot)driver;
            Screenshot screenshot = takesScreenshot.GetScreenshot();
            string screenshotLocation = Path.Combine(testResultPath, scenarioContext.ScenarioInfo.Title + ".png");
            screenshot.SaveAsFile(screenshotLocation); //, ImageFormat.Png);//ScreenshotImageFormat.Png
            return screenshotLocation;
        }


    }
}
