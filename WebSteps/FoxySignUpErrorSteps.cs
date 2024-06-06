using AventStack.ExtentReports.Gherkin.Model;
using FluentAssertions.Execution;
using OpenQA.Selenium;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SpecTablenRegex.WebSteps
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
        By _ByEmailFeild = By.Id("email");
        By _ByEmailError = By.XPath("//label[@for='email'and @class='fc_error']");
        By _ByPasswordError = By.XPath("//label[@for='pwd' and @class='fc_error']");
        By _ByEmailValidationText = By.XPath("//form[@id='signup']/fieldset/div[2]");

        [Given(@"go to foxy signup page with url ""([^""]*)""")]
        public void Step01(string s01)
        {

            string x = Environment.GetEnvironmentVariable("browser");
            x.Should().BeNullOrEmpty();

            if (x is null)
            {
                Console.WriteLine("Its null");
            }
            if (x == "")
            {
                Console.WriteLine("x is empty");
            }
            driver.Url = s01;
        }

        [When(@"Enter signup button")]
        public void Step02()
        {
            driver.FindElement(By.Id("next")).Click();
            Thread.Sleep(1000);

            Console.WriteLine($"Error: {driver.FindElement(_ByFirstNameError).Text}");
            Console.WriteLine($"Error: {driver.FindElement(_ByLastNameError).Text}");
            Console.WriteLine($"Error: {driver.FindElement(_ByEmailError).Text}");
            Console.WriteLine($"Error: {driver.FindElement(_ByPasswordError).Text}");
            Console.WriteLine($"Error-innerText: {driver.FindElement(_ByPasswordError).GetAttribute("innerText")}");
            Console.WriteLine($"Error-innerHTML: {driver.FindElement(_ByPasswordError).GetAttribute("innerHTML")}");
        }

        [Then(@"all missing feilds error should display")]
        public void Step03(Table tbl)
        {
            Console.WriteLine($"count:{tbl.RowCount}");
            Console.WriteLine($"row value: {tbl.Rows.ToArray()[0]}");
            Console.WriteLine($"head value: {tbl.Header.ToArray()[0]}");

            foreach (TableRow row in tbl.Rows)
            {
                Console.WriteLine($"row value:{row["Errors"]}");  //addressRow.Add(row["Field"], row["Value"]);
            }

            IDictionary<string, string> tblDict = new Dictionary<string, string>();

            foreach (TableRow row in tbl.Rows)
            {
                tblDict.Add(row["FieldName"], row["Errors"]);
            }

            foreach (KeyValuePair<string, string> entry in tblDict)       //foreach(var (k,v) in tblDict)
            {
                Console.WriteLine($"{entry.Key} ==  {entry.Value}");
            }

            using (new AssertionScope())
            {
                driver.FindElement(_ByFirstNameError).Text.Should().Be(tblDict["FirstName"]);
                driver.FindElement(_ByLastNameError).Text.Should().Be(tblDict["LastName"]);
                driver.FindElement(_ByEmailError).Text.Should().Be(tblDict["Email"]);
                driver.FindElement(_ByPasswordError).Text.Should().Be(tblDict["Password"]);
                //"Actual".Should().Be("Expected");
            }
            //foreach( var err in errorTable )
            //{
            //    Console.WriteLine(err.ToString());
            //}

        }

        [When(@"validate user email message")]
        public void s03(Table tbl01)
        {
            this.driver.FindElement(_ByEmailFeild).SendKeys("max123@yopmail.com");
            this.driver.FindElement(By.XPath("//html/body//fieldset")).Click();
            Thread.Sleep(1000);
            string mailMessage = this.driver.FindElement(By.XPath("//form[@id='signup']/fieldset/div[2]")).Text;
            Console.WriteLine(mailMessage);
        }









    }
}