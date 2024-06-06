using TechTalk.SpecFlow;

namespace SpecTablenRegex.StepsExternalData
{
    [Binding]
    public class JsonDataSteps
    {
        private readonly ScenarioContext _scenarioContext;

        public JsonDataSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
        [Given(@"I got user (.*), (.*), (.*)")]
        public void GivenIGotUserHelenMaxRuby(string login, string fname,string lname) 
        {
            Console.WriteLine($"Login: {login} First Name: {fname} Last Name: {lname}");
        }
    }
}