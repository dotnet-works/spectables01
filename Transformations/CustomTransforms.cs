using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SpecTablenRegex.Transformations
{
    [Binding]
    public class CustomTransforms
    {
        public CustomTransforms()
        {

        }

        [StepArgumentTransformation(@"(?:(\d*) day(?:s)?(?:, )?)?(?:(\d*) hour(?:s)?(?:, )?)?(?:(\d*) minute(?:s)?(?:, )?)?(?:(\d*) second(?:s)?(?:, )?)?")]
        public TimeSpan convertToTimeSpan(string days, string hours, string minutes, string seconds)
        {
            int daysValue;
            int hoursValue;
            int minutesValue;
            int secondsValue;

            int.TryParse(days, out daysValue);
            int.TryParse(hours, out hoursValue);
            int.TryParse(minutes, out minutesValue);
            int.TryParse(seconds, out secondsValue);

            return new TimeSpan(daysValue, hoursValue, minutesValue, secondsValue);
        }

        //[StepArgumentTransformation(@"""([^""]*)"" form data")]
        //[StepArgumentTransformation(@"""([^a-zA-Z]*)(?:, )"" form data")]
        //[StepArgumentTransformation(@"""^(?:[^a-zA-Z]*,?:)"" form data")]
        [StepArgumentTransformation(@"""^(?:[^a-z]*?:,)"" form data")]
        public IList<string> ConvertToList(string commaValues)
        {
            IList<string> commaList = commaValues.Split(",").ToList();
            foreach (string comma in commaList)
            {
                //commaList.Add(comma);
            }

            return commaList;
        }




    }
}