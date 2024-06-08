using AventStack.ExtentReports.Gherkin.Model;
using FluentAssertions.Equivalency;
using FluentAssertions.Execution;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using SpecTablenRegex.StepDefinitions;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks.Dataflow;
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

        [When(@"click signup button")]
        [Then(@"click signup button")]
        public void Step02()
        {
            driver.FindElement(By.Id("next")).Click();
            Thread.Sleep(1000);

            //Console.WriteLine($"Error: {driver.FindElement(_ByFirstNameError).Text}");
            //Console.WriteLine($"Error: {driver.FindElement(_ByLastNameError).Text}");
            //Console.WriteLine($"Error: {driver.FindElement(_ByEmailError).Text}");
            //Console.WriteLine($"Error: {driver.FindElement(_ByPasswordError).Text}");
            //Console.WriteLine($"Error-innerText: {driver.FindElement(_ByPasswordError).GetAttribute("innerText")}");
            //Console.WriteLine($"Error-innerHTML: {driver.FindElement(_ByPasswordError).GetAttribute("innerHTML")}");
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

        [When(@"fill all data feilds")]
        public void FillFieldData(Table table)
        {

            this.driver.FindElement(By.Id("first_name")).SendKeys(Faker.Name.First());
            this.driver.FindElement(By.Id("last_name")).SendKeys(Faker.Name.Last());
            this.driver.FindElement(By.Id("email")).SendKeys("xyz123@yopmail.com");
            this.driver.FindElement(By.XPath("//html/body//fieldset")).Click();
            Thread.Sleep(1000);
            string mailMessage = this.driver.FindElement(By.XPath("//form[@id='signup']/fieldset/div[2]")).Text;
            Console.WriteLine(mailMessage);
            this.driver.FindElement(By.Id("pwd")).Click();
            driver.FindElement(By.Id("pwd")).SendKeys("1234@Test@1234");
            this.driver.FindElement(By.Id("foxy_desire")).Click();

            this.driver.FindElement(By.Id("is_programmer")).Click();
            this.driver.FindElement(By.Id("is_developer")).Click();
            this.driver.FindElement(By.Id("is_designer")).Click();
            this.driver.FindElement(By.Id("is_merchant")).Click();

            string storeName = Faker.Name.First()+"123";

            this.driver.FindElement(By.Id("store_name")).SendKeys(storeName);
            this.driver.FindElement(By.Id("store_domain")).SendKeys(storeName + "Daily");
            Thread.Sleep(2000);
            this.driver.FindElement(By.XPath("//html/body//fieldset")).Click();
            string check_StoreDomainAvailiablity = this.driver.FindElement(By.XPath("//fieldset[3]//div[3]")).Text;
            Thread.Sleep(5000);

            driver.ExecuteJavaScript("arguments[0].scrollIntoView();", driver.FindElement(By.CssSelector(".row>.label_checkbox")));
            driver.FindElement(By.Id("terms_agree")).Click();
            Thread.Sleep(500);
            //driver.SwitchTo().Frame("reCAPTCHA");
            driver.SwitchTo().Frame(0);
            Thread.Sleep(500);
            driver.FindElement(By.CssSelector(".recaptcha-checkbox-border")).Click();
            Thread.Sleep(3000);
            //this.driver.FindElement()
        }

        //# And click on submit button
        //#  Then user navigates to new user page


        [When(@"only headers are given")]
        public void x1(Table tb1)
        {
            //List<string> hed = new List<string>();
            //foreach (var header in tb1.Header)
            //{
            //    hed.Add(header.ToString());//, typeof(string));
            //}
            //Console.WriteLine(hed[0]);
            tb1.HeaderToList();
            
        }

        [When("enter (.*) info fieldset with following data:")]
        public void fieldset_data(string fieldSetName, Table Fieldtable)
        {

            List<string> fields = new List<string>();
            foreach(var rowx in Fieldtable.Rows)
            {

                Console.WriteLine(rowx["FieldSet"]);
                fields.Add(rowx["FieldSet"].ToLower());
            }

            string formset = fieldSetName.ToLower();

            if (fieldSetName.ToLower().Contains("about yourself"))
            {
                if (fields.Contains("firstname")){
                    this.driver.FindElement(By.Id("first_name")).SendKeys(Faker.Name.First()); 
                }
                if (fields.Contains("lastname"))
                {
                    this.driver.FindElement(By.Id("last_name")).SendKeys(Faker.Name.Last());  
                }
                if (fields.Contains("email"))
                {
                    var newMail = "maxy"+Faker.RandomNumber.Next(1000, 2000)+"@yopmail.com";
                    this.driver.FindElement(By.Id("email")).SendKeys(newMail);
                   // this.driver.FindElement(By.Id("email")).SendKeys("zulutest01@yopmail.com"); //
                    this.driver.FindElement(By.XPath("//html/body//fieldset")).Click();
                    Thread.Sleep(3000);
                    string mailMessage = this.driver.FindElement(By.XPath("//form[@id='signup']/fieldset/div[2]")).Text;
                    Console.WriteLine(mailMessage);
                    if(!mailMessage.Contains("Email Check: Available"))
                    {
                        throw new Exception($"Exception: {mailMessage} :Mail not availiable");
                    }
                    
                }
                if (fields.Contains("password"))
                {
                    this.driver.FindElement(By.Id("pwd")).Click();
                    driver.FindElement(By.Id("pwd")).SendKeys("1234@Test@1234");
                }

                if (fields.Contains("foxydesire"))
                {
                    this.driver.FindElement(By.Id("foxy_desire")).Click();
                    this.driver.FindElement(By.Id("foxy_desire")).SendKeys(Faker.Lorem.Sentence());
                }


            }


            if (fieldSetName.ToLower().Contains("consider yourself"))
            {
                if(fields.Contains("is_programmer")) {
                    this.driver.FindElement(By.Id("is_programmer")).Click();
                }

                if (fields.Contains("is_developer"))
                {
                    this.driver.FindElement(By.Id("is_developer")).Click();
                }

                if (fields.Contains("is_designer"))
                {
                    this.driver.FindElement(By.Id("is_designer")).Click();
                }

                if (fields.Contains("is_merchant"))
                {
                    this.driver.FindElement(By.Id("is_merchant")).Click();
                }

            }

            if (fieldSetName.ToLower().Contains("store domain"))
            {
                string storeName = Faker.Name.First() + "123";

                if (fields.Contains("storename"))
                {
                    this.driver.FindElement(By.Id("store_name")).SendKeys(storeName);                     
                }

                if (fields.Contains("storedomain"))
                {
                    this.driver.FindElement(By.Id("store_domain")).SendKeys(storeName + "Daily"); //zimstore

                    this.driver.FindElement(By.XPath("//html/body//fieldset")).Click();
                    Thread.Sleep(1500);
                    string domainAvailibilty = this.driver.FindElement(By.CssSelector("div#store_domain_found.more_info")).Text;
                    if (!domainAvailibilty.Contains("Domain Check: Available"))
                    {
                        throw new Exception($"Exception: {domainAvailibilty} domain not availiable");
                    }
                }
                                
                string check_StoreDomainAvailiablity = this.driver.FindElement(By.XPath("//fieldset[3]//div[3]")).Text;
                Thread.Sleep(5000);

                driver.ExecuteJavaScript("arguments[0].scrollIntoView();", driver.FindElement(By.CssSelector(".row>.label_checkbox")));
                   
            }
        }

        [When("click agree and captch checkbox")]
        public void AgreeAndClick()
        {
            driver.FindElement(By.Id("terms_agree")).Click();
            Thread.Sleep(500);
            driver.SwitchTo().Frame(0);
            Thread.Sleep(500);
            driver.FindElement(By.CssSelector(".recaptcha-checkbox-border")).Click();
            Thread.Sleep(3000);
            driver.SwitchTo().DefaultContent();
        }


        [Given(@"(?i)^hey all  i know$")]
        public void checkspaces()
        {
            Console.WriteLine("Execute step ");
        }

       // [Given(@"(?s+)^remove extra spaces in step  def$")]
        //[Given(@"(\\s+(?:\\s+\\s+)+)^remove extra spaces in step def$")]
        [Given(@"(\s+)^remove extra spaces in step def$")]
        public void checkspaces2()
        {
            Console.WriteLine("Execute step ");
        }


        /*
         
         
         */











    }
}