using AventStack.ExtentReports.Gherkin.Model;
using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using RazorEngine.Compilation.ImpromptuInterface.Dynamic;
using SpecTablenRegex.TestUtils;
using System.Diagnostics;
using TechTalk.SpecFlow;

namespace SpecTablenRegex.WebSteps
{
    [Binding]
    public class WebHook       //: EExtentReports
    {
        private readonly IObjectContainer? _objectContainer;
        private  IWebDriver? _driver;
        EExtentReports ereport;

        public WebHook(IObjectContainer _objectContainer)
        {
            this._objectContainer = _objectContainer;
        }

        [BeforeTestRun]
        public static void runInit()
        {
            Console.WriteLine("Before Test Run hook executed");
            //ereport = new EExtentReports();
            //EExtentReports.ExtentReportInit();
            //ExtentReportInit();
        }

        [AfterTestRun]
        public static void afterTestRunHook()
        {
            Console.WriteLine("After Test Run hook executed");
            Process proc = new Process();
            proc.StartInfo.FileName = "livingdoc";
            proc.StartInfo.Arguments = "test-assembly SpecTablenRegex.dll -t TestExecution.json --output ../../../report.html";
            proc.StartInfo.RedirectStandardError = true;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.CreateNoWindow = true;
            proc.StartInfo.UseShellExecute = false;
            proc.Start();

            //EExtentReports.ExtentReportTearDown();
        }

        //[BeforeFeature]
        //public static void BeforeFeature(FeatureContext featureContext)
        //{
        //    Console.WriteLine("Running before feature...");
        //    _feature = _extentReports.CreateTest<Feature>(featureContext.FeatureInfo.Title);
        //}

        [AfterFeature]
        public static void AfterFeature()
        {
            Console.WriteLine("Running after feature...");
        }


        [BeforeScenario("@web")]
        public void BeforeScenario(ScenarioContext scenarioContext)
        {
            ChromeOptions chrome_options = new ChromeOptions();
            chrome_options.AddArgument("--incognito");
            chrome_options.AddArgument("--test-type");


            this._driver = new ChromeDriver(chrome_options);
            
            this._driver.Manage().Window.Maximize();
            this._driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);

            this._objectContainer.RegisterInstanceAs<IWebDriver>(this._driver);

            //_driver = new ChromeDriver();
            //_driver.Manage().Window.Maximize();
            //_driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);

            //_objectContainer.RegisterInstanceAs<IWebDriver>(_driver);


            //_scenario = _feature.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);

        }

        [AfterScenario("@web")]
        public void AfterScenario()
        {
            this._driver?.Close();
            this._driver?.Dispose();
        }

        //[BeforeStep]
        //public void beforeStephook(ScenarioStepContext Stepx)
        //{
        //    //Console.WriteLine($"=== {Stepx.StepInfo.Text} ===");

        //}

        [AfterStep]
        public void afterStepHook(ScenarioContext scenarioContext)
        {
            Console.WriteLine("Running after step....");
            string stepType = scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
            string stepName = scenarioContext.StepContext.StepInfo.Text;
            Console.WriteLine($"=== StepType: {stepType}  StepName: {stepName} ===");
            ////Console.WriteLine($"=== {Stepx.Status} ===");
            ////Console.WriteLine($"=== {Stepx.StepInfo.StepInstance.StepContext.ScenarioTitle} ===");

            ////When scenario passed
            //if (scenarioContext.TestError == null)
            //{
            //    if (stepType == "Given") 
            //    {
            //        _scenario?.CreateNode<Given>(stepName);
            //    }
            //    else if (stepType == "When")
            //    {
            //        _scenario?.CreateNode<When>(stepName);
            //    }
            //    else if (stepType == "Then")
            //    {
            //        _scenario?.CreateNode<Then>(stepName);
            //    }
            //    else if (stepType == "And")
            //    {
            //        _scenario?.CreateNode<And>(stepName);
            //    }
            //}





        }





    }
}