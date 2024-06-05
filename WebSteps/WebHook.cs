using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Diagnostics;
using TechTalk.SpecFlow;

namespace SpecTablenRegex.WebSteps
{
    [Binding]
    public class WebHook
    {
        private readonly IObjectContainer? _objectContainer;
        private  IWebDriver? _driver;

        public WebHook(IObjectContainer _objectContainer)
        {
            this._objectContainer = _objectContainer;
        }

        [BeforeTestRun]
        public static void runInit()
        {

        }

        [BeforeScenario("@web")]
        public void BeforeScenario()
        {
            this._driver = new ChromeDriver();
            this._driver.Manage().Window.Maximize();
            this._driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);

            this._objectContainer.RegisterInstanceAs<IWebDriver>(this._driver);

        }

        [AfterScenario("@web")]
        public void AfterScenario()
        {
            this._driver?.Close();
            this._driver?.Dispose();
        }

        [AfterTestRun]
        public static void runTearDown()
        {
            //using Process p = new();
            //ProcessStartInfo startInfo = new()
            //{
            //    WindowStyle = ProcessWindowStyle.Hidden,
            //    FileName = "cmd.exe",
            //    Arguments = @"/C dir"
            //};
            //p.StartInfo = startInfo;
            //p.Start();
            //string cmdOutput = p.StandardOutput.ReadToEnd();
            //Console.WriteLine(cmdOutput);

            //p.StartInfo.FileName = @"C:/Windows/system32/cmd.exe";
            //p.StartInfo.Arguments = "/C dir";
            //p.Start();
            //p.WaitForExit();
            //string cmdOutput = p.StandardOutput.ReadToEnd();
            //Console.WriteLine(cmdOutput);
        }
    }
}