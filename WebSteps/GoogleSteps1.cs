using AventStack.ExtentReports.Gherkin.Model;
using OpenQA.Selenium;
using System.Security.Policy;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.CommonModels;

namespace SpecTablenRegex.WebSteps
{
    [Binding]
    public class GoogleSteps1
    {
        private IWebDriver driver;
        public GoogleSteps1(IWebDriver driver)
        {
            this.driver = driver;
        }
        [Given(@"go to ""(.*)"" site")]
        public void s01(string p01)
        {
            driver.Url = "https://www.google.com/";
            Console.WriteLine($"open {p01} site");
        }

        [When(@"search something using ""(.*)""")]
        public void s02(string p02)
        {
            IWebElement searchBox = driver.FindElement(By.Name("q"));
            searchBox.Clear();
            searchBox.SendKeys($"{p02}\n");
        }

        [Then(@"user navigates to result page")]
        public void s03()
        {
            Console.WriteLine($"Title: {driver.Title}");
            // cucumber - Google Search
            // specflow - Google Search
        }

        [When(@"Navigate back to main search page")]
        [Then(@"Navigate back to main search page")]
        public void s04()
        {
            driver.Navigate().Back();
        }





    }
}