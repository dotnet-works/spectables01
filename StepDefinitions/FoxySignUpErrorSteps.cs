using AventStack.ExtentReports.Gherkin.Model;
using OpenQA.Selenium;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SpecTablenRegex.StepDefinitions
{
    [Binding]
    public sealed class FoxySignUpErrorSteps
    {
        private IWebDriver driver;
        public FoxySignUpErrorSteps(IWebDriver driver)
        {
            this.driver = driver;
        }

        By _ByFirstNameError = By.XPath("//label[@for='first_name'and @class='fc_error']");
        By _ByLastNameError = By.XPath("//label[@for='last_name'and @class='fc_error']");
        By _ByEmailError = By.XPath("//label[@for='email'and @class='fc_error']");
        By _ByPasswordError = By.XPath("//label[@for='pwd' and @class='fc_error']");

        [Given(@"go to foxy signup page with url ""([^""]*)""")]
        public void Step01(string s01){
            this.driver.Url = s01;
        }

        [When(@"Enter signup button")]
        public void Step02() {
            this.driver.FindElement(By.Id("next")).Click();
            Thread.Sleep(1000);

            Console.WriteLine($"Error: {this.driver.FindElement(_ByFirstNameError).Text}");
            Console.WriteLine($"Error: {this.driver.FindElement(_ByLastNameError).Text}");
            Console.WriteLine($"Error: {this.driver.FindElement(_ByEmailError).Text}");
            Console.WriteLine($"Error: {this.driver.FindElement(_ByPasswordError).Text}");
            Console.WriteLine($"Error-innerText: {this.driver.FindElement(_ByPasswordError).GetAttribute("innerText")}");
            Console.WriteLine($"Error-innerHTML: {this.driver.FindElement(_ByPasswordError).GetAttribute("innerHTML")}");
        }
        
        [Then(@"all missing feilds error should display")]
        public void Step03(Table tbl)
        {
            Console.WriteLine($"count:{tbl.RowCount}");
            Console.WriteLine($"row value: {tbl.Rows.ToArray<TableRow>()[0]}");
            Console.WriteLine($"head value: {tbl.Header.ToArray()[0]}");

            foreach (TableRow row in tbl.Rows)
            {
                Console.WriteLine($"row value:{row["Errors"]}");  //addressRow.Add(row["Field"], row["Value"]);
            }



            

            //foreach( var err in errorTable )
            //{
            //    Console.WriteLine(err.ToString());
            //}

        }









    }
}