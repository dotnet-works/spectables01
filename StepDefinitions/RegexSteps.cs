﻿using AventStack.ExtentReports.Gherkin.Model;
using System.Diagnostics;
using TechTalk.SpecFlow;
using System.Collections;
using System.Security;

namespace SpecTablenRegex.StepDefinitions
{
    [Binding]
    public sealed class RegexSteps
    {
        public RegexSteps()
        {
        }

        [Given(@"(?i)^SOME STEP1$")]
        public void sp1()
        {
            Console.WriteLine("Case-InSensitive Step1");
        }

        [When(@"(?i)^process step$")]
        public void sp2()
        {
            Console.WriteLine("Case-InSensitive Step2");
        }

        [Then(@"(?i)^process then step$")]
        public void sp3()
        {
            Console.WriteLine("Case-InSensitive Step3");
        }

        //[Given(@"I have entered ((.*) day, (.*) hour, (.*) minute, (.*) seconds) into the timestamp to minute")]
        [Given(@"I have entered ""(.*)"" into the timestamp to minute")]
        public void TimeSpanMethod(TimeSpan t) //String days, String hours, String minutes, String seconds)
        { //TimeSpan day,string hour,string minute, string seconds  )
            
                Console.WriteLine(t.ToString());
                //new CustomTransforms().
                //object value = convertToTimeSpan(day,hour,minute,seconds);
            
        }


        [Given(@"enter (.*)")]
        public void GivenEnterFormData(IList FormFeilds)
        {
            Console.WriteLine(FormFeilds[0]);
        }




    }
}